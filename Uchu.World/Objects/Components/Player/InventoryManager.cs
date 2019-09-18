using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uchu.Core;
using Uchu.Core.CdClient;

namespace Uchu.World
{
    public class InventoryManager : Component
    {
        private readonly Dictionary<InventoryType, Inventory> _inventories = new Dictionary<InventoryType, Inventory>();
        private InventoryComponent _inventoryComponent;

        private object _lock;

        public InventoryManager()
        {
            OnStart += () =>
            {
                _inventoryComponent = GameObject.GetComponent<InventoryComponent>();
                _lock = new object();

                foreach (var value in Enum.GetValues(typeof(InventoryType)))
                {
                    var id = (InventoryType) value;

                    Logger.Information($"[{id}]");

                    _inventories.Add(id, new Inventory(id, this));
                }
            };

            OnDestroyed += () =>
            {
                foreach (var item in _inventories.Values.SelectMany(inventory => inventory.Items)) Destroy(item);
            };
        }

        public Inventory this[InventoryType inventoryType] => _inventories[inventoryType];

        public Item GetItem(long id)
        {
            using (var ctx = new UchuContext())
            {
                var item = ctx.InventoryItems.FirstOrDefault(
                    i => i.InventoryItemId == id && i.CharacterId == Player.ObjectId
                );

                if (item == default)
                {
                    Logger.Error($"{id} is not an item on {Player}");
                    return null;
                }

                var managedItem = _inventories[(InventoryType) item.InventoryType][id];

                Logger.Information($"Getting item: {id} -> {managedItem}");

                if (managedItem == null) Logger.Error($"{item.InventoryItemId} is not managed on {Player}");

                return managedItem;
            }
        }

        public async Task AddItemAsync(int lot, uint count)
        {
            using (var cdClient = new CdClientContext())
            {
                var componentId = await cdClient.ComponentsRegistryTable.FirstOrDefaultAsync(
                    r => r.Id == lot && r.Componenttype == (int) ReplicaComponentsId.Item
                );

                if (componentId == default)
                {
                    Logger.Error($"{lot} does not have a Item component");
                    return;
                }

                var component = await cdClient.ItemComponentTable.FirstOrDefaultAsync(
                    i => i.Id == componentId.Componentid
                );

                if (component == default)
                {
                    Logger.Error(
                        $"{lot} has a corrupted component registry. There is no Item component of Id: {componentId.Componentid}"
                    );
                    return;
                }

                Debug.Assert(component.ItemType != null, "component.ItemType != null");

                AddItem(lot, count, ((ItemType) component.ItemType).GetInventoryType());
            }
        }

        public void AddItem(int lot, uint count, InventoryType inventoryType)
        {
            // The math here cannot be executed in parallel
            lock (_lock)
            {
                using (var cdClient = new CdClientContext())
                {
                    var componentId = cdClient.ComponentsRegistryTable.FirstOrDefault(
                        r => r.Id == lot && r.Componenttype == (int) ReplicaComponentsId.Item
                    );

                    if (componentId == default)
                    {
                        Logger.Error($"{lot} does not have a Item component");
                        return;
                    }

                    var component = cdClient.ItemComponentTable.FirstOrDefault(
                        i => i.Id == componentId.Componentid
                    );

                    if (component == default)
                    {
                        Logger.Error(
                            $"{lot} has a corrupted component registry. There is no Item component of Id: {componentId.Componentid}"
                        );
                        return;
                    }

                    var stackSize = component.StackSize ?? 1;
                    
                    // Bricks and alike does not have a stack limit.
                    if (stackSize == default) stackSize = int.MaxValue;

                    var inventory = _inventories[inventoryType];

                    //
                    // Update quest tasks
                    //

                    var questInventory = Player.GetComponent<QuestInventory>();

                    for (var i = 0; i < count; i++)
                    {
#pragma warning disable 4014
                        Task.Run(async () =>
#pragma warning restore 4014
                        {
                            await questInventory.UpdateObjectTaskAsync(MissionTaskType.ObtainItem, lot);
                        });
                    }

                    //
                    // Fill stacks
                    //

                    foreach (var item in inventory.Items.Where(i => i.Lot == lot))
                    {
                        if (item.Count == stackSize) continue;

                        var toAdd = (uint) Min(stackSize, (int) count, (int) (stackSize - item.Count));

                        Logger.Debug($"Stack Math: {stackSize}, {count}, ({stackSize} - {item.Count}): {stackSize - item.Count} ; Min = {toAdd}");
                        
                        item.Count += toAdd;

                        count -= toAdd;

                        if (count <= 0) return;
                    }

                    //
                    // Create new stacks
                    //

                    var toCreate = count;

                    while (toCreate != default)
                    {
                        var toAdd = (uint) Min(stackSize, (int) toCreate);

                        var item = Item.Instantiate(lot, inventory, toAdd);

                        Start(item);

                        toCreate -= toAdd;
                    }
                }
            }
        }

