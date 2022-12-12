using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platform_game
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, jumping, isGameOver;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;
        int horizontalSpeed2 = 5;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;
        int enemyThreeSpeed = 4;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }


       





        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            player.Top += jumpSpeed;

            if(goLeft == true)
            {
                player.Left -= playerSpeed;
            }

            if(goRight == true)
            {
                player.Left += playerSpeed;
            }

            if(jumping == true && force < 0)
            {
                jumping = false;
            }

            if(jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;

            }

            else
            {
                jumpSpeed = 10;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;


                            if((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPLatform" && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }



                        }

                        x.BringToFront();
                    }

                    if((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if((string)x.Tag == "enemy")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameTimer.Stop();
                            isGameOver = true;
                            txtScore.Text = "Score: " + score + Environment.NewLine + "You were killed in your journey!!!";
                        }
                    }



                }


                    
            }

            horizontalPlatform.Left -= horizontalSpeed;
            if (horizontalPlatform.Left < 180 || horizontalPlatform.Left > 210)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            horizontalPlatform2.Left -= horizontalSpeed;
            if (horizontalPlatform2.Left < 180 || horizontalPlatform2.Left > 390)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            verticalPlatform.Top += verticalSpeed;
            if(verticalPlatform.Top < 320 || verticalPlatform.Top > 772)
            {
                verticalSpeed = -verticalSpeed;
            }


            enemyOne.Left -= enemyOneSpeed;
            if(enemyOne.Left < pictureBox3.Left || enemyOne.Left + enemyOne.Width > pictureBox3.Left + pictureBox3.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left -= enemyTwoSpeed;
            if (enemyTwo.Left < pictureBox2.Left || enemyTwo.Left + enemyTwo.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            enemyThree.Left -= enemyThreeSpeed;
            if (enemyThree.Left < pictureBox38.Left || enemyThree.Left + enemyThree.Width > pictureBox38.Left + pictureBox38.Width)
            {
                enemyThreeSpeed = -enemyThreeSpeed;
            }

            

            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                GameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "You Fell to your death!";
            }

            if(player.Bounds.IntersectsWith(door.Bounds) && score == 48)
            {
                GameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "Your Quest Is Complete!";
            }
            else
            {
                txtScore.Text = "Score: " + score + Environment.NewLine + "Collect all the coins";
            }

        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {

        }

        private void enemyTwo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

            if(e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if(jumping == true)
            {
                jumping = false;
            }

            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            txtScore.Text = "score: " + score;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            //reset the position of enemy platform and player.


            player.Left = 98;
            player.Top = 869;

            enemyOne.Left = 554;
            enemyTwo.Left = 574;

            horizontalPlatform.Left = 321;
            verticalPlatform.Top = 772;

            GameTimer.Start();
            

        }
    }
}
