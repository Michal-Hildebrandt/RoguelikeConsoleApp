
using FluentAssertions;
using Roguelike.Domain.Entity;
using Xunit;

namespace Roguelike.Test
{
    public class BossServiceTest
    {
        [Fact]
        public void NewBoss()
        {
            //Arrange
            int floor = 10;
            BossService bossService = new BossService();

            //Act
            Boss newBoss = bossService.NewBoss(bossService, floor);
            //Assert
            newBoss.Id.Should().Be(10);

        }
        [Fact]
        public void AttackBoss()
        {
            //Arrange
            Boss bossStats = new Boss(10, 75, 25, 50, "Generic First Boss Name");
            ChosenClass result = new ChosenClass(1,"Warrior",50,30,1);
            BossService bossService = new BossService();
            SkillsService skillsService = new SkillsService();
            Skills bossSkill = new Skills();
            //Act 
            bossService.AttackBoss(result, bossStats, bossService, skillsService, bossSkill);
            //Assert
            bossStats.Hp.Should().Be(45);

        }
        [Fact]
        public void UseSkill()
        {
            //Arrange
            ChosenClass result = new ChosenClass();
            Boss bossStats = new Boss();
            BossService bossService = new BossService();
            SkillsService skillsService = new SkillsService();
            Skills skillActive = new Skills(1, 0, 2, "Blessing", 2, false, true);
            Skills bossSkill = new Skills();
            //Act 
            bossService.UseSkill(result, bossStats, bossService, skillsService, skillActive, bossSkill);
            //Assert
            skillActive.TurnsRequired.Should().Be(2);
        }
    }
}
