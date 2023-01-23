using Roguelike.Domain.Entity;
using Rogulike;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.App.Managers
{
    public class EnemyGeneratorManager
    {
        public ChosenClass EnemyBattle(ChosenClass result, EnemyGenerator enemyStats, EnemyGeneratorService enemyGeneratorService, Helpers spacingLine, Skills skill, SkillsService skillsService)
        {
            while (enemyStats.Hp > 0 && result.Hp > 0)
            {
                var operation2 = Console.ReadKey();
                Console.WriteLine();
                int.TryParse(operation2.KeyChar.ToString(), out int val1);
                switch (val1)
                {
                    case 1:
                        enemyGeneratorService.Attack(result, enemyStats, spacingLine);
                        break;
                    case 2:
                        enemyGeneratorService.UseSkill(result, enemyStats, skillsService, skill, spacingLine);
                        break;
                    case 3:
                        enemyGeneratorService.RunAway(result, spacingLine);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
