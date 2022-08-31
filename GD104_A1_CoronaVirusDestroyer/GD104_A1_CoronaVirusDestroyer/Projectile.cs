using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace GD104_A1_CoronaVirusDestroyer
{
    class Projectile
    {
        //Projectile Variables
        //Projectile direction & movement
        public string proDir;
        public int proLeft;
        public int proTop;

        private int speed = 20;
        //Creates projectile picture box and timer so it can appear and move
        private PictureBox projectile_PB = new PictureBox();
        private Timer projectileTimer = new Timer();


        public void MakeProjectile(Form form)
        {
            //Creates the projectile when called with these settings
            //Selects between directional images of projectile depending on player direction
           if (proDir == "up")
            {
                projectile_PB.Image = Properties.Resources.Syring;
            }
            if (proDir == "down")
            {
                projectile_PB.Image = Properties.Resources.Syring_Down;
            }
            if (proDir == "left")
            {
                projectile_PB.Image = Properties.Resources.Syring_Left;
            }
            if (proDir == "right")
            {
                projectile_PB.Image = Properties.Resources.Syring_Right;
            }


            projectile_PB.SizeMode = PictureBoxSizeMode.StretchImage;
            projectile_PB.BackColor = Color.Transparent;
            projectile_PB.Size = new Size(40, 40);
            projectile_PB.Tag = "projectile";
            projectile_PB.Left = proLeft;
            projectile_PB.Top = proTop;
            projectile_PB.BringToFront();

            form.Controls.Add(projectile_PB);

            //Starts the timer and configures it for each projectile
            projectileTimer.Interval = speed;
            projectileTimer.Tick += new EventHandler(projectileTimerEvent);
            projectileTimer.Start();
        }

        private void projectileTimerEvent(object sender, EventArgs e)
        {
            //Sets up the projectile directional movement
            if (proDir == "left")
            {
                projectile_PB.Left -= speed;
            }

            if (proDir == "right")
            {
                projectile_PB.Left += speed;
            }

            if (proDir == "up")
            {
                projectile_PB.Top -= speed;
            }

            if (proDir == "down")
            {
                projectile_PB.Top += speed;
            }

            //Despawns the projectile if it goes out of the bounds of the level
            if (projectile_PB.Left < 10 || projectile_PB.Left > 800 || projectile_PB.Top < 10 || projectile_PB.Top > 600)
            {
                projectileTimer.Stop();
                projectileTimer.Dispose();
                projectile_PB.Dispose();
                projectileTimer = null;
                projectile_PB = null;
            }

        }

    }

}
