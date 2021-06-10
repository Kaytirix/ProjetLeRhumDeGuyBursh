using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet
{
    /// <summary>
    /// Modelise la carte
    /// </summary>
    class Carte
    {
        #region Attribut

        /// <summary>
        /// La carte donner mais sous forme de tableau pour parcourir la carte
        /// </summary>
        private char[,] tableauCarte = new char[10,10];

        /// <summary>
        /// La carte crypter. Elle est sous forme de tableau.
        /// </summary>
        private int[,] carteCrypter = new int[10, 10];
        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur de la classe carte
        /// </summary>
        /// <param name="cheminAccesFichier">Le chemin d'accèes du fichier de la carte</param>
        public Carte(string cheminAccesFichier)
        {
            try
            {
                StreamReader ligne = new StreamReader(cheminAccesFichier);
                string str;
                int ligne_ = 0;

                while ((str = ligne.ReadLine()) != null)
                {
                    for (ligne_ = 0; ligne_ < 10; ligne_++)
                    {
                        for (int colone = 0; colone < 10; colone++)
                        {
                            tableauCarte[ligne_, colone] = str[colone];
                        }
                        str = ligne.ReadLine();
                    }
                }
                ligne.Close();
            }
            catch (Exception e)
            {
                // Exectuté si des instruction dans le try échoue
                // Donc, si tout se passe bien dans le try, le bloc catch est ignoré
                // e est remplie par windows avec un message d'erreur
                Console.WriteLine(e); // Affichage du message d'erreur
                return; // On quitte le constructeur
            }


        }
        #endregion


        #region Méthode

        /// <summary>
        /// Permet d'afficher la carte crypter
        /// </summary>
        public void AffichageCarteCrypter()
        {
            uint position = 0;

            foreach(int valeur in carteCrypter)
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

        /// <summary>
        /// Permet d'initialiser la carte crypter avec des valeurs qui seront toujours les mêmes
        /// </summary>
        public void InitCarteCrypter()
        {
            int ligne = 0, colone = 0;

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    if (colone == 0)
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 2;
                    }

                    if (ligne == 0)
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 1;
                    }

                    if (ligne == 9)
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 4;
                    }

                    if (colone == 9)
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 8;
                    }

                    if (tableauCarte[ligne, colone] == 'M')
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 64;
                    }
                    else
                    {
                        if (tableauCarte[ligne, colone] == 'F')
                        {
                            carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 32;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Permet de faire le cryptage de la carte
        /// </summary>
        public void Cryptage()
        {
            int ligne, colone;

            InitCarteCrypter();

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 9; colone++)
                {
                    if (tableauCarte[ligne, colone] != tableauCarte[ligne, colone + 1])
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 8;
                    }
                }
            }

            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colone = 1; colone < 10; colone++)
                {
                    if (tableauCarte[ligne, colone] != tableauCarte[ligne, colone - 1])
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 2;
                    }
                }
            }

            for (ligne = 0; ligne < 9; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    if (tableauCarte[ligne, colone] != tableauCarte[ligne +1, colone])
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 4;
                    }
                }
            }

            for (ligne = 1; ligne < 10; ligne++)
            {
                for (colone = 0; colone < 10; colone++)
                {
                    if (tableauCarte[ligne, colone] != tableauCarte[ligne -1, colone])
                    {
                        carteCrypter[ligne, colone] = carteCrypter[ligne, colone] + 1;
                    }
                }
            }
        }

        #endregion
    }
}
