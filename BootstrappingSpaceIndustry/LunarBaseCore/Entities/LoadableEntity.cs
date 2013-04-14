using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore.Entities
{
	/// <summary>
	///  Derive from this class for any objects that will be loaded from XML
	/// </summary>
	public class LoadableEntity : IEquatable<LoadableEntity>
	{
		public LoadableEntity()
		{
			ID = Guid.NewGuid();
		}

		/// <summary>
		/// This is the name of the object as specified in the XML; this could be referenced by other objects in the XML, and should not contain spaces.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		public Guid ID
		{
			get;
			private set;
		}

		#region IEquatable<LoadableObject> Members

		public bool Equals(LoadableEntity other)
		{
			return ID.Equals(other.ID);
		}

		#endregion
	}
}
