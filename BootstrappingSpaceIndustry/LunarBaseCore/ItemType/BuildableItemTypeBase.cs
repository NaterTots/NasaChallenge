using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    /// <summary>
    /// Base class for all buildable ItemType objects.  Defines all standard methods of an Buildable ItemType.
    /// </summary>
    public class BuildableItemTypeBase : ItemTypeBase, IEquatable<ItemTypeBase>//??? should this be abstract or an interface?
    {

		// All item type properties are stored in a dictionary;
		// This allows use to quickly add itemtype properties merely by modifying the XML,
		// rather than having to add a "C# property" to the class.
        private IDictionary<string, string> _itemTypeProps = new Dictionary<string, string>();

        public BuildableItemTypeBase() : base()
		{
            Consumables = new List<ItemTypeBase>();
            Consumables = new List<ItemTypeBase>();
		}

        #region Public Enums
        public enum FabricationSuccess
        {
            Low,
            Medium,
            High,
            Always
        }
        #endregion

        #region Public Properties
		public FabricationSuccess FabSuccess
		{
			get
			{
                return (FabricationSuccess)Enum.Parse(typeof(FabricationSuccess), GetProperty("success"));
			}
		}

        public IList<ItemTypeBase> Consumables { get; set; }
        public IList<ItemTypeBase> Requirements { get; set; }
        public IList<ItemTypeBase> Output { get; set; }
        public IList<ItemTypeBase> PartsRequired { get; set; }
        #endregion
    }
}
