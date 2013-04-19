using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    /// <summary>
    /// The user itemtype is the item for robonauts and humans
    /// </summary>
    public class UserItemType : BuildableItemTypeBase
    {
        #region Public Properties
        private IDictionary<ItemTypeBase, long> _consumableMaterials = new Dictionary<ItemTypeBase, long>();
        public IDictionary<ItemTypeBase, long> ConsumableMaterials { get { return _consumableMaterials; } }
        #endregion

        public UserItemType()
        {
        }

        /// <summary>
        /// This function will parse xml for user item tupes
        /// </summary>
        /// <param name="element"></param>
        public void ParseUserProperties(XElement element)
        {
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
        }
    }
}
