using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    public class BuildingItemType : BuildableItemTypeBase
    {
		public BuildingItemType()
		{
		}

        public void ParseBuildingProperties(XElement element)
        {
            SetProperty("buildtime", element.Attribute("buildTime").Value);

            foreach (XElement part in element.Descendants("consumable"))
            {
                Dictionary<string, string> props = new Dictionary<string, string>();
                props.Add("name", part.Attribute("name").Value);

                if (part.Attributes("quantity").Any())
                {
                    _consumableMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), long.Parse(part.Attribute("quantity").Value)));
                }
                else
                {
                    _consumableMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), 1));
                }
            }

            foreach (XElement part in element.Descendants("output"))
            {
                Dictionary<string, string> props = new Dictionary<string, string>();
                props.Add("name", part.Attribute("name").Value);

                if (part.Attributes("quantity").Any())
                {
                    _outputMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), long.Parse(part.Attribute("quantity").Value)));
                }
                else
                {
                    _outputMaterials.Add(new KeyValuePair<ItemTypeBase, long>(new ItemTypeBase(props), 1));
                }
            }
        }

        #region Public Properties
        public long BuildTime
        {
            get
            {
                return long.Parse(GetProperty("buildtime"));
            }
        }

        private IDictionary<ItemTypeBase, long> _consumableMaterials = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> ConsumableMaterials { get { return _consumableMaterials; } }

        private IDictionary<ItemTypeBase, long> _outputMaterials = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> OutputMaterials { get { return _outputMaterials; } }
        #endregion
    }
}
