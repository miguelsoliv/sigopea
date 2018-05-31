namespace TCC.View.Pesquisas
{
    partial class PesqClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PesqClientes));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btSair = new System.Windows.Forms.Button();
            this.groupBoxClientes = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textDocumento = new System.Windows.Forms.TextBox();
            this.textCidade = new System.Windows.Forms.TextBox();
            this.textUF = new System.Windows.Forms.TextBox();
            this.textTel2 = new System.Windows.Forms.TextBox();
            this.textTel = new System.Windows.Forms.TextBox();
            this.btFechar2 = new System.Windows.Forms.Button();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textEndereco = new System.Windows.Forms.TextBox();
            this.textNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.panelArrow = new System.Windows.Forms.Panel();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.listBoxObs = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btFechar = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            this.textObservacao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btDetalhes = new System.Windows.Forms.Button();
            this.groupBoxFCidade = new System.Windows.Forms.GroupBox();
            this.comboFCidade = new System.Windows.Forms.ComboBox();
            this.btLimpar = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.groupBoxFNome = new System.Windows.Forms.GroupBox();
            this.textFNome = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxClientes.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel.SuspendLayout();
            this.groupBoxFCidade.SuspendLayout();
            this.groupBoxFNome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView.Size = new System.Drawing.Size(941, 325);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
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
            // groupBoxClientes
            // 
            this.groupBoxClientes.Controls.Add(this.tabControl);
            this.groupBoxClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxClientes.Location = new System.Drawing.Point(0, 375);
            this.groupBoxClientes.Name = "groupBoxClientes";
            this.groupBoxClientes.Size = new System.Drawing.Size(941, 163);
            this.groupBoxClientes.TabIndex = 10;
            this.groupBoxClientes.TabStop = false;
            this.groupBoxClientes.Text = "Detalhes";
            this.groupBoxClientes.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 16);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(935, 144);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textDocumento);
            this.tabPage1.Controls.Add(this.textCidade);
            this.tabPage1.Controls.Add(this.textUF);
            this.tabPage1.Controls.Add(this.textTel2);
            this.tabPage1.Controls.Add(this.textTel);
            this.tabPage1.Controls.Add(this.btFechar2);
            this.tabPage1.Controls.Add(this.textEmail);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textEndereco);
            this.tabPage1.Controls.Add(this.textNome);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(927, 118);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informações Gerais";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textDocumento
            // 
            this.textDocumento.Location = new System.Drawing.Point(51, 49);
            this.textDocumento.Name = "textDocumento";
            this.textDocumento.ReadOnly = true;
            this.textDocumento.Size = new System.Drawing.Size(110, 20);
            this.textDocumento.TabIndex = 10;
            // 
            // textCidade
            // 
            this.textCidade.Location = new System.Drawing.Point(499, 49);
            this.textCidade.Name = "textCidade";
            this.textCidade.ReadOnly = true;
            this.textCidade.Size = new System.Drawing.Size(283, 20);
            this.textCidade.TabIndex = 12;
            // 
            // textUF
            // 
            this.textUF.Location = new System.Drawing.Point(329, 49);
            this.textUF.Name = "textUF";
            this.textUF.ReadOnly = true;
            this.textUF.Size = new System.Drawing.Size(110, 20);
            this.textUF.TabIndex = 11;
            // 
            // textTel2
            // 
            this.textTel2.Location = new System.Drawing.Point(683, 93);
            this.textTel2.Name = "textTel2";
            this.textTel2.ReadOnly = true;
            this.textTel2.Size = new System.Drawing.Size(99, 20);
            this.textTel2.TabIndex = 15;
            // 
            // textTel
            // 
            this.textTel.Location = new System.Drawing.Point(513, 93);
            this.textTel.Name = "textTel";
            this.textTel.ReadOnly = true;
            this.textTel.Size = new System.Drawing.Size(100, 20);
            this.textTel.TabIndex = 14;
            // 
            // btFechar2
            // 
            this.btFechar2.Image = ((System.Drawing.Image)(resources.GetObject("btFechar2.Image")));
            this.btFechar2.Location = new System.Drawing.Point(817, 40);
            this.btFechar2.Name = "btFechar2";
            this.btFechar2.Size = new System.Drawing.Size(104, 37);
            this.btFechar2.TabIndex = 16;
            this.btFechar2.Text = "&Fechar";
            this.btFechar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFechar2.UseVisualStyleBackColor = true;
            this.btFechar2.Click += new System.EventHandler(this.btFechar2_Click);
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(499, 6);
            this.textEmail.Name = "textEmail";
            this.textEmail.ReadOnly = true;
            this.textEmail.Size = new System.Drawing.Size(283, 20);
            this.textEmail.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(458, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 137;
            this.label9.Text = "E-mail";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 136;
            this.label8.Text = "Telefone 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 135;
            this.label5.Text = "Telefone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 134;
            this.label7.Text = "UF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Cidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 132;
            this.label3.Text = "Endereço";
            // 
            // textEndereco
            // 
            this.textEndereco.Location = new System.Drawing.Point(69, 93);
            this.textEndereco.Name = "textEndereco";
            this.textEndereco.ReadOnly = true;
            this.textEndereco.Size = new System.Drawing.Size(370, 20);
            this.textEndereco.TabIndex = 13;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(51, 6);
            this.textNome.Name = "textNome";
            this.textNome.ReadOnly = true;
            this.textNome.Size = new System.Drawing.Size(388, 20);
            this.textNome.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "CPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Nome";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btExcluir);
            this.tabPage2.Controls.Add(this.panelArrow);
            this.tabPage2.Controls.Add(this.listBoxData);
            this.tabPage2.Controls.Add(this.listBoxObs);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.btFechar);
            this.tabPage2.Controls.Add(this.btAlterar);
            this.tabPage2.Controls.Add(this.textObservacao);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(927, 118);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Observações";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(770, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "*";
            // 
            // btExcluir
            // 
            this.btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btExcluir.Image")));
            this.btExcluir.Location = new System.Drawing.Point(401, 45);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(100, 35);
            this.btExcluir.TabIndex = 18;
            this.btExcluir.Text = "&Excluir";
            this.btExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // panelArrow
            // 
            this.panelArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelArrow.BackgroundImage")));
            this.panelArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelArrow.Location = new System.Drawing.Point(165, 55);
            this.panelArrow.Name = "panelArrow";
            this.panelArrow.Size = new System.Drawing.Size(45, 34);
            this.panelArrow.TabIndex = 17;
            // 
            // listBoxData
            // 
            this.listBoxData.FormattingEnabled = true;
            this.listBoxData.Location = new System.Drawing.Point(9, 30);
            this.listBoxData.Name = "listBoxData";
            this.listBoxData.Size = new System.Drawing.Size(150, 82);
            this.listBoxData.TabIndex = 16;
            this.listBoxData.SelectedIndexChanged += new System.EventHandler(this.listBoxData_SelectedIndexChanged);
            // 
            // listBoxObs
            // 
            this.listBoxObs.FormattingEnabled = true;
            this.listBoxObs.Location = new System.Drawing.Point(216, 30);
            this.listBoxObs.Name = "listBoxObs";
            this.listBoxObs.Size = new System.Drawing.Size(150, 82);
            this.listBoxObs.TabIndex = 15;
            this.listBoxObs.SelectedIndexChanged += new System.EventHandler(this.listBoxObs_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(213, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Selecione a Observação";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Selecione a Data";
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.Location = new System.Drawing.Point(801, 77);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(100, 35);
            this.btFechar.TabIndex = 9;
            this.btFechar.Text = "&Fechar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Enabled = false;
            this.btAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btAlterar.Image")));
            this.btAlterar.Location = new System.Drawing.Point(801, 6);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(100, 35);
            this.btAlterar.TabIndex = 7;
            this.btAlterar.Text = "&Alterar";
            this.btAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // textObservacao
            // 
            this.textObservacao.AcceptsReturn = true;
            this.textObservacao.AcceptsTab = true;
            this.errorProvider.SetIconPadding(this.textObservacao, 5);
            this.textObservacao.Location = new System.Drawing.Point(576, 6);
            this.textObservacao.Multiline = true;
            this.textObservacao.Name = "textObservacao";
            this.textObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textObservacao.Size = new System.Drawing.Size(188, 106);
            this.textObservacao.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(505, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Observação";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btDetalhes);
            this.panel.Controls.Add(this.groupBoxFCidade);
            this.panel.Controls.Add(this.groupBoxFNome);
            this.panel.Controls.Add(this.btSair);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(941, 50);
            this.panel.TabIndex = 8;
            // 
            // btDetalhes
            // 
            this.btDetalhes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btDetalhes.Image = ((System.Drawing.Image)(resources.GetObject("btDetalhes.Image")));
            this.btDetalhes.Location = new System.Drawing.Point(640, 0);
            this.btDetalhes.Name = "btDetalhes";
            this.btDetalhes.Size = new System.Drawing.Size(108, 50);
            this.btDetalhes.TabIndex = 4;
            this.btDetalhes.Text = "&Ver Detalhes";
            this.btDetalhes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDetalhes.UseVisualStyleBackColor = true;
            this.btDetalhes.Click += new System.EventHandler(this.btDetalhes_Click);
            // 
            // groupBoxFCidade
            // 
            this.groupBoxFCidade.Controls.Add(this.comboFCidade);
            this.groupBoxFCidade.Controls.Add(this.btLimpar);
            this.groupBoxFCidade.Controls.Add(this.btPesquisar);
            this.groupBoxFCidade.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxFCidade.Location = new System.Drawing.Point(266, 0);
            this.groupBoxFCidade.Name = "groupBoxFCidade";
            this.groupBoxFCidade.Size = new System.Drawing.Size(374, 50);
            this.groupBoxFCidade.TabIndex = 14;
            this.groupBoxFCidade.TabStop = false;
            this.groupBoxFCidade.Text = "Filtro por Cidade";
            // 
            // comboFCidade
            // 
            this.comboFCidade.FormattingEnabled = true;
            this.comboFCidade.Location = new System.Drawing.Point(12, 19);
            this.comboFCidade.Name = "comboFCidade";
            this.comboFCidade.Size = new System.Drawing.Size(174, 21);
            this.comboFCidade.TabIndex = 1;
            this.comboFCidade.DropDown += new System.EventHandler(this.comboFCidade_DropDown);
            this.comboFCidade.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboFCidade_PreviewKeyDown);
            // 
            // btLimpar
            // 
            this.btLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btLimpar.Image")));
            this.btLimpar.Location = new System.Drawing.Point(291, 17);
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
            this.btPesquisar.Location = new System.Drawing.Point(201, 17);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(77, 23);
            this.btPesquisar.TabIndex = 2;
            this.btPesquisar.Text = "&Pesquisar";
            this.btPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // groupBoxFNome
            // 
            this.groupBoxFNome.Controls.Add(this.textFNome);
            this.groupBoxFNome.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxFNome.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFNome.Name = "groupBoxFNome";
            this.groupBoxFNome.Size = new System.Drawing.Size(266, 50);
            this.groupBoxFNome.TabIndex = 10;
            this.groupBoxFNome.TabStop = false;
            this.groupBoxFNome.Text = "Filtro por Nome do Cliente";
            // 
            // textFNome
            // 
            this.textFNome.Location = new System.Drawing.Point(12, 19);
            this.textFNome.Name = "textFNome";
            this.textFNome.Size = new System.Drawing.Size(227, 20);
            this.textFNome.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 200;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // PesqClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 538);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBoxClientes);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "PesqClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Clientes";
            this.Activated += new System.EventHandler(this.PesqClientes_Activated);
            this.Load += new System.EventHandler(this.PesqClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesqClientes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxClientes.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel.ResumeLayout(false);
            this.groupBoxFCidade.ResumeLayout(false);
            this.groupBoxFNome.ResumeLayout(false);
            this.groupBoxFNome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.GroupBox groupBoxClientes;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textTel2;
        private System.Windows.Forms.TextBox textTel;
        private System.Windows.Forms.Button btFechar2;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEndereco;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxFNome;
        private System.Windows.Forms.TextBox textFNome;
        private System.Windows.Forms.Button btDetalhes;
        private System.Windows.Forms.GroupBox groupBoxFCidade;
        private System.Windows.Forms.Button btLimpar;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox textUF;
        private System.Windows.Forms.TextBox textCidade;
        private System.Windows.Forms.TextBox textDocumento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.TextBox textObservacao;
        private System.Windows.Forms.ListBox listBoxData;
        private System.Windows.Forms.ListBox listBoxObs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelArrow;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox comboFCidade;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
    }
}