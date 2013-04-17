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
			ServiceManager.Instance.Add(new LogManager());
			ServiceManager.Instance.Add(new ConfigurationManager());
			ServiceManager.Instance.Add(new RandomGenerator());
			ServiceManager.Instance.Add(new InventoryManager());
			ServiceManager.Instance.Add(new ResourceManager());

            //ServiceManager - Initialization
			ServiceManager.Instance.Initialize();

			// Load resources from XML
			ServiceManager.Instance.GetService<ResourceManager>().Load("xml/resources.xml");

            //Add test data to configuration manager
			ConfigurationManager configurationManager = ServiceManager.Instance.GetService<ConfigurationManager>();
			// Loading from xml
			//configurationManager.AddResourceType(new ResourceType("Money"));
			//configurationManager.AddResourceType(new ResourceType("Iron"));
			//configurationManager.AddResourceType(new ResourceType("Electricity"));


            //Initialize inventory
			InventoryManager inventoryManager = ServiceManager.Instance.GetService<InventoryManager>();
            inventoryManager.AddResources(configurationManager.GetResourceType("Money"), 1000);
            inventoryManager.AddResources(configurationManager.GetResourceType("Iron"), 50);
            inventoryManager.AddResources(configurationManager.GetResourceType("Electricity"), 220);
            Console.WriteLine("Adding 1000 Money");
            Console.WriteLine("Adding 50 Iron");
            Console.WriteLine("Adding 220 Electricity");
            Console.WriteLine();

            foreach (KeyValuePair<ResourceItemType, long> inventory in inventoryManager.GetInventory())
            {
                Console.WriteLine("{0} ({1}, acquired by {2}) {3}", inventory.Key.Name, inventory.Key.ResourceScarcity, inventory.Key.Acquired, inventory.Value);
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

            foreach (KeyValuePair<ResourceItemType, long> inventory in inventoryManager.GetInventory())
            {
                Console.WriteLine("{0}: {1}", inventory.Key.Name, inventory.Value);
            }
            Console.WriteLine();

            //Test Random Number generator
			RandomGenerator randomGenerator = ServiceManager.Instance.GetService<RandomGenerator>();
            
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
			LogManager logger = ServiceManager.Instance.GetService<LogManager>();

            logger.Log(new ArgumentException("invalid argument exception"));
            logger.Log("This is a statement we need to log");
            logger.Log(new FormatException("invalid format exception"), "format invalid dummy");

            //Clean up
			ServiceManager.Instance.Cleanup();

            Console.ReadLine();
        }
    }
}
