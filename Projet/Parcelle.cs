using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    /// <summary>
    /// Modelise une parcelle
    /// </summary>
    class Parcelle
    {
        #region Attribut

        /// <summary>
        /// Le type de parcelle (Mer,Foret...)
        /// </summary>
        private char Type;

        /// <summary>
        /// Le nombre d'unité de la parcelle
        /// </summary>
        private uint NombreUnite;

        #endregion


        #region Constructeur

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="type">Le type de parcelle</param>
        /// <param name="nombreUnite">Le nombre d'unité de la parcelle</param>
        public Parcelle(char type, uint nombreUnite)
        {
            Type = type;
            NombreUnite = nombreUnite;
        }

        #endregion
    }
}
