using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Domain.Entity
{
    public class Experience
    {

        public int[] ExpRequired { get; set; }
        public int TotalExp { get; set; }
        public int UpgradePoints { get; set; }

        public Experience()
        {
            int [] ExpRequired = new int[30];
            ExpRequired[0] = 0;
            for (int i = 0; i < 30; i++)
            {
               ExpRequired[i] = 35 * i;
            }
        }

        public Experience(int [] expRequired,int totalExp, int upgradePoints)
        {
            ExpRequired = expRequired;
            expRequired = new int[30];
            expRequired[0] = 0;
            for (int i = 0; i < 30; i++)
            {
                expRequired[i] = 35 * i;
            }
            TotalExp = totalExp;
            UpgradePoints = upgradePoints;
        }
    }
}
