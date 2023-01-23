using Roguelike.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Roguelike.Domain.Entity
{
    public class Score: BaseEntity
    {
        [XmlElement("Place")]
        public int Place { get; set; }
        [XmlElement("Floor")]
       public int Floor { get; set; } 

       [XmlElement("Nickname")]
       public string PlayerNickname { get; set; }
       
       public Score()
        {

        }

        public Score(int place, int floor, string playerNickname)
        {
            Place = place;
            Floor = floor;
            PlayerNickname = playerNickname;       
        }
    }
}
