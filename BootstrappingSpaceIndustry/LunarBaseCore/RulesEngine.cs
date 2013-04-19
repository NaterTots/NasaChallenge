using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LunarBaseCore.Rules;

namespace LunarBaseCore
{
	class RulesEngine : IService
	{
		InventoryManager inventoryManager;
		public void Initialize()
		{
			inventoryManager = ServiceManager.Instance.GetService<InventoryManager>();
		}

		public void Cleanup()
		{
			//throw new NotImplementedException();
		}

		public ServiceType GetServiceType()
		{
			return ServiceType.RulesEngine;
		}

		/// <summary>
		/// Run all Building rules
		/// </summary>
		public void UpdateBuilding(BuildingItem item, long timeElapsed)
		{
			BuildingProductionRule.Run(inventoryManager, item, timeElapsed);
			//Run decay rule here?
		}

		public bool UpdateBuildingConstruction(BuildingItem item, long timeElapsed)
		{
			//TODO:this
			//return value is true if the building construction has completed
			//BuildingCreationRule.Run

			return item.IsConstructed();
		}
	}
}
