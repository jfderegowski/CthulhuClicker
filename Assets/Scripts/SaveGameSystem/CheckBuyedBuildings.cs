using System.Collections.Generic;
using System.Linq;

namespace SaveGameSystem
{
    public class CheckBuyedBuildings
    {
        public void IsBuyed(List<Building> buildings)
        {
            foreach (var building in buildings.Where(building => building.Lvl > 0))
            {
                building.ObjectOnIsland.SetActive(true);
            }
        }
    }
}
