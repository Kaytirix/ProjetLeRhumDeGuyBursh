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

            //Parcours le tableau pour pourvoir l'afficher
            foreach(int valeur in carteCrypter)
            {
                position++;

                //Pour faire un affichage visible, au bout de 10 valeurs, une barre apparait
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
            int ligne = 0, colonne = 0;

            //Attribution des valeurs commune à toutes les cartes
            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colonne = 0; colonne < 10; colonne++)
                {
                    if (colonne == 0)
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 2;
                    }

                    if (ligne == 0)
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 1;
                    }

                    if (ligne == 9)
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 4;
                    }

                    if (colonne == 9)
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 8;
                    }

                    if (tableauCarte[ligne, colonne] == 'M')
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 64;
                    }
                    else
                    {
                        if (tableauCarte[ligne, colonne] == 'F')
                        {
                            carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 32;
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
            int ligne, colonne;

            //Initialise le tableau avec les valeurs déjà connu
            InitCarteCrypter();
            
            //Vérification d'une frontière Est pour chaque unité. Parcours du tableau de gauche à droite.
            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colonne = 0; colonne < 9; colonne++)
                {
                    if (tableauCarte[ligne, colonne] != tableauCarte[ligne, colonne + 1])
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 8;
                    }
                }
            }

            //Vérification d'une frontière Ouest pour chaque unité. Parcours du tableau de droite à gauche.
            for (ligne = 0; ligne < 10; ligne++)
            {
                for (colonne = 1; colonne < 10; colonne++)
                {
                    if (tableauCarte[ligne, colonne] != tableauCarte[ligne, colonne - 1])
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 2;
                    }
                }
            }

            //Vérification d'une frontière Nord pour chaque unité. Parcours du tableau bas en haut.
            for (ligne = 0; ligne < 9; ligne++)
            {
                for (colonne = 0; colonne < 10; colonne++)
                {
                    if (tableauCarte[ligne, colonne] != tableauCarte[ligne +1, colonne])
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 4;
                    }
                }
            }

            //Vérification d'une frontière Sud pour chaque unité. Parcours du tableau haut en bas.
            for (ligne = 1; ligne < 10; ligne++)
            {
                for (colonne = 0; colonne < 10; colonne++)
                {
                    if (tableauCarte[ligne, colonne] != tableauCarte[ligne -1, colonne])
                    {
                        carteCrypter[ligne, colonne] = carteCrypter[ligne, colonne] + 1;
                    }
                }
            }
        }

        #endregion
    }
}
