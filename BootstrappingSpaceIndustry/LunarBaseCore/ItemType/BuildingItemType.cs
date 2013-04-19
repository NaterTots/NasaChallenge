using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    public class BuildingItemType : BuildableItemTypeBase
    {
        #region Public Properties
        /// <summary>
        /// The rate at which the building decays
        /// </summary>
        public double DecayRate
        {
            get
            {
                return double.Parse(GetProperty("decayrate"));
            }
        }

        private IDictionary<ItemTypeBase, long> _consumableMaterials = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> ConsumableMaterials { get { return _consumableMaterials; } }

        private IDictionary<ItemTypeBase, long> _outputMaterials = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> OutputMaterials { get { return _outputMaterials; } }
        #endregion

		public BuildingItemType()
		{
		}

        /// <summary>
        /// This function will parse xml for building item types and get the properties
        /// </summary>
        /// <param name="element"></param>
        public void ParseBuildingProperties(XElement element)
        {
            SetProperty("decayrate", element.Attribute("decayrate").Value);
            
            // Consumables are items that are consumed every time period to keep the building running and producing output.
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

            // Output are items that are created or output every time period.
            // AKA - a power station building will output power
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
    }
}
