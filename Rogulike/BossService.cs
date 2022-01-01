using System;
using System.Collections.Generic;
using System.Text;

namespace Rogulike
{
    public class BossService
    {
        private List<Boss> bossDifficulty = new List<Boss>()
        {
            new Boss() { Apperance = 10, Hp = 75, Damage = 25, Exp = 50, Name = "Generic First Boss Name" },
            new Boss() { Apperance = 20, Hp = 95, Damage = 40, Exp = 70,Name = "Generic Second Boss Name" },
            new Boss() { Apperance = 30, Hp = 115, Damage = 55, Exp = 90, Name = "Generic Third Boss Name" }
        };
        public List<Boss> ChoosingBoss(int floor)
        {
            List<Boss> bossStats = new List<Boss>();
            foreach (var Boss in bossDifficulty)
            {
                if (floor == Boss.Apperance)
                {
                    bossStats.Add(Boss);
                    break;
                }
            }
            return bossStats;
        }
        public void BossBehaviour(SkillsService skillsService, Skills bossSkill, ChosenClass result, Boss bossStats)
        {
            int damageTaken;
            Random random = new Random();
            Helpers spacingLine = new Helpers();

            int randomNumber = random.Next(0, 9);
            if (randomNumber > 5 && bossSkill.TurnsRequired != default)
            {
                result.Hp -= bossStats.Damage;
                damageTaken = bossStats.Damage;

                if (result.Hp <= 0)
                {
                    Console.WriteLine("You've been attacked and took " + damageTaken + " damage and you've died\n");
                    spacingLine.SpacingLine();
                }
                else
                {
                    Console.WriteLine("You've been attacked and took " + damageTaken + " damage -> you have " + result.Hp + " hp left \n");
                    spacingLine.SpacingLine();
                }
            }
            else
            {
                skillsService.BossSkillsAction(bossSkill, result);
                damageTaken = bossSkill.Damage;
                if (bossSkill.TurnsRequired == 0) {
                    result.Hp -= bossSkill.Damage;

                    if (result.Hp <= 0)
                    {
                        Console.WriteLine("You've been attacked and took " + damageTaken + " damage and you've died\n");
                        spacingLine.SpacingLine();
                    }
                    else
                    {
                        Console.WriteLine("You've been attacked and took " + damageTaken + " damage -> you have " + result.Hp + " hp left \n");
                        spacingLine.SpacingLine();
                    }

                }
                else
                {
                    bossSkill.TurnsRequired -= 1;
                }
             }
        }
    }
}
