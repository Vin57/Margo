using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marguerite
{
    class Theme
    {
        private string nom;

        // List représente une liste (collection) fortement typée 
        private List<Mot> lesMots = new List<Mot>();

        public Theme(string unNom)
        {
            nom = unNom;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public List<Mot> LesMots
        {
            get { return lesMots; }
            set { lesMots = value; }
        }

        // calculer la valeur du thème. Elle correspond
        //     à la somme des nombres de points des mots du thème
        public int Valeur
        {
            get
            {
                int laValeur = 0;
                foreach (Mot m in lesMots)
                    laValeur += m.NbPoints;
                return laValeur;
            }
        }

    }
}
