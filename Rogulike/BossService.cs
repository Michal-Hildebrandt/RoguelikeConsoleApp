using System;
using System.Collections.Generic;
using System.Text;

namespace Rogulike
{
    public class BossService
    {
        private List<Boss> bossDifficulty = new List<Boss>()
        {
            new Boss() { Apperance = 10, Hp = 75, Damage = 25, Exp = 50, Name = "Generic First Boss Name" },
            new Boss() { Apperance = 20, Hp = 95, Damage = 40, Exp = 70,Name = "Generic Second Boss Name" },
            new Boss() { Apperance = 30, Hp = 115, Damage = 55, Exp = 90, Name = "Generic Third Boss Name" },
            new Boss() { Apperance = 40, Hp = 150, Damage = 70, Exp = 120, Name = "Generic Last Boss Name" }
        };
        public List<Boss> ChoosingBoss(int floor)
        {
            List<Boss> bossStats = new List<Boss>();
            foreach (var Boss in bossDifficulty)
            {
                if (floor == Boss.Apperance)
                {
                    bossStats.Add(Boss);
                    break;
                }
            }
            return bossStats;
        }
    }
}
