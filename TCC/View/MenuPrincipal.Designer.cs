namespace TCC.View
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trabalhadoresStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesqClientesStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesqTrabalhadoresStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesqFornecedoresStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gráficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.palavrasProibidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.movimentosToolStripMenuItem,
            this.pesquisasToolStripMenuItem,
            this.gráficosToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.utilitáriosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(810, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesStripMenuItem,
            this.trabalhadoresStripMenuItem,
            this.fornecedoresStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "&Cadastros";
            // 
            // clientesStripMenuItem
            // 
            this.clientesStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clientesStripMenuItem.Image")));
            this.clientesStripMenuItem.Name = "clientesStripMenuItem";
            this.clientesStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.clientesStripMenuItem.Text = "&Clientes";
            this.clientesStripMenuItem.Click += new System.EventHandler(this.clientesStripMenuItem_Click);
            // 
            // trabalhadoresStripMenuItem
            // 
            this.trabalhadoresStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trabalhadoresStripMenuItem.Image")));
            this.trabalhadoresStripMenuItem.Name = "trabalhadoresStripMenuItem";
            this.trabalhadoresStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.trabalhadoresStripMenuItem.Text = "&Trabalhadores";
            this.trabalhadoresStripMenuItem.Click += new System.EventHandler(this.trabalhadoresStripMenuItem_Click);
            // 
            // fornecedoresStripMenuItem
            // 
            this.fornecedoresStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fornecedoresStripMenuItem.Image")));
            this.fornecedoresStripMenuItem.Name = "fornecedoresStripMenuItem";
            this.fornecedoresStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.fornecedoresStripMenuItem.Text = "&Fornecedores";
            this.fornecedoresStripMenuItem.Click += new System.EventHandler(this.fornecedoresStripMenuItem_Click);
            // 
            // movimentosToolStripMenuItem
            // 
            this.movimentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obrasToolStripMenuItem,
            this.projetosToolStripMenuItem});
            this.movimentosToolStripMenuItem.Name = "movimentosToolStripMenuItem";
            this.movimentosToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.movimentosToolStripMenuItem.Text = "&Movimentos";
            // 
            // obrasToolStripMenuItem
            // 
            this.obrasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("obrasToolStripMenuItem.Image")));
            this.obrasToolStripMenuItem.Name = "obrasToolStripMenuItem";
            this.obrasToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.obrasToolStripMenuItem.Text = "&Obras";
            this.obrasToolStripMenuItem.Click += new System.EventHandler(this.obrasToolStripMenuItem_Click);
            // 
            // projetosToolStripMenuItem
            // 
            this.projetosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("projetosToolStripMenuItem.Image")));
            this.projetosToolStripMenuItem.Name = "projetosToolStripMenuItem";
            this.projetosToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.projetosToolStripMenuItem.Text = "&Projetos";
            this.projetosToolStripMenuItem.Click += new System.EventHandler(this.projetosToolStripMenuItem_Click);
            // 
            // pesquisasToolStripMenuItem
            // 
            this.pesquisasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesqClientesStripMenuItem,
            this.pesqTrabalhadoresStripMenuItem,
            this.pesqFornecedoresStripMenuItem});
            this.pesquisasToolStripMenuItem.Name = "pesquisasToolStripMenuItem";
            this.pesquisasToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.pesquisasToolStripMenuItem.Text = "&Pesquisas";
            // 
            // pesqClientesStripMenuItem
            // 
            this.pesqClientesStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pesqClientesStripMenuItem.Image")));
            this.pesqClientesStripMenuItem.Name = "pesqClientesStripMenuItem";
            this.pesqClientesStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pesqClientesStripMenuItem.Text = "&Clientes";
            this.pesqClientesStripMenuItem.Click += new System.EventHandler(this.pesqClientesStripMenuItem_Click);
            // 
            // pesqTrabalhadoresStripMenuItem
            // 
            this.pesqTrabalhadoresStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pesqTrabalhadoresStripMenuItem.Image")));
            this.pesqTrabalhadoresStripMenuItem.Name = "pesqTrabalhadoresStripMenuItem";
            this.pesqTrabalhadoresStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pesqTrabalhadoresStripMenuItem.Text = "&Trabalhadores";
            this.pesqTrabalhadoresStripMenuItem.Click += new System.EventHandler(this.pesqTrabalhadoresStripMenuItem_Click);
            // 
            // pesqFornecedoresStripMenuItem
            // 
            this.pesqFornecedoresStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pesqFornecedoresStripMenuItem.Image")));
            this.pesqFornecedoresStripMenuItem.Name = "pesqFornecedoresStripMenuItem";
            this.pesqFornecedoresStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pesqFornecedoresStripMenuItem.Text = "&Fornecedores";
            this.pesqFornecedoresStripMenuItem.Click += new System.EventHandler(this.pesqFornecedoresStripMenuItem_Click);
            // 
            // gráficosToolStripMenuItem
            // 
            this.gráficosToolStripMenuItem.Name = "gráficosToolStripMenuItem";
            this.gráficosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.gráficosToolStripMenuItem.Text = "&Gráficos";
            this.gráficosToolStripMenuItem.Click += new System.EventHandler(this.gráficosToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "&Relatórios";
            this.relatóriosToolStripMenuItem.Click += new System.EventHandler(this.relatóriosToolStripMenuItem_Click);
            // 
            // utilitáriosToolStripMenuItem
            // 
            this.utilitáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarEmailToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.palavrasProibidasToolStripMenuItem});
            this.utilitáriosToolStripMenuItem.Name = "utilitáriosToolStripMenuItem";
            this.utilitáriosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.utilitáriosToolStripMenuItem.Text = "&Utilitários";
            // 
            // enviarEmailToolStripMenuItem
            // 
            this.enviarEmailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enviarEmailToolStripMenuItem.Image")));
            this.enviarEmailToolStripMenuItem.Name = "enviarEmailToolStripMenuItem";
            this.enviarEmailToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.enviarEmailToolStripMenuItem.Text = "&Enviar E-mail";
            this.enviarEmailToolStripMenuItem.Click += new System.EventHandler(this.enviarEmailToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backupToolStripMenuItem.Image")));
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.backupToolStripMenuItem.Text = "&Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logsToolStripMenuItem.Image")));
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.logsToolStripMenuItem.Text = "Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // palavrasProibidasToolStripMenuItem
            // 
            this.palavrasProibidasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("palavrasProibidasToolStripMenuItem.Image")));
            this.palavrasProibidasToolStripMenuItem.Name = "palavrasProibidasToolStripMenuItem";
            this.palavrasProibidasToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.palavrasProibidasToolStripMenuItem.Text = "Palavras Proibidas";
            this.palavrasProibidasToolStripMenuItem.Click += new System.EventHandler(this.palavrasProibidasToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(605, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 404);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 336);
            this.panel2.TabIndex = 5;
            this.panel2.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel2_ControlRemoved);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 30;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(810, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Status";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MenuPrincipal";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trabalhadoresStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesqClientesStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesqTrabalhadoresStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesqFornecedoresStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gráficosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarEmailToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem palavrasProibidasToolStripMenuItem;
    }
}