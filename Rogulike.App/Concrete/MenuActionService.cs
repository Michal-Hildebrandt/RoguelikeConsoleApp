using Roguelike.App.Commnon;
using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName (string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            CreateItem(new MenuAction(1, "New Game", "Main Menu"));
            CreateItem(new MenuAction(2, "High score", "Main Menu"));
            CreateItem(new MenuAction(3, "About/ To implement", "Main Menu"));

            CreateItem(new MenuAction(1, "Warrior - high hp, low damage, can buff himself", "Choosing Class"));
            CreateItem(new MenuAction(2, "Mage -  moderate damage, moderate hp, can cast fireball", "Choosing Class"));
            CreateItem(new MenuAction(3, "Rogue - high damage, low hp, after long preparation can deal massive damage", "Choosing Class"));

            CreateItem(new MenuAction(1, "Attack", "Battle"));
            CreateItem(new MenuAction(2, "Skills", "Battle"));
            CreateItem(new MenuAction(3, "Run away \n", "Battle"));

        }
    }
}
