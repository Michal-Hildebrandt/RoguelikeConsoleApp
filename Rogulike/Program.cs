using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Rogulike
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            { 
                MenuActionService actionService = new MenuActionService();
                actionService = Initialize(actionService);

                Helpers spacingLine = new Helpers();
                
                Console.WriteLine("Welcome to my Roguelike RPG");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main Menu");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                spacingLine.SpacingLine();

                var operation = Console.ReadKey();
                Console.WriteLine();
                Console.Clear();

                switch (operation.KeyChar)
                {
                    case '1':
                        ChosenClassService chosenClass = new ChosenClassService();
                        chosenClass.ChoosingClass(actionService);

                        var operation1 = Console.ReadKey();
                        int val;
                        int.TryParse(operation1.KeyChar.ToString(), out val);
                        Console.WriteLine();

                        ChosenClass result = chosenClass.YourClass(val)[0];

                        Console.WriteLine("Do you want to start as " + result.ClassType.ToString() + " ? (y/n) \n ");
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

                        BattleService battle = new BattleService();
                        Experience experience = new Experience();
                        ExperienceService experienceCounter = new ExperienceService();
                        SkillsService skillsService = new SkillsService();

                        Skills skill = new Skills();
                        skill = skillsService.GettingPlayerSkill(result)[0];

                        while (result.Hp>0)
                        {
                            Console.WriteLine("You are on the floor: " + floor);
                            if (floor != 10 && floor != 20 && floor != 30)
                            {
                                EnemyGeneratorService newEnemy = new EnemyGeneratorService();
                                EnemyGenerator enemy = newEnemy.NewEnemy()[0];
                                Console.WriteLine("It has " + enemy.Hp.ToString() + " hp \n");

                                if (skill.Name == "Blessing" && skill.IsActive == true)
                                {
                                    skillsService.BlessingEffect(enemy, skill);
                                    skill.Duration -= 1;

                                }
                               
                                battle.InitializeBattle(result, actionService, enemy, skillsService, skill);

                                if (result.Hp > 0)
                                {
                                    experienceCounter.CalculateExperience(enemy, experience, result, skillsService, skill);
                                    floor++;
                                }

                                if (skill.Duration < 1 && skill.IsActive == true)
                                {
                                    skillsService.SkillEffectEnd(result, skill);
                                }
                            }
                            else
                            {
                                BossService newBoss = new BossService();
                                Boss bossStats = newBoss.ChoosingBoss(floor)[0];
                                Skills bossSkills = new Skills();
                                bossSkills = skillsService.GettingBossSkill(bossStats)[0];
                                Console.WriteLine("It's time for a boss fight ! It's " + bossStats.Name);

                                battle.InitializeBattle(result, actionService, bossStats, newBoss, skillsService, skill, bossSkills);

                                if (result.Hp > 0)
                                {
                                    experienceCounter.CalculateExperience(bossStats, experience, result, skillsService, skill);
                                    floor++;
                                }
                                
                                if (skill.Duration < 1 && skill.IsActive == true)
                                {
                                    skillsService.SkillEffectEnd(result, skill);
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

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "New Game", "Main Menu");
            actionService.AddNewAction(2, "High score", "Main Menu");
            actionService.AddNewAction(3, "About/ To implement", "Main Menu");

            actionService.AddNewAction(1, "Warrior - high hp, low damage, can buff himself", "Choosing Class");
            actionService.AddNewAction(2, "Mage -  moderate damage, moderate hp, can cast fireball", "Choosing Class");
            actionService.AddNewAction(3, "Rogue - high damage, low hp, after long preparation can deal massive damage", "Choosing Class");

            actionService.AddNewAction(1, "Attack", "Battle");
            actionService.AddNewAction(2, "Skills", "Battle");
            actionService.AddNewAction(3, "Run away \n", "Battle");

            return actionService;
        }
    }
}
