using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
    /// <summary>
    /// The resource loader loads the xml for resource items
    /// </summary>
	public class ResourceLoader : EntityManagerBase<ResourceItemType>, IService
	{
		protected override string NodeName
		{
			get
			{
				return "resource";
			}
		}

		protected override void LoadEntityFromNode(XElement node, ResourceItemType entity)
		{
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
