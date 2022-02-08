using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Roguelike;
using Roguelike.Domain.Entity;
using System.Linq;
using Roguelike.App.Managers;
using Roguelike.App.Concrete;

namespace Rogulike
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            Helpers helpers= new Helpers();
            ChosenClass result = new ChosenClass();
            ChosenClassService chosenClassService = new ChosenClassService();
            ChosenClassManager chosenClassManager = new ChosenClassManager();
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
            ScoreService scoreService = new ScoreService();

           

            while (true)
            {
                int floor = 1;
                int bossKillCount = 0;
                int enemyKillCount = 0;
                Console.WriteLine("Welcome to my Roguelike RPG");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main Menu");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                helpers.SpacingLine();

                var operation = Console.ReadKey();
                Console.Clear();

               switch (operation.KeyChar)
                {
                    case '1':
                        var val =  chosenClassManager.ChoosingClass(actionService);
                        result = chosenClassService.GetYourClass(val, chosenClassService);

                        if (chosenClassManager.Confirmation(result) == true)
                        {

                        }
                        else
                        {
                            break;
                        }
                        
                        skill = skillsService.GetAllItems().Where(x => x.Id == result.Id).FirstOrDefault();

                        var map = helpers.CreateMap();
                        helpers.DrawPlayer(result, map);
                        helpers.DrawEnemyOnMap(map);

                        while (result.Hp > 0)
                        {
                            Console.WriteLine("You are on the floor: " + floor);
                            
                            helpers.GetMap(result, map);
                            chosenClassService.PlayerMovement(result, map, helpers);
                            if (helpers.Encounter(result,map) == true)
                            {
                                if (floor != 10 && floor != 20 && floor != 30)
                                {
                                    enemyStats = enemyGeneratorService.NewEnemy();
                                    skillsService.SkillEffectChecker(skill, skillsService, enemyStats);

                                    var battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                                    for (int i = 0; i < battleMenu.Count; i++)
                                    {
                                        Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                                    }

                                    helpers.SpacingLine();
                                    enemyGeneratorManager.EnemyBattle(result, enemyStats, enemyGeneratorService, helpers, skill, skillsService);

                                    if (result.Hp > 0)
                                    {
                                        experienceService.CalculateExperience(enemyStats, experience);
                                        experienceManager.CurrentExp(experience, result);
                                        experienceService.LevelUp(result, experience, experienceManager, skill, experienceService);
                                    }

                                    if (skill.Duration < 1 && skill.IsActive == true)
                                    {
                                        skillsService.SkillEffectEnd(skill);
                                    }
                                    Console.Clear();
                                    enemyKillCount++;
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

                                    helpers.SpacingLine();
                                    bossManager.BossBattle(result, bossStats, helpers, skill, skillsService, bossService, bossSkill);

                                    if (result.Hp > 0)
                                    {
                                        experienceService.CalculateExperience(bossStats, experience);
                                        experienceManager.CurrentExp(experience, result);
                                        experienceService.LevelUp(result, experience, experienceManager, skill, experienceService);
                                    }

                                    if (skill.Duration < 1 && skill.IsActive == true)
                                    {
                                        skillsService.SkillEffectEnd(skill);
                                    }
                                    Console.Clear();
                                    bossKillCount++;
                                }   
                            }
                            if (helpers.Exit(result, map) == true && (bossKillCount == 1 || enemyKillCount == 3))
                            {
                                floor++;
                                bossKillCount = 0;
                                enemyKillCount = 0;
                                helpers.ProceedToNextFloor(map, floor, helpers,result);
                            } 
                            
                            else if (helpers.Exit(result, map) == true)
                            {
                                helpers.DrawPlayer(result, map);
                                map[7, 5] = 'E';
                            }
                        }
                        scoreManager.ScoreMenu(floor);
                        scoreService.CreateOrOverwriteScoreList(floor);
                        
                        break;
                    case '2':
                        scoreService.ReadScoreList();
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
