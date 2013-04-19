﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class BuildQueue
    {
        Queue<WorkItem> _queue = new Queue<WorkItem>();

        public void AddWorkItem(WorkItem item)
        {
            _queue.Enqueue(item);
        }

        public WorkItem GetNextWorkItem()
        {
            return _queue.Dequeue();
        }

        public WorkItem PeekAtNextWorkItem()
        {
            return _queue.Peek();
        }

        public IEnumerable<WorkItem> QueueEnumerable()
        {
            foreach (WorkItem item in _queue)
            {
                yield return item;
            }
        }
    }

    public class WorkItem
    {
        //Anything necessary here?
    }

    public class ConstructionWorkItem : WorkItem
    {
        public ConstructionWorkItem(ItemTypeBase item)
        {
            ItemType = item;
        }

        public ItemTypeBase ItemType { get; private set; }
    }
}
