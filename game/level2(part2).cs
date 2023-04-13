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
    public partial class level2_part2_ : Form
    {
        int playerHealth = 3;
        PictureBox player;
        PictureBox enemy;
        string enemyDirection;
        public level2_part2_()
        {
            InitializeComponent();
        }

        private void level2_part2__Load(object sender, EventArgs e)
        {
            addPlayer();
            addEnemey();
        }

        private void addEnemey()
        {
            enemy = new PictureBox();
            Image img = Properties.Resources.enemyPic;
            enemy.Image = img;
            enemy.Width = img.Width;
            enemy.Height = img.Height;
            enemy.BackColor = Color.Transparent;
            enemy.Location = new System.Drawing.Point(1060, 100);
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
            player.Location = new System.Drawing.Point(80, 610);
            this.Controls.Add(player);
        }

        private void tmrLeveltwo1_Tick(object sender, EventArgs e)
        {
            lblLives.Text = "Total Lives = " + playerHealth;
            movePlayer();
            moveEnemy();
            collideFire();
            collideEnemy();
        }

        private void collideEnemy()
        {
            if (player.Bounds.IntersectsWith(enemy.Bounds))
            {
                playerHealth--;
                player.Location = new System.Drawing.Point(80, 610);
            }
            if (playerHealth == 0 && Keyboard.IsKeyPressed(Key.RightArrow))
            {
                tmrLeveltwo1.Enabled = false;
                this.Hide();
                lose myForm = new lose();
                myForm.ShowDialog();
                tmrLeveltwo1.Interval = 0;
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

        private void collideFire()
        {
            if(player.Bounds.IntersectsWith(picFire1.Bounds) || player.Bounds.IntersectsWith(picFire2.Bounds) || player.Bounds.IntersectsWith(picFire3.Bounds) || player.Bounds.IntersectsWith(picFire4.Bounds) || player.Bounds.IntersectsWith(picFire5.Bounds))
            {
                playerHealth--;
                player.Location = new System.Drawing.Point(80, 610);
            }
            if (playerHealth == 0 && Keyboard.IsKeyPressed(Key.RightArrow))
            {
                tmrLeveltwo1.Enabled = false;
                this.Hide();
                lose myForm = new lose();
                myForm.ShowDialog();
                tmrLeveltwo1.Interval = 0;
            }
        }

        private void moveEnemy()
        {
            if (enemyDirection == "left")
            {
                enemy.Left -= 40;
            }
            if (enemyDirection == "right")
            {
                enemy.Left += 40;
            }
            if (enemy.Bounds.IntersectsWith(picDoor.Bounds))
            {
                enemyDirection = "left";
            }
            if (enemy.Bounds.IntersectsWith(picB1.Bounds))
            {
                enemyDirection = "right";
            }
        }
    }
}
