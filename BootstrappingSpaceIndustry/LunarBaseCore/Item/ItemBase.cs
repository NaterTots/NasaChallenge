using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
	/// <summary>
	/// Stores the instance data of an Item.
	/// Should reference the corresponding ItemTypeBase class so an Item can validate itself upon loading from the xml that all properties are valid.
	/// </summary>
	public class ItemBase
	{
		protected ItemTypeBase _itemType;

		private long _constructionProgress;
		private long _currentTicks;
		private long _decay; //could call this health instead

		public ItemBase()
		{
			_constructionProgress = 0;
			_currentTicks = 0;
			_decay = 0;
		}

		#region Construction
		/// <summary>
		/// Indicates the progress toward finishing construction on this Item.  When _constructionProgress reaches 100 the Item has been created.
		/// Maximum value is 100
		/// </summary>
		public long ConstructionProgress
		{
			get { return _constructionProgress; }
		}

		/// <summary>
		/// Indicates if construction is complete on the Item.
		/// </summary>
		public bool IsConstructed()
		{
			return _constructionProgress < 100 ? false : true;
		}

		/// <summary>
		/// Increments the construction progress of the Item.
		/// </summary>
		/// <param name="increment">Amount by which the construction progress should be incremented.</param>
		/// <returns>Returns true if the Item has been fully constructed</returns>
		public bool IncrementConstructionProgress(long increment)
		{
			_constructionProgress = _constructionProgress + increment;
			//max construction at 100
			if (_constructionProgress > 100)
			{
				_constructionProgress = 100;
			}

			return IsConstructed();
		}

		public long CurrentTicks
		{
			get { return _currentTicks; }
		}

		public void ResetCurrentTicks()
		{
			_currentTicks = 0;
		}

		public void IncrementCurrentTicks()
		{
			_currentTicks = _currentTicks + 1;
		}


		#endregion

		public ItemTypeBase ItemType
		{
			get { return _itemType; }
			set { _itemType = value; }
		}

	}
}
