using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;           // pour le dessin
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marguerite
{
    partial class FmMotDePasse : Form
    {
        List<Password> lesMotDePasse = new List<Password>();// La liste des mots de passe créé à partir de la BD
        Random leHasard = new Random();
        int countPassword = 0;// Le nombre de mdp dans la BD
        int pwdSelect;// Le mot de passe à chercher
        int erreur = 0;// Le nombre d'erreur
        public FmMotDePasse()
        {
            InitializeComponent();
            GameInit();
            GameStart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == lesMotDePasse[pwdSelect].GetPassword)
            {
                MessageBox.Show("Vous vous êtes correctement authentifié ! Bienvenue !", "Vous avez gagné ! ");
                GameStart();
            }
            else
            {
                erreur += 1;
                switch (erreur)
                {
                    case 1:
                        label3.Text = "Indication de mot de passe N° 2 : " + lesMotDePasse[pwdSelect].GetLesIndication[erreur];
                        label1.Text = "Entrer mot de passe (5 essais)";
                        break;
                    case 2:
                        label4.Text = "Indication de mot de passe N° 3 : " + lesMotDePasse[pwdSelect].GetLesIndication[erreur];
                        label1.Text = "Entrer mot de passe (4 essais)";
                        break;
                    case 3:
                        label1.Text = "Entrer mot de passe (3 essais)";
                        break;
                    case 4:
                        label1.Text = "Entrer mot de passe (2 essais)";
                        break;
                    case 5:
                        label1.Text = "Entrer mot de passe (1 essai)";
                        break;
                    case 6:
                        label1.Text = "Entrer mot de passe (0 essai)";
                        MessageBox.Show("Vous avez perdu ! ", "Alert ! ");
                        GameStart();
                        break;

                }
            }
        }

        public void GameInit()
        {
            string chaineConnexion = "Database=Marguerite;Data Source=localhost;User Id=root;Password=";

            try
            {

                MySqlConnection connexion = new MySqlConnection(chaineConnexion);
                string query = "SELECT * FROM Password;";
                MySqlCommand exec = new MySqlCommand(query, connexion);

                connexion.Open();

                MySqlDataReader curseur = exec.ExecuteReader();

                while (curseur.Read())
                {
                    // On créé le mot de passe
                    int id_password = Convert.ToInt32(curseur[0]);
                    string mdp = Convert.ToString(curseur[1]);
                    Password unPassword = new Password(id_password, mdp);
                    lesMotDePasse.Add(unPassword);

                    countPassword += 1;
                }

                curseur.Close();
                connexion.Close();

                foreach (Password unPassword in lesMotDePasse)
                {
                    MySqlConnection connect = new MySqlConnection(chaineConnexion);
                    string requete = "SELECT * FROM Password INNER JOIN Indication_MDP ON Password.id_password = Indication_MDP.id_password WHERE Password.id_password = " + "'" + unPassword.GetIdPassword + "'";
                    MySqlCommand executer = new MySqlCommand(requete, connect);
                    connect.Open();

                    MySqlDataReader courseur = executer.ExecuteReader();

                    while (courseur.Read())
                    {
                        string indication = Convert.ToString(courseur[4]);

                        unPassword.GetLesIndication.Add(indication);
                    }
                    connect.Close();
                    courseur.Close();
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void GameStart()
        {

            // Aucune erreur 
            erreur = 0;
            // Aucune indication

            label2.Text = "Indication de mot de passe N° 1 : ";
            label3.Text = "Indication de mot de passe N° 2 : ";
            label4.Text = "Indication de mot de passe N° 3 : ";
            label1.Text = "Entrer mot de passe (6 essais)";


            pwdSelect = leHasard.Next(0, countPassword-1);


           label2.Text = "Indication de mot de passe N° 1 : " + lesMotDePasse[pwdSelect].GetLesIndication[0];

            textBox1.Text = "";
        }
    }
}
