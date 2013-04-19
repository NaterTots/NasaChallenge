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
	public class UserLoader : EntityManagerBase<UserItemType>, IService
	{
		protected override string NodeName
		{
			get
			{
				return "user";
			}
		}

        /// <summary>
        /// Required to load fabrication properties from the xml
        /// </summary>
        /// <param name="node"></param>
        /// <param name="entity"></param>
        protected override void LoadEntityFromNode(XElement node, UserItemType entity)
        {
            entity.ParseFabricationProperties(node.Element("fabricationProperties"));
            entity.ParseUserProperties(node.Element("userProperties"));
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
