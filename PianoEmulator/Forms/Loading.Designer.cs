namespace PianoEmulator.Forms
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.pianoTimer = new System.Windows.Forms.Timer(this.components);
            this.labelCheckSettings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pianoTimer
            // 
            this.pianoTimer.Tick += new System.EventHandler(this.pianoTimer_Tick);
            // 
            // labelCheckSettings
            // 
            this.labelCheckSettings.AutoSize = true;
            this.labelCheckSettings.BackColor = System.Drawing.Color.Transparent;
            this.labelCheckSettings.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheckSettings.Location = new System.Drawing.Point(342, 505);
            this.labelCheckSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckSettings.Name = "labelCheckSettings";
            this.labelCheckSettings.Size = new System.Drawing.Size(401, 40);
            this.labelCheckSettings.TabIndex = 0;
            this.labelCheckSettings.Text = "Проверка соединения";
            this.labelCheckSettings.Click += new System.EventHandler(this.labelCheckSettings_Click);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.labelCheckSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Симулятор пиано";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Loading_FormClosed);
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer pianoTimer;
        private System.Windows.Forms.Label labelCheckSettings;
    }
}