using Roguelike.App.Commnon;
using Roguelike.Domain.Entity;
using System;
using System.Linq;

namespace Roguelike
{
    public class BossService:BaseService<Boss>
    {
        public BossService()
        {
            Initialize();
        }

        public Boss NewBoss(BossService bossService, int floor)
        {
            Boss bossStats = bossService.GetAllItems().Where(x => x.Id == floor).FirstOrDefault();
            Console.WriteLine("It's time for a boss fight ! It's " + bossStats.Name);
            return bossStats;
        }

        public void BossBehaviour(SkillsService skillsService, Skills bossSkill, ChosenClass result, Boss bossStats)
        {
            int damageTaken;
            Random random = new Random();
            int randomNumber = random.Next(0, 9);
            if (randomNumber > 5 && bossSkill.TurnsRequired != default)
            {
                result.Hp -= bossStats.Damage;
                damageTaken = bossStats.Damage;

                if (result.Hp <= 0)
                {
                    Console.WriteLine("You've been attacked and took " + damageTaken + " damage and you've died\n");
                }
                else
                {
                    Console.WriteLine("You've been attacked and took " + damageTaken + " damage -> you have " + result.Hp + " hp left \n");
                }
            }
            else
            {
                skillsService.BossSkillsAction(bossSkill, result);
                damageTaken = bossSkill.Damage;
                if (bossSkill.TurnsRequired == 0) 
                {
                    result.Hp -= bossSkill.Damage;

                    if (result.Hp <= 0)
                    {
                        Console.WriteLine("You've been attacked and took " + damageTaken + " damage and you've died\n");
                    }
                    else
                    {
                        Console.WriteLine("You've been attacked and took " + damageTaken + " damage -> you have " + result.Hp + " hp left \n");
                    }

                }
                else
                {
                    bossSkill.TurnsRequired -= 1;
                }
             }
        }
        public ChosenClass AttackBoss(ChosenClass result, Boss bossStats, BossService bossService, SkillsService skillsService, Skills bossSkill)
        {
            bossStats.Hp -= result.Damage;
            if (bossStats.Hp <= 0)
            {
                Console.WriteLine("Boss has been defeated");
                Console.WriteLine("You have earned " + bossStats.Exp + "exp");
            }
            else
            {
                Console.WriteLine("Boss has " + bossStats.Hp + " hp  \n");

                bossService.BossBehaviour(skillsService, bossSkill, result, bossStats);
            }

 
            return result;
        }
        public ChosenClass UseSkill(ChosenClass result, Boss bossStats, BossService bossService, SkillsService skillsService, Skills skill, Skills bossSkill)
        {
            if (skill.IsLocked == true)
            {
                Console.WriteLine("You need to unlock your skills first !");

                bossService.BossBehaviour(skillsService, bossSkill, result, bossStats);

            }
            else
            {
                for (int i = skill.TurnsRequired; i >= 0; i--)
                {
                    skillsService.SkillsAction(skill, result, bossStats);
                    skill.TurnsRequired -= 1;

                    if (skill.Name == "Blessing" && skill.IsActive == true)
                    {
                        skillsService.BlessingEffect(bossStats, skill);
                        skill.Duration -= 1;
                    }

                    bossService.BossBehaviour(skillsService, bossSkill, result, bossStats);

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
            CreateItem(new Boss(10, 75, 25, 50, "Generic First Boss Name"));
            CreateItem(new Boss(20, 95, 40, 70, "Generic Second Boss Name"));
            CreateItem(new Boss(30, 115,55, 90, "Generic Third Boss Name"));
        }
    }
}
