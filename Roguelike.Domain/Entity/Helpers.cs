using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Roguelike.Domain.Entity
{
    public class Helpers
    {
        public void SpacingLine()
        {
            Console.WriteLine("===============\n");
        }

        public char[,] CreateMap()
        {
            string path = @"../../../Files/Map.txt";
            StreamReader streamReader = File.OpenText(path);
            char[,] map = new char[9, 20];

            if (File.Exists(path))
            {
                for (int i = 0; i <9; i++)
                {
                    string line = streamReader.ReadLine();
                    for (int j =0; j <line.Length; j++)
                    {
                        map[i, j] = line[j];                    
                    }
                }
            }
            return map;
        }

        public void DrawPlayer(ChosenClass result, char[,] map)
        {
            map[result.PositionY, result.PositionX] = ' ';
            result.PositionY = 5;
            result.PositionX = 5;
            map[result.PositionY, result.PositionX] = result.Symbol;
            
        }

        public void GetMap(ChosenClass result, char[,] map)
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void DrawEnemyOnMap(char[,] map)
        {

            Random position = new Random();
            for (int i =0; i<3; i++)
            {
                int positionY = position.Next(1, 8);
                int positionX = position.Next(1, 19);
                map[positionY, positionX] = 'O';
            }
        }

        public void DrawBossOnMap(char[,] map)
        {
            Random position = new Random();
            int positionY = position.Next(1, 8);
            int positionX = position.Next(1, 19);
            map[positionY, positionX] = 'B';
        }

        public bool Encounter(ChosenClass result, char[,] map)
        {
            bool encounter = map[result.PositionY, result.PositionX] == 'O';
            return encounter;
        }

        public bool Exit(ChosenClass result, char[,] map)
        {
            bool exit = map[result.PositionY, result.PositionX] == 'E';
            return exit;
        }

        public void ProceedToNextFloor(char [,] map, int floor, Helpers helpers, ChosenClass result)
        {
            if (floor != 10 && floor != 20 && floor != 30)
            {
                DrawPlayer(result, map);
                map[7, 5] = 'E';
                helpers.DrawEnemyOnMap(map);
            }
            else
            {
                DrawPlayer(result, map);
                map[7, 5] = 'E';
                helpers.DrawBossOnMap(map);
            }

        }
    }

}
    

