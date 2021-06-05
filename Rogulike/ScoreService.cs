using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogulike
{
    public class ScoreService
    {
        
       public void GetScore(int enemyDefeated, string playerNickname)
        {
            TextWriter score = new StreamWriter(@"D:\Highscore.txt", true);
            score.WriteLine( "Number of defeated enemies: " + enemyDefeated.ToString() + ", by "+ playerNickname.ToString());
            score.Close();
            
        }
    }
}
