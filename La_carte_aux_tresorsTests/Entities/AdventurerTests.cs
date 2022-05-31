using Microsoft.VisualStudio.TestTools.UnitTesting;
using La_carte_aux_tresors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_carte_aux_tresors.Tests
{
    [TestClass()]
    public class AdventurerTests
    {
        [TestMethod()]
        public void moveTest()
        {
            Entity[,] _map = new Entity[4, 3] { {new Plain(), new Mountain(1, 0), new Plain()},
                                                {new Plain(), new Adventurer("Lara",1,1,'S',"AADADAGGA"), new Mountain(2,1)},
                                                {new Plain(), new Plain(), new Plain()},
                                                {new Treasure(0,3,2), new Treasure(1,3,3), new Plain()}};

            List<Mountain> mountains =  new List<Mountain>();
            List<Treasure> treasures =  new List<Treasure>();
            Mountain mountain1 = new Mountain(1, 0);
            Mountain mountain2 = new Mountain(2, 1);
            Treasure treasure1 = new Treasure(0, 3, 2);
            Treasure treasure2 = new Treasure(1, 3, 3);
            mountains.Add(mountain1);
            mountains.Add(mountain2);
            treasures.Add(treasure1);
            treasures.Add(treasure2);

            GameManager gameManager = new GameManager();
            gameManager._mountains = mountains;
            gameManager._treasures = treasures;
            gameManager._map = _map;

            Adventurer adventurer = new Adventurer("Lara", 1, 1, 'S', "AADADAGGA");
            adventurer.move(gameManager);

            Assert.AreEqual(adventurer._xCoordinates, 0, "Incorrect x coordinates");
            Assert.AreEqual(adventurer._yCoordinates, 0, "Incorrect y coordinates");
            Assert.AreEqual(adventurer._orientation, 'S', "Incorrect orientation");
            Assert.AreEqual(adventurer._nbTreasuresGathered, 3, "Incorrect number of treasures gathered");
        }
    }
}