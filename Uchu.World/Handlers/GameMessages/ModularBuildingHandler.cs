using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uchu.Core;

namespace Uchu.World.Handlers.GameMessages
{
    public class ModularBuildingHandler : HandlerGroup
    {
        [PacketHandler]
        public async Task StartBuildingHandler(StartBuildingWithItemMessage message, Player player)
        {
            await player.GetComponent<ModularBuilderComponent>().StartBuildingAsync(message);
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
        public async Task ModelPrefabHandler(StartArrangingWithModelMessage message, Player player)
        {
            await player.GetComponent<ModularBuilderComponent>().StartBuildingWithModel(message.Item);
        }

        [PacketHandler]
        public async Task BuildExitConfirmationHandler(BuildExitConfirmationMessage message, Player player)
        {
            await player.GetComponent<ModularBuilderComponent>().ConfirmFinish();
        }

        [PacketHandler]
        public void SetLastCustomBuildHandler(SetLastCustomBuildMessage message, Player player)
        {
            if (player.TryGetComponent<CharacterComponent>(out var characterComponent))
                characterComponent.Rocket = message.Tokens;
        }

        [PacketHandler]
        public void SetBuildModeHandler(SetBuildModeMessage message, Player player)
        {
            player.Message(new SetBuildModeConfirmedMessage
            {
                Associate = message.Associate,
                ModePaused = message.ModePaused,
                ModeValue = message.ModeValue,
                Player = player,
                Start = message.Start,
                StartPosition = message.StartPosition
            });
        }

        [PacketHandler]
        public void ModuleAssemblyQueryDataHandler(ModuleAssemblyQueryDataMessage message, Player player)
        {
            if (!message.Associate.TryGetComponent<ModuleAssemblyComponent>(out var moduleAssembly))
                Logger.Error($"assembly data requested for {message.Associate} but no module assembly component exists");
            player.Zone.BroadcastMessage(new ModuleAssemblyDBDataForClientMessage
            {
                AssemblyId = GameObject.InvalidObject, // todo subkey? i think
                // chassis wheels engine frontbumper rearpanel rearbumper sides
                Blob = moduleAssembly.GetAssembly(),
                Associate = message.Associate,
            });
        }
    }
}
