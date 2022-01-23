using System;
using System.Collections.Generic;
using System.Text;
using Roguelike.Domain.Common;
using Roguelike.Domain.Entity;

namespace Roguelike.Domain.Entity
{
    public class Skills:BaseEntity
    {
        public int Damage { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public int TurnsRequired { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }

        public Skills()
        {

        }
        public Skills (int id,int damage, int duration, string name, int turnsRequired, bool isLocked, bool isActive)
        {
            Id = id;
            Damage = damage;
            Duration = duration;
            Name = name;
            TurnsRequired = turnsRequired;
            IsLocked = true;
            IsActive = false;
        }
  
    }
}
