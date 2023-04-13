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
    public partial class level1 : Form
    {
        PictureBox player;
        int index = 0;
        int score = 0, Lives = 3;
        string playerDirection;

        public level1()
        {
            InitializeComponent();
        }

        private void level1_Load(object sender, EventArgs e)
        {
            addPlayer();
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
            playerDirection = "right";
        }

        private void tmrLevel1_Tick(object sender, EventArgs e)
        {
            lblLives.Text ="Total Lives = "+Lives;
            lblScore.Text = "Total Score = " + score;
            movePlayer();
            detectCollision();
            diamondBoxes();
            exitDoor();
        }

        private void exitDoor()
        {
            if (picDoor.Bounds.IntersectsWith(player.Bounds) && Keyboard.IsKeyPressed(Key.Space))
            { 
                picDoor.Image = Properties.Resources.door_open;
                this.Hide();
                level2 myForm = new level2();
                myForm.ShowDialog();
                tmrLevel1.Interval = 0;
            }
        }

        private void diamondBoxes()
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
        }

        private void detectCollision()
        {
            if (picD1.Bounds.IntersectsWith(player.Bounds))
            {
                index = 0;
                picD1.Visible = false;
                picD1=null;
                Properties.Resources.Daimond.Dispose();
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            if (picB4.Bounds.IntersectsWith(player.Bounds))
            {
                player.Left -= 20;
            }
        }
    }
}
