using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using BiBlioControles;


namespace Marguerite
{
    partial class fmMarguerite : Form
    {
        private Fleur margo;
        private Dictionnaire dico;
        private Professeur prof;

        public Professeur Prof
        {
            get { return prof; }
        }

        public fmMarguerite()
        {
            InitializeComponent();            

            // créer la fleur et donner sa position
            margo = new Fleur();
            margo.SetPosition(380, 310);

            // créer le dictionnaire et donner sa position
            dico = new Dictionnaire();
            dico.SetPosition(this.ClientRectangle.Right - 200, this.ClientRectangle.Top + 40);

            // instancier la classe professeur pour créer l'objet prof
            prof = new Professeur(margo, dico);
            prof.SetPositionMot(120, 120);
            prof.SetPositionRebut(this.ClientRectangle.Right - 220, this.ClientRectangle.Bottom - 30);
            // chargement des thèmes dans la comboBox de la barre d'outils
            dico.ChargerThemes(toolStripComboBoxThemes);
            // par défaut, aucun thème sélectionné d'où le -1
            toolStripComboBoxThemes.SelectedIndex = -1; // provoque démarrage jeu dans themesComboBox_SelectedIndexChanged
            // par défaut le bouton Annuler est inactif
            toolStripButtonAnnulerTheme.Enabled = false;
            // par défaut la liste des thèmes est inactive
            toolStripComboBoxThemes.Enabled = false;

            this.Invalidate();
        }

        private void fmMarguerite_Paint_1(object sender, PaintEventArgs e)
        {
            // créer le graphique correspondant au formulaire  
            Graphics g = this.CreateGraphics();
            // dessiner la fleur
            margo.Dessiner(g, prof.NombreErreurs);
            // dessiner le score
            dico.Dessiner(g);
            // dessiner le jeu
            prof.Dessiner(g);
        }
        private void fmMarguerite_KeyPress(object sender, KeyPressEventArgs e)
        {

            // récupérer le caractère tapé
            char unCar = e.KeyChar;
            string majCar = unCar.ToString().ToUpper();
            unCar = majCar[0];
            // traiter les deux cas :
            //  cas où on attend la réponse à la question Veux-tu continuer (on a gagné ou perdu)

            if (prof.Gagner || prof.Perdre)
            {
                if (unCar == 'O')
                {
                    prof.Demarrer();
                }
                if (unCar == 'N')
                {
                    Application.Exit();
                }
            }
            else
            {
                prof.Executer(unCar);
            }

            // pour repeindre le formulaire
            this.Invalidate();
        }

        private void toolStripButtonChoisirTheme_Click(object sender, EventArgs e)
        {
            toolStripComboBoxThemes.Enabled = true;
            toolStripButtonAnnulerTheme.Enabled = true;
        }

        private void toolStripComboBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxThemes.SelectedIndex == -1)
                toolStripButtonAnnulerTheme.Enabled = false;
            else
                toolStripButtonAnnulerTheme.Enabled = true;

            // une fois un thème sélectionné, on désactive la liste pour que l'IHM soit claire pour l'utilisateur
            dico.NumeroThemeSelectionne = toolStripComboBoxThemes.SelectedIndex;
            toolStripComboBoxThemes.Enabled = false;
            // on redémarre un jeu
            prof.Demarrer();
            this.Invalidate();
            this.Focus();
        }

        private void toolStripButtonAnnulerTheme_Click(object sender, EventArgs e)
        {
            // on n'affiche aucun thème dans la liste déroulante
            toolStripComboBoxThemes.SelectedIndex = -1;  
            // on désactive le bouton Annuler
            toolStripButtonAnnulerTheme.Enabled = false;

        }

        private void arbreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // afficher le formulaire pour le jeu 'Compter'
            fmCompter fm = new fmCompter();
            fm.Show();
        }

        private void traduireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
        }

        private void motDePasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmMotDePasse fmPass = new FmMotDePasse();
            fmPass.ShowDialog();
        }
        

    }
}
