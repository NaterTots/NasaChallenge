using LunarBaseCore.EntityLoading;
using LunarBaseCore.ItemType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
	public enum Scarcity
	{
		Common,
		Uncommon,
		Rare,
		Epic,
	}

	public enum AcquisitionMethod
	{
		FromEarth,
		Refined,
		Mined
	}

    /// <summary>
    /// Everything costs resources or creates resources.  This defines the different resource types.
    /// </summary>
    public class ResourceItemType : ItemTypeBase
    {
		// I don't know if we actually need these properties, but I wanted some for testing
		public Scarcity ResourceScarcity
		{
			get
			{
				return (Scarcity)Enum.Parse(typeof(Scarcity), GetProperty("scarcity"));
			}
		}

		public AcquisitionMethod Acquired
		{
			get
			{
				return (AcquisitionMethod)Enum.Parse(typeof(AcquisitionMethod), GetProperty("acquiredBy"));
			}
		}

        public ResourceItemType()
        {
            //Name = name;
            //_resourceID = resourceID++;
        }
    }
}
