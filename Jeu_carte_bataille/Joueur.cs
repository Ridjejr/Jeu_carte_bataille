using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_carte_bataille
{
    internal class Joueur
    {
        private string nom;
        private string prenom;
        private List<Carte> lesCartes = new List<Carte>();

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        internal List<Carte> LesCartes { get => lesCartes; set => lesCartes = value; }

        public Joueur(string nomJoueur, string prenomJoueur)
        {
            this.nom = nomJoueur;
            this.prenom = prenomJoueur;
            lesCartes = new List<Carte>();
        }


        public Carte Jouer()
        {
            if (lesCartes.Count > 0)
            {
                // Vérifie si le joueur à au moins 1 carte dans sa main
                Carte carteJouee = lesCartes[0];
                lesCartes.RemoveAt(0);
                return carteJouee;
            }
            else
            {
                // Le joueur n'a plus de cartes à jouer
                return null; 
            }
        }

        public void Vainqueur(List<Carte> lesCartes) 
        {
            // Récupère les cartes gagné lors d'une bataille
            lesCartes.AddRange(lesCartes);
        }

        public bool Afficher()
        {
            Console.WriteLine( this.nom + " a les cartes suivantes dans sa main:");
            int i = 0;
            Console.WriteLine(lesCartes[0]);
            return LesCartes.Count > 0;
        }


    }
}
