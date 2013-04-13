using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LunarBaseCore;

namespace CoreTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceManager - Construction
            ServiceManager serviceManager = new ServiceManager();
            serviceManager.Add(new ConfigurationManager());
            serviceManager.Add(new InventoryManager());

            //ServiceManager - Initialization
            serviceManager.Initialize();

            //Add test data to configuration manager
            ConfigurationManager configurationManager = serviceManager.GetService<ConfigurationManager>(ServiceType.ConfigurationManager);
            configurationManager.AddResourceType(new ResourceType("Money"));
            configurationManager.AddResourceType(new ResourceType("Iron"));
            configurationManager.AddResourceType(new ResourceType("Electricity"));


            //Initialize inventory
            InventoryManager inventoryManager = serviceManager.GetService<InventoryManager>(ServiceType.InventoryManager);
            inventoryManager.AddResources(configurationManager.GetResourceType("Money"), 1000);
            inventoryManager.AddResources(configurationManager.GetResourceType("Iron"), 50);
            inventoryManager.AddResources(configurationManager.GetResourceType("Electricity"), 220);

            foreach (KeyValuePair<ResourceType, long> inventory in inventoryManager.GetInventory())
            {
                Console.WriteLine("{0}: {1}", inventory.Key.ResourceName, inventory.Value);
            }
            Console.WriteLine();

            //Modify inventory
            inventoryManager.RemoveResources(configurationManager.GetResourceType("Money"), 900);
            inventoryManager.RemoveResources(configurationManager.GetResourceType("Iron"), 100);
            inventoryManager.RemoveResources(configurationManager.GetResourceType("Electricity"), 300, true);

            foreach (KeyValuePair<ResourceType, long> inventory in inventoryManager.GetInventory())
            {
                Console.WriteLine("{0}: {1}", inventory.Key.ResourceName, inventory.Value);
            }
            Console.WriteLine();

            //Clean up
            serviceManager.Finalize();

            Console.ReadLine();
        }
    }
}
