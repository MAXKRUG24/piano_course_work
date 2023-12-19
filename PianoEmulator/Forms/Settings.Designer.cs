namespace PianoEmulator.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tbPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.labelDatabaseName = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.labelServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(17, 274);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(294, 37);
            this.tbPort.TabIndex = 38;
            this.tbPort.Text = "5432";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.ForeColor = System.Drawing.Color.White;
            this.labelPort.Location = new System.Drawing.Point(13, 247);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(70, 30);
            this.labelPort.TabIndex = 37;
            this.labelPort.Text = "Порт";
            // 
            // tbDBName
            // 
            this.tbDBName.Location = new System.Drawing.Point(17, 215);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(294, 37);
            this.tbDBName.TabIndex = 36;
            this.tbDBName.Text = "PianoEmulator";
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.AutoSize = true;
            this.labelDatabaseName.ForeColor = System.Drawing.Color.White;
            this.labelDatabaseName.Location = new System.Drawing.Point(13, 188);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(222, 30);
            this.labelDatabaseName.TabIndex = 35;
            this.labelDatabaseName.Text = "Имя базы данных";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(17, 156);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(294, 37);
            this.tbPassword.TabIndex = 34;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Location = new System.Drawing.Point(13, 129);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(101, 30);
            this.labelPassword.TabIndex = 33;
            this.labelPassword.Text = "Пароль";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(17, 97);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(294, 37);
            this.tbUser.TabIndex = 32;
            this.tbUser.Text = "postgres";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(13, 70);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(171, 30);
            this.labelUser.TabIndex = 31;
            this.labelUser.Text = "Пользователь";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(17, 403);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(294, 41);
            this.btnReturn.TabIndex = 30;
            this.btnReturn.Text = "Выход в главное меню";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(17, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(294, 41);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(17, 38);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(294, 37);
            this.tbServer.TabIndex = 28;
            this.tbServer.Text = "localhost";
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(17, 309);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(294, 41);
            this.btnConnection.TabIndex = 27;
            this.btnConnection.Text = "Создать соединение";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.ForeColor = System.Drawing.Color.White;
            this.labelServer.Location = new System.Drawing.Point(13, 11);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(108, 30);
            this.labelServer.TabIndex = 26;
            this.labelServer.Text = "Сервер";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(325, 455);
            this.ControlBox = false;
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.tbDBName);
            this.Controls.Add(this.labelDatabaseName);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.labelServer);
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.Label labelDatabaseName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label labelUser;
        public System.Windows.Forms.Button btnReturn;
        public System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Label labelServer;
    }
}