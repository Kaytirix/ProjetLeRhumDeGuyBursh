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
        #region Attribut
        private char[,] TableauCaractere = new char[10,10];
        private int[,] tableauValeur = new int[10, 10];
        #endregion

        #region Constructeur
        public Carte(string CheminAccesFichier)
        {
            StreamReader ligne = new StreamReader(CheminAccesFichier);
            string str;
            int ligne_ = 0;

            while ((str = ligne.ReadLine()) != null)
            {
                for (ligne_ = 0; ligne_ < 10; ligne_++)
                {
                    for (int colone = 0; colone < 10; colone++)
                    {
                        TableauCaractere[ligne_, colone] = str[colone];
                    }
                    str = ligne.ReadLine();
                }
            }
            ligne.Close();
        }
        #endregion


        #region Méthode
        public void AffichageCarte()
        {
            uint position = 0;

            foreach (char carac in TableauCaractere)
            {
                position++;
                if (position != 10)
                {
                    Console.Write("{0}", carac);
                }
                else
                {
                    Console.Write("\n");
                    position = 0;
                }
            }
            Console.Write("\n");
        }

        public void AffichageTableauValeur()
        {
            uint position = 0;

            foreach(int valeur in tableauValeur)
            {
                position++;
                if(position != 10)
                {
                    Console.Write("{0}:", valeur);
                }else
                {
                    Console.Write("{0}|", valeur);
                    position = 0;
                }
            }
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

                    if (TableauCaractere[ligne, colone] == 'M')
                    {
                        tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 64;
                    }
                    else
                    {
                        if (TableauCaractere[ligne, colone] == 'F')
                        {
                            tableauValeur[ligne, colone] = tableauValeur[ligne, colone] + 32;
                        }
                    }
                }
            }
        }

        public void Cryptage()
        {
            int ligne, colone;

            InitTableauValeur();

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

        #endregion
    }
}
