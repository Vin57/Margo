using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;           // pour le dessin
using System.Drawing.Drawing2D; // pour le dessin
using System.Collections;       // pour arraylist
using System.Media;             // pour sons

namespace Marguerite
{
    class Professeur
    {
        private const int MAX_REBUT = 8;    // nombre maximum de lettres au rebut


        private Point positionMot = new Point(0, 0);               // position du mot
        private Point positionRebut = new Point(0, 0);          // position des lettres au rebut
        private Font policeMot = new Font("Times New Roman", 24);
        private Font policeRebut = new Font("Times New Roman", 18);

        // sons
        private SoundPlayer sonLettreAuRebut = new SoundPlayer(Marguerite.Properties.Resources.ding);
        private SoundPlayer sonLettreTrouvee = new SoundPlayer(Marguerite.Properties.Resources.tada);
        private SoundPlayer sonGagne = new SoundPlayer(Marguerite.Properties.Resources.APPLAUSE);
        private SoundPlayer sonPerdu = new SoundPlayer(Marguerite.Properties.Resources.ringout);

        private Fleur margo;                     // la fleur 
        private Dictionnaire dico;               // le dictionnaire
        private Mot motComplet;                  // Le mot et son score
        private string leMotCherche;             // le mot à chercher en majuscules
        private bool[] lesLettres;               // tableau de booléen indiquant quelles lettres ont été trouvées
        private ArrayList lesLettresAuRebut = new ArrayList();  // liste des lettres au rebut
        private int nbLettresTrouvees;
        private int nombreErreurs;
        private int nbParties;

        public int NombreErreurs
        {
            get { return nombreErreurs; }
            set { nombreErreurs = value; }
        }

        // Constructeur
        public Professeur(Fleur uneFleur, Dictionnaire unDico)
        {
            margo = uneFleur;
            dico = unDico;
            Demarrer();
        }


        // Methodes
        // initialisation des variables de travail utilisées pour la gestion d'un mot
        public void Demarrer()
        {
            motComplet = dico.DonnerMot();
            leMotCherche = motComplet.Contenu.ToUpper();
            nombreErreurs = 0;
            nbLettresTrouvees = 0;
            lesLettresAuRebut.Clear();
            lesLettres = new bool[leMotCherche.Length];
            for (int i = 0; i < leMotCherche.Length; i++)
            {
                lesLettres.SetValue(false, i);
            }
        }


        // procédure
        public void SetPositionMot(int x, int y)
        {
            positionMot.X = x;
            positionMot.Y = y;
        }

        public void SetPositionRebut(int x, int y)
        {
            positionRebut.X = x;
            positionRebut.Y = y;
        }

        // chercher la lettre dans le mot à trouver
        // si la lettre est trouvée, l'enregistrer et émettre le son correspondant
        // sinon, incrémenter le nombre d'erreurs et mettre la lettre au rebut
        // si mot entièrement trouvé, alors émettre le son correspondant et mettre à jour le score 
        // si nombre maximum d'erreurs atteint, alors émettre le son correspondant
        public void Executer(char uneLettre)
        {
            int nbCharTrouve = 0;
            for (int i = 0; i < leMotCherche.Length; i++)
            {
                if (uneLettre == leMotCherche[i])
                {
                    if (!lesLettres[i])
                    {
                        lesLettres.SetValue(true, i);
                        sonLettreTrouvee.Play();
                        nbCharTrouve += 1;
                        nbLettresTrouvees += 1;
                    }
                }
            }
            if (nbCharTrouve == 0)
            {
                lesLettresAuRebut.Add(uneLettre);
                nombreErreurs++;
                sonLettreAuRebut.Play();
            }
            if (Gagner)
            {
                sonGagne.Play();
                dico.AjouterScore(motComplet.NbPoints);
            }
            if (Perdre)
            {
                sonPerdu.Play();
            }
        }

        public string MotAfficher()
        {
            string mot = "";
            for (int i = 0; i < leMotCherche.Length; i++)
            {
                if (lesLettres[i] == false)
                {
                    mot += "_";
                }
                else
                {
                    mot += leMotCherche[i]; ;
                }
            }
            return mot;
        }





        // vrai si toutes les lettre du mot ont été trouvées
        public bool Gagner
        {
            // nbLettresTrouvees est incrémenter à chaque lettres trouvé par le joueur
            // leMotCherche est le mot représenter par des _ pour les caractéres non trouvé et les lettres
            // en position i ou i et la position de la lettre trouvé
            get { return nbLettresTrouvees == leMotCherche.Length; }
        }
        // vrai si maximum de lettres au rebut atteint
        public bool Perdre
        {
            get { return lesLettresAuRebut.Count == MAX_REBUT; }

        }

        public string LeMotCherche
        {
            get
            {
                return leMotCherche;
            }

            set
            {
                leMotCherche = value;
            }
        }


        // dessiner le mot à chercher avec _ ou lettre
        // dessiner les lettres au rebut
        // dessiner les messages "Tu as gagné !" ou « Tu as perdu !"
        // dessiner la question "Veux-tu continuer (O/N) ?"
        public void Dessiner(Graphics g)
        {
            SolidBrush ploum = new SolidBrush(Color.Plum);
            Font police = new Font("Times New Roman", 24);
            string motAffiche = "";
            // construire le mot à afficher (motAffiche)
            for (int i = 0; i < lesLettres.Length; i++)
            {
                if (lesLettres[i] == false)
                {
                    motAffiche += "_ ";
                }
                else
                {
                    motAffiche += leMotCherche[i] + " ";
                }
            }
            g.DrawString(motAffiche, police, ploum, positionMot);
            string rebus = "Erreur : ";
            for (int a = 0; a < lesLettresAuRebut.Count; a++)
            {
                rebus += lesLettresAuRebut[a];
                g.DrawString(Convert.ToString(lesLettresAuRebut[a]), police, new SolidBrush(Color.Orange), 0, positionMot.Y - 40 + (a * 25));
            }
            // g.DrawString(rebus, police, new SolidBrush(Color.Orange), 40, positionMot.Y -40);

            if (Gagner || Perdre)
            {
                nbParties += 1;

                Continuer(g);
                if (Gagner == true)
                {
                    g.DrawString("Vous avez gagné ! +" + motComplet.NbPoints + " Points !", police, new SolidBrush(Color.Green), positionMot.X + 300, positionMot.Y + 50);
                }
                else
                {
                    g.DrawString("Vous avez perdu !", police, new SolidBrush(Color.Red), positionMot.X + 300, positionMot.Y + 50);
                    g.DrawString("Le mot à trouver était : " + LeMotCherche, police, new SolidBrush(Color.Black), positionMot.X + 200, positionMot.Y + 100);
                }

            }
            //g.DrawString(" / " + Convert.ToString(nbParties) + " Parties", new Font("Arial", 12), new SolidBrush(Color.Green),
            //      900, 40);
            // Peut être utile lors du développement //
            /*string nbErreur = Convert.ToString(nombreErreurs);
            g.DrawString(nbErreur, police, ploum, positionMot.X + 200, positionMot.Y + 150);*/
        }

        // dessiner la question "Veux-tu continuer (O/N) ?"
        public void Continuer(Graphics g)
        {
            Font police = new Font("Arial", 24);
            g.DrawString("Veux tu continuer (0/N) ?", police, new SolidBrush(Color.Black), positionMot.X + 250/*Pour descendre la position du mot par rapport aux mot à chercher*/, positionMot.Y + 150);
        }
    }
}
