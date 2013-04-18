using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LunarBaseCore
{
	public class ModuleLoader : EntityManagerBase<ResourceItemType>, IService
	{

		protected override string NodeName
		{
			get
			{
				return "module";
			}
		}

		protected override void LoadEntityFromNode(XElement node, ResourceItemType entity)
		{
			// The base already loads all the properties - do we need to load anything else?

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
