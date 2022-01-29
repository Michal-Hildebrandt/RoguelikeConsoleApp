using FluentAssertions;
using Roguelike.Domain.Entity;
using Rogulike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Roguelike.Test.Services
{
    public class EnemyGeneratorTest
    {
        [Fact]
        public void NewEnemy()
        {
            //Arrange
            EnemyGenerator enemy = new EnemyGenerator();
            EnemyGeneratorService enemyGeneratorService = new EnemyGeneratorService();
            //Act
            enemy = enemyGeneratorService.NewEnemy();
            //Assert
            enemy.Strength.Should().NotBeNull();
            enemy.Type.Should().NotBeNull();

        }
        [Fact]
        public void AttackBoss()
        {
            //Arrange
            EnemyGenerator enemy = new EnemyGenerator(1,1,31,1,1,"example","example");
            ChosenClass result = new ChosenClass(1, "Warrior", 50, 30, 1);
            Helpers spacingLine = new Helpers();
            EnemyGeneratorService enemyGeneratorService = new EnemyGeneratorService();
            //Act 
            enemyGeneratorService.Attack(result, enemy, spacingLine);
            //Assert
            enemy.Hp.Should().Be(1);

        }
        [Fact]
        public void UseSkill()
        {
            //Arrange
            EnemyGenerator enemy = new EnemyGenerator(1, 1, 31, 1, 1, "example", "example");
            EnemyGeneratorService enemyGeneratorService = new EnemyGeneratorService();
            Helpers spacingLine = new Helpers();
            ChosenClass result = new ChosenClass();
            SkillsService skillsService = new SkillsService();
            Skills skillActive = new Skills(1, 0, 2, "Blessing", 2, false, true);
            //Act 
            enemyGeneratorService.UseSkill( result, enemy, skillsService, skillActive, spacingLine);
            //Assert
            skillActive.TurnsRequired.Should().Be(2);
        }
    }
}
