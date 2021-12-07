using System;
using System.Collections.Generic;
using System.Text;

namespace Rogulike
{
    public class Skills
    {
        public int Id { get; set; }
        public int Damage { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public int TurnsRequired { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }

        public Skills() : this(true, false)
        {

        }

        public Skills(bool isLocked, bool isActive)
        {
            IsLocked = isLocked;
            IsActive = isActive;
        }
    }
}
