using Roguelike.App.Commnon;
using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rogulike
{
    public class EnemyGeneratorService:BaseService<EnemyGenerator>
    {
        public EnemyGeneratorService()
        {
            Initialize();
        }
        public EnemyGenerator NewEnemy()
        {
            EnemyGeneratorService enemyGeneneratorService = new EnemyGeneratorService();
            string[] enemyStrength = new string[] { "Weak", "Basic", "Stronger", "Powerful", "Legendary" };
            string[] enemyType = new string[] { "Goblin", "Wolf", "Orc", "Necromancer", "Golem", "Manticore" };

            Random random = new Random();
            int newEnemyStrength = random.Next(0, (enemyStrength.Length));
            Random random2 = new Random();
            int newEnemyType = random2.Next(0, (enemyType.Length));

            Console.WriteLine("New enemy approach ... it is " + enemyStrength[newEnemyStrength] + " " + enemyType[newEnemyType] + " ! ");

            int enemyRangeDifficulty = newEnemyStrength + newEnemyType;

            EnemyGenerator enemyStats = enemyGeneneratorService.GetAllItems().Where(x => enemyRangeDifficulty <= x.DifficultyRange).FirstOrDefault();
            Console.WriteLine("It has " + enemyStats.Hp.ToString() + " hp \n");

            return enemyStats;
        }

        private void Initialize()
        {
           CreateItem(new EnemyGenerator(1,0, 15,10, 5 ));
           CreateItem(new EnemyGenerator(2,3, 20, 15, 10));
           CreateItem(new EnemyGenerator(3,6, 35, 25, 25));
           CreateItem(new EnemyGenerator(4,9, 50, 40, 50));
        }
    }
}