using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marguerite
{
    class Mot
    {
        private string contenu;
        private int nbPoints;

        public Mot(string unMot, int unNbPoints)
        {
            contenu = unMot;
            nbPoints = unNbPoints;
        }

        public string Contenu
        {
            get { return contenu; }
            set { contenu = value; }
        }

        public int NbPoints
        {
            get { return nbPoints; }
            set { nbPoints = value; }
        }

    }
}
