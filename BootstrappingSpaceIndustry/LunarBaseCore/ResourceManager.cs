using LunarBaseCore.EntityLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
	public class ResourceManager : EntityManagerBase<ResourceType>, IService
	{

		protected override string NodeName
		{
			get
			{
				return "resource";
			}
		}

		protected override void LoadEntityFromNode(XElement node, ResourceType entity)
		{
			XAttribute attr = node.Attribute("scarcity");
			Scarcity scarcity;
			if (attr != null && Enum.TryParse<Scarcity>(attr.Value, out scarcity))
			{
				entity.Scarcity = scarcity;
				//ServiceManager.Instance.GetService<LogManager>().Log("Unknown Scarcity type: " + attr.Value);
			}

			attr = node.Attribute("acquiredBy");
			AcquisitionMethod acquire;
			if (attr != null && Enum.TryParse<AcquisitionMethod>(attr.Value, out acquire))
			{
				entity.Acquired = acquire;
			}
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
