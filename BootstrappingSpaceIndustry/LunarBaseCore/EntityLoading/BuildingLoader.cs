using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    /// <summary>
    /// This class loads building item types from the xml
    /// </summary>
    public class BuildingLoader : EntityManagerBase<BuildingItemType>, IService
    {

        protected override string NodeName
        {
            get
            {
                return "building";
            }
        }

        /// <summary>
        /// Required to load both fabrication and building properties from the xml
        /// </summary>
        /// <param name="node"></param>
        /// <param name="entity"></param>
        protected override void LoadEntityFromNode(XElement node, BuildingItemType entity)
        {
            entity.ParseFabricationProperties(node.Element("fabricationProperties"));
            entity.ParseBuildingProperties(node.Element("buildingProperties"));
        }

        

        #region IService Members

        public void Initialize()
        {
        }

        public void Cleanup()
        {
        }

        public ServiceType GetServiceType()
        {
            return ServiceType.ResourceManager;
        }

        #endregion
    }
}
