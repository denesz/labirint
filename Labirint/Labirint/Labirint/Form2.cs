using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint
{
    public partial class Form2 : Form
    {
        int t = 0, posX = 0, posY = 0, nr=0;
        int dx = 62, dy = 62;
        bool candy1 = false,candy2 = false,candy3 = false, key;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public int[,] harta = new int[8,13] { {0,0,0,0,0,0,1,1,1,0,1,0,0},
                                              {1,1,1,1,1,0,1,1,0,0,0,0,0},
                                              {1,0,0,0,1,0,1,0,0,0,1,1,0},
                                              {1,0,0,0,1,0,1,0,1,0,0,1,0},
                                              {1,0,1,0,1,0,1,0,1,0,0,0,0},
                                              {1,0,1,0,1,0,1,0,1,1,1,1,0},
                                              {1,0,1,0,1,0,0,0,1,0,0,1,0},
                                              {1,0,1,0,0,0,0,0,1,0,0,0,0} 
                                            };
        public Form2()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            label1.Text = t.ToString();
        }
        private bool interior(int x, int y)
        {
            if (y < 0 || y > 7 || x < 0 || x > 12)
                return false;
            return true;
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int x = label2.Location.X;   // pe label2 am pus vrăjitoarea
            int y = label2.Location.Y;
            pictureBox7.Visible = false;
            pictureBox7.Image = Image.FromFile("delicios.gif");
            if (e.KeyCode == Keys.Up)
            {
                label2.Image = Image.FromFile("up.png");
                if (interior(posX, posY - 1) && harta[posY - 1, posX] == 0)
                {
                    posY--;
                    label2.Location = new Point(x, y - dy);
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                label2.Image= Image.FromFile("down.png");
                if (interior(posX, posY + 1) && harta[posY + 1, posX] == 0)
                {
                    label2.Location = new Point(x, y + dy);
                    posY++;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                label2.Image = Image.FromFile("right.png");
                if (interior(posX + 1, posY) && harta[posY, posX + 1] == 0)
                {
                    label2.Location = new Point(x + dx, y);
                    posX++;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                label2.Image = Image.FromFile("left.png");
                if (interior(posX - 1, posY) && harta[posY, posX - 1] == 0)
                {
                    label2.Location = new Point(x - dx, y);
                    posX--;
                }
            } 
           
            if (!candy1 && posX==1 && posY==6)
            {
                candy1 = true;
                nr++;
                pictureBox1.Image = Image.FromFile("patrat_gol.png");
                if(nr==1)
                    pictureBox6.Image = Image.FromFile("1din3.png");
                if (nr == 2)
                    pictureBox6.Image = Image.FromFile("2din3.png");
                if (nr == 3)
                    pictureBox6.Image = Image.FromFile("3din3.png");
                pictureBox7.Visible = true;
            }
            if (!candy2 && posX == 7 && posY == 3)
            {
                candy2 = true;
                nr++;
                pictureBox2.Image = Image.FromFile("patrat_gol.png");
                if (nr == 1)
                    pictureBox6.Image = Image.FromFile("1din3.png");
                if (nr == 2)
                    pictureBox6.Image = Image.FromFile("2din3.png");
                if (nr == 3)
                    pictureBox6.Image = Image.FromFile("3din3.png");
                pictureBox7.Visible = true;
            }
            if (!candy3 && posX == 10 && posY == 6)
            {
                candy3 = true;
                nr++;
                pictureBox3.Image = Image.FromFile("patrat_gol.png");
                if (nr == 1)
                    pictureBox6.Image = Image.FromFile("1din3.png");
                if (nr == 2)
                    pictureBox6.Image = Image.FromFile("2din3.png");
                if (nr == 3)
                    pictureBox6.Image = Image.FromFile("3din3.png");
                pictureBox7.Visible = true;
            }

            if(!key && posX == 11 && posY == 0)
            {
                key = true;
                pictureBox4.Image = Image.FromFile("fara_cheie.png");
                pictureBox5.Image = Image.FromFile("odoor.png");
            }

            if(key && posX == 9 && posY == 0)
            {
                this.Hide();
                Form3 f = new Form3();
                f.Show();
            }
        }
    }      
}
