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
    public class BuildableItemTypeBase : ItemTypeBase, IEquatable<ItemTypeBase>
    {
        public BuildableItemTypeBase() : base()
		{
            //TODO: how do we load the RequiredMaterials and RequiredDependencies properties?
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

        private List<KeyValuePair<ItemTypeBase, long>> _requiredMaterials = new List<KeyValuePair<ItemTypeBase, long>>();
        public List<KeyValuePair<ItemTypeBase, long>> RequiredMaterials { get { return _requiredMaterials; } }

        private List<KeyValuePair<ItemTypeBase, long>> _requiredDependencies = new List<KeyValuePair<ItemTypeBase, long>>();
        public List<KeyValuePair<ItemTypeBase, long>> RequiredDependencies { get { return _requiredDependencies; } }

        //TODO: initial properties are needed for 'required robots to build'

        #endregion
    }
}
