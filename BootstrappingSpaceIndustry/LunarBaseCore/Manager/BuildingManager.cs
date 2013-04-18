using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class BuildingManager : IService
    {
        List<BuildingItem> _activeBuildings = new List<BuildingItem>();
        List<BuildingItem> _inProgressBuildings = new List<BuildingItem>();

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
            return ServiceType.BuildingManager;
        }

        public IEnumerable<BuildingItem> GetActiveBuildings()
        {
            foreach (BuildingItem item in _activeBuildings)
            {
                yield return item;
            }
        }

        public IEnumerable<BuildingItem> GetInProgressBuildings()
        {
            foreach (BuildingItem item in _inProgressBuildings)
            {
                yield return item;
            }
        }

        public void AddBuilding(BuildingItem building)
        {
            _inProgressBuildings.Add(building);
        }

        public void AddBuildingOfType(BuildingItemType buildingType)
        {
            _inProgressBuildings.Add(new BuildingItem(buildingType));
        }

        public void Update(TickEventArgs tick)
        {
            //Update all active buildings
            foreach (BuildingItem item in _activeBuildings)
            {
                item.Update(tick);
            }

            //Update construction for all buildings in progress
            for (int i = 0; i < _inProgressBuildings.Count; )
            {
                //if construction has been completed
                if (_inProgressBuildings[i].UpdateConstruction(tick))
                {
                    //add the building to the active list
                    _activeBuildings.Add(_inProgressBuildings[i]);
                    _inProgressBuildings.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
            }
        }
    }
}