        public async Task RemoveItemAsync(int lot, uint count)
        {
            using (var cdClient = new CdClientContext())
            {
                var componentId = await cdClient.ComponentsRegistryTable.FirstOrDefaultAsync(
                    r => r.Id == lot && r.Componenttype == (int) ReplicaComponentsId.Item
                );

                if (componentId == default)
                {
                    Logger.Error($"{lot} does not have a Item component");
                    return;
                }

                var component = await cdClient.ItemComponentTable.FirstOrDefaultAsync(
                    i => i.Id == componentId.Componentid
                );

                if (component == default)
                {
                    Logger.Error(
                        $"{lot} has a corrupted component registry. There is no Item component of Id: {componentId.Componentid}"
                    );
                    return;
                }

                Debug.Assert(component.ItemType != null, "component.ItemType != null");

                RemoveItem(lot, count, ((ItemType) component.ItemType).GetInventoryType());
            }
        }

        public void RemoveItem(int lot, uint count, InventoryType inventoryType)
        {
            // The math here cannot be executed in parallel
            lock (_lock)
            {
                using (var cdClient = new CdClientContext())
                {
                    var componentId = cdClient.ComponentsRegistryTable.FirstOrDefault(
                        r => r.Id == lot && r.Componenttype == (int) ReplicaComponentsId.Item
                    );

                    if (componentId == default)
                    {
                        Logger.Error($"{lot} does not have a Item component");
                        return;
                    }

                    var component = cdClient.ItemComponentTable.FirstOrDefault(
                        i => i.Id == componentId.Componentid
                    );

                    if (component == default)
                    {
                        Logger.Error(
                            $"{lot} has a corrupted component registry. There is no Item component of Id: {componentId.Componentid}"
                        );
                        return;
                    }

                    var items = _inventories[inventoryType].Items.Where(i => i.Lot == lot).ToList();

                    //
                    // Sort to make sure we remove from the stacks with the lowest count first.
                    //

                    items.Sort((i1, i2) => (int) (i1.Count - i2.Count));

                    foreach (var item in items)
                    {
                        var toRemove = (uint) Min((int) count, (int) item.Count);

                        item.Count -= toRemove;

                        count -= toRemove;

                        if (count != default) continue;

                        return;
                    }

                    Logger.Error(
                        $"Trying to remove {lot} x {count} when {GameObject} does not have that many of {lot} in their {inventoryType} inventory"
                    );
                }
            }
        }

        public void SyncItemMove(long itemId, int newSlot, InventoryType sourceInventoryType,
            InventoryType destinationInventoryType)
        {
            var item = GetItem(itemId);

            if (item == null)
            {
                Logger.Error(
                    $"Trying to sync an item movement for Item: {itemId} to Slot: {newSlot}, with an item that does not exist"
                );

                return;
            }

            item.Slot = (uint) newSlot;
        }

        private static int Min(params int[] nums)
        {
            return nums.Min();
        }
    }
}