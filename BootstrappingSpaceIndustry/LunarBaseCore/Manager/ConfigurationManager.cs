﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class ConfigurationManager : IService
    {

        public void Initialize()
        {
            //TODO:THIS
            //throw new NotImplementedException();
        }

		public void Cleanup()
        {
            //TODO:anything necessary?
            //throw new NotImplementedException();
        }

        public ServiceType GetServiceType()
        {
            return ServiceType.ConfigurationManager;
        }

        #region Resource Types

		// We're now loading resources from xml - do we need to add in this manner? RJW
		//public void AddResourceType(ResourceType newResourceType)
		//{
		//	_resourceTypes.Add(newResourceType);
		//}

		//public void AddResourceType(string name)
		//{
		//	_resourceTypes.Add(new ResourceType(name));
		//}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="">This throws an exception if the resource type doesn't exist.</exception>
        /// <returns></returns>
        public ResourceItemType GetResourceType(string name)
        {
			return ServiceManager.Instance.GetService<ResourceLoader>().Find(name);
        }

        public ModuleItemType GetModuleType(string name)
        {
            return ServiceManager.Instance.GetService<ModuleLoader>().Find(name);
        }

        public BuildingItemType GetBuildingType(string name)
        {
            return ServiceManager.Instance.GetService<BuildingLoader>().Find(name);
        }

        public List<ResourceItemType> GetResourceTypes()
        {
            return ServiceManager.Instance.GetService<ResourceLoader>().FindAll();
        }

        public List<ModuleItemType> GetModuleTypes()
        {
            return ServiceManager.Instance.GetService<ModuleLoader>().FindAll();
        }

        public List<BuildingItemType> GetBuildingTypes()
        {
            return ServiceManager.Instance.GetService<BuildingLoader>().FindAll();
        }

        #endregion
    }
}
