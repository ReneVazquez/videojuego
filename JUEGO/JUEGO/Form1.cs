using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUEGO
{
    public partial class Avioncitos : Form
    {
        public Avioncitos()
        {
            InitializeComponent();

            enemy1.Top = -500;
            enemy2.Top = -900;
            enemy3.Top = -1300;
            bullet.Top = -100;
            bullet.Left = -100;
        }

        //variables del juego
        int moveLeft = 0;
        int enemyMove = 5;
        Random rnd = new Random();
        int bulletSpeed = 8;
        bool shooting = false;
        int score = 0;

        //metodo para cuando una bala le da a un enemigo
        private void enemyHit()
        {
            if (bullet.Bounds.IntersectsWith(enemy1.Bounds))
            {
                score += 1;
                enemy1.Top = -500;
                int ranP = rnd.Next(1, 300);
                enemy1.Left = ranP;
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }

            else if (bullet.Bounds.IntersectsWith(enemy2.Bounds))
                {
                    score += 1;
                    enemy2.Top = -900;
                    int ranP = rnd.Next(1, 400);
                    enemy2.Left = ranP;
                    shooting = false;
                    bulletSpeed = 0;
                    bullet.Top = -100;
                    bullet.Left = -100;
                }

            else if (bullet.Bounds.IntersectsWith(enemy3.Bounds))
            {
                score += 1;
                enemy3.Top = -1300;
                int ranP = rnd.Next(1, 500);
                enemy3.Left = ranP;
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }
        }

        // DialogResult res;

        private void gameOver()
        {
            playTimer.Enabled = false;
            MessageBox.Show("Tu puntuacion es = " + score +
                "\nHaz click en OK para jugar de nuevo", "Puntaje"/*, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation*/);
            score = 0;
            scoreText.Text = score.ToString();
            enemy1.Top = -500;
            enemy2.Top = -900;
            enemy3.Top = -1300;
            bullet.Top = -100;
            bullet.Left = -100;
            playTimer.Enabled = true;
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                if (player.Location.X < 0)
                {
                    moveLeft = 0;
                }
                else
                {
                    moveLeft = -5;
                }
            }

            else if(e.KeyCode == Keys.Right)
            {
                if (player.Location.X > 512)
                {
                    moveLeft = 0;
                }
                else
                {
                    moveLeft = 5;
                }
            }

            else if (e.KeyCode == Keys.Space)
            {
                if (shooting == false)
                {
                    bulletSpeed = 8;
                    bullet.Left = player.Left + 50;
                    bullet.Top = player.Top;
                    shooting = true;
                }
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = 0;
            }

            else if (e.KeyCode == Keys.Right)
            {
                moveLeft = 0;
            }
        }

        private void playTimer_Tick(object sender, EventArgs e)
        {
            player.Left += moveLeft;
            bullet.Top -= bulletSpeed;
            enemy1.Top += enemyMove;
            enemy2.Top += enemyMove;
            enemy3.Top += enemyMove;
            scoreText.Text = "" + score;

            if (enemy1.Top == 660 || enemy2.Top == 660 || enemy3.Top == 660)
            {
                gameOver();
            }

            if (shooting && bullet.Top < 0)
            {
                shooting = false;

                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }

            enemyHit();
        }
    }
}
