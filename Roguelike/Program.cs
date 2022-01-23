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
            MenuActionService actionService = new MenuActionService();
            Helpers spacingLine = new Helpers();
            ChosenClassService chosenClassService = new ChosenClassService();
            ChosenClassManager confirmation = new ChosenClassManager();
            Experience experience = new Experience();
            ExperienceService experienceService = new ExperienceService();
            ExperienceManager experienceManager = new ExperienceManager();
            SkillsService skillsService = new SkillsService();
            EnemyGeneratorService enemyGeneratorService = new EnemyGeneratorService();
            EnemyGenerator enemyStats = new EnemyGenerator();
            EnemyGeneratorManager enemyGeneratorManager = new EnemyGeneratorManager();
            Boss bossStats = new Boss();
            BossService bossService = new BossService();
            BossManager bossManager = new BossManager();
            Skills skill = new Skills();
            Skills bossSkill = new Skills();
            ScoreManager scoreManager = new ScoreManager();

            int floor = 1;

            while (true)
            {
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
                        chosenClassService.ChoosingClass(actionService);

                        var operation1 = Console.ReadKey();
                        int val;
                        int.TryParse(operation1.KeyChar.ToString(), out val);
                        Console.WriteLine();

                        ChosenClass result = chosenClassService.GetAllItems().Where(x => x.Id == val).FirstOrDefault();

                        if (confirmation.Confirmation(result) == true)
                        {

                        }
                        else
                        {
                            break;
                        }
                        
                        skill = skillsService.GetAllItems().Where(x => x.Id == result.Id).FirstOrDefault();

                        while (result.Hp > 0)
                        {
                            Console.WriteLine("You are on the floor: " + floor);
                            if (floor != 10 && floor != 20 && floor != 30)
                            {
                                enemyStats = enemyGeneratorService.NewEnemy();
                                skillsService.SkillEffectChecker(skill, skillsService, enemyStats);

                                var battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                                for (int i = 0; i < battleMenu.Count; i++)
                                {
                                    Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                                }

                                spacingLine.SpacingLine();
                                enemyGeneratorManager.EnemyBattle(result, enemyStats, enemyGeneratorService, spacingLine, skill, skillsService);

                                if (result.Hp > 0)
                                {                              
                                    experienceService.CalculateExperience(enemyStats, experience);
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
                                bossStats = bossService.NewBoss(bossService, floor);
                                bossSkill = skillsService.GetAllItems().Where(x => x.Id == bossStats.Id).FirstOrDefault();

                                var battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                                for (int i = 0; i < battleMenu.Count; i++)
                                {
                                    Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                                }

                                spacingLine.SpacingLine();
                                bossManager.BossBattle(result, bossStats, spacingLine, skill, skillsService, bossService, bossSkill);

                                if (result.Hp > 0)
                                {
                                    experienceService.CalculateExperience(bossStats, experience);
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
                        scoreManager.Highscore(floor);
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
