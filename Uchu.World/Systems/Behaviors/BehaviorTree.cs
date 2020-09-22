using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RakDotNet.IO;
using Uchu.Core;
using Uchu.Core.Client;

namespace Uchu.World.Systems.Behaviors
{
    public class BehaviorTree
    {
        private static Dictionary<BehaviorTemplateId, Type> _behaviors;

        public BehaviorInfo[] BehaviorIds { get; private set; }

        public Dictionary<int, BehaviorBase> SkillRoots { get; set; } = new Dictionary<int, BehaviorBase>();

        public Dictionary<SkillCastType, List<BehaviorBase>> RootBehaviors { get; } =
            new Dictionary<SkillCastType, List<BehaviorBase>>();

        public static Dictionary<BehaviorTemplateId, Type> Behaviors
        {
            get
            {
                if (_behaviors != default) return _behaviors;

                _behaviors = new Dictionary<BehaviorTemplateId, Type>();

                var behaviors = typeof(BehaviorBase).Assembly.GetTypes().Where(
                    t => t.BaseType == typeof(BehaviorBase) && t != typeof(BehaviorBase)
                ).ToArray();

                foreach (var behavior in behaviors)
                {
                    _behaviors.Add(((BehaviorBase) Activator.CreateInstance(behavior)).Id, behavior);
                }

                return _behaviors;
            }
        }

        private BehaviorTree()
        {
        }

        public static async Task<BehaviorTree> FromLotAsync(Lot lot)
        {
            var tree = new BehaviorTree();

            await using var cdClient = new CdClientContext();

            var objectSkills = cdClient.ObjectSkillsTable.Where(i =>
                i.ObjectTemplate == lot
            ).ToArray();

            tree.BehaviorIds = new BehaviorInfo[objectSkills.Length];

            for (var index = 0; index < objectSkills.Length; index++)
            {
                var objectSkill = objectSkills[index];

                var behavior = cdClient.SkillBehaviorTable.FirstOrDefault(b => b.SkillID == objectSkill.SkillID);

                if (behavior == default)
                {
                    Logger.Error($"Could not find behavior for skill: {objectSkill.SkillID}");

                    continue;
                }

                Logger.Information($"[{lot}] SKILL: {objectSkill.SkillID} -> {behavior.BehaviorID}");

                tree.BehaviorIds[index] = new BehaviorInfo
                {
                    BaseBehavior = behavior.BehaviorID ?? 0,
                    CastType = objectSkill.CastOnType.HasValue ? (SkillCastType) objectSkill.CastOnType : SkillCastType.OnUse,
                    SkillId = objectSkill.SkillID ?? 0,
                    ImaginationCost = behavior.Imaginationcost ?? 0
                };
            }
            
            await tree.BuildAsync();

            return tree;
        }

        /// <summary>
        /// Takes a skill ID and creates a simple skill tree with that skill from the behavior table
        /// </summary>
        /// <param name="skillId">The skill ID to use</param>
        /// <returns>A behavior tree that contains the skill belonging to the skill ID</returns>
        public static async Task<BehaviorTree> FromSkillAsync(int skillId)
        {
            await using var cdClient = new CdClientContext();

            var tree = new BehaviorTree();
            var behavior = cdClient.SkillBehaviorTable.FirstOrDefault(b => b.SkillID == skillId);
            
            if (behavior == default)
            {
                Logger.Error($"Could not find behavior for skill: {skillId}");
                return tree;
            }

            if (behavior.BehaviorID == default)
            {
                Logger.Error($"{skillId} has an invalid behavior id");
                return tree;
            }

            tree.BehaviorIds = new[]
            {
                new BehaviorInfo
                {
                    SkillId = skillId,
                    CastType =  SkillCastType.Default,
                    BaseBehavior = behavior.BehaviorID.Value,
                    ImaginationCost = behavior.Imaginationcost ?? 0
                }
            };

            await tree.BuildAsync();
            return tree;
        }

        /// <summary>
        /// Builds the skill tree by finding all behaviors associated with it and storing them in the rootbehaviors dict 
        /// </summary>
        private async Task BuildAsync()
        {
            await using var ctx = new CdClientContext();

            // Build the base behavior for each requested skill
            foreach (var skill in BehaviorIds)
            {
                var root = BehaviorBase.Cache.ToArray().FirstOrDefault(
                    b => b.BehaviorId == skill.BaseBehavior);

                // If the behavior can't be found in the cache, build in from scratch using its template
                if (root == default)
                {
                    root = await CreateBehaviorFromInfo(ctx, skill);
                    if (root == null)
                    {
                        continue;
                    }
                }

                // For each skill, store the fresh behavior root
                SkillRoots[skill.SkillId] = root;

                // Also store each behavior by CastType
                if (RootBehaviors.TryGetValue(skill.CastType, out var list))
                {
                    list.Add(root);
                }
                else
                {
                    RootBehaviors[skill.CastType] = new List<BehaviorBase> { root };
                }
            }
        }

