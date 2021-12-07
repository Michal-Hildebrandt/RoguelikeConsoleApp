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
            new EnemyGenerator() { DifficultyRange = 0, Hp = 15, Damage = 10, Exp = 5 },
            new EnemyGenerator() { DifficultyRange = 3, Hp = 20, Damage = 15, Exp = 10 },
            new EnemyGenerator() { DifficultyRange = 6, Hp = 35, Damage = 25, Exp = 25 },
            new EnemyGenerator() { DifficultyRange = 9, Hp = 50, Damage = 40, Exp = 50 }
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
                if (enemyRangeDifficulty <= EnemyGenerator.DifficultyRange)
                {
                    enemyStats.Add(EnemyGenerator);
                    break ;
                }
            }
            return enemyStats;
        }
    }
}