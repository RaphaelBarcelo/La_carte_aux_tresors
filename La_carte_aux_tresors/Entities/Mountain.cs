using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_carte_aux_tresors
{
    public class Mountain : Entity
    {
        public Mountain(int xCoordinates = -1, int yCoordinates = -1) : base(xCoordinates, yCoordinates){}

        public Mountain(string[] parsedLine) : base(Int32.Parse(parsedLine[1]), Int32.Parse(parsedLine[2])){}

        public override string toOutput_exhaustive()
        {
            return ("M - " + _xCoordinates + " - " + _yCoordinates + "\n");
        }

        public override string toOutput_simplified()
        {
            throw new NotImplementedException();
        }
    }
}
