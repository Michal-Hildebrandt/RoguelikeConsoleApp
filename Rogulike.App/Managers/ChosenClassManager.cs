using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roguelike.App.Managers
{
    public class ChosenClassManager
    {
        public int ChoosingClass(MenuActionService actionService)
        {
            var choosingClass = actionService.GetMenuActionsByMenuName("Choosing Class");
            Console.WriteLine("Choose your class: ");
            for (int i = 0; i < choosingClass.Count; i++)
            {
                Console.WriteLine($"{choosingClass[i].Id}. {choosingClass[i].Name}");
            }

            var operation1 = Console.ReadKey();
            int val;
            int.TryParse(operation1.KeyChar.ToString(), out val);
            Console.WriteLine();

            return val;

        }
        public bool Confirmation(ChosenClass result )
        {
            bool confirm;
            Console.WriteLine("Do you want to start as " + result.Name.ToString() + " ? (y/n) \n ");

            var confirmation = Console.ReadKey().KeyChar;
            if (confirmation == 'y')
            {
                confirm = true;
            }
            else
            {
                confirm = false;
            }
            Console.WriteLine();
            Console.Clear();

            return confirm;
        }
    }
}
