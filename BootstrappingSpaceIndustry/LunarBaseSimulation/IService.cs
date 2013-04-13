using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public interface IService
    {
        void Initialize();
        void Finalize();

        ServiceType GetServiceType();
    }

    public enum ServiceType
    {
        InventoryManager,
        ConfigurationManager
        //RandomGenerator,
        //Logger,
        //Game,
        //TextureManager
    }
}