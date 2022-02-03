using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Roguelike.App.Managers
{
    public class ScoreManager
    {
        public int ScoreMenu(int floor)
        {
            Console.WriteLine("You've completed " + (floor-1) + " floor/-s \n");
            Console.WriteLine("Type your nickname: ");

            return floor;
        }
    }
}
