﻿using System;

namespace Projet
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string NomFichier;

            Console.WriteLine("Le nom du fichier :");
            NomFichier = Console.ReadLine();
            Carte Carte = new Carte("C:\\Users\\sebas\\Desktop\\Projet\\Projet\\Projet\\" + NomFichier + ".txt");

            Carte.AffichageCarte();
            Carte.Cryptage();
            Carte.AffichageTableauValeur();
        }

    }
}
