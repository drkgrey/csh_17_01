namespace Asteroid_game
{
    partial class SplashScreenForm
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
            this.Record_button = new System.Windows.Forms.Button();
            this.Start_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Record_button
            // 
            this.Record_button.BackColor = System.Drawing.SystemColors.GrayText;
            this.Record_button.Location = new System.Drawing.Point(2, 418);
            this.Record_button.Name = "Record_button";
            this.Record_button.Size = new System.Drawing.Size(157, 51);
            this.Record_button.TabIndex = 0;
            this.Record_button.Text = "Рекорды";
            this.Record_button.UseVisualStyleBackColor = false;
            this.Record_button.Click += new System.EventHandler(this.Record_button_Click);
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.SystemColors.Info;
            this.Start_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start_button.Location = new System.Drawing.Point(185, 373);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(187, 96);
            this.Start_button.TabIndex = 1;
            this.Start_button.Text = "Начать";
            this.Start_button.UseVisualStyleBackColor = false;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.BackColor = System.Drawing.SystemColors.GrayText;
            this.Exit_button.Location = new System.Drawing.Point(396, 418);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(136, 51);
            this.Exit_button.TabIndex = 2;
            this.Exit_button.Text = "Выход";
            this.Exit_button.UseVisualStyleBackColor = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Info.Location = new System.Drawing.Point(0, -1);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(44, 7);
            this.Info.TabIndex = 3;
            this.Info.Text = "made by drk";
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(534, 469);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Start_button);
            this.Controls.Add(this.Record_button);
            this.Name = "SplashScreenForm";
            this.Text = "SplashScreenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Record_button;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.Label Info;
    }
}