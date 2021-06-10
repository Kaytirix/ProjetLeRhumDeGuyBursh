using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{

    class Unite
    {
        private char Nom;
        private uint ValeurCrypter;
        private int[,] tableauValeur = new int[10, 10];

        public Unite(char nom, uint valeurCrypter)
        {
            Nom = nom;
            ValeurCrypter = valeurCrypter;
        }

        public void InitTableauValeur()
        {
            int ligne = 0, colone = 0;

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    if (colone == 0)
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 2;
                    }

                    if (ligne == 0)
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 1;
                    }

                    if (ligne == 9)
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 4;
                    }

                    if (colone == 9)
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 8;
                    }
                }
            }
        }
    }
}
