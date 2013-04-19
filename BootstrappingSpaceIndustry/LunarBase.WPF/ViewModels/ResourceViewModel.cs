using LunarBaseCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LunarBase.WPF.ViewModels
{
	internal class ResourceViewModel : ViewModelBase
	{
		private ObservableCollection<ResourceItemInstance> _resources = new ObservableCollection<ResourceItemInstance>();
		public ObservableCollection<ResourceItemInstance> Resources
		{
			get
			{
				return _resources;
			}
		}


		private DateTime _currentDate;

		public DateTime CurrentDate
		{
			get { return _currentDate; }
			set
			{
				_currentDate = value;
				OnPropertyChanged("CurrentDate");
			}
		}

		public ResourceViewModel()
		{
			// Test data
			CurrentDate = DateTime.Parse("02/25/2099");

			ServiceManager.Instance.GetService<InventoryManager>().InventoryChange += ResourceViewModel_InventoryChange;

			// TODO This initial call might not be necessary after testing phase
			updateResourcesFromInventory();
		}

		void ResourceViewModel_InventoryChange(object sender, InventoryManager.InventoryChangeEventArgs e)
		{
			updateResourcesFromInventory();
		}

		private void updateResourcesFromInventory()
		{
			_resources.Clear();
			foreach (KeyValuePair<ItemTypeBase, long> item in ServiceManager.Instance.GetService<InventoryManager>().GetInventory())
			{
				_resources.Add(new ResourceItemInstance(item.Key, item.Value));
			}
		}

	}

	internal class ResourceItemInstance
	{
		public ItemTypeBase ItemType
		{
			get;
			set;
		}

		public long Count
		{
			get;
			set;
		}

		public ResourceItemInstance(ItemTypeBase itemType, long count)
		{
			ItemType = itemType;
			Count = count;
		}
	}
}
