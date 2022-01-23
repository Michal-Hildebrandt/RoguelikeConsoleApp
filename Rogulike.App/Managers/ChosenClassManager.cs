using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.App.Managers
{
    public class ChosenClassManager
    {
        public bool  Confirmation(ChosenClass result )
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
