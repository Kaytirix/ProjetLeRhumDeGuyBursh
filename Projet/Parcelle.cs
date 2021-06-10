using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Parcelle
    {
        private char Type;
        private uint NombreUnite;

        public Parcelle(char type, uint nombreUnite)
        {
            Type = type;
            NombreUnite = nombreUnite;
        }
    }
}
