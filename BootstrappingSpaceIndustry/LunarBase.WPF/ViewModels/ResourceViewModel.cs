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
		public ResourceViewModel()
		{
			Wallet = 123400000;
			CurrentDate = DateTime.Parse("02/25/2099");

			ResourceItemType res1 = new ResourceItemType();
			res1.SetProperty("name", "Titanium");
			//res1.Quantity = 214;

			ResourceItemType res2 = new ResourceItemType();
			res2.SetProperty("name", "Wool");
			//res2.Quantity = 607;

			_resources.Add(res1);
			_resources.Add(res2);
		}

		private ObservableCollection<ResourceItemType> _resources = new ObservableCollection<ResourceItemType>();
		public ObservableCollection<ResourceItemType> Resources
		{
			get
			{
				return _resources;
			}
		}

		private long _wallet;
		public long Wallet
		{
			get
			{
				return _wallet;
			}
			set
			{
				_wallet = value;
				OnPropertyChanged("Wallet");
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

		//public ICommand NextTurnClick

	}
}
