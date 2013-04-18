using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class BuildingItem : ItemBase
    {
        public enum ConstructionState
        {
            InProgress,
            Active
        };

        ConstructionState _constructionState;
        public ConstructionState State { get { return _constructionState; } }

        public BuildingItem(BuildingItemType itemtype)
        {
            _itemType = itemtype;

            _constructionState = ConstructionState.InProgress;

            //TODO: set initial values - is there anything else that needs to be set?
        }

        /// <summary>
        /// This method is called when a turn ends.  It requests that a building updates itself (rules, decay, etc).
        /// </summary>
        /// <param name="tick">Amount of time that has passed.</param>
        public void Update(TickEventArgs tick)
        {
            //TODO: calls into Rules Engine
            if (_constructionState == ConstructionState.Active)
            {
                ServiceManager.Instance.GetService<RulesEngine>().UpdateBuilding(this, tick);
            }
            else
            {
                ServiceManager.Instance.GetService<LogManager>().Log("Trying to update building that is not in an Active state.");
            }
        }

        /// <summary>
        /// This method is called for buildings that are in progress.
        /// </summary>
        /// <param name="tick">Amount of time that has passed.</param>
        /// <returns>True if the building is finished with construction.</returns>
        public bool UpdateConstruction(TickEventArgs tick)
        {
            //TODO: calls into Rules Engine?  Or evaluate property directly?
            if (_constructionState == ConstructionState.InProgress)
            {
                ServiceManager.Instance.GetService<RulesEngine>().UpdateBuildingConstruction(this, tick);
            }
            else
            {
                ServiceManager.Instance.GetService<LogManager>().Log("Trying to update construction of building that is not in an In Progress state.");
            }

            return false;
        }
    }
}
