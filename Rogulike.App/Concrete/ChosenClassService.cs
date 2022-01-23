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
            CreateItem(new ChosenClass(1, "Warrior", 50, 35, 1));
            CreateItem(new ChosenClass(2, "Mage", 40, 45, 1));
            CreateItem(new ChosenClass(3, "Rogue", 30, 55, 1));
        }
    }           
}

