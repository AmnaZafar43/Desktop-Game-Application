using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace game
{
    public partial class level2 : Form
    {
        int playerHealth = 3;
        PictureBox player;
        PictureBox bullet;
        PictureBox enemy;
        int score = 0;
        string enemyDirection;

        public level2()
        {
            InitializeComponent();
        }

        private void level2_Load(object sender, EventArgs e)
        {
            addPlayer();
            addEnemy();
        }

        private void tmrLevel2_Tick(object sender, EventArgs e)
        {
            lblLivesLevel2.Text = "Total Lives : " + playerHealth.ToString();
            lblScore.Text = "Total Score = " + score;
            movePlayer();
            moveEnemy();
            detectCollision();
            loseHealth();
            nextPart();
            eatTrophie();
            detectBrickCollision();
            collidewithEnemey();
            loseGame();
        }

        private void collidewithEnemey()
        {
            if(player.Bounds.IntersectsWith(enemy.Bounds))
            {
                playerHealth--;
                player.Location = new System.Drawing.Point(80, 610);
            }
        }

        private void moveEnemy()
        {
            if(enemyDirection == "left")
            {
                enemy.Left -= 10;
            }
            if(enemyDirection == "right")
            {
                enemy.Left += 10;
            }
            if(enemy.Bounds.IntersectsWith(picnewExit.Bounds))
            {
                enemyDirection = "left";
            }
            if (enemy.Bounds.IntersectsWith(picB1.Bounds))
            {
                enemyDirection = "right";
            }
        }

        private void detectBrickCollision()
        {
            if (picsb1.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;

            }
            if (picsb2.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb3.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb4.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb5.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb6.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb7.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb8.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb9.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb10.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
            if (picsb11.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
        }

        private void eatTrophie()
        {
            if (player.Bounds.IntersectsWith(picTrophie.Bounds))
            {
               picTrophie.Visible = false;
               score = score + 5;
            }
        }

        private void nextPart()
        {
            if (player.Bounds.IntersectsWith(picnewExit.Bounds) && Keyboard.IsKeyPressed(Key.RightArrow))
            {
                this.Hide();
                level2_part2_ myForm = new level2_part2_();
                myForm.ShowDialog();
                tmrLevel2.Interval = 0;
            }
        }

        private void loseGame()
        {
            if(playerHealth == 0 && Keyboard.IsKeyPressed(Key.LeftArrow) || playerHealth == 0 && Keyboard.IsKeyPressed(Key.RightArrow) || playerHealth == 0 && Keyboard.IsKeyPressed(Key.UpArrow)|| playerHealth == 0 && Keyboard.IsKeyPressed(Key.DownArrow))
            {
                tmrLevel2.Enabled = false;
                this.Hide();
                lose myForm = new lose();
                myForm.ShowDialog();
                //tmrLevel2.Interval = 0;
            }
        }

        private void loseHealth()
        {
            if(player.Bounds.IntersectsWith(picFire1.Bounds))
            {
                playerHealth--;
                player.Location = new System.Drawing.Point(80,610);
            }
        }

        private void detectCollision()
        {
            if (picD1.Bounds.IntersectsWith(player.Bounds))
            {
                picD1.Visible = false;
                score++;
            }
            if (picD2.Bounds.IntersectsWith(player.Bounds))
            {
                picD2.Visible = false;
                score++;
            }
            if (picD3.Bounds.IntersectsWith(player.Bounds))
            {
                picD3.Visible = false;
                score++;
            }
            if (picD4.Bounds.IntersectsWith(player.Bounds))
            {
                picD4.Visible = false;
                score++;
            }
            if (picD5.Bounds.IntersectsWith(player.Bounds))
            {
                picD5.Visible = false;
                score++;
            }
            if (picD6.Bounds.IntersectsWith(player.Bounds))
            {
                picD6.Visible = false;
                score++;
            }
            if (picD7.Bounds.IntersectsWith(player.Bounds))
            {
                picD7.Visible = false;
                score++;
            }
        }

        private void movePlayer()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.Image = Properties.Resources.run1;
                player.Left = player.Left + 20;
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                player.Image = Properties.Resources.run2;
                player.Left = player.Left - 20;
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                player.Top = player.Top - 20;
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                player.Top = player.Top + 20;
            }
            if (picB1.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left = 80;
            }
            if (picB2.Bounds.IntersectsWith(player.Bounds))
            {
                player.Top += 20;
            }
            if (picB3.Bounds.IntersectsWith(player.Bounds))
            {
                player.Top -= 20;
            }
        }

        private void addEnemy()
        {
            enemy = new PictureBox();
            Image img = Properties.Resources.enemyPic;
            enemy.Image = img;
            enemy.Width = img.Width;
            enemy.Height = img.Height;
            enemy.BackColor = Color.Transparent;
            enemy.Location = new System.Drawing.Point(1220, 70);
            this.Controls.Add(enemy);
            enemyDirection = "left";
        }

        private void addPlayer()
        {
            player = new PictureBox();
            Image img = Properties.Resources.run1;
            player.Image = img;
            player.Width = img.Width;
            player.Height = img.Height;
            player.BackColor = Color.Transparent;
            player.Location = new System.Drawing.Point(80,610);
            this.Controls.Add(player);
        }
    }
}
