using Roguelike.Domain.Common;
using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Domain.Entity
{
    public class ChosenClass : BaseEntity
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Level {get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public char Symbol { get; set; }
        public ChosenClass()
        {

        }
        public ChosenClass(int id, string name, int hp, int damage, int level, int positionX, int positionY, char symbol)
        {
            Id = id;
            Name = name;
            Hp = hp;
            Damage = damage;
            Level = level;
            PositionX = positionX;
            PositionY = positionY;
            Symbol = symbol;
        }
    }

   
}
