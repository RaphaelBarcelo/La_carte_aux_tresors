using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_carte_aux_tresors
{
    public class Adventurer : Entity
    {
        public string _name { get; set; }
        public char _orientation { get; set; }
        public string _moveset { get; set; }
        public int _nbTreasuresGathered { get; set; }

        public Adventurer(string name, int xCoordinates = -1, int yCoordinates = -1, char orientation = 'N', string moveset = "") : base(xCoordinates, yCoordinates)
        {
            _name = name;
            _orientation = orientation;
            _moveset = moveset;
            _nbTreasuresGathered = 0;
        }

        public Adventurer(string[] parsedLine) : base(Int32.Parse(parsedLine[2]), Int32.Parse(parsedLine[3]))
        {
            _name = parsedLine[1];
            _orientation = char.Parse(parsedLine[4]);
            _moveset = parsedLine[5];
            _nbTreasuresGathered = 0;
        }

        public void move(GameManager gameManager)
        {
            Entity[,] map = gameManager._map;
            char[] moveset = _moveset.ToCharArray();
            foreach (char move in moveset)
            {
                switch (move)
                {
                    case 'A':
                        int x = _xCoordinates;
                        int y = _yCoordinates;
                        switch (_orientation)
                        {
                            case 'N':
                                if (map[x, y - 1] is not Mountain) 
                                {
                                    _yCoordinates--;
                                }
                                break;
                            case 'E':
                                if (map[x + 1, y] is not Mountain)
                                {
                                    _xCoordinates++;
                                }
                                break;
                            case 'S':
                                if (map[x, y + 1] is not Mountain)
                                {
                                    _yCoordinates++;
                                }
                                break;
                            case 'W':
                                if (map[x - 1, y] is not Mountain)
                                {
                                    _xCoordinates--;
                                }
                                break;
                        }
                        if (map[_xCoordinates, _yCoordinates] is Treasure) 
                        {
                            _nbTreasuresGathered++;
                            Treasure treasure = (Treasure)map[_xCoordinates, _yCoordinates];
                            if (treasure._remainingTreasures--  == 0)
                            {
                                gameManager._treasures.Remove(treasure);
                                map[_xCoordinates, _yCoordinates] = new Plain();
                            }
                        }
                        break;
                    case 'D':
                        switch (_orientation)
                        {
                            case 'N':
                                _orientation = 'E';
                                break;
                            case 'E':
                                _orientation = 'S';
                                break;
                            case 'S':
                                _orientation = 'W';
                                break;
                            case 'W':
                                _orientation = 'N';
                                break;
                        }
                        break;
                    case 'G':
                        switch (_orientation)
                        {
                            case 'N':
                                _orientation = 'W';
                                break;
                            case 'E':
                                _orientation = 'S';
                                break;
                            case 'S':
                                _orientation = 'E';
                                break;
                            case 'W':
                                _orientation = 'N';
                                break;
                        }
                        break;
                }
            }
        }

        public override string toOutput_exhaustive()
        {
            return("A - " + _name + " - " + _xCoordinates + " - " + _yCoordinates + " - " + _orientation + " - " 
                + _nbTreasuresGathered + "\n");
        }

        public override string toOutput_simplified()
        {
            throw new NotImplementedException();
        }

        public override bool compareTo(Entity entity)
        {
            bool result = true;
            Adventurer adventurer = (Adventurer)entity;
            if (adventurer == null) return false;
            if (this == adventurer) return true;
            result = _name == adventurer._name &&
                    _orientation == adventurer._orientation &&
                    _moveset == adventurer._moveset &&
                    _nbTreasuresGathered == adventurer._nbTreasuresGathered;
            return false;
        }
    }
}
