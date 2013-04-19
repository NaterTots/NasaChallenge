using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore.Rules
{
	/// <summary>
	/// This rule defines the production algorithm for items of type BuildingItemType.
	/// </summary>
	static public class BuildingProductionRule
	{
		//could add decay here, leaving it out for now.  Wasn't sure if decay should be part of this process or another, and how exactly we were calculating it.
		//???should using a building make it decay faster, or for simplicity sake, should we just decay based on total ticks?

		private static long _tickThreashold = 3; //number of ticks before output is generated //TODO:  SAMPLE VALUE, also wrong type, a tick is not a long
		//long _requiredFuel = ; //will actually be a property on the ItemType 

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private static bool HasEnoughEnergy() //TODO - I wasn't sure where to get the energy values or what we were calling them
		{
			return true;
		}

		//TODO: decide the best way to pass back errors
		public static void Run(InventoryManager inventory, BuildingItem item, long ticks)
		{
			for (long tick = item.CurrentTicks; tick == _tickThreashold; tick++) //TODO: loop through ticks
			{
				if (HasEnoughEnergy())
				{
					//consumablematerials = KeyValuePair<ItemTypeBase, long>
					foreach (KeyValuePair<ItemTypeBase, long> consumable in ((BuildingItemType)item.ItemType).ConsumableMaterials)
					{
						//first pass - make sure inventory has enough of everything needed for this building
						if (!inventory.HasEnoughItems(consumable.Key, consumable.Value))
						{
							break; //throw?
						}
					}

					//all necessary input is available in inventory, so subtract it for this pass.
					foreach (KeyValuePair<ItemTypeBase, long> consumable in ((BuildingItemType)item.ItemType).ConsumableMaterials)
					{
						inventory.RemoveItems(consumable.Key, consumable.Value);
					}

					//if this process has run the necessary number of ticks
					if (item.CurrentTicks == _tickThreashold)
					{
						foreach (KeyValuePair<ItemTypeBase, long> output in ((BuildingItemType)item.ItemType).OutputMaterials)
						{
							inventory.AddItems(output.Key, output.Value);
						}
						item.ResetCurrentTicks();
					}
					else
					{
						item.IncrementCurrentTicks();
					}
				}
			}
		}

	}
}
