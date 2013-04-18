﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    /// <summary>
    /// Everything costs resources or creates resources.  This defines the different resource types.
    /// </summary>
    public class ModuleItemType : BuildableItemTypeBase
    {
		// I don't know if we actually need these properties, but I wanted some for testing
		public Scarcity ResourceScarcity
		{
			get
			{
				return (Scarcity)Enum.Parse(typeof(Scarcity), GetProperty("scarcity"));
			}
		}

		public AcquisitionMethod Acquired
		{
			get
			{
				return (AcquisitionMethod)Enum.Parse(typeof(AcquisitionMethod), GetProperty("acquiredBy"));
			}
		}

        public ModuleItemType()
        {
            //Name = name;
            //_resourceID = resourceID++;
        }
    }
}