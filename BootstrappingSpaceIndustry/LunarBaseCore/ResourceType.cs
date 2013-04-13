using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    /// <summary>
    /// Everything costs resources or creates resources.  This defines the different resource types.
    /// </summary>
    public class ResourceType
    {
        private static int resourceID = 1;

        //TODO: what all do we need in order to define a resource?
        private string _resourceName;
        public string ResourceName { get { return _resourceName; } }
        private int _resourceID;
        public int ResourceID { get { return _resourceID; } }

        public ResourceType(string name)
        {
            _resourceName = name;
            _resourceID = resourceID++;
        }
    }
}
