using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marguerite
{
    public partial class fmCompter : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer(); // Temps pour affiché img gagné/perdu

        Random leHasard = new Random();
        int nbPomme;
        public fmCompter()
        {
            InitializeComponent();
            toolStripButton1.Visible = false;
            nbPomme = leHasard.Next(1, 12);
            GenerePomme();
            toolStripTextBox1.Select(); // Focus une fois cliqué
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            myTimer.Tick += Mytimer_Tick;
            myTimer.Interval = 5000;
            toolStripTextBox1.Enabled = false;
            if (toolStripTextBox1.Text == Convert.ToString(nbPomme - 1))
            {
                pictureBox13.Visible = true;
                pictureBox13.BringToFront();
                myTimer.Start();
            }
            else
            {
                pictureBox14.Visible = true;
                pictureBox14.BringToFront();
                myTimer.Start();
            }
        }

        public void Mytimer_Tick(object sender, EventArgs args)
        {
            myTimer.Stop();
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;

            nbPomme = leHasard.Next(1, 11);
            InitZone();
            toolStripTextBox1.Text = "";
            GenerePomme();
            toolStripButton1.Visible = false;
            toolStripTextBox1.Enabled = true;
        }

        public void InitZone()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
        }

        public void GenerePomme()
        {
            switch (nbPomme)
            {
                case 1:
                    pictureBox1.Visible = true;
                    break;
                case 2:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    break;
                case 3:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    break;
                case 4:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    break;
                case 5:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    break;
                case 6:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    break;
                case 7:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = true;
                    break;
                case 8:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = true;
                    pictureBox8.Visible = true;
                    break;
                case 9:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = true;
                    pictureBox8.Visible = true;
                    pictureBox9.Visible = true;
                    break;
                case 10:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = true;
                    pictureBox8.Visible = true;
                    pictureBox9.Visible = true;
                    pictureBox10.Visible = true;
                    break;
                case 11:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = true;
                    pictureBox8.Visible = true;
                    pictureBox9.Visible = true;
                    pictureBox10.Visible = true;
                    pictureBox11.Visible = true;
                    break;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged_1(object sender, EventArgs e)
        {

            if (toolStripTextBox1.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(toolStripTextBox1.Text) > 12)
                    {
                        toolStripTextBox1.Text = "12";
                    }
                    toolStripButton1.Visible = true;
                }
                catch
                {
                    toolStripButton1.Visible = false;
                    toolStripTextBox1.Text = "";
                }

            }
            else
            {
                toolStripButton1.Visible = false;
            }
        }
    }
}
