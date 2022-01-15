using Roguelike.App.Commnon;
using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class SkillsService:BaseService<Skills>
    {
       public SkillsService()
        {
            Initialize();
        }
        public void SkillsAction(Skills skill, ChosenClass result, EnemyGenerator enemy)
        {
                switch (skill.Name)
                {
                    case "Blessing":
                        switch (skill.TurnsRequired)
                        {
                            case 2:
                                Console.WriteLine("You started to pray");
                                break;
                            case 1:
                                Console.WriteLine("Gods are watching your faithful devotion");
                                break;
                            case 0:
                                Console.WriteLine("Gods are pleased - they improved your vitality and damage");
                                Console.WriteLine("For next 2 turns you won't take any damage");
                                result.Hp += 10;
                                result.Damage += 15;
                                skill.IsActive = true;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Fireball":
                        switch (skill.TurnsRequired)
                        {
                            case 1:
                                Console.WriteLine("You are gathering your inner power to form fireball");
                                break;
                            case 0:
                                Console.WriteLine("You've thrown massive fireball !");
                                Console.WriteLine("Fireball dealt "+ skill.Damage + " damage to opponent");
                                 enemy.Hp -= skill.Damage;
                                break;
                            default:
                                break;
                    }
                        break;
                    case "Legacy Strike":
                        switch (skill.TurnsRequired)
                        {
                            case 3:
                                Console.WriteLine("You silenced your mind");
                                break;
                            case 2:
                                Console.WriteLine("You spotted opponent's weakpoint");
                                break;
                            case 1:
                                Console.WriteLine("You are preparing final strike");
                                break;
                            case 0:
                                Console.WriteLine("With all your dexterity and swiftness you' ve inflicted " + skill.Damage + " damage");
                                enemy.Hp -= skill.Damage;
                                break;
                            default:
                                break;
                    }
                        break;

                    default:
                        break;
                }
        }
        public void SkillsAction(Skills skill, ChosenClass result, Boss bossStats)
        {
            switch (skill.Name)
            {
                case "Blessing":
                    switch (skill.TurnsRequired)
                    {
                        case 2:
                            Console.WriteLine("You started to pray");
                            break;
                        case 1:
                            Console.WriteLine("Gods are watching your faithful devotion");
                            break;
                        case 0:
                            Console.WriteLine("Gods are pleased - they improved your vitality and damage");
                            Console.WriteLine("For next 2 turns you won't take any damage");
                            result.Hp += 10;
                            result.Damage += 15;
                            skill.IsActive = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Fireball":
                    switch (skill.TurnsRequired)
                    {
                        case 1:
                            Console.WriteLine("You are gathering your inner power to form fireball");
                            break;
                        case 0:
                            Console.WriteLine("You've thrown fireball !");
                            Console.WriteLine("Fireball dealt " + skill.Damage + " damage to opponent");
                            bossStats.Hp -= skill.Damage;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Legacy Strike":
                    switch (skill.TurnsRequired)
                    {
                        case 3:
                            Console.WriteLine("You silenced your mind");
                            break;
                        case 2:
                            Console.WriteLine("You spotted opponent's weakpoint");
                            break;
                        case 1:
                            Console.WriteLine("You are preparing final strike");
                            break;
                        case 0:
                            Console.WriteLine("With all your dexterity and swiftness you' ve inflicted " + skill.Damage + " damage");
                            bossStats.Hp -= skill.Damage;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        public void BossSkillsAction(Skills bossSkill, ChosenClass result)
        {
            switch(bossSkill.Name)
            {
                case "Unholy Strikes":
                    switch (bossSkill.TurnsRequired)
                    {
                        case 1:
                            Console.WriteLine("Darkness embraces surroundings");
                            break;
                        case 0:
                            Console.WriteLine("You've been attacked by evil power !");
                            result.Hp -= bossSkill.Damage;
                            break;
                    }
                    break;
                case "Behemoth Cleave":
                    switch (bossSkill.TurnsRequired)
                    {
                        case 1:
                            Console.WriteLine("Boss is gathering his strength");
                            break;
                        case 0:
                            Console.WriteLine("You've been striked down by Behemoth Cleave !");
                            result.Hp -= bossSkill.Damage;
                            break;
                    }
                    break;
                case "Player deletion":
                    switch (bossSkill.TurnsRequired)
                    {
                        case 4:
                            Console.WriteLine("...");
                            break;
                        case 3:
                            Console.WriteLine("...");
                            break;
                        case 2:
                            Console.WriteLine("...");
                            break;
                        case 1:
                            Console.WriteLine(@"This is your last chance ...");
                            break;
                        case 0:
                            Console.WriteLine("Boss deleted you like a peasant you are !");
                            result.Hp -= bossSkill.Damage;
                            break;
                    }
                    break;
            }
        }

        public void SkillEffectChecker(Skills skill, SkillsService skillsService, EnemyGenerator enemy) 
        {
            if (skill.Name == "Blessing" && skill.IsActive == true)
            {
                skillsService.BlessingEffect(enemy, skill);
                skill.Duration -= 1;

            }
        }
        public Skills SkillEffectEnd(Skills skill)
        {
                Console.WriteLine("Skill effect was worned out\n");
                skill.IsActive = false;
                skill.Duration = 2;
                return skill;
        }
        public EnemyGenerator BlessingEffect (EnemyGenerator enemy, Skills skill)
        {
           
            enemy.Damage = 0;
            Console.WriteLine("Enemy can't damage for " + skill.Duration + " turn/-s due to Blessing");
            return enemy;

        }
        public Boss BlessingEffect(Boss bossStats, Skills skill)
        {
           
            bossStats.Damage = 0;
            Console.WriteLine("Boss can't damage for " + skill.Duration + " turn/-s due to Blessing");
            return bossStats;
        }
        private void Initialize()
        {
            CreateItem(new Skills(1, 0, 2, "Blessing", 2, default, default));
            CreateItem(new Skills(2, 75, default, "Fireball", 1, default, default));
            CreateItem(new Skills(3, 150, default, "Legacy Strike", 3, default, default));
            CreateItem(new Skills(10, 60, default, "Unholy Strikes", 1, default, default));
            CreateItem(new Skills(20, 85, default, "Behemoth Cleave", 1, default, default));
            CreateItem(new Skills(20, 999, default, "Player deletion", 5, default, default));
        }
    }
}