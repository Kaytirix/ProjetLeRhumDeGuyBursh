using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet
{
    class Carte
    {
        private char[,] TableauCaractere = new char[10,10];

        public Carte(string CheminAccesFichier)
        {
            StreamReader ligne = new StreamReader(CheminAccesFichier);
            string str;
            int i = 0;

            while ((str = ligne.ReadLine()) != null)
            {
                for (i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        TableauCaractere[i, j] = str[j];
                    }
                    str = ligne.ReadLine();
                }
            }
            ligne.Close();
        }

        public void AffichageCarte()
        {
            int ligne, colone;

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    Console.Write("{0}", TableauCaractere[ligne, colone]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void AffichageTableauValeur()
        {
            int ligne, colone;

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    Console.Write("{0}:", tableauValeur[ligne, colone]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void Cryptage()
        {
            int ligne, colone;

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 9; colone++)
                {
                    if (TableauCaractere[ligne, colone] != TableauCaractere[ligne, colone + 1])
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 8;
                    }
                }
            }

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 1; colone < 10; colone++)
                {
                    if (TableauCaractere[ligne, colone] != TableauCaractere[ligne, colone - 1])
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 2;
                    }
                }
            }

            for (ligne = 0; ligne < 9; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    if (TableauCaractere[ligne, colone] != TableauCaractere[ligne+1, colone])
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 4;
                    }
                }
            }

            for (ligne = 1; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    if (TableauCaractere[ligne, colone] != TableauCaractere[ligne-1, colone])
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 1;
                    }
                }
            }

        }
    }
}
