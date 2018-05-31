namespace TCC.View.Listagens_Cadastros
{
    partial class ListTrab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListTrab));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboUF = new System.Windows.Forms.ComboBox();
            this.comboCidade = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textEndereco = new System.Windows.Forms.TextBox();
            this.textNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btSair = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btIncluir = new System.Windows.Forms.Button();
            this.groupBoxTrab = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maskedDocumento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTel2 = new System.Windows.Forms.TextBox();
            this.textTel = new System.Windows.Forms.TextBox();
            this.comboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxTrab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.Location = new System.Drawing.Point(818, 110);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(104, 37);
            this.btCancelar.TabIndex = 15;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btSalvar.Image")));
            this.btSalvar.Location = new System.Drawing.Point(818, 35);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(104, 37);
            this.btSalvar.TabIndex = 14;
            this.btSalvar.Text = "&Salvar";
            this.btSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // textEmail
            // 
            this.errorProvider.SetIconPadding(this.textEmail, 5);
            this.textEmail.Location = new System.Drawing.Point(504, 35);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(266, 20);
            this.textEmail.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(463, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 118;
            this.label9.Text = "E-mail";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(624, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 117;
            this.label8.Text = "Telefone 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Telefone";
            // 
            // comboUF
            // 
            this.comboUF.DisplayMember = "0";
            this.comboUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUF.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.comboUF, 5);
            this.comboUF.Location = new System.Drawing.Point(365, 79);
            this.comboUF.Name = "comboUF";
            this.comboUF.Size = new System.Drawing.Size(62, 21);
            this.comboUF.TabIndex = 9;
            this.comboUF.SelectedIndexChanged += new System.EventHandler(this.comboUF_SelectedIndexChanged);
            // 
            // comboCidade
            // 
            this.comboCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCidade.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.comboCidade, 5);
            this.comboCidade.Location = new System.Drawing.Point(509, 79);
            this.comboCidade.Name = "comboCidade";
            this.comboCidade.Size = new System.Drawing.Size(261, 21);
            this.comboCidade.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 115;
            this.label7.Text = "UF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Cidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 113;
            this.label3.Text = "Endereço";
            // 
            // textEndereco
            // 
            this.errorProvider.SetIconPadding(this.textEndereco, 5);
            this.textEndereco.Location = new System.Drawing.Point(74, 127);
            this.textEndereco.Name = "textEndereco";
            this.textEndereco.Size = new System.Drawing.Size(353, 20);
            this.textEndereco.TabIndex = 11;
            // 
            // textNome
            // 
            this.errorProvider.SetIconPadding(this.textNome, 5);
            this.textNome.Location = new System.Drawing.Point(56, 35);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(371, 20);
            this.textNome.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "Nome";
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(941, 325);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // btSair
            // 
            this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSair.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSair.Image = ((System.Drawing.Image)(resources.GetObject("btSair.Image")));
            this.btSair.Location = new System.Drawing.Point(866, 0);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(75, 50);
            this.btSair.TabIndex = 3;
            this.btSair.Text = "&Sair";
            this.btSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btExcluir.Image")));
            this.btExcluir.Location = new System.Drawing.Point(150, 0);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 50);
            this.btExcluir.TabIndex = 2;
            this.btExcluir.Text = "&Excluir";
            this.btExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btAlterar.Image")));
            this.btAlterar.Location = new System.Drawing.Point(75, 0);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(75, 50);
            this.btAlterar.TabIndex = 1;
            this.btAlterar.Text = "&Alterar";
            this.btAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btIncluir
            // 
            this.btIncluir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btIncluir.Image")));
            this.btIncluir.Location = new System.Drawing.Point(0, 0);
            this.btIncluir.Name = "btIncluir";
            this.btIncluir.Size = new System.Drawing.Size(75, 50);
            this.btIncluir.TabIndex = 0;
            this.btIncluir.Text = "&Incluir";
            this.btIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btIncluir.UseVisualStyleBackColor = true;
            this.btIncluir.Click += new System.EventHandler(this.btIncluir_Click);
            // 
            // groupBoxTrab
            // 
            this.groupBoxTrab.Controls.Add(this.label14);
            this.groupBoxTrab.Controls.Add(this.label13);
            this.groupBoxTrab.Controls.Add(this.label12);
            this.groupBoxTrab.Controls.Add(this.label11);
            this.groupBoxTrab.Controls.Add(this.label10);
            this.groupBoxTrab.Controls.Add(this.maskedDocumento);
            this.groupBoxTrab.Controls.Add(this.label4);
            this.groupBoxTrab.Controls.Add(this.textTel2);
            this.groupBoxTrab.Controls.Add(this.textTel);
            this.groupBoxTrab.Controls.Add(this.comboServico);
            this.groupBoxTrab.Controls.Add(this.label2);
            this.groupBoxTrab.Controls.Add(this.btCancelar);
            this.groupBoxTrab.Controls.Add(this.btSalvar);
            this.groupBoxTrab.Controls.Add(this.textEmail);
            this.groupBoxTrab.Controls.Add(this.label9);
            this.groupBoxTrab.Controls.Add(this.label8);
            this.groupBoxTrab.Controls.Add(this.label5);
            this.groupBoxTrab.Controls.Add(this.comboUF);
            this.groupBoxTrab.Controls.Add(this.comboCidade);
            this.groupBoxTrab.Controls.Add(this.label7);
            this.groupBoxTrab.Controls.Add(this.label6);
            this.groupBoxTrab.Controls.Add(this.label3);
            this.groupBoxTrab.Controls.Add(this.textEndereco);
            this.groupBoxTrab.Controls.Add(this.textNome);
            this.groupBoxTrab.Controls.Add(this.label1);
            this.groupBoxTrab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxTrab.Location = new System.Drawing.Point(0, 375);
            this.groupBoxTrab.Name = "groupBoxTrab";
            this.groupBoxTrab.Size = new System.Drawing.Size(941, 163);
            this.groupBoxTrab.TabIndex = 10;
            this.groupBoxTrab.TabStop = false;
            this.groupBoxTrab.Text = "groupBox";
            this.groupBoxTrab.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(606, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 13);
            this.label14.TabIndex = 132;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(433, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 131;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(171, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 130;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(776, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 129;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(433, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 128;
            this.label10.Text = "*";
            // 
            // maskedDocumento
            // 
            this.errorProvider.SetIconPadding(this.maskedDocumento, 5);
            this.maskedDocumento.Location = new System.Drawing.Point(222, 79);
            this.maskedDocumento.Mask = "000,000,000-00";
            this.maskedDocumento.Name = "maskedDocumento";
            this.maskedDocumento.Size = new System.Drawing.Size(100, 20);
            this.maskedDocumento.TabIndex = 8;
            this.maskedDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "CPF";
            // 
            // textTel2
            // 
            this.errorProvider.SetIconPadding(this.textTel2, 5);
            this.textTel2.Location = new System.Drawing.Point(688, 127);
            this.textTel2.Name = "textTel2";
            this.textTel2.Size = new System.Drawing.Size(82, 20);
            this.textTel2.TabIndex = 13;
            // 
            // textTel
            // 
            this.errorProvider.SetIconPadding(this.textTel, 5);
            this.textTel.Location = new System.Drawing.Point(518, 127);
            this.textTel.Name = "textTel";
            this.textTel.Size = new System.Drawing.Size(82, 20);
            this.textTel.TabIndex = 12;
            // 
            // comboServico
            // 
            this.comboServico.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.comboServico, 5);
            this.comboServico.Location = new System.Drawing.Point(64, 79);
            this.comboServico.Name = "comboServico";
            this.comboServico.Size = new System.Drawing.Size(101, 21);
            this.comboServico.TabIndex = 7;
            this.comboServico.DropDown += new System.EventHandler(this.comboServico_DropDown);
            this.comboServico.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboServico_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Serviço";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSair);
            this.panel1.Controls.Add(this.btExcluir);
            this.panel1.Controls.Add(this.btAlterar);
            this.panel1.Controls.Add(this.btIncluir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 50);
            this.panel1.TabIndex = 8;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 200;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // ListTrab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 538);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBoxTrab);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "ListTrab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Trabalhadores";
            this.Activated += new System.EventHandler(this.ListTrab_Activated);
            this.Load += new System.EventHandler(this.ListTrab_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListTrab_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxTrab.ResumeLayout(false);
            this.groupBoxTrab.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboUF;
        private System.Windows.Forms.ComboBox comboCidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEndereco;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.Button btIncluir;
        private System.Windows.Forms.GroupBox groupBoxTrab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboServico;
        private System.Windows.Forms.TextBox textTel;
        private System.Windows.Forms.TextBox textTel2;
        private System.Windows.Forms.MaskedTextBox maskedDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}