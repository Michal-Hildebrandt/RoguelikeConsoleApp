using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogulike
{
    public class Battle
    {
    
        public ChosenClass InitializeBattle(EnemyGenerator enemyStats, ChosenClass result, MenuActionService actionService, int enemyDefeated)
        {
            int playerHp = result.Hp;
            int enemyHp = enemyStats.Hp;
            
            while (enemyHp > 0 && playerHp > 0 )
            {
                var operation1 = Console.ReadKey();
                Console.WriteLine();
                int val;
                int.TryParse(operation1.KeyChar.ToString(), out val);
                switch (val)
                {
                    case 1:
                          enemyHp = enemyHp - result.Damage;
                            if (enemyHp <= 0)
                            {
                                Console.WriteLine("Enemy has been defeated");
                            break;
                            }
                            else
                            {
                                Console.WriteLine("Enemy has " + enemyHp + " hp  \n");
                            
                            }
                            playerHp = playerHp - enemyStats.Damage;
                            if (playerHp <= 0)
                            {
                                Console.WriteLine("You've been attacked and took " + enemyStats.Damage + " damage and you've died\n");
                                Console.WriteLine("You've defeated " + enemyDefeated + " enemies \n");
                            }
                            else
                            {
                                Console.WriteLine("You've been attacked and took " + enemyStats.Damage + " damage -> you have " + playerHp + " hp left \n");
                            var battleMenu = actionService.GetMenuActionsByMenuName("Battle");
                            for (int i = 0; i < battleMenu.Count; i++)
                            {
                                Console.WriteLine($"{battleMenu[i].Id}. {battleMenu[i].Name}");
                            }
                        }
                        result.Hp = playerHp;
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
