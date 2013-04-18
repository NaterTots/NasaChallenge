using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class BuildingItem : ItemBase
    {
        public BuildingItem(BuildingItemType itemtype)
        {
            //TODO: what does this do?
        }

        /// <summary>
        /// This method is called when a turn ends.  It requests that a building updates itself (rules, decay, etc).
        /// </summary>
        /// <param name="tick">Amount of time that has passed.</param>
        public void Update(TickEventArgs tick)
        {
            //TODO: calls into Rules Engine
        }

        /// <summary>
        /// This method is called for buildings that are in progress.
        /// </summary>
        /// <param name="tick">Amount of time that has passed.</param>
        /// <returns>True if the building is finished with construction.</returns>
        public bool UpdateConstruction(TickEventArgs tick)
        {
            //TODO: calls into Rules Engine?  Or evaluate property directly?

            return false;
        }
    }
}
