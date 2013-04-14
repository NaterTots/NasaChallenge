using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LunarBaseCore.Entities
{
	/// <summary>
	/// Derive from this class when you need to load objects/entities/things from XML. 
	/// This page gives an overview of using Linq to XML (XDocument is this): http://www.hookedonlinq.com/LINQtoXML5MinuteOverview.ashx
	/// </summary>
	public abstract class EntityManagerBase<T> 
		where T : LoadableEntity, new()
	{
		protected List<LoadableEntity> allObjects = new List<LoadableEntity>();

		/// <summary>
		/// Derived classes must specify the name of the node to load
		/// </summary>
		protected abstract string NodeName { get; set; }

		public EntityManagerBase()
		{

		}

		public void Load(string xmlFile)
		{
			allObjects.Clear();

			if (File.Exists(xmlFile))
			{
				XDocument doc = XDocument.Load(xmlFile);
				var nodes = from e in doc.Descendants(NodeName) select e;

				foreach (XElement node in nodes)
				{
					T entity = new T();
					
					// Get attributes that every node should have
					XAttribute nameAttr = node.Attribute("name");
					if (nameAttr != null)
					{
						entity.Name = nameAttr.Value;
					}

					LoadEntityFromNode(node, entity);

					allObjects.Add(entity);
				}
			}
			else
			{
				ServiceManager.Instance.GetService<LogManager>().Log("Cannot load XML, file does not exist: " + xmlFile);
			}
			
		}

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

	}
}
