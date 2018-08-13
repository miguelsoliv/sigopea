namespace TCC.View.Admin
{
    partial class LogsAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkData = new System.Windows.Forms.CheckBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btLimpar = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.groupBoxFAcao = new System.Windows.Forms.GroupBox();
            this.comboFAcao = new System.Windows.Forms.ComboBox();
            this.groupBoxFUsuario = new System.Windows.Forms.GroupBox();
            this.comboFUsuario = new System.Windows.Forms.ComboBox();
            this.btSair = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxFAcao.SuspendLayout();
            this.groupBoxFUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Controls.Add(this.groupBoxFAcao);
            this.panel.Controls.Add(this.groupBoxFUsuario);
            this.panel.Controls.Add(this.btSair);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(941, 50);
            this.panel.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkData);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.btLimpar);
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(437, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 50);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // checkData
            // 
            this.checkData.AutoSize = true;
            this.checkData.Location = new System.Drawing.Point(6, 0);
            this.checkData.Name = "checkData";
            this.checkData.Size = new System.Drawing.Size(143, 17);
            this.checkData.TabIndex = 6;
            this.checkData.Text = "Mostrar Logs até a Data:";
            this.checkData.UseVisualStyleBackColor = true;
            this.checkData.CheckedChanged += new System.EventHandler(this.checkData_CheckedChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Location = new System.Drawing.Point(6, 20);
            this.dateTimePicker.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(226, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // btLimpar
            // 
            this.btLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btLimpar.Image")));
            this.btLimpar.Location = new System.Drawing.Point(320, 17);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(77, 23);
            this.btLimpar.TabIndex = 3;
            this.btLimpar.Text = "&Limpar";
            this.btLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // btPesquisar
            // 
            this.btPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btPesquisar.Image")));
            this.btPesquisar.Location = new System.Drawing.Point(238, 17);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(77, 23);
            this.btPesquisar.TabIndex = 2;
            this.btPesquisar.Text = "&Pesquisar";
            this.btPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // groupBoxFAcao
            // 
            this.groupBoxFAcao.Controls.Add(this.comboFAcao);
            this.groupBoxFAcao.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxFAcao.Location = new System.Drawing.Point(228, 0);
            this.groupBoxFAcao.Name = "groupBoxFAcao";
            this.groupBoxFAcao.Size = new System.Drawing.Size(209, 50);
            this.groupBoxFAcao.TabIndex = 14;
            this.groupBoxFAcao.TabStop = false;
            this.groupBoxFAcao.Text = "Filtro por Ação";
            // 
            // comboFAcao
            // 
            this.comboFAcao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboFAcao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboFAcao.FormattingEnabled = true;
            this.comboFAcao.Location = new System.Drawing.Point(12, 19);
            this.comboFAcao.Name = "comboFAcao";
            this.comboFAcao.Size = new System.Drawing.Size(179, 21);
            this.comboFAcao.TabIndex = 1;
            this.comboFAcao.DropDown += new System.EventHandler(this.comboFAcao_DropDown);
            this.comboFAcao.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboFAcao_PreviewKeyDown);
            // 
            // groupBoxFUsuario
            // 
            this.groupBoxFUsuario.Controls.Add(this.comboFUsuario);
            this.groupBoxFUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxFUsuario.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFUsuario.Name = "groupBoxFUsuario";
            this.groupBoxFUsuario.Size = new System.Drawing.Size(228, 50);
            this.groupBoxFUsuario.TabIndex = 10;
            this.groupBoxFUsuario.TabStop = false;
            this.groupBoxFUsuario.Text = "Filtro por Usuário";
            // 
            // comboFUsuario
            // 
            this.comboFUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboFUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboFUsuario.FormattingEnabled = true;
            this.comboFUsuario.Location = new System.Drawing.Point(12, 19);
            this.comboFUsuario.Name = "comboFUsuario";
            this.comboFUsuario.Size = new System.Drawing.Size(181, 21);
            this.comboFUsuario.TabIndex = 15;
            this.comboFUsuario.DropDown += new System.EventHandler(this.comboFUsuario_DropDown);
            this.comboFUsuario.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboFUsuario_PreviewKeyDown);
            // 
            // btSair
            // 
            this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSair.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSair.Image = ((System.Drawing.Image)(resources.GetObject("btSair.Image")));
            this.btSair.Location = new System.Drawing.Point(866, 0);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(75, 50);
            this.btSair.TabIndex = 5;
            this.btSair.Text = "&Sair";
            this.btSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 50);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(941, 488);
            this.dataGridView.TabIndex = 11;
            // 
            // LogsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSair;
            this.ClientSize = new System.Drawing.Size(941, 538);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LogsAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs";
            this.Activated += new System.EventHandler(this.LogsAdmin_Activated);
            this.Load += new System.EventHandler(this.LogsAdmin_Load);
            this.panel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxFAcao.ResumeLayout(false);
            this.groupBoxFUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox groupBoxFAcao;
        private System.Windows.Forms.ComboBox comboFAcao;
        private System.Windows.Forms.Button btLimpar;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.GroupBox groupBoxFUsuario;
        private System.Windows.Forms.ComboBox comboFUsuario;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.CheckBox checkData;
    }
}