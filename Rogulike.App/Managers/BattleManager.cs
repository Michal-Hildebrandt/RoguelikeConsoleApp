using Roguelike.Domain.Entity;
using System;

namespace Roguelike.App.Managers
{
    public class BattleManager
    {
        private readonly MenuActionService _actionService;
        private readonly SkillsService _skillsService;
        private readonly BossService _bossService;
        private Helpers _spacingLine;

        public BattleManager(MenuActionService actionService, SkillsService skillsService, Helpers spacingLine)
        {
            _actionService = actionService;
            _skillsService = skillsService;
            _spacingLine = spacingLine;
        }

        public BattleManager(MenuActionService actionService, BossService bossService, SkillsService skillsService, Helpers spacingLine)
        {
            _actionService = actionService;
            _bossService = bossService;
            _skillsService = skillsService;
            _spacingLine = spacingLine;

        }

        public ChosenClass Attack(ChosenClass result, EnemyGenerator enemy, Helpers spaceLine)
        {
            enemy.Hp -= result.Damage;
            if (enemy.Hp <= 0)
            {
                Console.WriteLine("Enemy has been defeated");
                Console.WriteLine("You have earned " + enemy.Exp + "exp");
            }
            else
            {
                Console.WriteLine("Enemy has " + enemy.Hp + " hp  \n");

                result.Hp -= enemy.Damage;

                if (result.Hp <= 0)
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage and you've died\n");
                    _spacingLine.SpacingLine();
                }
                else
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage -> you have " + result.Hp + " hp left \n");
                    _spacingLine.SpacingLine();
                }
            }
            return result;
        }

        public ChosenClass UseSkill(ChosenClass result, EnemyGenerator enemy, SkillsService skillsService, Skills skill, Helpers spaceLine)
        {
            if (skill.IsLocked == true)
            {
                Console.WriteLine("You need to unlock your skills first !");

                result.Hp -= enemy.Damage;

                if (result.Hp <= 0)
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage and you've died\n");
                    _spacingLine.SpacingLine();
                }
                else
                {
                    Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage -> you have " + result.Hp + " hp left \n");
                    _spacingLine.SpacingLine();
                }
            }
            else
            {
                for (int i = skill.TurnsRequired; i >= 0; i--)
                {
                    skillsService.SkillsAction(skill, result, enemy);

                    if (skill.Name == "Blessing" && skill.IsActive == true)
                    {
                        skillsService.BlessingEffect(enemy, skill);
                        skill.Duration -= 1;
                    }

                    result.Hp -= enemy.Damage;

                    skill.TurnsRequired -= 1;

                    if (result.Hp <= 0)
                    {
                        Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage and you've died\n");
                        _spacingLine.SpacingLine();
                    }
                    else
                    {
                        Console.WriteLine("You've been attacked and took " + enemy.Damage + " damage -> you have " + result.Hp + " hp left \n");
                        _spacingLine.SpacingLine();
                    }

                }
                skill.TurnsRequired = default;
            }

            return result;
        }

        public ChosenClass RunAway(ChosenClass result)
        {
            Console.WriteLine("You've decided to run away");
            _spacingLine.SpacingLine();
            return result;
        }

        public ChosenClass AttackBoss(ChosenClass result, Boss bossStats, BossService bossService, SkillsService skillsService, Skills bossSkill)
        {
            bossStats.Hp -= result.Damage;
            if (bossStats.Hp <= 0)
            {
                Console.WriteLine("Boss has been defeated");
                Console.WriteLine("You have earned " + bossStats.Exp + "exp");
            }
            else
            {
                Console.WriteLine("Boss has " + bossStats.Hp + " hp  \n");

                _bossService.BossBehaviour(skillsService, bossSkill, result, bossStats);
            }

            return result;
        }
        public ChosenClass UseSkill(ChosenClass result, Boss bossStats, SkillsService skillsService, Skills skill, Skills bossSkill)
        {
            if (skill.IsLocked == true)
            {
                Console.WriteLine("You need to unlock your skills first !");

                _bossService.BossBehaviour(skillsService, bossSkill, result, bossStats);

            }
            else
            {
                for (int i = skill.TurnsRequired; i >= 0; i--)
                {
                    skillsService.SkillsAction(skill, result, bossStats);
                    skill.TurnsRequired -= 1;

                    if (skill.Name == "Blessing" && skill.IsActive == true)
                    {
                        skillsService.BlessingEffect(bossStats, skill);
                        skill.Duration -= 1;
                    }

                    _bossService.BossBehaviour(skillsService, bossSkill, result, bossStats);

                }
                skill.TurnsRequired = default;
            }
            return result;
        }
    }
}
            




      
           

