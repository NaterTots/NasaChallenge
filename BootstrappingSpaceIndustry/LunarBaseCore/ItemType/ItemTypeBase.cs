using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    /// <summary>
    /// Base class for all ItemType objects.  Defines all standard methods of an ItemType.
    /// </summary>
    public class ItemTypeBase : IEquatable<ItemTypeBase>//??? should this be abstract or an interface?
    {

		// All item type properties are stored in a dictionary;
		// This allows use to quickly add itemtype properties merely by modifying the XML,
		// rather than having to add a "C# property" to the class.
        private IDictionary<string, string> _itemTypeProps = new Dictionary<string, string>();

		public ItemTypeBase()
		{
			ID = Guid.NewGuid();
		}

        public ItemTypeBase(Dictionary<string, string> Properties)
        {
            ID = Guid.NewGuid();
            this._itemTypeProps = Properties;
        }


        #region Public Enums
        public enum ItemWeight
        {
            High,
            Medium,
            Low
        }
        public enum ItemSource
        {
            Earth,
            Moon
        }
        #endregion

        #region Public Properties
        /// <summary>
		/// This is the name of the object as specified in the XML; this could be referenced by other objects in the XML, and should not contain spaces.
		/// </summary>
		public string Name
		{
			get
			{
				return GetProperty("name");
			}
		}

        public ItemSource[] Sources
        {
            get
            {
                return (GetProperty("sources")).Split(',').Select(x => (ItemSource)Enum.Parse(typeof(ItemSource), x)).ToArray();
            }
        }

        public string Description
        {
            get
            {
                return GetProperty("description");
            }
        }

        public ItemWeight Weight
        {
            get
            {
                return (ItemWeight)Enum.Parse(typeof(ItemWeight), GetProperty("weight"));
            }
        }

        public int Price
        {
            get
            {
                return int.Parse(GetProperty("price"));
            }
        }

		public Guid ID
		{
			get;
			private set;
		}
        #endregion

        /// <summary>
		/// Gets the value associated with the given property.
		/// </summary>
		/// <param name="propName"></param>
		/// <returns>Returns the value of the property, or null if the property doesn't exist.</returns>
		public string GetProperty(string propName)
		{
			string propValue = null;
			if(_itemTypeProps.ContainsKey(propName))
			{
				propValue = _itemTypeProps[propName];
			}

			return propValue;
		}

		// Generic allows the caller to set any basic type as a property - its always stored
		// as a string, so I don't know if this is useful.  Maybe just convienent.
		public void SetProperty<T>(string propName, T propValue)
		{
			_itemTypeProps[propName] = propValue.ToString();
		}

		public bool Validate(List<string> properties)
		{
			bool hasAllProps = true;
			foreach (string prop in properties)
			{
				if (!_itemTypeProps.ContainsKey(prop))
				{
					hasAllProps = false;
					break;
				}
			}

			return hasAllProps;
		}

		#region IEquatable<LoadableObject> Members

		public bool Equals(ItemTypeBase other)
		{
			return ID.Equals(other.ID);
		}

		#endregion

    }
}
