using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Marguerite
{
    class Fleur
    {
        public const int COEFF = 100 / 100;
        public const int DIAMETRE_TETE = 80 * COEFF;
        public const int LARGEUR_PETALE = DIAMETRE_TETE;
        public const int LONGUEUR_PETALE = LARGEUR_PETALE * 2;
        public const int DECAL = 30;    // décalage pour pétales de la couronne extérieure
        private Point position = new Point(0, 0);
        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }
        public void Dessiner(Graphics g, int nbErreur)
        {
            Pen crayonInterieur = new Pen(System.Drawing.Color.Red, 3);
            Pen crayonExterieur = new Pen(System.Drawing.Color.Red, 3);
            Pen crayonOeil = new Pen(System.Drawing.Color.White, 8);
            Pen crayonBouche = new Pen(System.Drawing.Color.Pink, 5);
            Pen crayonTige = new Pen(System.Drawing.Color.Green, 6);
            SolidBrush brosseInterieur = new System.Drawing.SolidBrush(System.Drawing.Color.Pink);
            SolidBrush brosseExterieur = new System.Drawing.SolidBrush(System.Drawing.Color.Pink);
            SolidBrush brosseTete = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            SolidBrush brosseOeil = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            SolidBrush brosseIntOeil = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            //pétales extérieur
            if (nbErreur < 1)
            {
                g.FillEllipse(brosseExterieur, position.X, position.Y - LARGEUR_PETALE + DECAL, LARGEUR_PETALE, LONGUEUR_PETALE); //1
                g.DrawEllipse(crayonExterieur, position.X, position.Y - LARGEUR_PETALE + DECAL, LARGEUR_PETALE, LONGUEUR_PETALE); //1
            }
            if (nbErreur < 2)
            {
                g.FillEllipse(brosseExterieur, position.X - LARGEUR_PETALE + DECAL, position.Y, LONGUEUR_PETALE, LARGEUR_PETALE); //2
                g.DrawEllipse(crayonExterieur, position.X - LARGEUR_PETALE + DECAL, position.Y, LONGUEUR_PETALE, LARGEUR_PETALE); //2
            }
            if (nbErreur < 3)
            {
                g.FillEllipse(brosseExterieur, position.X, position.Y, LARGEUR_PETALE, LONGUEUR_PETALE - DECAL); //3
                g.DrawEllipse(crayonExterieur, position.X, position.Y, LARGEUR_PETALE, LONGUEUR_PETALE - DECAL); //3 
            }
            if (nbErreur < 4)
            {
                g.FillEllipse(brosseExterieur, position.X, position.Y, LONGUEUR_PETALE - DECAL, LARGEUR_PETALE); //4
                g.DrawEllipse(crayonExterieur, position.X, position.Y, LONGUEUR_PETALE - DECAL, LARGEUR_PETALE); //4
            }

            //pétales intérieur
            if (nbErreur < 5)
            {
                g.FillEllipse(brosseInterieur, position.X + LARGEUR_PETALE / 2, position.Y + LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //5
                g.DrawEllipse(crayonInterieur, position.X + LARGEUR_PETALE / 2, position.Y + LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //5
            }
            if (nbErreur < 6)
            {
                g.FillEllipse(brosseInterieur, position.X + LARGEUR_PETALE / 2, position.Y - LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //6
                g.DrawEllipse(crayonInterieur, position.X + LARGEUR_PETALE / 2, position.Y - LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //6
            }
            if (nbErreur < 7)
            {
                g.FillEllipse(brosseInterieur, position.X - LARGEUR_PETALE / 2, position.Y - LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //7
                g.DrawEllipse(crayonInterieur, position.X - LARGEUR_PETALE / 2, position.Y - LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //7 
            }
            if (nbErreur < 8)
            {
                g.FillEllipse(brosseInterieur, position.X - LARGEUR_PETALE / 2, position.Y + LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //8
                g.DrawEllipse(crayonInterieur, position.X - LARGEUR_PETALE / 2, position.Y + LARGEUR_PETALE / 2, LARGEUR_PETALE, LARGEUR_PETALE); //8
            }



            //tête et visage
            g.FillEllipse(brosseTete, position.X, position.Y, DIAMETRE_TETE, DIAMETRE_TETE);
            g.FillEllipse(brosseOeil, position.X + DIAMETRE_TETE / 5, position.Y + DIAMETRE_TETE / 4, 15, 15);
            g.FillEllipse(brosseOeil, position.X + DIAMETRE_TETE - 15 - DIAMETRE_TETE / 5, position.Y + DIAMETRE_TETE / 4, 15, 15);
            g.FillEllipse(brosseIntOeil, 8 + position.X + DIAMETRE_TETE / 5, 4 + position.Y + DIAMETRE_TETE / 4, 4, 4);
            g.FillEllipse(brosseIntOeil, 8 + position.X + DIAMETRE_TETE - 15 - DIAMETRE_TETE / 5, 4 + position.Y + DIAMETRE_TETE / 4, 4, 4);

            if (nbErreur < 4)
            {
                g.DrawArc(crayonBouche, position.X + (DIAMETRE_TETE / 3), position.Y + (DIAMETRE_TETE / 3) + (DIAMETRE_TETE / 8), 30, 30, 0, 180);
            }
            else
            {
                if (nbErreur < 6)
                {
                    g.DrawArc(crayonBouche, position.X + (DIAMETRE_TETE / 3), position.Y + (DIAMETRE_TETE / 3) + (DIAMETRE_TETE / 8), 30, 30, 0, 120);
                }
                else
                {
                    g.DrawArc(crayonBouche, position.X + (DIAMETRE_TETE / 3), position.Y + (DIAMETRE_TETE / 3) + (DIAMETRE_TETE / 8), 30, 30, 0, -180);
                }
            }


            // libérer les ressources système
            crayonInterieur.Dispose();
            crayonExterieur.Dispose();
            crayonOeil.Dispose();
            crayonBouche.Dispose();
            brosseInterieur.Dispose();
            brosseExterieur.Dispose();
            brosseTete.Dispose();
            brosseOeil.Dispose();
            brosseIntOeil.Dispose();
        }


    }
}
