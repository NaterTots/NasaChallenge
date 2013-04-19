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
        public BuildableItemTypeBase() : base()
		{
            //TODO: how do we load the RequiredMaterials and RequiredDependencies properties?
		}

        public void ParseFabricationProperties(XElement element)
        {
            SetProperty("success", element.Attribute("success").Value);

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

        private IDictionary<ItemTypeBase, long> _requiredMaterials = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> RequiredMaterials { get { return _requiredMaterials; } }

        private IDictionary<ItemTypeBase, long> _requiredDependencies = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> RequiredDependencies { get { return _requiredDependencies; } }

        //TODO: initial properties are needed for 'required robots to build'

        #endregion
    }
}
