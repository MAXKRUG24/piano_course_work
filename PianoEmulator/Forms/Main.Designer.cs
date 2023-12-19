namespace PianoEmulator.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авторизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnDoDies = new System.Windows.Forms.Button();
            this.btnRe = new System.Windows.Forms.Button();
            this.btnFa = new System.Windows.Forms.Button();
            this.btnMi = new System.Windows.Forms.Button();
            this.btnLa = new System.Windows.Forms.Button();
            this.btnSol = new System.Windows.Forms.Button();
            this.btnDo2 = new System.Windows.Forms.Button();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnReDies = new System.Windows.Forms.Button();
            this.btnFaDies = new System.Windows.Forms.Button();
            this.btnSolDies = new System.Windows.Forms.Button();
            this.btnLaDies = new System.Windows.Forms.Button();
            this.rtbHistory = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbLoop = new System.Windows.Forms.GroupBox();
            this.btnOffLaDies = new System.Windows.Forms.Button();
            this.btnOffSolDies = new System.Windows.Forms.Button();
            this.btnOffFaDies = new System.Windows.Forms.Button();
            this.btnOffReDies = new System.Windows.Forms.Button();
            this.btnOffDoDies = new System.Windows.Forms.Button();
            this.btnOffDo2 = new System.Windows.Forms.Button();
            this.btnOffSi = new System.Windows.Forms.Button();
            this.btnOffLa = new System.Windows.Forms.Button();
            this.btnOffSol = new System.Windows.Forms.Button();
            this.btnOffFa = new System.Windows.Forms.Button();
            this.btnOffMi = new System.Windows.Forms.Button();
            this.btnOffRe = new System.Windows.Forms.Button();
            this.btnOffDo = new System.Windows.Forms.Button();
            this.cbLaDies = new System.Windows.Forms.CheckBox();
            this.cbSolDies = new System.Windows.Forms.CheckBox();
            this.cbFaDies = new System.Windows.Forms.CheckBox();
            this.cbReDies = new System.Windows.Forms.CheckBox();
            this.cbDoDies = new System.Windows.Forms.CheckBox();
            this.cbDo2 = new System.Windows.Forms.CheckBox();
            this.cbLa = new System.Windows.Forms.CheckBox();
            this.cbFa = new System.Windows.Forms.CheckBox();
            this.cbRe = new System.Windows.Forms.CheckBox();
            this.cbSi = new System.Windows.Forms.CheckBox();
            this.cbDo = new System.Windows.Forms.CheckBox();
            this.cbMi = new System.Windows.Forms.CheckBox();
            this.cbSol = new System.Windows.Forms.CheckBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.cbCompositions = new System.Windows.Forms.ComboBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.загрузитьКомпозициюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.gbLoop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.загрузитьКомпозициюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авторизацияToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // авторизацияToolStripMenuItem
            // 
            this.авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            this.авторизацияToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.авторизацияToolStripMenuItem.Text = "Авторизация";
            this.авторизацияToolStripMenuItem.Click += new System.EventHandler(this.авторизацияToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // btnDo
            // 
            this.btnDo.BackColor = System.Drawing.Color.White;
            this.btnDo.Location = new System.Drawing.Point(12, 27);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(93, 308);
            this.btnDo.TabIndex = 1;
            this.btnDo.Text = "Q\r\n\r\ndo\r\nc";
            this.btnDo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDo.UseVisualStyleBackColor = false;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnDoDies
            // 
            this.btnDoDies.BackColor = System.Drawing.Color.Black;
            this.btnDoDies.ForeColor = System.Drawing.Color.White;
            this.btnDoDies.Location = new System.Drawing.Point(76, 27);
            this.btnDoDies.Name = "btnDoDies";
            this.btnDoDies.Size = new System.Drawing.Size(69, 187);
            this.btnDoDies.TabIndex = 2;
            this.btnDoDies.Text = "1\r\n\r\nc#";
            this.btnDoDies.UseVisualStyleBackColor = false;
            this.btnDoDies.Click += new System.EventHandler(this.btnDoDies_Click);
            // 
            // btnRe
            // 
            this.btnRe.BackColor = System.Drawing.Color.White;
            this.btnRe.Location = new System.Drawing.Point(111, 27);
            this.btnRe.Name = "btnRe";
            this.btnRe.Size = new System.Drawing.Size(93, 308);
            this.btnRe.TabIndex = 3;
            this.btnRe.Text = "W\r\n\r\nre\r\nd";
            this.btnRe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRe.UseVisualStyleBackColor = false;
            this.btnRe.Click += new System.EventHandler(this.btnRe_Click);
            // 
            // btnFa
            // 
            this.btnFa.BackColor = System.Drawing.Color.White;
            this.btnFa.Location = new System.Drawing.Point(309, 27);
            this.btnFa.Name = "btnFa";
            this.btnFa.Size = new System.Drawing.Size(93, 308);
            this.btnFa.TabIndex = 5;
            this.btnFa.Text = "R\r\n\r\nfa\r\nf";
            this.btnFa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFa.UseVisualStyleBackColor = false;
            this.btnFa.Click += new System.EventHandler(this.btnFa_Click);
            // 
            // btnMi
            // 
            this.btnMi.BackColor = System.Drawing.Color.White;
            this.btnMi.Location = new System.Drawing.Point(210, 27);
            this.btnMi.Name = "btnMi";
            this.btnMi.Size = new System.Drawing.Size(93, 308);
            this.btnMi.TabIndex = 4;
            this.btnMi.Text = "E\r\n\r\nmi\r\ne";
            this.btnMi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMi.UseVisualStyleBackColor = false;
            this.btnMi.Click += new System.EventHandler(this.btnMi_Click);
            // 
            // btnLa
            // 
            this.btnLa.BackColor = System.Drawing.Color.White;
            this.btnLa.Location = new System.Drawing.Point(507, 27);
            this.btnLa.Name = "btnLa";
            this.btnLa.Size = new System.Drawing.Size(93, 308);
            this.btnLa.TabIndex = 7;
            this.btnLa.Text = "Y\r\n\r\nla\r\na";
            this.btnLa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLa.UseVisualStyleBackColor = false;
            this.btnLa.Click += new System.EventHandler(this.btnLa_Click);
            // 
            // btnSol
            // 
            this.btnSol.BackColor = System.Drawing.Color.White;
            this.btnSol.Location = new System.Drawing.Point(408, 27);
            this.btnSol.Name = "btnSol";
            this.btnSol.Size = new System.Drawing.Size(93, 308);
            this.btnSol.TabIndex = 6;
            this.btnSol.Text = "T\r\n\r\nsol\r\ng";
            this.btnSol.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSol.UseVisualStyleBackColor = false;
            this.btnSol.Click += new System.EventHandler(this.btnSol_Click);
            // 
            // btnDo2
            // 
            this.btnDo2.BackColor = System.Drawing.Color.White;
            this.btnDo2.Location = new System.Drawing.Point(705, 27);
            this.btnDo2.Name = "btnDo2";
            this.btnDo2.Size = new System.Drawing.Size(93, 308);
            this.btnDo2.TabIndex = 9;
            this.btnDo2.Text = "I\r\n\r\ndo\r\nc";
            this.btnDo2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDo2.UseVisualStyleBackColor = false;
            this.btnDo2.Click += new System.EventHandler(this.btnDo2_Click);
            // 
            // btnSi
            // 
            this.btnSi.BackColor = System.Drawing.Color.White;
            this.btnSi.Location = new System.Drawing.Point(606, 27);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(93, 308);
            this.btnSi.TabIndex = 8;
            this.btnSi.Text = "U\r\n\r\nsi\r\nb";
            this.btnSi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSi.UseVisualStyleBackColor = false;
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // btnReDies
            // 
            this.btnReDies.BackColor = System.Drawing.Color.Black;
            this.btnReDies.ForeColor = System.Drawing.Color.White;
            this.btnReDies.Location = new System.Drawing.Point(173, 27);
            this.btnReDies.Name = "btnReDies";
            this.btnReDies.Size = new System.Drawing.Size(69, 187);
            this.btnReDies.TabIndex = 10;
            this.btnReDies.Text = "2\r\n\r\nd#";
            this.btnReDies.UseVisualStyleBackColor = false;
            this.btnReDies.Click += new System.EventHandler(this.btnReDies_Click);
            // 
            // btnFaDies
            // 
            this.btnFaDies.BackColor = System.Drawing.Color.Black;
            this.btnFaDies.ForeColor = System.Drawing.Color.White;
            this.btnFaDies.Location = new System.Drawing.Point(371, 27);
            this.btnFaDies.Name = "btnFaDies";
            this.btnFaDies.Size = new System.Drawing.Size(69, 187);
            this.btnFaDies.TabIndex = 12;
            this.btnFaDies.Text = "3\r\n\r\nf#";
            this.btnFaDies.UseVisualStyleBackColor = false;
            this.btnFaDies.Click += new System.EventHandler(this.btnFaDies_Click);
            // 
            // btnSolDies
            // 
            this.btnSolDies.BackColor = System.Drawing.Color.Black;
            this.btnSolDies.ForeColor = System.Drawing.Color.White;
            this.btnSolDies.Location = new System.Drawing.Point(467, 27);
            this.btnSolDies.Name = "btnSolDies";
            this.btnSolDies.Size = new System.Drawing.Size(69, 187);
            this.btnSolDies.TabIndex = 13;
            this.btnSolDies.Text = "4\r\n\rg#";
            this.btnSolDies.UseVisualStyleBackColor = false;
            this.btnSolDies.Click += new System.EventHandler(this.btnSolDies_Click);
            // 
            // btnLaDies
            // 
            this.btnLaDies.BackColor = System.Drawing.Color.Black;
            this.btnLaDies.ForeColor = System.Drawing.Color.White;
            this.btnLaDies.Location = new System.Drawing.Point(568, 27);
            this.btnLaDies.Name = "btnLaDies";
            this.btnLaDies.Size = new System.Drawing.Size(69, 187);
            this.btnLaDies.TabIndex = 14;
            this.btnLaDies.Text = "5\r\n\r\na#";
            this.btnLaDies.UseVisualStyleBackColor = false;
            this.btnLaDies.Click += new System.EventHandler(this.btnLaDies_Click);
            // 
            // rtbHistory
            // 
            this.rtbHistory.Location = new System.Drawing.Point(408, 343);
            this.rtbHistory.Name = "rtbHistory";
            this.rtbHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbHistory.Size = new System.Drawing.Size(390, 92);
            this.rtbHistory.TabIndex = 15;
            this.rtbHistory.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(408, 441);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(390, 66);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Очистка истории";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gbLoop
            // 
            this.gbLoop.Controls.Add(this.btnOffLaDies);
            this.gbLoop.Controls.Add(this.btnOffSolDies);
            this.gbLoop.Controls.Add(this.btnOffFaDies);
            this.gbLoop.Controls.Add(this.btnOffReDies);
            this.gbLoop.Controls.Add(this.btnOffDoDies);
            this.gbLoop.Controls.Add(this.btnOffDo2);
            this.gbLoop.Controls.Add(this.btnOffSi);
            this.gbLoop.Controls.Add(this.btnOffLa);
            this.gbLoop.Controls.Add(this.btnOffSol);
            this.gbLoop.Controls.Add(this.btnOffFa);
            this.gbLoop.Controls.Add(this.btnOffMi);
            this.gbLoop.Controls.Add(this.btnOffRe);
            this.gbLoop.Controls.Add(this.btnOffDo);
            this.gbLoop.Controls.Add(this.cbLaDies);
            this.gbLoop.Controls.Add(this.cbSolDies);
            this.gbLoop.Controls.Add(this.cbFaDies);
            this.gbLoop.Controls.Add(this.cbReDies);
            this.gbLoop.Controls.Add(this.cbDoDies);
            this.gbLoop.Controls.Add(this.cbDo2);
            this.gbLoop.Controls.Add(this.cbLa);
            this.gbLoop.Controls.Add(this.cbFa);
            this.gbLoop.Controls.Add(this.cbRe);
            this.gbLoop.Controls.Add(this.cbSi);
            this.gbLoop.Controls.Add(this.cbDo);
            this.gbLoop.Controls.Add(this.cbMi);
            this.gbLoop.Controls.Add(this.cbSol);
            this.gbLoop.Location = new System.Drawing.Point(803, 513);
            this.gbLoop.Name = "gbLoop";
            this.gbLoop.Size = new System.Drawing.Size(191, 480);
            this.gbLoop.TabIndex = 17;
            this.gbLoop.TabStop = false;
            this.gbLoop.Text = "Цикл";
            // 
            // btnOffLaDies
            // 
            this.btnOffLaDies.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffLaDies.Location = new System.Drawing.Point(103, 444);
            this.btnOffLaDies.Name = "btnOffLaDies";
            this.btnOffLaDies.Size = new System.Drawing.Size(75, 26);
            this.btnOffLaDies.TabIndex = 26;
            this.btnOffLaDies.Text = "СТОП";
            this.btnOffLaDies.UseVisualStyleBackColor = true;
            this.btnOffLaDies.Click += new System.EventHandler(this.btnOffLaDies_Click);
            // 
            // btnOffSolDies
            // 
            this.btnOffSolDies.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffSolDies.Location = new System.Drawing.Point(103, 412);
            this.btnOffSolDies.Name = "btnOffSolDies";
            this.btnOffSolDies.Size = new System.Drawing.Size(75, 26);
            this.btnOffSolDies.TabIndex = 25;
            this.btnOffSolDies.Text = "СТОП";
            this.btnOffSolDies.UseVisualStyleBackColor = true;
            this.btnOffSolDies.Click += new System.EventHandler(this.btnOffSolDies_Click);
            // 
            // btnOffFaDies
            // 
            this.btnOffFaDies.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffFaDies.Location = new System.Drawing.Point(103, 380);
            this.btnOffFaDies.Name = "btnOffFaDies";
            this.btnOffFaDies.Size = new System.Drawing.Size(75, 26);
            this.btnOffFaDies.TabIndex = 24;
            this.btnOffFaDies.Text = "СТОП";
            this.btnOffFaDies.UseVisualStyleBackColor = true;
            this.btnOffFaDies.Click += new System.EventHandler(this.btnOffFaDies_Click);
            // 
            // btnOffReDies
            // 
            this.btnOffReDies.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffReDies.Location = new System.Drawing.Point(103, 348);
            this.btnOffReDies.Name = "btnOffReDies";
            this.btnOffReDies.Size = new System.Drawing.Size(75, 26);
            this.btnOffReDies.TabIndex = 23;
            this.btnOffReDies.Text = "СТОП";
            this.btnOffReDies.UseVisualStyleBackColor = true;
            this.btnOffReDies.Click += new System.EventHandler(this.btnOffReDies_Click);
            // 
            // btnOffDoDies
            // 
            this.btnOffDoDies.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffDoDies.Location = new System.Drawing.Point(103, 316);
            this.btnOffDoDies.Name = "btnOffDoDies";
            this.btnOffDoDies.Size = new System.Drawing.Size(75, 26);
            this.btnOffDoDies.TabIndex = 22;
            this.btnOffDoDies.Text = "СТОП";
            this.btnOffDoDies.UseVisualStyleBackColor = true;
            this.btnOffDoDies.Click += new System.EventHandler(this.btnOffDoDies_Click);
            // 
            // btnOffDo2
            // 
            this.btnOffDo2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffDo2.Location = new System.Drawing.Point(103, 254);
            this.btnOffDo2.Name = "btnOffDo2";
            this.btnOffDo2.Size = new System.Drawing.Size(75, 26);
            this.btnOffDo2.TabIndex = 21;
            this.btnOffDo2.Text = "СТОП";
            this.btnOffDo2.UseVisualStyleBackColor = true;
            this.btnOffDo2.Click += new System.EventHandler(this.btnOffDo2_Click);
            // 
            // btnOffSi
            // 
            this.btnOffSi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffSi.Location = new System.Drawing.Point(103, 222);
            this.btnOffSi.Name = "btnOffSi";
            this.btnOffSi.Size = new System.Drawing.Size(75, 26);
            this.btnOffSi.TabIndex = 20;
            this.btnOffSi.Text = "СТОП";
            this.btnOffSi.UseVisualStyleBackColor = true;
            this.btnOffSi.Click += new System.EventHandler(this.btnOffSi_Click);
            // 
            // btnOffLa
            // 
            this.btnOffLa.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffLa.Location = new System.Drawing.Point(103, 190);
            this.btnOffLa.Name = "btnOffLa";
            this.btnOffLa.Size = new System.Drawing.Size(75, 26);
            this.btnOffLa.TabIndex = 19;
            this.btnOffLa.Text = "СТОП";
            this.btnOffLa.UseVisualStyleBackColor = true;
            this.btnOffLa.Click += new System.EventHandler(this.btnOffLa_Click);
            // 
            // btnOffSol
            // 
            this.btnOffSol.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffSol.Location = new System.Drawing.Point(103, 158);
            this.btnOffSol.Name = "btnOffSol";
            this.btnOffSol.Size = new System.Drawing.Size(75, 26);
            this.btnOffSol.TabIndex = 18;
            this.btnOffSol.Text = "СТОП";
            this.btnOffSol.UseVisualStyleBackColor = true;
            this.btnOffSol.Click += new System.EventHandler(this.btnOffSol_Click);
            // 
            // btnOffFa
            // 
            this.btnOffFa.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffFa.Location = new System.Drawing.Point(103, 126);
            this.btnOffFa.Name = "btnOffFa";
            this.btnOffFa.Size = new System.Drawing.Size(75, 26);
            this.btnOffFa.TabIndex = 17;
            this.btnOffFa.Text = "СТОП";
            this.btnOffFa.UseVisualStyleBackColor = true;
            this.btnOffFa.Click += new System.EventHandler(this.btnOffFa_Click);
            // 
            // btnOffMi
            // 
            this.btnOffMi.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffMi.Location = new System.Drawing.Point(103, 94);
            this.btnOffMi.Name = "btnOffMi";
            this.btnOffMi.Size = new System.Drawing.Size(75, 26);
            this.btnOffMi.TabIndex = 16;
            this.btnOffMi.Text = "СТОП";
            this.btnOffMi.UseVisualStyleBackColor = true;
            this.btnOffMi.Click += new System.EventHandler(this.btnOffMi_Click);
            // 
            // btnOffRe
            // 
            this.btnOffRe.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffRe.Location = new System.Drawing.Point(103, 62);
            this.btnOffRe.Name = "btnOffRe";
            this.btnOffRe.Size = new System.Drawing.Size(75, 26);
            this.btnOffRe.TabIndex = 15;
            this.btnOffRe.Text = "СТОП";
            this.btnOffRe.UseVisualStyleBackColor = true;
            this.btnOffRe.Click += new System.EventHandler(this.btnOffRe_Click);
            // 
            // btnOffDo
            // 
            this.btnOffDo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOffDo.Location = new System.Drawing.Point(103, 30);
            this.btnOffDo.Name = "btnOffDo";
            this.btnOffDo.Size = new System.Drawing.Size(75, 26);
            this.btnOffDo.TabIndex = 14;
            this.btnOffDo.Text = "СТОП";
            this.btnOffDo.UseVisualStyleBackColor = true;
            this.btnOffDo.Click += new System.EventHandler(this.btnOffDo_Click);
            // 
            // cbLaDies
            // 
            this.cbLaDies.AutoSize = true;
            this.cbLaDies.Location = new System.Drawing.Point(6, 444);
            this.cbLaDies.Name = "cbLaDies";
            this.cbLaDies.Size = new System.Drawing.Size(132, 34);
            this.cbLaDies.TabIndex = 13;
            this.cbLaDies.Text = "Цикл a#";
            this.cbLaDies.UseVisualStyleBackColor = true;
            // 
            // cbSolDies
            // 
            this.cbSolDies.AutoSize = true;
            this.cbSolDies.Location = new System.Drawing.Point(6, 412);
            this.cbSolDies.Name = "cbSolDies";
            this.cbSolDies.Size = new System.Drawing.Size(132, 34);
            this.cbSolDies.TabIndex = 12;
            this.cbSolDies.Text = "Цикл g#";
            this.cbSolDies.UseVisualStyleBackColor = true;
            // 
            // cbFaDies
            // 
            this.cbFaDies.AutoSize = true;
            this.cbFaDies.Location = new System.Drawing.Point(6, 380);
            this.cbFaDies.Name = "cbFaDies";
            this.cbFaDies.Size = new System.Drawing.Size(124, 34);
            this.cbFaDies.TabIndex = 11;
            this.cbFaDies.Text = "Цикл f#";
            this.cbFaDies.UseVisualStyleBackColor = true;
            // 
            // cbReDies
            // 
            this.cbReDies.AutoSize = true;
            this.cbReDies.Location = new System.Drawing.Point(6, 348);
            this.cbReDies.Name = "cbReDies";
            this.cbReDies.Size = new System.Drawing.Size(132, 34);
            this.cbReDies.TabIndex = 10;
            this.cbReDies.Text = "Цикл d#";
            this.cbReDies.UseVisualStyleBackColor = true;
            // 
            // cbDoDies
            // 
            this.cbDoDies.AutoSize = true;
            this.cbDoDies.Location = new System.Drawing.Point(6, 316);
            this.cbDoDies.Name = "cbDoDies";
            this.cbDoDies.Size = new System.Drawing.Size(132, 34);
            this.cbDoDies.TabIndex = 9;
            this.cbDoDies.Text = "Цикл c#";
            this.cbDoDies.UseVisualStyleBackColor = true;
            // 
            // cbDo2
            // 
            this.cbDo2.AutoSize = true;
            this.cbDo2.Location = new System.Drawing.Point(6, 254);
            this.cbDo2.Name = "cbDo2";
            this.cbDo2.Size = new System.Drawing.Size(115, 34);
            this.cbDo2.TabIndex = 8;
            this.cbDo2.Text = "Цикл c";
            this.cbDo2.UseVisualStyleBackColor = true;
            // 
            // cbLa
            // 
            this.cbLa.AutoSize = true;
            this.cbLa.Location = new System.Drawing.Point(6, 190);
            this.cbLa.Name = "cbLa";
            this.cbLa.Size = new System.Drawing.Size(115, 34);
            this.cbLa.TabIndex = 7;
            this.cbLa.Text = "Цикл a";
            this.cbLa.UseVisualStyleBackColor = true;
            // 
            // cbFa
            // 
            this.cbFa.AutoSize = true;
            this.cbFa.Location = new System.Drawing.Point(6, 126);
            this.cbFa.Name = "cbFa";
            this.cbFa.Size = new System.Drawing.Size(107, 34);
            this.cbFa.TabIndex = 6;
            this.cbFa.Text = "Цикл f";
            this.cbFa.UseVisualStyleBackColor = true;
            // 
            // cbRe
            // 
            this.cbRe.AutoSize = true;
            this.cbRe.Location = new System.Drawing.Point(6, 62);
            this.cbRe.Name = "cbRe";
            this.cbRe.Size = new System.Drawing.Size(115, 34);
            this.cbRe.TabIndex = 5;
            this.cbRe.Text = "Цикл d";
            this.cbRe.UseVisualStyleBackColor = true;
            // 
            // cbSi
            // 
            this.cbSi.AutoSize = true;
            this.cbSi.Location = new System.Drawing.Point(6, 222);
            this.cbSi.Name = "cbSi";
            this.cbSi.Size = new System.Drawing.Size(115, 34);
            this.cbSi.TabIndex = 4;
            this.cbSi.Text = "Цикл b";
            this.cbSi.UseVisualStyleBackColor = true;
            // 
            // cbDo
            // 
            this.cbDo.AutoSize = true;
            this.cbDo.Location = new System.Drawing.Point(6, 30);
            this.cbDo.Name = "cbDo";
            this.cbDo.Size = new System.Drawing.Size(115, 34);
            this.cbDo.TabIndex = 0;
            this.cbDo.Text = "Цикл c";
            this.cbDo.UseVisualStyleBackColor = true;
            // 
            // cbMi
            // 
            this.cbMi.AutoSize = true;
            this.cbMi.Location = new System.Drawing.Point(6, 94);
            this.cbMi.Name = "cbMi";
            this.cbMi.Size = new System.Drawing.Size(115, 34);
            this.cbMi.TabIndex = 2;
            this.cbMi.Text = "Цикл e";
            this.cbMi.UseVisualStyleBackColor = true;
            // 
            // cbSol
            // 
            this.cbSol.AutoSize = true;
            this.cbSol.Location = new System.Drawing.Point(6, 158);
            this.cbSol.Name = "cbSol";
            this.cbSol.Size = new System.Drawing.Size(115, 34);
            this.cbSol.TabIndex = 3;
            this.cbSol.Text = "Цикл g";
            this.cbSol.UseVisualStyleBackColor = true;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(12, 380);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(390, 55);
            this.btnRecord.TabIndex = 18;
            this.btnRecord.Text = "Записать композицию";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // cbCompositions
            // 
            this.cbCompositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompositions.FormattingEnabled = true;
            this.cbCompositions.Location = new System.Drawing.Point(12, 441);
            this.cbCompositions.Name = "cbCompositions";
            this.cbCompositions.Size = new System.Drawing.Size(390, 38);
            this.cbCompositions.TabIndex = 19;
            this.cbCompositions.SelectedIndexChanged += new System.EventHandler(this.cbCompositions_SelectedIndexChanged);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 477);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(192, 30);
            this.btnPlay.TabIndex = 20;
            this.btnPlay.Text = "Пуск";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 343);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(390, 37);
            this.tbName.TabIndex = 21;
            this.tbName.Click += new System.EventHandler(this.tbName_Click);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(809, 486);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(192, 30);
            this.btnStop.TabIndex = 22;
            this.btnStop.Text = "Остановить всё";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 477);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 30);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // загрузитьКомпозициюToolStripMenuItem
            // 
            this.загрузитьКомпозициюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьФайлToolStripMenuItem});
            this.загрузитьКомпозициюToolStripMenuItem.Name = "загрузитьКомпозициюToolStripMenuItem";
            this.загрузитьКомпозициюToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.загрузитьКомпозициюToolStripMenuItem.Text = "Загрузить композицию";
            // 
            // выбратьФайлToolStripMenuItem
            // 
            this.выбратьФайлToolStripMenuItem.Name = "выбратьФайлToolStripMenuItem";
            this.выбратьФайлToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.выбратьФайлToolStripMenuItem.Text = "Выбрать файл...";
            this.выбратьФайлToolStripMenuItem.Click += new System.EventHandler(this.выбратьФайлToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(805, 508);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.cbCompositions);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.gbLoop);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtbHistory);
            this.Controls.Add(this.btnLaDies);
            this.Controls.Add(this.btnSolDies);
            this.Controls.Add(this.btnFaDies);
            this.Controls.Add(this.btnReDies);
            this.Controls.Add(this.btnDoDies);
            this.Controls.Add(this.btnDo2);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.btnLa);
            this.Controls.Add(this.btnSol);
            this.Controls.Add(this.btnFa);
            this.Controls.Add(this.btnMi);
            this.Controls.Add(this.btnRe);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Симулятор пианино";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbLoop.ResumeLayout(false);
            this.gbLoop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авторизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnDoDies;
        private System.Windows.Forms.Button btnRe;
        private System.Windows.Forms.Button btnFa;
        private System.Windows.Forms.Button btnMi;
        private System.Windows.Forms.Button btnLa;
        private System.Windows.Forms.Button btnSol;
        private System.Windows.Forms.Button btnDo2;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnReDies;
        private System.Windows.Forms.Button btnFaDies;
        private System.Windows.Forms.Button btnSolDies;
        private System.Windows.Forms.Button btnLaDies;
        private System.Windows.Forms.RichTextBox rtbHistory;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbLoop;
        private System.Windows.Forms.CheckBox cbDo2;
        private System.Windows.Forms.CheckBox cbLa;
        private System.Windows.Forms.CheckBox cbFa;
        private System.Windows.Forms.CheckBox cbRe;
        private System.Windows.Forms.CheckBox cbSi;
        private System.Windows.Forms.CheckBox cbSol;
        private System.Windows.Forms.CheckBox cbMi;
        private System.Windows.Forms.CheckBox cbDo;
        private System.Windows.Forms.CheckBox cbLaDies;
        private System.Windows.Forms.CheckBox cbSolDies;
        private System.Windows.Forms.CheckBox cbFaDies;
        private System.Windows.Forms.CheckBox cbReDies;
        private System.Windows.Forms.CheckBox cbDoDies;
        private System.Windows.Forms.Button btnOffLaDies;
        private System.Windows.Forms.Button btnOffSolDies;
        private System.Windows.Forms.Button btnOffFaDies;
        private System.Windows.Forms.Button btnOffReDies;
        private System.Windows.Forms.Button btnOffDoDies;
        private System.Windows.Forms.Button btnOffDo2;
        private System.Windows.Forms.Button btnOffSi;
        private System.Windows.Forms.Button btnOffLa;
        private System.Windows.Forms.Button btnOffSol;
        private System.Windows.Forms.Button btnOffFa;
        private System.Windows.Forms.Button btnOffMi;
        private System.Windows.Forms.Button btnOffRe;
        private System.Windows.Forms.Button btnOffDo;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox cbCompositions;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripMenuItem загрузитьКомпозициюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьФайлToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}