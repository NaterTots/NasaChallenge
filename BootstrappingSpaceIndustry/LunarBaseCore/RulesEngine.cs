﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    class RulesEngine : IService
    {
        public void Initialize()
        {
            //throw new NotImplementedException();
        }

        public void Cleanup()
        {
            //throw new NotImplementedException();
        }

        public ServiceType GetServiceType()
        {
            return ServiceType.RulesEngine;
        }

        public void UpdateBuilding(BuildingItem item, long timeElapsed)
        {
            //TODO:this
        }

        public bool UpdateBuildingConstruction(BuildingItem item, long timeElapsed)
        {
            //TODO:this
                //return value is true if the building construction has completed

            return false;
        }
    }
}
