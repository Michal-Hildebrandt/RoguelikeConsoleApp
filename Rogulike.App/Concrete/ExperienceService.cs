using Roguelike.App.Managers;
using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class ExperienceService:SkillsService
    {
        public ChosenClass CalculateExperience(EnemyGenerator enemy, Experience experience, ChosenClass result)
        {
            experience.TotalExp += enemy.Exp;
            return result;
        }
        public ChosenClass CalculateExperience(Boss bossStats, Experience experience, ChosenClass result)
        {
            return result;
        }

        public ChosenClass LevelUp(ChosenClass result, Experience experience, ExperienceManager experienceManager, Skills skill, ExperienceService experienceService)
        {

            bool isGreater = experience.TotalExp >= experience.ExpRequired[result.Level + 1];

            if (result.Level <30)
            {
                if (isGreater == true)
                {
                    result.Level += 1;
                    experience.UpgradePoints += 1;
                    experience.TotalExp = experience.TotalExp - experience.ExpRequired[result.Level];
                    experienceManager.GetLeveulUpMenu(result, experience, skill, experienceService);
                }
            }
            else
            {
                experienceManager.MaxLvlWarning(experience);
            }
            
            return result;
        }
        
        public ChosenClass IncreaseHp(ChosenClass result, Experience experience)
        {
            result.Hp += 10;
            experience.UpgradePoints -= 1;
            return result;
        }

        public ChosenClass IncreaseDmg(ChosenClass result, Experience experience)
        {
            result.Damage += 5;
            experience.UpgradePoints -= 1;
            return result;
        }
    }   
}
