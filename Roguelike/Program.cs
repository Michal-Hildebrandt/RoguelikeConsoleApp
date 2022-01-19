using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Roguelike;
using Roguelike.Domain.Entity;
using System.Linq;
using Roguelike.App.Managers;

namespace Rogulike
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MenuActionService actionService = new MenuActionService();

                Helpers spacingLine = new Helpers();

                Console.WriteLine("Welcome to my Roguelike RPG");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main Menu");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                spacingLine.SpacingLine();

                var operation = Console.ReadKey();
                Console.Clear();

                switch (operation.KeyChar)
                {
                    case '1':
                        ChosenClassService chosenClassService = new ChosenClassService();
                        chosenClassService.ChoosingClass(actionService);

                        var operation1 = Console.ReadKey();
                        int val;
                        int.TryParse(operation1.KeyChar.ToString(), out val);
                        Console.WriteLine();

                        ChosenClass result = chosenClassService.GetAllItems().Where(x => x.Id == val).FirstOrDefault();

                        Console.WriteLine("Do you want to start as " + result.Name.ToString() + " ? (y/n) \n ");

                        var confirmation = Console.ReadKey().KeyChar;
                        if (confirmation == 'y')
                        {

                        }
                        else
                        {
                            break;
                        }
                        Console.WriteLine();
                        Console.Clear();

                        int floor = 1;

                        Experience experience = new Experience();
                        ExperienceService experienceService = new ExperienceService();
                        ExperienceManager experienceManager = new ExperienceManager();

                        SkillsService skillsService = new SkillsService();
                        Skills skill = skillsService.GetAllItems().Where(x => x.Id == result.Id).FirstOrDefault();

                        var battleMenu = actionService.GetMenuActionsByMenuName("Battle");

                        while (result.Hp > 0)
                        {
                            Console.WriteLine("You are on the floor: " + floor);
                            if (floor != 10 && floor != 20 && floor != 30)
                            {
                                EnemyGeneratorService newEnemy = new EnemyGeneratorService();
                                EnemyGenerator enemy = newEnemy.NewEnemy();
                                skillsService.SkillEffectChecker(skill, skillsService, enemy);
                                BattleManager EnemyBattleManager = new BattleManager(actionService, skillsService, spacingLine);

                                while (enemy.Hp > 0 && result.Hp > 0)
                                {
                                    for (int i = 0; i < battleMenu.Count; i++)
                                    {
                                        Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                                    }

                                    spacingLine.SpacingLine();

                                    var operation2 = Console.ReadKey();
                                    Console.WriteLine();
                                    int.TryParse(operation2.KeyChar.ToString(), out int val1);
                                    switch (val1)
                                    {
                                        case 1:
                                            EnemyBattleManager.Attack(result, enemy, spacingLine);
                                            break;
                                        case 2:
                                            EnemyBattleManager.UseSkill(result, enemy, skillsService, skill, spacingLine);
                                            break;
                                        case 3:
                                            EnemyBattleManager.RunAway(result);
                                            break;
                                        default:
                                            break;
                                    }

                                }

                                if (result.Hp > 0)
                                {                              
                                    experienceService.CalculateExperience(enemy, experience, result);
                                    experienceManager.CurrentExp(experience, result);
                                    experienceService.LevelUp(result, experience, experienceManager, skill, experienceService);
                                    floor++;
                                }

                                if (skill.Duration < 1 && skill.IsActive == true)
                                {
                                    skillsService.SkillEffectEnd(skill);
                                }
                            }
                            else
                            {
                                BossService bossService = new BossService();
                                Boss bossStats = bossService.NewBoss(bossService, floor);
                                Skills bossSkill = skillsService.GetAllItems().Where(x => x.Id == bossStats.Id).FirstOrDefault();
                                BattleManager BossBattleManager = new BattleManager(actionService, bossService, skillsService, spacingLine);

                                while (bossStats.Hp > 0 && result.Hp >0)
                                {
                                    battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                                    for (int i = 0; i < battleMenu.Count; i++)
                                    {
                                        Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                                    }

                                    spacingLine.SpacingLine();

                                    var operation3 = Console.ReadKey();
                                    Console.WriteLine();
                                    int.TryParse(operation3.KeyChar.ToString(), out int val2);

                                    switch (val2)
                                    {
                                        case 1:
                                            BossBattleManager.AttackBoss(result, bossStats, bossService, skillsService, bossSkill);
                                            break;
                                        case 2:
                                            BossBattleManager.UseSkill(result, bossStats, skillsService, skill, bossSkill);
                                            break;
                                        case 3:
                                            BossBattleManager.RunAway(result);
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                if (result.Hp > 0)
                                {
                                    experienceService.CalculateExperience(bossStats, experience, result);
                                    experienceManager.CurrentExp(experience, result);
                                    experienceService.LevelUp(result, experience, experienceManager, skill, experienceService);
                                    floor++;
                                }

                                if (skill.Duration < 1 && skill.IsActive == true)
                                {
                                    skillsService.SkillEffectEnd(skill);
                                }
                            }
                        }
                            Console.WriteLine("You've completed " + floor + " floor/-s \n");

                            Console.WriteLine("Type your nickname: ");
                            var playerNickname = Console.ReadLine();
                            Score score = new Score();
                            score.GetScore(floor, playerNickname);

                            break;
                    case '2':
                        using (StreamReader highscore = new StreamReader(@"D:\Highscore.txt"))
                        {
                            string line;
                            while ((line = highscore.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                        break;
                    case '3':
                        Console.WriteLine("It's simple project which helps me in learning C# basics.");
                        Console.WriteLine("Roguelike RPG is based on Random Number Generation (like most of roguelike games)\n" +
                        "You can choose one from three classes and try to defeat as many enemies as you can\n " +
                        "To implement or already implemented stuff:" +
                        "- Skills [X]\n " +
                        "- Defence [X]\n " +
                        "- Boss fight [X]\n " +
                        "- Getting experience and points from leveling up [X]\n "
                        );
                        break;
                    default:
                        Console.WriteLine("Press proper key");
                        break;
                }
            }
        }
    }
}
