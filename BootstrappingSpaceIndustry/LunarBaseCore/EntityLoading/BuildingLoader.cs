using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    public class BuildingLoader : EntityManagerBase<BuildingItemType>, IService
    {

        protected override string NodeName
        {
            get
            {
                return "building";
            }
        }

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
