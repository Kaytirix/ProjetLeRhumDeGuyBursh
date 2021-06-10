using System;

namespace Projet
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string NomFichier;

            //Demande le nom du fichier
            Console.WriteLine("Le nom du fichier :");
            NomFichier = Console.ReadLine();

            //Création de l'objet carte
            Carte Carte = new Carte(".\\..\\..\\..\\" + NomFichier + ".txt");

            Carte.Cryptage();
            Carte.AffichageCarteCrypter();

        }

    }
}
