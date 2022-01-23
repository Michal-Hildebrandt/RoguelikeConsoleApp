using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Experience
    {

        public int[] ExpRequired { get; set; }
        public int TotalExp { get; set; }
        public int UpgradePoints { get; set; }

        public Experience()
        {
            ExpRequired = new int[30];
            ExpRequired[0] = 0;
            for (int i = 0; i < 30; i++)
            {
               ExpRequired[i] = 35 * i;
            }
        }
    }
}
