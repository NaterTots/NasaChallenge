using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public interface IService
    {
        void Initialize();
        void Cleanup();

        ServiceType GetServiceType();
    }

    public enum ServiceType
    {
        InventoryManager,
        ConfigurationManager,
		ResourceManager,
        BuildingManager,
        RandomGenerator,
        RulesEngine,
        Logger
        //Game,
        //TextureManager
    }
}