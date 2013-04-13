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
            serviceManager.Add(new LogManager());
            serviceManager.Add(new ConfigurationManager());
            serviceManager.Add(new RandomGenerator());
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
            Console.WriteLine("Adding 1000 Money");
            Console.WriteLine("Adding 50 Iron");
            Console.WriteLine("Adding 220 Electricity");
            Console.WriteLine();

            foreach (KeyValuePair<ResourceType, long> inventory in inventoryManager.GetInventory())
            {
                Console.WriteLine("{0}: {1}", inventory.Key.ResourceName, inventory.Value);
            }
            Console.WriteLine();

            //Modify inventory
            inventoryManager.RemoveResources(configurationManager.GetResourceType("Money"), 900);
            inventoryManager.RemoveResources(configurationManager.GetResourceType("Iron"), 100);
            inventoryManager.RemoveResources(configurationManager.GetResourceType("Electricity"), 300, true);
            Console.WriteLine("Removing 900 Money");
            Console.WriteLine("Removing 100 Iron");
            Console.WriteLine("Removing 300 Electricity, regardless.");
            Console.WriteLine();

            foreach (KeyValuePair<ResourceType, long> inventory in inventoryManager.GetInventory())
            {
                Console.WriteLine("{0}: {1}", inventory.Key.ResourceName, inventory.Value);
            }
            Console.WriteLine();

            //Test Random Number generator
            RandomGenerator randomGenerator = serviceManager.GetService<RandomGenerator>(ServiceType.RandomGenerator);
            
            Console.WriteLine("Generating 10 Random Integers under 10000:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(randomGenerator.Next(10000).ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Generating 10 Random Integers between 100000 and 300000:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(randomGenerator.Next(100000, 300000).ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Generating 10 Random Doubles between -1000 and +1000:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(randomGenerator.NextDouble(-1000, 1000).ToString());
            }
            Console.WriteLine();

            //Testing error handling
            ILogger logger = serviceManager.GetService<ILogger>(ServiceType.Logger);

            logger.Log(new ArgumentException("invalid argument exception"));
            logger.Log("This is a statement we need to log");
            logger.Log(new FormatException("invalid format exception"), "format invalid dummy");

            //Clean up
            serviceManager.Finalize();

            Console.ReadLine();
        }
    }
}
