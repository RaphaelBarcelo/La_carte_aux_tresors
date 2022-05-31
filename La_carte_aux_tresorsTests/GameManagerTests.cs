using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_carte_aux_tresors.Tests
{
    [TestClass()]
    public class GameManagerTests
    {
        [TestMethod()]
        public void initializeDataTest()
        {
            List<string> fileLines =  new List<string>();
            fileLines.Add("C - 3 - 4");
            fileLines.Add("M - 1 - 0");
            fileLines.Add("M - 2 - 1");
            fileLines.Add("M - 2 - 1");
            fileLines.Add("T - 0 - 3 - 2");
            fileLines.Add("T - 1 - 3 - 3");
            fileLines.Add("A - Lara - 1 - 1 - S - AADADAGGA");

            Entity[,] _map = new Entity[4, 3] { {new Plain(), new Mountain(1, 0), new Plain()},
                                                {new Plain(), new Adventurer("Lara",1,1,'S',"AADADAGGA"), new Mountain(2,1)},
                                                {new Plain(), new Plain(), new Plain()},
                                                {new Treasure(0,3,2), new Treasure(1,3,3), new Plain()}};

            //need to overide comparison methods to compare each elements in a dummy list and an initialized list
            Assert.Fail();
        }
    }
}