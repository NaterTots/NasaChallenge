using LunarBaseCore.EntityLoading;
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
    public class ResourceType : LoadableEntity
    {
		//private static int resourceID = 1;

		////TODO: what all do we need in order to define a resource?
		//private string _resourceName;
		//public string ResourceName { get { return _resourceName; } }
		//private int _resourceID;
		//public int ResourceID { get { return _resourceID; } }

		// I don't know if we actually need these properties, but I wanted to test with some
		public Scarcity Scarcity
		{
			get;
			set;
		}

		public AcquisitionMethod Acquired
		{
			get;
			set;
		}

        public ResourceType()
        {
            //Name = name;
            //_resourceID = resourceID++;
        }
    }
}
