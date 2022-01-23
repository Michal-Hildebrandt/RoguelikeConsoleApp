using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Roguelike.App.Managers
{
    public class ScoreManager
    {
        public void Highscore(int floor)
        {
            Console.WriteLine("You've completed " + floor + " floor/-s \n");
            Console.WriteLine("Type your nickname: ");
            var playerNickname = Console.ReadLine();
            TextWriter score = new StreamWriter(@"D:\Highscore.txt", true);
            score.WriteLine("Number of completed floors: " + floor + ", by " + playerNickname.ToString());
            score.Close();
        }
       
    }
}
