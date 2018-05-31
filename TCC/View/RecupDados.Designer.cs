namespace TCC.View
{
    partial class RecupDados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecupDados));
            this.btCancelar = new System.Windows.Forms.Button();
            this.btRecuperar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textSenhaAntiga = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.textConfSenha = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.textSenhaNova = new System.Windows.Forms.TextBox();
            this.textBoxFundo = new System.Windows.Forms.TextBox();
            this.pictureBoxSenha = new System.Windows.Forms.PictureBox();
            this.pictureBoxPol = new System.Windows.Forms.PictureBox();
            this.toolTipPolitica = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPol)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.Location = new System.Drawing.Point(255, 200);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 27);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btRecuperar
            // 
            this.btRecuperar.Image = ((System.Drawing.Image)(resources.GetObject("btRecuperar.Image")));
            this.btRecuperar.Location = new System.Drawing.Point(15, 200);
            this.btRecuperar.Name = "btRecuperar";
            this.btRecuperar.Size = new System.Drawing.Size(75, 27);
            this.btRecuperar.TabIndex = 4;
            this.btRecuperar.Text = "&Trocar";
            this.btRecuperar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRecuperar.UseVisualStyleBackColor = true;
            this.btRecuperar.Click += new System.EventHandler(this.btRecuperar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Senha Nova";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Senha Antiga";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "E-mail";
            // 
            // textSenhaAntiga
            // 
            this.errorProvider.SetIconPadding(this.textSenhaAntiga, 5);
            this.textSenhaAntiga.Location = new System.Drawing.Point(89, 64);
            this.textSenhaAntiga.Name = "textSenhaAntiga";
            this.textSenhaAntiga.PasswordChar = '•';
            this.textSenhaAntiga.Size = new System.Drawing.Size(224, 20);
            this.textSenhaAntiga.TabIndex = 1;
            // 
            // textEmail
            // 
            this.errorProvider.SetIconPadding(this.textEmail, 5);
            this.textEmail.Location = new System.Drawing.Point(53, 19);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(260, 20);
            this.textEmail.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPG/PNG|*.jpg;*.png|Todos os arquivos|*.*";
            this.openFileDialog.Title = "Anexar imagem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Confirmar Senha";
            // 
            // textConfSenha
            // 
            this.textConfSenha.AcceptsReturn = true;
            this.textConfSenha.AcceptsTab = true;
            this.errorProvider.SetIconPadding(this.textConfSenha, 5);
            this.textConfSenha.Location = new System.Drawing.Point(103, 151);
            this.textConfSenha.Name = "textConfSenha";
            this.textConfSenha.PasswordChar = '•';
            this.textConfSenha.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textConfSenha.Size = new System.Drawing.Size(210, 20);
            this.textConfSenha.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(319, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 124;
            this.label13.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(319, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(319, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 126;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(319, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 127;
            this.label7.Text = "*";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 200;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // textSenhaNova
            // 
            this.textSenhaNova.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorProvider.SetIconPadding(this.textSenhaNova, 5);
            this.textSenhaNova.Location = new System.Drawing.Point(92, 110);
            this.textSenhaNova.Name = "textSenhaNova";
            this.textSenhaNova.PasswordChar = '•';
            this.textSenhaNova.Size = new System.Drawing.Size(165, 13);
            this.textSenhaNova.TabIndex = 2;
            // 
            // textBoxFundo
            // 
            this.textBoxFundo.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider.SetIconPadding(this.textBoxFundo, 5);
            this.textBoxFundo.Location = new System.Drawing.Point(89, 107);
            this.textBoxFundo.Name = "textBoxFundo";
            this.textBoxFundo.ReadOnly = true;
            this.textBoxFundo.Size = new System.Drawing.Size(224, 20);
            this.textBoxFundo.TabIndex = 135;
            this.textBoxFundo.Enter += new System.EventHandler(this.textBoxFundo_Enter);
            // 
            // pictureBoxSenha
            // 
            this.pictureBoxSenha.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxSenha.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSenha.Image")));
            this.pictureBoxSenha.Location = new System.Drawing.Point(263, 109);
            this.pictureBoxSenha.Name = "pictureBoxSenha";
            this.pictureBoxSenha.Size = new System.Drawing.Size(21, 16);
            this.pictureBoxSenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSenha.TabIndex = 136;
            this.pictureBoxSenha.TabStop = false;
            this.pictureBoxSenha.Click += new System.EventHandler(this.pictureBoxSenha_Click);
            // 
            // pictureBoxPol
            // 
            this.pictureBoxPol.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxPol.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPol.Image")));
            this.pictureBoxPol.Location = new System.Drawing.Point(290, 109);
            this.pictureBoxPol.Name = "pictureBoxPol";
            this.pictureBoxPol.Size = new System.Drawing.Size(21, 16);
            this.pictureBoxPol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPol.TabIndex = 134;
            this.pictureBoxPol.TabStop = false;
            this.toolTipPolitica.SetToolTip(this.pictureBoxPol, resources.GetString("pictureBoxPol.ToolTip"));
            // 
            // toolTipPolitica
            // 
            this.toolTipPolitica.AutoPopDelay = 5000;
            this.toolTipPolitica.InitialDelay = 500;
            this.toolTipPolitica.ReshowDelay = 50;
            this.toolTipPolitica.ToolTipTitle = "Política de Senha";
            // 
            // RecupDados
            // 
            this.AcceptButton = this.btRecuperar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(342, 239);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxSenha);
            this.Controls.Add(this.textSenhaNova);
            this.Controls.Add(this.pictureBoxPol);
            this.Controls.Add(this.textBoxFundo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textConfSenha);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btRecuperar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSenhaAntiga);
            this.Controls.Add(this.textEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RecupDados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema - Trocar Senha";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btRecuperar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSenhaAntiga;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textConfSenha;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.PictureBox pictureBoxSenha;
        private System.Windows.Forms.TextBox textSenhaNova;
        private System.Windows.Forms.PictureBox pictureBoxPol;
        private System.Windows.Forms.TextBox textBoxFundo;
        private System.Windows.Forms.ToolTip toolTipPolitica;
    }
}