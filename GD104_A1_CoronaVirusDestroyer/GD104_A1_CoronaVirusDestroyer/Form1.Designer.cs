
namespace GD104_A1_CoronaVirusDestroyer
{
    partial class gameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameForm));
            this.score_LBL = new System.Windows.Forms.Label();
            this.health_LBL = new System.Windows.Forms.Label();
            this.healthBar_PRB = new System.Windows.Forms.ProgressBar();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player_PB = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // score_LBL
            // 
            this.score_LBL.AutoSize = true;
            this.score_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_LBL.Location = new System.Drawing.Point(12, 9);
            this.score_LBL.Name = "score_LBL";
            this.score_LBL.Size = new System.Drawing.Size(120, 32);
            this.score_LBL.TabIndex = 4;
            this.score_LBL.Text = "Score: 0";
            // 
            // health_LBL
            // 
            this.health_LBL.AutoSize = true;
            this.health_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.health_LBL.Location = new System.Drawing.Point(441, 587);
            this.health_LBL.Name = "health_LBL";
            this.health_LBL.Size = new System.Drawing.Size(98, 32);
            this.health_LBL.TabIndex = 5;
            this.health_LBL.Text = "Health";
            // 
            // healthBar_PRB
            // 
            this.healthBar_PRB.Location = new System.Drawing.Point(400, 634);
            this.healthBar_PRB.Name = "healthBar_PRB";
            this.healthBar_PRB.Size = new System.Drawing.Size(189, 23);
            this.healthBar_PRB.TabIndex = 6;
            this.healthBar_PRB.Value = 100;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player_PB
            // 
            this.player_PB.BackColor = System.Drawing.Color.Transparent;
            this.player_PB.Image = global::GD104_A1_CoronaVirusDestroyer.Properties.Resources.B_Cell;
            this.player_PB.Location = new System.Drawing.Point(472, 284);
            this.player_PB.Name = "player_PB";
            this.player_PB.Size = new System.Drawing.Size(50, 50);
            this.player_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player_PB.TabIndex = 0;
            this.player_PB.TabStop = false;
            this.player_PB.Tag = "player";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GD104_A1_CoronaVirusDestroyer.Properties.Resources.COVID19_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(472, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "enemy";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::GD104_A1_CoronaVirusDestroyer.Properties.Resources.Syring;
            this.pictureBox2.Location = new System.Drawing.Point(472, 216);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "projectile";
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1002, 669);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.healthBar_PRB);
            this.Controls.Add(this.health_LBL);
            this.Controls.Add(this.score_LBL);
            this.Controls.Add(this.player_PB);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "gameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoronaVirusDestroyer";
            this.Load += new System.EventHandler(this.gameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player_PB;
        private System.Windows.Forms.Label score_LBL;
        private System.Windows.Forms.Label health_LBL;
        private System.Windows.Forms.ProgressBar healthBar_PRB;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

