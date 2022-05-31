using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_carte_aux_tresors
{
    public abstract class Entity
    {
        public int _xCoordinates { get; set; }
        public int _yCoordinates { get; set; }
        public Entity(int xCoordinates = -1, int yCoordinates = -1) 
        { 
            this._xCoordinates = xCoordinates;
            this._yCoordinates = yCoordinates;
        }

        public abstract string toOutput_exhaustive();
        public abstract string toOutput_simplified();
        public abstract bool compareTo(Entity entity);
    }
}
