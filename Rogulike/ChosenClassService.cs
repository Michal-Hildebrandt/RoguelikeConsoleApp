using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogulike
{
    public class ChosenClassService
    {

        public List<ChosenClass> Classes = new List<ChosenClass>()
        {
            new ChosenClass() {PlayerChoice = 1, ClassType = "Warrior", Hp = 50, Def = 50, Damage = 15},
            new ChosenClass() {PlayerChoice = 2, ClassType = "Mage", Hp = 35, Def = 35, Damage = 30},
            new ChosenClass() {PlayerChoice = 3, ClassType = "Rogue", Hp = 20, Def = 20, Damage = 45}
        };

        public void ChoosingClass(MenuActionService actionService)
        {
            var choosingClass = actionService.GetMenuActionsByMenuName("Choosing Class");
            Console.WriteLine("Choose your class: ");
            for (int i = 0; i < choosingClass.Count; i++)
            {
                Console.WriteLine($"{choosingClass[i].Id}. {choosingClass[i].Name}");
            }
        }
       
        public List<ChosenClass> YourClass(int val)
        { 
            List<ChosenClass> result = new List<ChosenClass>();

            foreach (var ChosenClass in Classes)
            {
              if (val == ChosenClass.PlayerChoice)
               {
                    result.Add(ChosenClass);
               }
            }
             return result;
        }
    }           
}

