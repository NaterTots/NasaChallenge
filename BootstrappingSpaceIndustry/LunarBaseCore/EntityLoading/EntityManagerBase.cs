using LunarBaseCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LunarBaseCore
{
	/// <summary>
	/// Derive from this class when you need to load objects/entities/things from XML. 
	/// This page gives an overview of using Linq to XML (XDocument, used below): http://www.hookedonlinq.com/LINQtoXML5MinuteOverview.ashx
	/// </summary>
	public abstract class EntityManagerBase<T> 
		where T : ItemTypeBase, new()
	{
		private List<ItemTypeBase> _allEntities = new List<ItemTypeBase>();

		#region Protected Items that can/must be overridden
		/// <summary>
		/// Derived classes must specify the name of the node to load
		/// </summary>
		protected abstract string NodeName { get; }

		/// <summary>
		/// Derived classes should override this to grab any properties out of the XML.
		/// </summary>
		/// <remarks>node.Attribute("attributeInXml") will retrieve an XAttribute object from the node, representing that attribute. 
		/// If that attribute doesn't exist, it will return null! Make sure you check for null before trying to access XAttribute.Value.</remarks>
		/// <param name="node"></param>
		/// <param name="entity"></param>
		protected virtual void LoadEntityFromNode(XElement node, T entity)
		{

		} 
		#endregion

		public EntityManagerBase()
		{

		}

		public void Load(string xmlFile)
		{
			_allEntities.Clear();

			if (File.Exists(xmlFile))
			{
				XDocument doc = XDocument.Load(xmlFile);
				var nodes = from e in doc.Descendants(NodeName) select e;

				foreach (XElement node in nodes)
				{
					T entity = new T();
					// Load all attrs - saves us from having to add code for each new attribute
					addAllAttributes(node, entity);

					//// Get attributes that every node should have
					//XAttribute nameAttr = node.Attribute("name");
					//if (nameAttr != null)
					//{
					//	entity.Name = nameAttr.Value;
					//}
					LoadEntityFromNode(node, entity);

					_allEntities.Add(entity);
				}
			}
			else
			{
				ServiceManager.Instance.GetService<LogManager>().Log("Cannot load XML, file does not exist: " + xmlFile);
			}
			
		}

		private void addAllAttributes(XElement node, ItemTypeBase itemType)
		{
			foreach (XAttribute attr in node.Attributes())
			{
				itemType.SetProperty(attr.Name.ToString(), attr.Value);
			}
		}

		/// <summary>
		/// Finds the given entity by name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Returns the entity of the given name, or null if it doesn't exist.</returns>
		public T Find(string name)
		{
			return _allEntities.Find( (entity) => entity.Name.Equals(name, StringComparison.OrdinalIgnoreCase) ) as T;
		}

	}
}
