using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.App.Managers
{
    public class BossManager
    {
        public ChosenClass BossBattle(ChosenClass result, Boss bossStats, Helpers spacingLine, Skills skill, SkillsService skillsService, BossService bossService, Skills bossSkill )
        {
            while (bossStats.Hp > 0 && result.Hp > 0)
            {
                

                var operation3 = Console.ReadKey();
                Console.WriteLine();
                int.TryParse(operation3.KeyChar.ToString(), out int val2);

                switch (val2)
                {
                    case 1:
                        bossService.AttackBoss(result, bossStats, bossService, skillsService, bossSkill);
                        break;
                    case 2:
                        bossService.UseSkill(result, bossStats, bossService, skillsService, skill, bossSkill);
                        break;
                    case 3:
                        bossService.RunAway(result, spacingLine );
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}

