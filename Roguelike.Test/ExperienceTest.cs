using FluentAssertions;
using Moq;
using Roguelike.App.Managers;
using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Roguelike.Test.Services
{
    public class ExperienceTest
    {
        [Fact]
        public void CalculateExperience()
        {
            //Arrange
            EnemyGenerator enemy = new EnemyGenerator(1,1,1,1,150,"example", "example");
            Experience experience = new Experience();
            ExperienceService experienceService = new ExperienceService();
            //Act
            experienceService.CalculateExperience(enemy, experience);
            //Assert
            experience.TotalExp.Should().Be(150);

        }

        [Fact]
        public void LevelUp()
        {
            //Arrange
            ChosenClass result = new ChosenClass(1, "example", 10, 10, 1);

            Experience experience = new Experience(default,150,0);
            ExperienceManager experienceManager = new ExperienceManager();
            Skills skill = new Skills();
            ExperienceService experienceService = new ExperienceService();
            //Act
            experienceService.LevelUp(result, experience, experienceManager, skill, experienceService);
            //Assert
            result.Level.Should().Be(2);
        }

        [Fact]
        public void IncreaseHp()
        {
            //Arrange
            ExperienceService experienceService = new ExperienceService();
            ChosenClass result = new ChosenClass(1,"example",10,10,1);
            Experience experience = new Experience(default,default, 10);
            //Act
            experienceService.IncreaseHp(result, experience);
            //Assert
            result.Hp.Should().Be(20);
            experience.UpgradePoints.Should().Be(9);
        }
    }
}
