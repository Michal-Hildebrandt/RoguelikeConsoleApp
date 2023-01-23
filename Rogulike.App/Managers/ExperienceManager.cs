using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.App.Managers
{
    public class ExperienceManager
    {
        public readonly MenuActionService menuActionService;

        public void GetLeveulUpMenu(ChosenClass result, Experience experience, Skills skill, ExperienceService experienceService)
        {
            Console.WriteLine("You have advanced to " + result.Level + " level\n");
            Console.WriteLine("You have " + experience.UpgradePoints + " upgrade points to spend\n");
            Console.WriteLine("Choose which stat you want to upgrade or skip this time to accumulate points ");
            Console.WriteLine("Press 1 (spend points), 2 (unlock skill - costs 3 upgrade points), 3 (go further without any upgrade and keep points)\n");

            var operation = Console.ReadKey();
            Console.WriteLine();
            int.TryParse(operation.KeyChar.ToString(), out int val);

            switch (val)
            {
                case 1:

                    Console.WriteLine(" Currently you have " + result.Hp + " upgrade health (+10 HP - press 1)");
                    Console.WriteLine(" Currently you have " + result.Damage + " upgrade damage (+5 Dmg - press 2)");

                    var operation1 = Console.ReadKey();
                    Console.WriteLine();
                    int val1;
                    int.TryParse(operation1.KeyChar.ToString(), out val1);

                    switch (val1)
                    {
                        case 1:
                            experienceService.IncreaseHp(result, experience);
                            break;
                        case 2:
                            experienceService.IncreaseDmg(result, experience);
                            break;
                    }
                    break;
                case 2:

                    if (experience.UpgradePoints >= 3)
                    {
                        Console.WriteLine("You've unlocked skill: " + skill.Name);
                        skill.IsLocked = false;
                        experience.UpgradePoints -= 3;
                    }
                    else
                    {
                        Console.WriteLine("You don't have that much points to unlock skill !");
                    }
                    break;
               }     
            }
         public void CurrentExp(Experience experience, ChosenClass result)
        {
            Console.WriteLine("You have " + experience.TotalExp + " / " + experience.ExpRequired[result.Level + 1] + " exp\n");
        }

        public void MaxLvlWarning(Experience experience)
        {
            Console.WriteLine("You've reached max level ! You have " + experience.TotalExp);
        }
    }
}
