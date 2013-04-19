using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using LunarBaseCore;


namespace LunarBase.WPF.ViewModels
{
	internal class BuildQueueViewModel : ViewModelBase
	{
        private ObservableCollection<WorkItem> _workItems = new ObservableCollection<WorkItem>();
        public ObservableCollection<WorkItem> WorkItems
        {
            get
            {
                return _workItems;
            }
        }

        public BuildQueueViewModel()
		{
            ServiceManager.Instance.GetService<BuildQueue>().BuildQueueChange += BuildQueueViewModel_QueueChange;

			// TODO This initial call might not be necessary after testing phase
            updateBuildQueue();
		}

        void BuildQueueViewModel_QueueChange(object sender, BuildQueue.BuildQueueChangeEventArgs e)
        {
            updateBuildQueue();
        }

        private void updateBuildQueue()
        {
            _workItems.Clear();
            foreach (WorkItem item in ServiceManager.Instance.GetService<BuildQueue>().QueueEnumerable())
            {
                _workItems.Add(item);
            }
        }
	}
}
