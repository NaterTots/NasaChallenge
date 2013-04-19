using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    /// <summary>
    /// Base class for all buildable ItemType objects.  Defines all standard methods of an Buildable ItemType.
    /// </summary>
    public class BuildableItemTypeBase : ItemTypeBase, IEquatable<ItemTypeBase>
    {
        #region Public Properties
        /// <summary>
        /// The success rate of the fabrication of an item.  The lower the rate, the more material it takes to create an item.
        /// </summary>
        public FabricationSuccess FabSuccess
        {
            get
            {
                return (FabricationSuccess)Enum.Parse(typeof(FabricationSuccess), GetProperty("success"));
            }
        }

        private IDictionary<ItemTypeBase, long> _requiredMaterials = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> RequiredMaterials { get { return _requiredMaterials; } }

        private IDictionary<ItemTypeBase, long> _requiredDependencies = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> RequiredDependencies { get { return _requiredDependencies; } }

        //TODO: initial properties are needed for 'required robots to build'

        #endregion

        #region Public Enums
        public enum FabricationSuccess
        {
            Low,
            Medium,
            High,
            Always
        }
        #endregion

        public BuildableItemTypeBase() : base()
		{
		}

        /// <summary>
        /// This function will parse the xml element of fabricationProperties for buildable item types
        /// </summary>
        /// <param name="element"></param>
        public void ParseFabricationProperties(XElement element)
        {
            SetProperty("success", element.Attribute("success").Value);

            // Materials are items that are used to build an item
            foreach (XElement part in element.Descendants("material"))
            {
                Dictionary<string, string> props = new Dictionary<string, string>();
                props.Add("name", part.Attribute("name").Value);

                if (part.Attributes("quantity").Any())
                {
                    _requiredMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), long.Parse(part.Attribute("quantity").Value)));
                }
                else
                {
                    _requiredMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), 1));
                }
            }

            // Dependencies are items required for the item to be built.  They are not consumed, only required to exist before this item can be fabricated.
            // AKA - A robot cannot be built with a fabricator building.
            foreach (XElement part in element.Descendants("dependency"))
            {
                Dictionary<string, string> props = new Dictionary<string, string>();
                props.Add("name", part.Attribute("name").Value);

                if (part.Attributes("quantity").Any())
                {
                    _requiredMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), long.Parse(part.Attribute("quantity").Value)));
                }
                else
                {
                    _requiredMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), 1));
                }
            }
        }
    }
}
