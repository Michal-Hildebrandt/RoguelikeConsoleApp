using Roguelike.App.Commnon;
using Roguelike.Domain.Entity;
using System;
using System.Linq;

namespace Roguelike
{
    public class ChosenClassService : BaseService<ChosenClass>
    {
        public ChosenClassService()
        {
            Initialize();
        }

        public ChosenClass GetYourClass(int val,ChosenClassService chosenClassService)
        {
            ChosenClass result = chosenClassService.GetAllItems().Where(x => x.Id == val).FirstOrDefault();
            return result;
        }

        private void Initialize()
        {
            CreateItem(new ChosenClass(1, "Warrior", 50, 35, 1,5,5,'W'));
            CreateItem(new ChosenClass(2, "Mage", 40, 45, 1, 5, 5,'M'));
            CreateItem(new ChosenClass(3, "Rogue", 30, 55, 1, 5, 5,'R'));
        }

        public char[,] PlayerMovement(ChosenClass result, char [,] map, Helpers helpers)
        {
            ConsoleKeyInfo e = Console.ReadKey();
            switch (e.Key)
            {
                case(ConsoleKey.UpArrow):
                    map[result.PositionY, result.PositionX] = ' ';
                    result.PositionY -= 1;
                    if (map[result.PositionY, result.PositionX] == 'O' || map[result.PositionY, result.PositionX] == 'E')
                    {

                    }
                    else if (map[result.PositionY, result.PositionX] == 'x')
                    {
                        result.PositionY += 1;
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }
                    else
                    {
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }
                    break;
                case(ConsoleKey.DownArrow):
                    map[result.PositionY, result.PositionX] = ' ';
                    result.PositionY += 1;
                    if (map[result.PositionY, result.PositionX] == 'O' || map[result.PositionY, result.PositionX] == 'E')
                    {

                    }
                    else if (map[result.PositionY, result.PositionX] == 'x')
                    {
                        result.PositionY -= 1;
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }
                    else
                    {
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }

                    break;
                case (ConsoleKey.LeftArrow):
                    map[result.PositionY, result.PositionX] = ' ';
                    result.PositionX -= 1;
                    if (map[result.PositionY, result.PositionX] == 'O' || map[result.PositionY, result.PositionX] == 'E')
                    {

                    }
                    else if (map[result.PositionY, result.PositionX] == 'x')
                    {
                        result.PositionX += 1;
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }
                    else
                    {
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }

                    break;

                case (ConsoleKey.RightArrow):
                    map[result.PositionY, result.PositionX] = ' ';
                    result.PositionX += 1;
                    if (map[result.PositionY, result.PositionX] == 'O' || map[result.PositionY, result.PositionX] == 'E')
                    {
                        
                    }
                    else if (map[result.PositionY, result.PositionX] == 'x')
                    {
                        result.PositionX -= 1;
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }
                    else
                    {
                        map[result.PositionY, result.PositionX] = result.Symbol;
                    }
                    break;
                default:
                    break;
            }
            Console.Clear();
            return map;
        }

    }           
}

