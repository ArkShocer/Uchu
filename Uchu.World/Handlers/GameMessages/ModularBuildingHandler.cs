using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uchu.Core;

namespace Uchu.World.Handlers.GameMessages
{
    public class ModularBuildingHandler : HandlerGroup
    {
        [PacketHandler]
        public void StartBuildingHandler(StartBuildingWithItemMessage message, Player player)
        {
            player.GetComponent<ModularBuilderComponent>().StartBuildingAsync(message);
        }

        [PacketHandler]
        public async Task ModularBuildFinishHandler(ModularBuildFinishMessage message, Player player)
        {
            await player.GetComponent<ModularBuilderComponent>().FinishBuilding(message.Modules);
        }

        [PacketHandler]
        public void DoneArrangingHandler(DoneArrangingWithItemMessage message, Player player)
        {
            player.GetComponent<ModularBuilderComponent>().DoneArranging(message);
        }

        [PacketHandler]
        public async Task PickupModelHandler(ModularBuildMoveAndEquipMessage message, Player player)
        {
            await player.GetComponent<ModularBuilderComponent>().Pickup(message.Lot);
        }

        [PacketHandler]
        public void ModelPrefabHandler(StartArrangingWithModelMessage message, Player player)
        {
            
        }

        [PacketHandler]
        public async Task BuildExitConfirmationHandler(BuildExitConfirmationMessage message, Player player)
        {
            await player.GetComponent<ModularBuilderComponent>().ConfirmFinish();
        }

        [PacketHandler]
        public async Task SetLastCustomBuildHandler(SetLastCustomBuildMessage message, Player player)
        {
            await using var ctx = new UchuContext();

            var character = await ctx.Characters.FirstAsync(c => c.Id == player.Id);

            character.Rocket = message.Tokens;

            await ctx.SaveChangesAsync();
        }

        [PacketHandler]
        public async Task SetBuildModeHandler(SetBuildModeMessage message, Player player)
        {
            player.Message(new SetBuildModeConfirmed
            {
                Associate = message.Associate,
                ModePaused = message.ModePaused,
                ModeValue = message.ModeValue,
                Player = player,
                Start = message.Start,
                StartPosition = message.StartPosition
            });
        }
    }
}