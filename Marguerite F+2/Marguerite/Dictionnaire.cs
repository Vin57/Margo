using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;           // pour le dessin
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;

namespace Marguerite
{
    class Dictionnaire
    {
        // position pour affichage score
        private Point position = new Point(0, 0);
        //générateur de nombres pseudo-aléatoires
        private Random leHasard;
        // score
        private int score;

        // dictionnaire des mots
        private List<Mot> lesMots = new List<Mot>();

        // les thèmes chargées à partir de la base
        private List<Theme> lesThemes = new List<Theme>();
        // le numéro de thème (index) sélectionné par l'utilisateur
        //  ou -1 si aucun thème n'a été sélectionné
        private int numeroThemeSelectionne;

        public int NumeroThemeSelectionne
        {
            set { numeroThemeSelectionne = value; }
        }

        
        // constructeur
        public Dictionnaire()
        {
            leHasard = new Random();
            LireThemes();
            score = 0;
            // Par défaut
            numeroThemeSelectionne = -1;
        }

        public Mot DonnerMot()
        {
            if (numeroThemeSelectionne == -1)
            {
                // la méthode Next retourne un nombre aléatoire non négatif, inférieur au nombre maximal spécifié
                int indHasard = leHasard.Next(lesThemes.Count);
                Theme unTheme = lesThemes[indHasard];
                int motHasard = leHasard.Next(unTheme.LesMots.Count);
                return unTheme.LesMots[motHasard];
            }
            // Si on à selectionné un théme
            else
            {
                Theme unTheme = lesThemes[numeroThemeSelectionne];
                int motHasard = leHasard.Next(unTheme.LesMots.Count);
                return unTheme.LesMots[motHasard];
            }
        }

        public void ChargerThemes(System.Windows.Forms.ToolStripComboBox toolStripComboBoxThemes)
        {
            foreach (Theme unTheme in lesThemes)
            {
                // Items est la collection d'objets (ici des string) contenus dans la liste déroulante toolStripComboBoxThemes
                toolStripComboBoxThemes.Items.Add(unTheme.Nom);
            }
        }

        private void LireMots()
        {
            string chaineConnexion = "Database=Marguerite;Data Source=localhost;User Id=root;Password=";

            try
            {
                MySqlConnection connexion = new MySqlConnection(chaineConnexion);
                string query = "SELECT * FROM Mots";
                MySqlCommand exec = new MySqlCommand(query, connexion);

                connexion.Open();

                MySqlDataReader curseur = exec.ExecuteReader();

                while (curseur.Read())
                {
                    string mot = Convert.ToString(curseur[1]);
                    int nbPoints = Convert.ToInt32(curseur[2]);
                    Mot unMot = new Mot(mot, nbPoints);
                    lesMots.Add(unMot);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        private void LireThemes()
        {
            string chaineConnexion = "Database=Marguerite;Data Source=localhost;User Id=root;Password=";

            try
            {
                MySqlConnection connexion = new MySqlConnection(chaineConnexion);
                string query = "SELECT * FROM Themes;";
                MySqlCommand exec = new MySqlCommand(query, connexion);

                connexion.Open();

                MySqlDataReader curseur = exec.ExecuteReader();

                while (curseur.Read())
                {

                    // On créé le théme
                    int idTheme = Convert.ToInt32(curseur[0]);
                    string nomTheme = Convert.ToString(curseur[1]);
                    Theme unTheme = new Theme(nomTheme);
                    // On ajoute notre théme
                    lesThemes.Add(unTheme);
                }
                curseur.Close();
                connexion.Close();
                foreach (Theme unTheme in lesThemes)
                {
                    MySqlConnection connect = new MySqlConnection(chaineConnexion);
                    string requete = "SELECT * FROM Mots INNER JOIN Themes ON Themes.idTheme = Mots.idThemeMot WHERE nomTheme = " + "'" + unTheme.Nom + "'";
                    // string requete = "SELECT [idMot],[contenuMot],[nbPointsMot],[idThemeMot] FROM [Marguerite].[dbo].[Mots] INNER JOIN [Marguerite].[dbo].[Themes] ON [Themes].idTheme = [Mots].idThemeMot WHERE idTheme = " + idTheme;
                    MySqlCommand executer = new MySqlCommand(requete, connect);
                    connect.Open();

                    MySqlDataReader courseur = executer.ExecuteReader();

                    while (courseur.Read())
                    {
                        string mot = Convert.ToString(courseur[1]);
                        int nbPoints = Convert.ToInt32(courseur[2]);
                        Mot unMot = new Mot(mot, nbPoints);
                        unTheme.LesMots.Add(unMot);
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


        public void AjouterScore(int nbPoints)
        {
            score += nbPoints;
        }

        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public void Dessiner(Graphics g)
        {
            g.DrawString("Score  : " + score, new Font("Arial", 12), new SolidBrush(Color.Green),
                  position.X, position.Y);
        }



    }
}
