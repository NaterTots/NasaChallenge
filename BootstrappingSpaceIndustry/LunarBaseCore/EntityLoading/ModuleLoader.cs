using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
	public class ModuleLoader : EntityManagerBase<ModuleItemType>, IService
	{

		protected override string NodeName
		{
			get
			{
				return "module";
			}
		}

        protected override void LoadEntityFromNode(XElement node, ModuleItemType entity)
        {
            entity.ParseFabricationProperties(node.Element("fabricationProperties"));
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
