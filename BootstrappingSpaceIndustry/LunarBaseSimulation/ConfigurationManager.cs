using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class ConfigurationManager : IService
    {
        //TODO: is there a cleaner way to keep these lists or is this acceptable?
        private List<ResourceType> _resourceTypes = new List<ResourceType>();

        public void Initialize()
        {
            //TODO:THIS
            //throw new NotImplementedException();
        }

        public void Finalize()
        {
            //TODO:anything necessary?
            //throw new NotImplementedException();
        }

        public ServiceType GetServiceType()
        {
            return ServiceType.ConfigurationManager;
        }

        #region Resource Types

        public void AddResourceType(ResourceType newResourceType)
        {
            _resourceTypes.Add(newResourceType);
        }

        public void AddResourceType(string name)
        {
            _resourceTypes.Add(new ResourceType(name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="">This throws an exception if the resource type doesn't exist.</exception>
        /// <returns></returns>
        public ResourceType GetResourceType(string name)
        {
            foreach (ResourceType rt in _resourceTypes)
            {
                if (rt.ResourceName.CompareTo(name) == 0)
                {
                    return rt;
                }
            }

            throw new ArgumentException(name);
        }

        #endregion
    }
}
