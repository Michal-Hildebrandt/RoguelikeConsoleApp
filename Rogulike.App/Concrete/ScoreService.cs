using Roguelike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;


namespace Roguelike.App.Concrete
{
    public class ScoreService
    {
        public void CreateOrOverwriteScoreList(int floor)
        {
            var Nickname = Console.ReadLine();

            List<Score> scoreList = new List<Score>();
            string path = (@"C:\Temp\ScoreList.xml");

            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Place";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Score>), root);

            if (File.Exists(path))
            {

                string xml = File.ReadAllText(path);
                StringReader stringReader = new StringReader(xml);

                scoreList = (List<Score>)xmlSerializer.Deserialize(stringReader);
                stringReader.Close();
            }

            scoreList.Add(new Score(0, floor -1, Nickname));

            scoreList = scoreList.OrderByDescending(x => x.Floor).ThenBy(x => x.PlayerNickname).ToList();

            foreach (Score score in scoreList)
            {
                score.Place = scoreList.IndexOf(score);
            }

            using StreamWriter sw = new StreamWriter(path);
            xmlSerializer.Serialize(sw, scoreList);
            sw.Close();
        }

        public void ReadScoreList()
        {
            List<Score> scoreList = new List<Score>();
            string path = (@"C:\Temp\ScoreList.xml");

            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Place";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Score>), root);

            if (File.Exists(path))
            {

                string xml = File.ReadAllText(path);
                StringReader stringReader = new StringReader(xml);

                scoreList = (List<Score>)xmlSerializer.Deserialize(stringReader);
                stringReader.Close();

                foreach (Score score in scoreList)
                {
                    Console.WriteLine("# " + score.Place + " player named " + score.PlayerNickname + " reached " + score.Floor);
                }
            }
            else
            {
                Console.WriteLine("For now, scoreboard is empty");
            }
        }
    }
}
