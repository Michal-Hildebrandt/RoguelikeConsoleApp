using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Roguelike.Test.Services
{
    public class MenuActionTest
    {
        [Fact]
        public void MenuActionShouldNotBeEmpty()
        {
            MenuActionService actionService = new MenuActionService();

            var battleMenu = actionService.GetMenuActionsByMenuName("Battle");

            battleMenu.Should().NotBeEmpty();

        }
    }
}
