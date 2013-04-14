using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class InventoryManager : IService
    {
        //TODO: should this be keyed by type or type ID?
        Dictionary<ResourceType, long> _inventory = new Dictionary<ResourceType, long>();

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
        public bool HasEnoughResources(ResourceType rt, long quantity)
        {
            bool hasEnough = false;

            if (_inventory.ContainsKey(rt))
            {
                hasEnough = (_inventory[rt] >= quantity);
            }

            return hasEnough;
        }

        //TODO: should this be by ResourceType or TypeID?
        public void AddResources(ResourceType rt, long quantity)
        {
            if (_inventory.ContainsKey(rt))
            {
                _inventory[rt] += quantity;
            }
            else
            {
                _inventory.Add(rt, quantity);
            }
        }

        /// <summary>
        /// Removes the indicated resource quantity from the inventory
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="quantity"></param>
        /// <param name="removeRegardlessOfQuantity">If TRUE and the quantity is larger than the inventory, it will zero out inventory.  Otherwise, nothing will be removed.</param>
        /// <returns>TRUE if the inventory contained adequate resources, FALSE if it did not.  If removeRegardlessOfQuantity is set to true, the removal will still take place even if FALSE is returned.</returns>
        //TODO: should this be by ResourceType or TypeID?
        public bool RemoveResources(ResourceType rt, long quantity, bool removeRegardlessOfQuantity = false)
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
            }

            return retVal;
        }

        public System.Collections.Generic.IEnumerable<KeyValuePair<ResourceType, long>> GetInventory()
        {
            foreach (KeyValuePair<ResourceType, long> item in _inventory)
            {
                yield return new KeyValuePair<ResourceType, long>(item.Key, item.Value);
            }
        }
    }
}
