namespace TCC.View
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textSenha = new System.Windows.Forms.TextBox();
            this.btEntrar = new System.Windows.Forms.Button();
            this.btSair = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.linkEsqueceu = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBoxSenha = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textCadSenha = new System.Windows.Forms.TextBox();
            this.pictureBoxPol = new System.Windows.Forms.PictureBox();
            this.btGerar = new System.Windows.Forms.Button();
            this.textBoxFundo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btCadSair = new System.Windows.Forms.Button();
            this.btCadastrar = new System.Windows.Forms.Button();
            this.textCadConfSenha = new System.Windows.Forms.TextBox();
            this.textCadLogin = new System.Windows.Forms.TextBox();
            this.textCadEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTipPolitica = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipRandom = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha";
            // 
            // textLogin
            // 
            this.errorProvider.SetIconPadding(this.textLogin, 5);
            this.textLogin.Location = new System.Drawing.Point(85, 40);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(194, 20);
            this.textLogin.TabIndex = 0;
            // 
            // textSenha
            // 
            this.errorProvider.SetIconPadding(this.textSenha, 5);
            this.textSenha.Location = new System.Drawing.Point(85, 77);
            this.textSenha.Name = "textSenha";
            this.textSenha.PasswordChar = '•';
            this.textSenha.Size = new System.Drawing.Size(194, 20);
            this.textSenha.TabIndex = 1;
            // 
            // btEntrar
            // 
            this.btEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btEntrar.Image")));
            this.btEntrar.Location = new System.Drawing.Point(32, 156);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(90, 35);
            this.btEntrar.TabIndex = 3;
            this.btEntrar.Text = "&Entrar";
            this.btEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEntrar.UseVisualStyleBackColor = true;
            this.btEntrar.Click += new System.EventHandler(this.btEntrar_Click);
            // 
            // btSair
            // 
            this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSair.Image = ((System.Drawing.Image)(resources.GetObject("btSair.Image")));
            this.btSair.Location = new System.Drawing.Point(214, 156);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(90, 35);
            this.btSair.TabIndex = 4;
            this.btSair.Text = "&Sair";
            this.btSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(342, 239);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.linkEsqueceu);
            this.tabPage1.Controls.Add(this.textLogin);
            this.tabPage1.Controls.Add(this.btEntrar);
            this.tabPage1.Controls.Add(this.btSair);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textSenha);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(334, 213);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            // 
            // linkEsqueceu
            // 
            this.linkEsqueceu.AutoSize = true;
            this.linkEsqueceu.Location = new System.Drawing.Point(118, 112);
            this.linkEsqueceu.Name = "linkEsqueceu";
            this.linkEsqueceu.Size = new System.Drawing.Size(108, 13);
            this.linkEsqueceu.TabIndex = 2;
            this.linkEsqueceu.TabStop = true;
            this.linkEsqueceu.Text = "Esqueci minha senha";
            this.linkEsqueceu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEsqueceu_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.pictureBoxSenha);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textCadSenha);
            this.tabPage2.Controls.Add(this.pictureBoxPol);
            this.tabPage2.Controls.Add(this.btGerar);
            this.tabPage2.Controls.Add(this.textBoxFundo);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.btCadSair);
            this.tabPage2.Controls.Add(this.btCadastrar);
            this.tabPage2.Controls.Add(this.textCadConfSenha);
            this.tabPage2.Controls.Add(this.textCadLogin);
            this.tabPage2.Controls.Add(this.textCadEmail);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(334, 213);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cadastro";
            // 
            // pictureBoxSenha
            // 
            this.pictureBoxSenha.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxSenha.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSenha.Image")));
            this.pictureBoxSenha.Location = new System.Drawing.Point(255, 84);
            this.pictureBoxSenha.Name = "pictureBoxSenha";
            this.pictureBoxSenha.Size = new System.Drawing.Size(21, 16);
            this.pictureBoxSenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSenha.TabIndex = 132;
            this.pictureBoxSenha.TabStop = false;
            this.pictureBoxSenha.Click += new System.EventHandler(this.pictureBoxSenha_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(310, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 127;
            this.label9.Text = "*";
            // 
            // textCadSenha
            // 
            this.textCadSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorProvider.SetIconPadding(this.textCadSenha, 5);
            this.textCadSenha.Location = new System.Drawing.Point(117, 85);
            this.textCadSenha.Name = "textCadSenha";
            this.textCadSenha.PasswordChar = '•';
            this.textCadSenha.Size = new System.Drawing.Size(132, 13);
            this.textCadSenha.TabIndex = 2;
            // 
            // pictureBoxPol
            // 
            this.pictureBoxPol.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxPol.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPol.Image")));
            this.pictureBoxPol.Location = new System.Drawing.Point(282, 84);
            this.pictureBoxPol.Name = "pictureBoxPol";
            this.pictureBoxPol.Size = new System.Drawing.Size(21, 16);
            this.pictureBoxPol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPol.TabIndex = 128;
            this.pictureBoxPol.TabStop = false;
            this.toolTipPolitica.SetToolTip(this.pictureBoxPol, resources.GetString("pictureBoxPol.ToolTip"));
            this.pictureBoxPol.MouseHover += new System.EventHandler(this.pictureBoxPol_MouseHover);
            // 
            // btGerar
            // 
            this.btGerar.Image = ((System.Drawing.Image)(resources.GetObject("btGerar.Image")));
            this.btGerar.Location = new System.Drawing.Point(124, 156);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(90, 35);
            this.btGerar.TabIndex = 5;
            this.btGerar.Text = "&Gerar";
            this.btGerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipRandom.SetToolTip(this.btGerar, "Gerar uma senha aleatória como exemplo");
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // textBoxFundo
            // 
            this.textBoxFundo.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider.SetIconPadding(this.textBoxFundo, 5);
            this.textBoxFundo.Location = new System.Drawing.Point(114, 82);
            this.textBoxFundo.Name = "textBoxFundo";
            this.textBoxFundo.ReadOnly = true;
            this.textBoxFundo.Size = new System.Drawing.Size(190, 20);
            this.textBoxFundo.TabIndex = 131;
            this.textBoxFundo.Enter += new System.EventHandler(this.textBoxFundo_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(310, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 126;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(310, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 125;
            this.label7.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(310, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 124;
            this.label13.Text = "*";
            // 
            // btCadSair
            // 
            this.btCadSair.Image = ((System.Drawing.Image)(resources.GetObject("btCadSair.Image")));
            this.btCadSair.Location = new System.Drawing.Point(231, 156);
            this.btCadSair.Name = "btCadSair";
            this.btCadSair.Size = new System.Drawing.Size(90, 35);
            this.btCadSair.TabIndex = 6;
            this.btCadSair.Text = "&Sair";
            this.btCadSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCadSair.UseVisualStyleBackColor = true;
            this.btCadSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btCadastrar
            // 
            this.btCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btCadastrar.Image")));
            this.btCadastrar.Location = new System.Drawing.Point(12, 156);
            this.btCadastrar.Name = "btCadastrar";
            this.btCadastrar.Size = new System.Drawing.Size(90, 35);
            this.btCadastrar.TabIndex = 4;
            this.btCadastrar.Text = "&Cadastrar";
            this.btCadastrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCadastrar.UseVisualStyleBackColor = true;
            this.btCadastrar.Click += new System.EventHandler(this.btCadastrar_Click);
            // 
            // textCadConfSenha
            // 
            this.errorProvider.SetIconPadding(this.textCadConfSenha, 5);
            this.textCadConfSenha.Location = new System.Drawing.Point(114, 117);
            this.textCadConfSenha.Name = "textCadConfSenha";
            this.textCadConfSenha.PasswordChar = '•';
            this.textCadConfSenha.Size = new System.Drawing.Size(190, 20);
            this.textCadConfSenha.TabIndex = 3;
            // 
            // textCadLogin
            // 
            this.errorProvider.SetIconPadding(this.textCadLogin, 5);
            this.textCadLogin.Location = new System.Drawing.Point(50, 47);
            this.textCadLogin.Name = "textCadLogin";
            this.textCadLogin.Size = new System.Drawing.Size(254, 20);
            this.textCadLogin.TabIndex = 1;
            // 
            // textCadEmail
            // 
            this.errorProvider.SetIconPadding(this.textCadEmail, 5);
            this.textCadEmail.Location = new System.Drawing.Point(50, 12);
            this.textCadEmail.Name = "textCadEmail";
            this.textCadEmail.Size = new System.Drawing.Size(254, 20);
            this.textCadEmail.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Confirme sua Senha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Informe uma Senha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "E-mail";
            // 
            // toolTipPolitica
            // 
            this.toolTipPolitica.AutoPopDelay = 5000;
            this.toolTipPolitica.InitialDelay = 500;
            this.toolTipPolitica.ReshowDelay = 50;
            this.toolTipPolitica.ToolTipTitle = "Política de Senha";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 200;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 239);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema - Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormLogin_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textSenha;
        private System.Windows.Forms.Button btEntrar;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btCadSair;
        private System.Windows.Forms.Button btCadastrar;
        private System.Windows.Forms.TextBox textCadConfSenha;
        private System.Windows.Forms.TextBox textCadSenha;
        private System.Windows.Forms.TextBox textCadLogin;
        private System.Windows.Forms.TextBox textCadEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkEsqueceu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBoxPol;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.ToolTip toolTipPolitica;
        private System.Windows.Forms.TextBox textBoxFundo;
        private System.Windows.Forms.ToolTip toolTipRandom;
        private System.Windows.Forms.PictureBox pictureBoxSenha;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}