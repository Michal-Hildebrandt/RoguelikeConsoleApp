using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                Console.WriteLine("Welcome to my Roguelike RPG");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main Menu");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();
                Console.WriteLine();

                switch (operation.KeyChar)
                {
                    case '1':
                        ChosenClassService chosenClass = new ChosenClassService();
                        chosenClass.ChoosingClass(actionService);

                        var operation1 = Console.ReadKey();
                        int val;
                        int.TryParse(operation1.KeyChar.ToString(), out val);
                        Console.WriteLine();

                        ChosenClass yourClass = chosenClass.YourClass(val)[0];

                        Console.WriteLine("Do you want to start as " + yourClass.ClassType.ToString() + " ? (y/n) \n ");
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

                        int enemyDefeated = 0;

                        while (yourClass.Hp > 0)
                        {
                            EnemyGeneratorService newEnemy = new EnemyGeneratorService();
                            EnemyGenerator enemyHp = newEnemy.NewEnemy()[0];
                            Console.WriteLine(" - It has " + enemyHp.Hp.ToString() + " hp \n");

                            var battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                            for (int i = 0; i < battleMenu.Count; i++)
                            {
                                Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                            }

                            Battle battle = new Battle();
                            var playerHp = battle.InitializeBattle(enemyHp, yourClass, actionService, enemyDefeated);
                            enemyDefeated = enemyDefeated + 1;
                        }
                        Console.WriteLine("Type your nickname: ");
                        var playerNickname = Console.ReadLine();
                        ScoreService score = new ScoreService();

                        score.GetScore(enemyDefeated, playerNickname);
                        
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
                        // to implement
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
            actionService.AddNewAction(3, "About", "Main Menu");

            actionService.AddNewAction(1, "Warrior - high defence and hp, but low damage", "Choosing Class");
            actionService.AddNewAction(2, "Mage -  high damage, moderate hp and low defence", "Choosing Class");
            actionService.AddNewAction(3, "Rogue - the highest damage, low hp and defence", "Choosing Class");

            actionService.AddNewAction(1, "Attack", "Battle");
            actionService.AddNewAction(2, "Run away \n", "Battle");
            return actionService;
        }
    }
}
