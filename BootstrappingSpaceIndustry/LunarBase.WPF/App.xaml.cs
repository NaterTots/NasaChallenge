using LunarBaseCore;
using System.Windows;

namespace LunarBase.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ServiceManager.Instance.Add(new LogManager());
			ServiceManager.Instance.Add(new ConfigurationManager());
			ServiceManager.Instance.Add(new RandomGenerator());
			ServiceManager.Instance.Add(new InventoryManager());
			ServiceManager.Instance.Add(new ResourceLoader());
			ServiceManager.Instance.Add(new ModuleLoader());
			ServiceManager.Instance.Add(new BuildingLoader());
			ServiceManager.Instance.Add(new BuildingManager());

			//ServiceManager - Initialization
			ServiceManager.Instance.Initialize();

			// Load resources from XML
			ServiceManager.Instance.GetService<ResourceLoader>().Load("resources.xml");
			ServiceManager.Instance.GetService<ModuleLoader>().Load("resources.xml");
			ServiceManager.Instance.GetService<BuildingLoader>().Load("resources.xml");

			//////////////////////////////////////////
			// Testing code

			ConfigurationManager configurationManager = ServiceManager.Instance.GetService<ConfigurationManager>();

			InventoryManager inventoryManager = ServiceManager.Instance.GetService<InventoryManager>();
			inventoryManager.AddItems(configurationManager.GetResourceType("Money"), 1000);
			inventoryManager.AddItems(configurationManager.GetResourceType("Water"), 2349587);
		}

	}
}
