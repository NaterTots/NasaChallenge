using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class InventoryManager : IService
    {
        //TODO: should this be keyed by type or type ID?
        Dictionary<ItemTypeBase, long> _inventory = new Dictionary<ItemTypeBase, long>();

        // Fired when the inventory changes
        public event EventHandler<InventoryChangeEventArgs> InventoryChange;

        public void Initialize()
        {
            //nothing to do here - the InventoryManager should not populate itself
            //throw new NotImplementedException();
        }

		public void Cleanup()
        {
            //throw new NotImplementedException();
        }

        public ServiceType GetServiceType()
        {
            return ServiceType.InventoryManager;
        }

        //TODO: should this be by ResourceType or TypeID?
        public bool HasEnoughItems(ItemTypeBase rt, long quantity)
        {
            bool hasEnough = false;

            if (_inventory.ContainsKey(rt))
            {
                hasEnough = (_inventory[rt] >= quantity);
            }

            return hasEnough;
        }

        //TODO: should this be by ResourceType or TypeID?
        public void AddItems(ItemTypeBase rt, long quantity)
        {
            if (_inventory.ContainsKey(rt))
            {
                _inventory[rt] += quantity;
            }
            else
            {
                _inventory.Add(rt, quantity);
            }

            if (InventoryChange != null)
            {
                InventoryChange(this, new InventoryChangeEventArgs(rt, quantity));
            }
        }

        /// <summary>
        /// Removes the indicated item quantity from the inventory
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="quantity"></param>
        /// <param name="removeRegardlessOfQuantity">If TRUE and the quantity is larger than the inventory, it will zero out inventory.  Otherwise, nothing will be removed.</param>
        /// <returns>TRUE if the inventory contained adequate resources, FALSE if it did not.  If removeRegardlessOfQuantity is set to true, the removal will still take place even if FALSE is returned.</returns>
        //TODO: should this be by ResourceType or TypeID?
        public bool RemoveItems(ItemTypeBase rt, long quantity, bool removeRegardlessOfQuantity = false)
        {
            bool retVal = false;

            if (_inventory.ContainsKey(rt))
            {
                if (_inventory[rt] < quantity)
                {
                    if (removeRegardlessOfQuantity == true)
                    {
                        _inventory[rt] = 0;
                    }
                }
                else
                {
                    _inventory[rt] -= quantity;
                    retVal = true;
                }

                if (InventoryChange != null)
                {
                    InventoryChange(this, new InventoryChangeEventArgs(rt, quantity * -1));
                }
            }

            return retVal;
        }

        public IEnumerable<KeyValuePair<ItemTypeBase, long>> GetInventory()
        {
            foreach (KeyValuePair<ItemTypeBase, long> item in _inventory)
            {
                yield return new KeyValuePair<ItemTypeBase, long>(item.Key, item.Value);
            }
        }

        public IEnumerable<KeyValuePair<T, long>> GetSpecificInventory<T>() where T : ItemTypeBase
        {
            foreach (KeyValuePair<ItemTypeBase, long> item in _inventory)
            {
                if (item.Key.GetType() == typeof(T))
                {
                    yield return new KeyValuePair<T, long>((T)item.Key, item.Value);
                }
            }
        }

        public class InventoryChangeEventArgs : EventArgs
        {
            public InventoryChangeEventArgs(ItemTypeBase item, long quantity)
            {
                ItemType = item;
                Quantity = quantity;
            }

            public ItemTypeBase ItemType
            {
                get;
                private set;
            }

            /// <summary>
            /// This is negative if the quantity of the item is reduced
            /// </summary>
            public long Quantity
            {
                get;
                private set;
            }
        }
    }
}
