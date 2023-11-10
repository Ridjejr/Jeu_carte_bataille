using System;

namespace Jeu_carte_bataille // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creéation des joueurs 
            Joueur J1 = new Joueur("Ronaldo", "Cristiano");
            Joueur J2 = new Joueur("Messi", "Lionel");

            // Initialisation du jeu de cartes
            List<Carte> jeuDeCartes = Initialize();
            Shuffle(jeuDeCartes);


            // Distribution des cartes aux joueurs
            DealCards(jeuDeCartes, J1.LesCartes, J2.LesCartes);

            // Déroulement du jeu
            while (J1.LesCartes.Count > 0 && J2.LesCartes.Count > 0)
            {
                // Affichage de la LesCartes des joueurs
                J1.Afficher();
                J2.Afficher();

                // Jouer une carte par joueur
                Carte carteJ1 = J1.Jouer();
                Carte carteJ2 = J2.Jouer();

                // Comparaison des cartes
                int result = carteJ1.Comparer(carteJ2);

                // Attribution des cartes au gagnant
                if (result > 0)
                {
                    Console.WriteLine($"{J1.Nom} remporte la manche!");
                    J1.Vainqueur(new List<Carte> { carteJ1, carteJ2 });
                }
                else if (result < 0)
                {
                    Console.WriteLine($"{J2.Nom} remporte la manche!");
                    J2.Vainqueur(new List<Carte> { carteJ1, carteJ2 });
                }
                else
                {
                    Console.WriteLine("Égalité! Bataille!");
                    // Gérer la bataille en ajoutant plus de cartes à la "pile"
                }

                // Pause pour voir les résultats
                Console.ReadKey();
            }

            // Détermination du gagnant
            if (J1.LesCartes.Count > J2.LesCartes.Count)
            {
                Console.WriteLine($"{J1.Nom} remporte la partie!");
            }
            else if (J1.LesCartes.Count < J2.LesCartes.Count)
            {
                Console.WriteLine($"{J2.Nom} remporte la partie!");
            }
            else
            {
                Console.WriteLine("La partie se termine par une égalité!");
            }

            static List<Carte> Initialize()
            {
                // Implémentation de l'initialisation du jeu de cartes 
                List<Carte> jeuDeCartes = new List<Carte>();
                // Exemple avec un jeu de 52 cartes 
                string[] valeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dame", "Roi", "As" };
                string[] couleurs = { "Coeur", "Carreau", "Trèfle", "Pique" };

                foreach (var valeur in valeurs)
                {
                    foreach (var couleur in couleurs)
                    {
                        jeuDeCartes.Add(new Carte ( valeur, couleur));
                    }
                }

                return jeuDeCartes;
            }

            static void Shuffle(List<Carte> jeuDeCartes)
            {
                // Implémentation du mélange du jeu de cartes 
                Random random = new Random();
                int n = jeuDeCartes.Count;

                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    Carte carte = jeuDeCartes[k];
                    jeuDeCartes[k] = jeuDeCartes[n];
                    jeuDeCartes[n] = carte;
                }
            }

            static void DealCards(List<Carte> jeuDeCartes, List<Carte> Joueur1, List<Carte> Joueur2)
            {
                // Implémentation de la distribution des cartes 
                for (int i = 0; i < jeuDeCartes.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        Joueur1.Add(jeuDeCartes[i]);
                    }
                    else
                    {
                        Joueur2.Add(jeuDeCartes[i]);
                    }
                }
            }
        }
    }
}