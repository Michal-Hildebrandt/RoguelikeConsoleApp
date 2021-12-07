using System;
using System.Collections.Generic;
using System.Text;

namespace Rogulike
{
    public class SkillsService
    {
        private List<Skills> SkillsList = new List<Skills>()
        {
            new Skills() {Id = 1, Name = "Blessing", TurnsRequired = 2, Duration = 2},
            new Skills() {Id = 2, Damage = 75, Name = "Fireball", TurnsRequired = 1},
            new Skills() {Id = 3, Damage = 150, Name = "Legacy Strike", TurnsRequired = 3},
            new Skills() {Id = 10, Damage = 25, Name = "Unholy Strikes", TurnsRequired = 1},
            new Skills() {Id = 20, Damage = 55, Name = "Behemoth Cleave", TurnsRequired = 1},
            new Skills() {Id = 30, Damage = 999, Name = "Player deletion", TurnsRequired = 5},
        };

        public List<Skills> GettingPlayerSkill(ChosenClass result)
        {
            List<Skills> skill = new List<Skills>();
            foreach (var Skills in SkillsList)
            {
                if (Skills.Id == result.PlayerChoice)
                {
                    skill.Add(Skills);
                }
            }
            return skill;
        }

        public List<Skills> GettingBossSkill(Boss bossStats)
        {
            List<Skills> bossSkill = new List<Skills>();
            foreach (var Skills in SkillsList)
            {
                if (Skills.Id == bossStats.Apperance)
                {
                    bossSkill.Add(Skills);
                }
            }
            return bossSkill;
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
                                Console.WriteLine("Fireball dealt 75 damage to opponent");
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
                                Console.WriteLine("With all your dexterity and swiftness you' ve inflicted 150 damage");
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
                            Console.WriteLine("You've been attacked by ");
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
                            break;
                    }
                    break;
            }
        }
        public Skills SkillEffectEnd(ChosenClass result, Skills skill)
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
    }
}