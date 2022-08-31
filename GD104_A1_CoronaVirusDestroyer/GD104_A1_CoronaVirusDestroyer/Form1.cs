using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD104_A1_CoronaVirusDestroyer
{
    public partial class gameForm : Form
    {
        //Assigned Variables
        //PlayerMovement
        bool mvLeft;
        bool mvRight;
        bool mvUp;
        bool mvDown;
        //Game Over & Restart
        bool gameOver;
        //Sets player start location and stats
        string pDir = "up";
        int pHealth = 100;
        int speed = 10;
        int score = 0;
        //sets enemy stats
        int enemySpeed = 3;
        //creates randomiser
        Random rand = new Random();

        //Generates a list to store spawned enemies to be added or removed when enemies are shot
        List<PictureBox> enemyList = new List<PictureBox>();

        public gameForm()
        {
            //The Initialiser
            InitializeComponent();
            restartGame();
        }

        private void gameForm_Load(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Sets heath bar value of player & when heath <= 0 gameOver. Message box appears and pressing OK restarts the game.
            if (pHealth > 1)
            {
                healthBar_PRB.Value = pHealth;
            }
            else
            {
                gameOver = true;
                gameTimer.Stop();
                MessageBox.Show("Game Over!" + "\r\n" + "Click OK to restart\nPress Esc key to quit");
                restartGame();
            }

            //Generates score label text from data in integer variables
            score_LBL.Text = "Score: " + score;

            //Translates the player allowing them to move up, down, left & right. Creates bounds so player does not move off screen.
            if (mvLeft == true && player_PB.Left > 0)
            {
                player_PB.Image = Properties.Resources.B_Cell_Left;
                player_PB.Left -= speed;
            }
            if (mvRight == true && player_PB.Left + player_PB.Width < this.ClientSize.Width)
            {
                player_PB.Image = Properties.Resources.B_Cell_Right;
                player_PB.Left += speed;
            }
            if (mvUp == true && player_PB.Top > 50)
            {
                player_PB.Image = Properties.Resources.B_Cell;
                player_PB.Top -= speed;
            }
            if (mvDown == true && player_PB.Top + player_PB.Height < this.ClientSize.Height)
            {
                player_PB.Image = Properties.Resources.B_Cell_Down;
                player_PB.Top += speed;
            }

            //Controls enemy movement based on player movement. Enemy constantly moves towards player.
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    //adds damage to player when colliding with enemy
                    if (player_PB.Bounds.IntersectsWith(x.Bounds))
                    {
                        pHealth -= 2;
                    }

                    if (x.Left > player_PB.Left)
                    {
                        x.Left -= enemySpeed;
                    }
                    if (x.Left < player_PB.Left)
                    {
                        x.Left += enemySpeed;
                    }
                    if (x.Top > player_PB.Top)
                    {
                        x.Top -= enemySpeed;
                    }
                    if (x.Top < player_PB.Top)
                    {
                        x.Top += enemySpeed;
                    }
                }

                //When projectile intersects with enemy, score increases and enemy & projectile despawn. New enemy is spawned.
                foreach (Control z in this.Controls)
                {
                    if (z is PictureBox && (string)z.Tag == "projectile" && x is PictureBox && (string)x.Tag == "enemy")
                    {
                        if (x.Bounds.IntersectsWith(z.Bounds))
                        {
                            score++;
                            
                            this.Controls.Remove(z);
                            ((PictureBox)z).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            enemyList.Remove(((PictureBox)x));
                            spawnEnemy();
                        }
                    }
                }

            }

        }

        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Performs when a key is pressed down

            //Player Direction true
            if (e.KeyCode == Keys.Left)
            {
                mvLeft = true;
                pDir = "left";
            }

            if (e.KeyCode == Keys.Right)
            {
                mvRight = true;
                pDir = "right";
            }

            if (e.KeyCode == Keys.Up)
            {
                mvUp = true;
                pDir = "up";
            }

            if (e.KeyCode == Keys.Down)
            {
                mvDown = true;
                pDir = "down";
            }
        }

        private void gameForm_KeyUp(object sender, KeyEventArgs e)
        {
            //Performs when a key is released
            //Player Direction False
            if (e.KeyCode == Keys.Left)
            {
                mvLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                mvRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                mvUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                mvDown = false;
            }

            //fires the projectile when space is pressed. Function disabled when game is not over.
            if (e.KeyCode == Keys.Space && gameOver == false)
            {
                //Attempting a delay using async so projectile can only be fired once every half second instead of spammed
                //SSawait Task.Delay(500);
                shootProjectile(pDir);

            }

            //restarts the game when the specified key is pressed and if the game is over. Potential fix for if message box fails.
            if (e.KeyCode == Keys.R && gameOver == true)
            {
                restartGame();
            }

            //Closes the game when escape key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                closeGame();
            }
        }

        private void shootProjectile(string direction)
        {
            //Fires the projectile in the direction the player is facing
            Projectile shootProjectile = new Projectile();

            shootProjectile.proDir = direction;
            shootProjectile.proLeft = player_PB.Left + (player_PB.Width / 2);
            shootProjectile.proTop = player_PB.Top + (player_PB.Height / 2);

            shootProjectile.MakeProjectile(this);
        }

        private void spawnEnemy()
        {
            //Spawns in the hostile entities
            PictureBox enemy = new PictureBox();
            enemy.Tag = "enemy";
            enemy.Image = Properties.Resources.COVID19_Icon;
            enemy.BackColor = Color.Transparent;

            enemy.Left = rand.Next(0, 900);
            enemy.Top = rand.Next(0, 800);
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy.Size = new Size(40, 40);
            enemyList.Add(enemy);

            this.Controls.Add(enemy);
            player_PB.BringToFront();

        }

        private void restartGame()
        {
            //Restarts the game on key press
            //removes enemies already spawned in
            foreach (PictureBox i in enemyList)
            {
                this.Controls.Remove(i);
            }
            //reset enemies
            enemyList.Clear();
            //Number of enemy spawned at once
            for (int i = 0; i < 4; i++)
            {
                spawnEnemy();
            }
            //reset all values
            mvUp = false;
            mvDown = false;
            mvLeft = false;
            mvRight = false;

            gameOver = false;

            pHealth = 100;
            score = 0;
            enemySpeed = 3;

            gameTimer.Start();
        }

        private void closeGame()
        {
            //Closes the game, exiting the application
            Close();
        }
    }
}
