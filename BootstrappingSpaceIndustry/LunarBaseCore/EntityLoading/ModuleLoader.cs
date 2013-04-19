using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    /// <summary>
    /// The module loader loads modules from the xml
    /// </summary>
	public class ModuleLoader : EntityManagerBase<ModuleItemType>, IService
	{
		protected override string NodeName
		{
			get
			{
				return "module";
			}
		}

        /// <summary>
        /// Required to load fabrication properties from the xml
        /// </summary>
        /// <param name="node"></param>
        /// <param name="entity"></param>
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
