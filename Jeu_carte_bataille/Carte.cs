using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_carte_bataille
{
    internal class Carte
    {
        private string valeur;
        private string couleur;

        public string Valeur { get => valeur; set => valeur = value; }
        public string Couleur { get => couleur; set => couleur = value; }

        public Carte(string valeurCarte, string couleurCarte)
        {
            this.valeur = valeurCarte;
            this.couleur = couleurCarte;
        }


        public int Comparer(Carte autreCarte) // Comparaison basée sur la valeur des carte
        {
            string[] valeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dame", "Roi", "As" };
            int indiceCetteCarte = Array.IndexOf(valeurs, this.valeur);
            int indiceAutreCarte = Array.IndexOf(valeurs, autreCarte.valeur);

            return indiceCetteCarte - indiceAutreCarte;
        }


        public override string ToString()
        {
            return this.valeur + " - " + this.couleur.ToString();
        }

    }
}
