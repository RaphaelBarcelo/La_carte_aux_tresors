using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.IO;
using System.Linq;

namespace La_carte_aux_tresors
{
    public class GameManager
    {
        public List<Mountain> _mountains { get; set; }
        public List<Treasure> _treasures { get; set; }
        public Adventurer _adventurer { get; set; }
        public Entity[,] _map { get; set; }
        public GameManager(List<string> fileLines)
        {
            _mountains = new List<Mountain>();
            _treasures = new List<Treasure>();
            initializeData(fileLines);

        }

        public void initializeData(List<string> fileLines)
        {
            char[] separators = new char[] {' ', '-' };

            string[] firstLine = fileLines.First().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int mapWidth = Int32.Parse(firstLine[1]);
            int mapHeight = Int32.Parse(firstLine[2]);
            _map = new Entity[mapWidth, mapHeight]; 
            for (int x = 0; x < mapWidth; x++)
                for (int y = 0; y < mapHeight; y++)
                {
                    _map[x, y] = new Plain();
                }
            fileLines.RemoveAt(0);

            foreach (string line in fileLines)
            {
                string[] parsedLine = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                switch (parsedLine[0])
                {
                    case "M":
                        int xCoordinatesM = Int32.Parse(parsedLine[1]);
                        int yCoordinatesM = Int32.Parse(parsedLine[2]);
                        Mountain mountain = new Mountain(xCoordinatesM, yCoordinatesM);
                        _mountains.Add(mountain);
                        _map[xCoordinatesM, yCoordinatesM] = mountain;
                        break;
                    case "T":
                        int xCoordinatesT = Int32.Parse(parsedLine[1]);
                        int yCoordinatesT = Int32.Parse(parsedLine[2]);
                        int totalTreasures = Int32.Parse(parsedLine[3]);
                        Treasure treasure = new Treasure(totalTreasures);
                        _treasures.Add(treasure);
                        _map[xCoordinatesT, yCoordinatesT] = treasure;
                        break;
                    case "A":
                        string name = parsedLine[1];
                        int xCoordinatesA = Int32.Parse(parsedLine[2]);
                        int yCoordinatesA = Int32.Parse(parsedLine[3]);
                        char direction = char.Parse(parsedLine[3]);
                        string moveset = parsedLine[4];
                        _adventurer = new Adventurer(name, xCoordinatesA, yCoordinatesA, direction, moveset);
                        _map[xCoordinatesA, yCoordinatesA] = _adventurer;
                        break;
                }
            }
        }

        public string mapToOutput()
        {
            string output = "C - " + _map.GetLength(0) + " - " + _map.GetLength(1) + "\n";
            foreach (Mountain mountain in _mountains)
            {
                output += mountain.toOutput_exhaustive();
            }
            foreach (Treasure treasure in _treasures)
            {
                output += treasure.toOutput_exhaustive();
            }
            output += _adventurer.toOutput_exhaustive();
            output += "\n" + "____" + "\n";

            return output;
        }
    }
 
}
