using Roguelike.App.Commnon;
using Roguelike.Domain.Entity;
using System;

namespace Roguelike
{
    public class ChosenClassService : BaseService<ChosenClass>
    {
        public ChosenClassService()
        {
            Initialize();
        }

        public void ChoosingClass(MenuActionService actionService)
        {
            var choosingClass = actionService.GetMenuActionsByMenuName("Choosing Class");
            Console.WriteLine("Choose your class: ");
            for (int i = 0; i < choosingClass.Count; i++)
            {
                Console.WriteLine($"{choosingClass[i].Id}. {choosingClass[i].Name}");
            }
        }
        private void Initialize()
        {
            CreateItem(new ChosenClass(1, "Warrior", 50, 35, 1));
            CreateItem(new ChosenClass(2, "Mage", 40, 45, 1));
            CreateItem(new ChosenClass(3, "Rogue", 30, 55, 1));
        }
    }           
}

