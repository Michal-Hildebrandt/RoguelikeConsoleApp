using Roguelike.App.Commnon;
using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Roguelike;

namespace Rogulike
{
    public class EnemyGeneratorService:BaseService<EnemyGenerator>
    {
        private string[] enemyStrength = new string[] { "Weak", "Basic", "Stronger", "Powerful", "Legendary" };
        private string[] enemyType = new string[] { "Goblin", "Wolf", "Orc", "Necromancer", "Golem", "Manticore" };

        public EnemyGeneratorService()
        {
            Initialize();
        }
        public EnemyGenerator NewEnemy()
        {
            EnemyGeneratorService enemyGeneneratorService = new EnemyGeneratorService();

            Random random = new Random();
            int newEnemyStrength = random.Next(0, (enemyStrength.Length));
            Random random2 = new Random();
            int newEnemyType = random2.Next(0, (enemyType.Length));


            int enemyRangeDifficulty = newEnemyStrength + newEnemyType;
            EnemyGenerator enemyStats = enemyGeneneratorService.GetAllItems().Where(x => enemyRangeDifficulty <= x.DifficultyRange).FirstOrDefault();
            enemyStats.Strength = enemyStrength[newEnemyStrength];
            enemyStats.Type = enemyType[newEnemyType];

            Console.WriteLine("New enemy approach ... it is " + enemyStats.Strength + " " + enemyStats.Type + " ! ");
            Console.WriteLine("It has " + enemyStats.Hp.ToString() + " hp \n");

            return enemyStats;
        }

        public ChosenClass Attack(ChosenClass result, EnemyGenerator enemy, Helpers spacingLine)
        {
            enemy.Hp -= result.Damage;
            if (enemy.Hp <= 0)
            {
                Console.WriteLine("Enemy has been defeated");
                Console.WriteLine("You have earned " + enemy.Exp + "exp");
            }
            else
            {
                Console.WriteLine("Enemy has " + enemy.Hp + " hp  \n");

                result.Hp -= enemy.Damage;

                if (result.Hp <= 0)
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage and you've died\n");
                    spacingLine.SpacingLine();
                }
                else
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage -> you have " + result.Hp + " hp left \n");
                    spacingLine.SpacingLine();
                }
            }
            return result;
        }
        public ChosenClass UseSkill(ChosenClass result, EnemyGenerator enemy, SkillsService skillsService, Skills skill, Helpers spacingLine)
        {
            if (skill.IsLocked == true)
            {
                Console.WriteLine("You need to unlock your skills first !");

                result.Hp -= enemy.Damage;

                if (result.Hp <= 0)
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage and you've died\n");
                    spacingLine.SpacingLine();
                }
                else
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage -> you have " + result.Hp + " hp left \n");
                    spacingLine.SpacingLine();
                }
            }
            else
            {
                for (int i = skill.TurnsRequired; i >= 0; i--)
                {
                    skillsService.SkillsAction(skill, result, enemy);

                    if (skill.Name == "Blessing" && skill.IsActive == true)
                    {
                        skillsService.BlessingEffect(enemy, skill);
                        skill.Duration -= 1;
                    }

                    result.Hp -= enemy.Damage;

                    skill.TurnsRequired -= 1;

                    if (result.Hp <= 0)
                    {
                        Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage and you've died\n");
                        spacingLine.SpacingLine();
                    }
                    else
                    {
                        Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage -> you have " + result.Hp + " hp left \n");
                        spacingLine.SpacingLine();
                    }

                }
                skill.TurnsRequired = default;
            }

            return result;
        }
        public ChosenClass RunAway(ChosenClass result, Helpers spacingLine)
        {
            Console.WriteLine("You've decided to run away");
            spacingLine.SpacingLine();
            return result;
        }

        private void Initialize()
        {
           CreateItem(new EnemyGenerator(1,0, 15,10, 5, null,null));
           CreateItem(new EnemyGenerator(2,3, 20, 15, 10, null, null));
           CreateItem(new EnemyGenerator(3,6, 35, 25, 25, null, null));
           CreateItem(new EnemyGenerator(4,9, 50, 40, 50, null, null));
        }
    }
}