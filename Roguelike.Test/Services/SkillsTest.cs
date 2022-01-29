using FluentAssertions;
using Roguelike.Domain.Entity;
using System;
using Xunit;

namespace Roguelike.Test.Services
{
    public class SkillsTest
    { 
        [Fact]
        public void SkillsAction()
        {
            //Arrange
            Skills skill = new Skills(1, 0, 2, "Blessing", 0, default, default);
            SkillsService skillsService = new SkillsService();
            ChosenClass result = new ChosenClass();
            EnemyGenerator enemy = new EnemyGenerator();
            //Act
            skillsService.SkillsAction(skill, result, enemy);
            //Assert  
            skill.IsActive.Should().Be(true);
        }

        [Fact]
        public void BossSkillsAction()
        {
            //Arrange
            Skills bossSkills = new Skills(10, 60, default, "Unholy Strikes", 0, default, default);
            ChosenClass result = new ChosenClass(1, "Warrior", 50, 35, 1);
            SkillsService skillsService = new SkillsService();
            //Act
            skillsService.BossSkillsAction(bossSkills, result);
            //Assert  
            result.Hp.Should().Be(-10);
        }
        [Fact]
        public void SkillEffectEnd()
        {
            //Arrange
            Skills skill = new Skills(1, 0, 0, "Blessing", 0, default, true);
            SkillsService skillsService = new SkillsService();
            //Act
            skillsService.SkillEffectEnd(skill);
            //Assert
            skill.IsActive.Should().Be(false);
            skill.Duration.Should().Be(2);

        }
        [Fact]
        public void BlessingEffect()
        {
            //Arrange
            Skills skill = new Skills(1, 0, 2, "Blessing", 0, default, default);
            SkillsService skillsService = new SkillsService();
            EnemyGenerator enemy = new EnemyGenerator();
            //Act
            skillsService.SkillEffectEnd(skill);
            //Assert
            enemy.Damage.Should().Be(0);
        }
    }
}
