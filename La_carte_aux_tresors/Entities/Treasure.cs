using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_carte_aux_tresors
{
    public class Treasure : Entity
    {
        public int _remainingTreasures { get; set; }

        public Treasure(int xCoordinates = -1, int yCoordinates = -1, int _totalTreasure = 0) : base(xCoordinates, yCoordinates)
        {
            _remainingTreasures = _totalTreasure;
        }

        public override string toOutput_exhaustive()
        {
            Debug.Print("printing");
            Debug.Print(_xCoordinates.ToString());
            Debug.Print(_yCoordinates.ToString());
            return ("T - " + _xCoordinates + " - " + _yCoordinates + " - " + _remainingTreasures + "\n");
        }

        public override string toOutput_simplified()
        {
            throw new NotImplementedException();
        }
    }
}
