using LunarBaseCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBase.WPF.ViewModels
{
	internal class InfoPanelViewModel : ViewModelBase
	{
		private DateTime _currentGameDate;
		public DateTime CurrentGameDate
		{
			get
			{
				return _currentGameDate;
			}

			set
			{
				_currentGameDate = value;
				OnPropertyChanged("CurrentGameDate");
			}
		}

		public RelayCommand NextTurnCommand
		{
			get;
			set;
		}

		public InfoPanelViewModel()
		{
			NextTurnCommand = new RelayCommand(executeNextTurnCommand);
		}

		private void executeNextTurnCommand(object test)
		{
			//ServiceManager.Instance.GetService<GameEngine>().TurnStart(null, null);
		}

	}
}