        /// <summary>
        /// Creates a behavior base from skill information by finding its behavior template and spawning an instance
        /// of that.
        /// </summary>
        /// <remarks>
        /// Also adds this behavior base to the cache
        /// </remarks>
        /// <param name="context">Reusable context to query from</param>
        /// <param name="info">The behavior info to get the skill from</param>
        /// <returns>The instantiated behavior base if succeeded, <c>null</c> otherwise</returns>
        private async Task<BehaviorBase> CreateBehaviorFromInfo(CdClientContext context, BehaviorInfo info)
        {
            var behavior = await context.BehaviorTemplateTable.FirstOrDefaultAsync(
                t => t.BehaviorID == info.BaseBehavior
            );

            if (behavior?.TemplateID == null)
                return null;
            
            var behaviorTypeId = (BehaviorTemplateId) behavior.TemplateID;

            if (!Behaviors.TryGetValue(behaviorTypeId, out var behaviorType))
            {
                Logger.Error($"No behavior type of \"{behaviorTypeId}\" found.");
                return null;
            }

            var instance = (BehaviorBase) Activator.CreateInstance(behaviorType);
            if (instance == null)
            {
                Logger.Error($"Could not create behaviour of type {behaviorType}.");
                return null;
            }
            
            instance.BehaviorId = info.BaseBehavior;
            BehaviorBase.Cache.Add(instance);
            await instance.BuildAsync();
            
            return instance;
        }

        /// <summary>
        /// Calculate a server preformed skill
        /// </summary>
        /// <param name="associate">Executioner</param>
        /// <param name="writer">Data to be sent to clients</param>
        /// <param name="skillId">Skill to execute</param>
        /// <param name="syncId">Sync Id</param>
        /// <param name="calculatingPosition">Where position calculations are done from</param>
        /// <param name="target">Explicit target</param>
        /// <returns>Context</returns>
        public async Task<NpcExecutionContext> CalculateAsync(GameObject associate, BitWriter writer, int skillId,
            uint syncId, Vector3 calculatingPosition, GameObject target = default)
        {
            target ??= associate;

            var context = new NpcExecutionContext(target, writer, skillId, syncId, calculatingPosition);

            if (!SkillRoots.TryGetValue(skillId, out var root))
            {
                Logger.Debug($"Failed to find skill: {skillId}");
                return context;
            }

            context.Root = root;

            var branchContext = new ExecutionBranchContext(target);

            try
            {
                await root.CalculateAsync(context, branchContext);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return context;
        }

        /// <summary>
        /// Execute a user preformed skill
        /// </summary>
        /// <param name="associate">Executioner</param>
        /// <param name="reader">Client skill data</param>
        /// <param name="castType">Type of skill</param>
        /// <param name="target">Explicit target</param>
        /// <returns>Context</returns>
        public async Task<ExecutionContext> ExecuteAsync(GameObject associate, BitReader reader,
            SkillCastType castType = SkillCastType.OnEquip, GameObject target = default)
        {
            var context = new ExecutionContext(associate, reader, default)
            {
                ExplicitTarget = target
            };

            if (RootBehaviors.TryGetValue(SkillCastType.Default, out var defaultList))
            {
                foreach (var root in defaultList)
                {
                    context.Root = root;
                    var branchContext = new ExecutionBranchContext(associate);
                    await root.ExecuteAsync(context, branchContext);
                }
            }

            if (!RootBehaviors.TryGetValue(castType, out var list)) return context;
            foreach (var root in list)
            {
                context.Root = root;
                var branchContext = new ExecutionBranchContext(associate);
                await root.ExecuteAsync(context, branchContext);
            }

            return context;
        }

        public async Task<ExecutionContext> UseAsync(GameObject associate, BitReader reader, GameObject target)
        {
            var context = new ExecutionContext(associate, reader, default);

            if (!RootBehaviors.TryGetValue(SkillCastType.OnUse, out var list)) return context;

            foreach (var root in list)
            {
                context.Root = root;

                var branchContext = new ExecutionBranchContext(target);

                await root.ExecuteAsync(context, branchContext);
            }

            return context;
        }

        public async Task<ExecutionContext> MountAsync(GameObject associate)
        {
            var context = new ExecutionContext(associate, new BitReader(new MemoryStream()),
                new BitWriter(new MemoryStream()));

            if (!RootBehaviors.TryGetValue(SkillCastType.OnEquip, out var list)) return context;

            foreach (var root in list)
            {
                context.Root = root;

                var branchContext = new ExecutionBranchContext(associate);

                await root.ExecuteAsync(context, branchContext);
            }

            return context;
        }

        public async Task<ExecutionContext> DismantleAsync(GameObject associate)
        {
            var context = new ExecutionContext(associate, new BitReader(new MemoryStream()),
                new BitWriter(new MemoryStream()));

            if (!RootBehaviors.TryGetValue(SkillCastType.OnEquip, out var list)) return context;

            foreach (var root in list)
            {
                context.Root = root;

                var branchContext = new ExecutionBranchContext(associate);

                await root.DismantleAsync(context, branchContext);
            }

            return context;
        }

        public static async Task<BehaviorInfo[]> GetSkillsForObject(Lot lot)
        {
            var tree = await FromLotAsync(lot);

            return tree.BehaviorIds;
        }
    }
}