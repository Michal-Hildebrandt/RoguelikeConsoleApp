using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Boss:EnemyGenerator
    {
        public string Name { get; set; }

        public Boss(int id, int hp, int damage, int exp, string name)
        {
            Id = id;
            Hp = hp;
            Damage = damage;
            Exp = exp;
            Name = name;
        }
    }
}
