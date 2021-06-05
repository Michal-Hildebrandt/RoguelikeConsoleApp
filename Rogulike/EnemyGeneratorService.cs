using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogulike
{
    public class EnemyGeneratorService
    {
       private List<EnemyGenerator> enemyDifficulty = new List<EnemyGenerator>()
        {
            new EnemyGenerator() { difficultyRange = 0, Hp = 15, Def = 5, Damage = 10 },
            new EnemyGenerator() { difficultyRange = 3, Hp = 20, Def = 15, Damage = 15 },
            new EnemyGenerator() { difficultyRange = 6, Hp = 30, Def = 25, Damage = 25 },
            new EnemyGenerator() { difficultyRange = 9, Hp = 50, Def = 35, Damage = 40 }
        };
        public List<EnemyGenerator> NewEnemy()
        {
            string[] enemyStrength = new string[] { "Weak", "Basic", "Stronger", "Powerful", "Legendary" };
            string[] enemyType = new string[] { "Goblin", "Wolf", "Orc", "Necromancer", "Golem", "Manticore" };

            Random random = new Random();
            int newEnemyStrength = random.Next(0, (enemyStrength.Length));
            Random random2 = new Random();
            int newEnemyType = random2.Next(0, (enemyType.Length));

            Console.WriteLine("New enemy approach ... it is " + enemyStrength[newEnemyStrength] + " " + enemyType[newEnemyType] + " ! ");

            int enemyRangeDifficulty = newEnemyStrength + newEnemyType;
            
            List<EnemyGenerator> enemyStats = new List<EnemyGenerator>();
            foreach (var EnemyGenerator in enemyDifficulty)
            {
                if (enemyRangeDifficulty <= EnemyGenerator.difficultyRange)
                {
                    enemyStats.Add(EnemyGenerator);
                    break ;
                }

            }
            return enemyStats;

        }
    }

}