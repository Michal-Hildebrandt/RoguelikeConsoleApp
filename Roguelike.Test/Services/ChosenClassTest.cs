using FluentAssertions;
using Moq;
using Roguelike.Domain.Entity;
using Xunit;

namespace Roguelike.Test.Services
{
    public class ChosenClassTest
    {
        [Fact]
        public void GetYourClass()
        {
            //Arrange
            int val = 1;
            ChosenClassService chosenClassService = new ChosenClassService();

            //Act
            ChosenClass comparedClass = chosenClassService.GetYourClass(val, chosenClassService);
            //Assert
            comparedClass.Id.Should().Be(1);

        }
    }
}
