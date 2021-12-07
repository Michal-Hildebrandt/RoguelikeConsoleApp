using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogulike
{
    public class Score
    {
        
       public void GetScore(int floor, string playerNickname)
        {
            TextWriter score = new StreamWriter(@"D:\Highscore.txt", true);
            score.WriteLine( "Number of completed floors: " + floor + ", by "+ playerNickname.ToString());
            score.Close();
            
        }
    }
}
