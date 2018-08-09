namespace TCC.View
{
    partial class RelObras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelObras));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSair = new System.Windows.Forms.Button();
            this.btGerar = new System.Windows.Forms.Button();
            this.radioAgendProj = new System.Windows.Forms.RadioButton();
            this.radioAgendObra = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioUltimaFoto = new System.Windows.Forms.RadioButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 50);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(989, 480);
            this.webBrowser.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSair);
            this.groupBox1.Controls.Add(this.btGerar);
            this.groupBox1.Controls.Add(this.radioAgendProj);
            this.groupBox1.Controls.Add(this.radioAgendObra);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.radioUltimaFoto);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de Relatório";
            // 
            // btSair
            // 
            this.btSair.Image = ((System.Drawing.Image)(resources.GetObject("btSair.Image")));
            this.btSair.Location = new System.Drawing.Point(914, 5);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(75, 45);
            this.btSair.TabIndex = 6;
            this.btSair.Text = "&Sair";
            this.btSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btGerar
            // 
            this.btGerar.Image = ((System.Drawing.Image)(resources.GetObject("btGerar.Image")));
            this.btGerar.Location = new System.Drawing.Point(798, 5);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(110, 45);
            this.btGerar.TabIndex = 5;
            this.btGerar.Text = "&Gerar Relatório no Browser";
            this.btGerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // radioAgendProj
            // 
            this.radioAgendProj.AutoSize = true;
            this.radioAgendProj.Location = new System.Drawing.Point(553, 20);
            this.radioAgendProj.Name = "radioAgendProj";
            this.radioAgendProj.Size = new System.Drawing.Size(183, 17);
            this.radioAgendProj.TabIndex = 3;
            this.radioAgendProj.Text = "Projetos x Agendamentos Futuros";
            this.radioAgendProj.UseVisualStyleBackColor = true;
            this.radioAgendProj.CheckedChanged += new System.EventHandler(this.radioAgendProj_CheckedChanged);
            // 
            // radioAgendObra
            // 
            this.radioAgendObra.AutoSize = true;
            this.radioAgendObra.Location = new System.Drawing.Point(283, 20);
            this.radioAgendObra.Name = "radioAgendObra";
            this.radioAgendObra.Size = new System.Drawing.Size(173, 17);
            this.radioAgendObra.TabIndex = 2;
            this.radioAgendObra.Text = "Obras x Agendamentos Futuros";
            this.radioAgendObra.UseVisualStyleBackColor = true;
            this.radioAgendObra.CheckedChanged += new System.EventHandler(this.radioAgendObra_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(773, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox1, "A geração dos relatórios requer conexão com a internet e a sua exibição na aplica" +
        "ção requer o navegador Microsoft Edge para o funcionamento correto");
            // 
            // radioUltimaFoto
            // 
            this.radioUltimaFoto.AutoSize = true;
            this.radioUltimaFoto.Location = new System.Drawing.Point(12, 20);
            this.radioUltimaFoto.Name = "radioUltimaFoto";
            this.radioUltimaFoto.Size = new System.Drawing.Size(174, 17);
            this.radioUltimaFoto.TabIndex = 0;
            this.radioUltimaFoto.Text = "Obras x Última Foto Cadastrada";
            this.radioUltimaFoto.UseVisualStyleBackColor = true;
            this.radioUltimaFoto.CheckedChanged += new System.EventHandler(this.radioUltimaFoto_CheckedChanged);
            // 
            // RelObras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 530);
            this.ControlBox = false;
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RelObras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "6";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioUltimaFoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioAgendProj;
        private System.Windows.Forms.RadioButton radioAgendObra;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.ToolTip toolTip;
    }
}