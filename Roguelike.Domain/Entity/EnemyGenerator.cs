using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Domain.Common;
using Roguelike.Domain.Entity;

namespace Roguelike.Domain.Entity
{
    public class EnemyGenerator:BaseEntity
    {
        public int DifficultyRange { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Exp { get; set; }

        public EnemyGenerator()
        {

        }
        public EnemyGenerator (int id, int difficultyRange, int hp, int damage, int exp)
        {
            Id = id;
            DifficultyRange = difficultyRange;
            Hp = hp;
            Damage = damage;
            Exp = exp;
        }
    }
}
