using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogulike
{
    public class BattleService
    {
        public ChosenClass InitializeBattle(ChosenClass result, MenuActionService actionService, EnemyGenerator enemy, SkillsService skillsService, Skills skill)
        {
            int damageTaken;

            while (enemy.Hp > 0 && result.Hp > 0)
            {
                var battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                for (int i = 0; i < battleMenu.Count; i++)
                {
                    Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                }

                Helpers spacingLine = new Helpers();
                spacingLine.SpacingLine();

                var operation1 = Console.ReadKey();
                Console.WriteLine();
                int.TryParse(operation1.KeyChar.ToString(), out int val);
                switch (val)
                {
                    case 1:
                        enemy.Hp -= result.Damage;
                        if (enemy.Hp <= 0)
                        {
                            Console.WriteLine("Enemy has been defeated");
                            Console.WriteLine("You have earned " + enemy.Exp + "exp");
                            break;
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
                        break;
                    case 2:
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
                            break;
                        }
                        else 
                        {
                            for (int i = skill.TurnsRequired; i >=0; i--)
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
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage -> you have " + result.Hp + " hp left \n");
                                    spacingLine.SpacingLine();
                                }

                            }
                            skill.TurnsRequired = default;
                        }
                        break;
                    case 3:
                        Console.WriteLine("You've decided to run away");
                        spacingLine.SpacingLine();
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
        public ChosenClass InitializeBattle(ChosenClass result, MenuActionService actionService, Boss bossStats, BossService newBoss, SkillsService skillsService, Skills skill, Skills bossSkill)
        {
            while (bossStats.Hp > 0 && result.Hp > 0)
            {
                var battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                for (int i = 0; i < battleMenu.Count; i++)
                {
                    Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                }

                Helpers spacingLine = new Helpers();
                spacingLine.SpacingLine();

                var operation1 = Console.ReadKey();
                Console.WriteLine();
                int.TryParse(operation1.KeyChar.ToString(), out int val);
                switch (val)
                {
                    case 1:
                        bossStats.Hp -= result.Damage;
                        if (bossStats.Hp <= 0)
                        {
                            Console.WriteLine("Boss has been defeated");
                            Console.WriteLine("You have earned " + bossStats.Exp + "exp");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Boss has " + bossStats.Hp + " hp  \n");

                            newBoss.BossBehaviour(skillsService, bossSkill, result, bossStats);

                        }
                        break;
                    case 2:
                        if (skill.IsLocked == true)
                        {
                            Console.WriteLine("You need to unlock your skills first !");

                            newBoss.BossBehaviour(skillsService, bossSkill, result, bossStats);

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

                                newBoss.BossBehaviour(skillsService, bossSkill, result, bossStats);

                            }
                            skill.TurnsRequired = default;
                        }
                        break;
                    case 3:
                        Console.WriteLine("You've decided to run away");
                        spacingLine.SpacingLine();
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
