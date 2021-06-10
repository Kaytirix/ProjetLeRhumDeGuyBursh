using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    /// <summary>
    /// Modélise une unité
    /// </summary>
    class Unite
    {

        #region Attribut

        /// <summary>
        /// Nom de l'unité (a,b,M...)
        /// </summary>
        private char Nom;

        /// <summary>
        /// La valeur crypter selon les frontières de l'unité
        /// </summary>
        private uint ValeurCrypter;
        #endregion

        #region Constructeur

        /// <summary>
        /// Construteur de la classe
        /// </summary>
        /// <param name="nom">Nom de l'unité (a,b,M...)</param>
        /// <param name="valeurCrypter"> La valeur crypter selon les frontières de l'unité</param>
        public Unite(char nom, uint valeurCrypter)
        {
            Nom = nom;
            ValeurCrypter = valeurCrypter;
        }
        #endregion
    }
}
