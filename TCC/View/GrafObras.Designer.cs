namespace TCC.View
{
    partial class GrafObras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrafObras));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioVisitas = new System.Windows.Forms.RadioButton();
            this.btSair = new System.Windows.Forms.Button();
            this.radioClientes = new System.Windows.Forms.RadioButton();
            this.radioStatus = new System.Windows.Forms.RadioButton();
            this.comboAno = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioVisitas);
            this.groupBox1.Controls.Add(this.btSair);
            this.groupBox1.Controls.Add(this.radioClientes);
            this.groupBox1.Controls.Add(this.radioStatus);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de Gráfico";
            // 
            // radioVisitas
            // 
            this.radioVisitas.AutoSize = true;
            this.radioVisitas.Location = new System.Drawing.Point(553, 20);
            this.radioVisitas.Name = "radioVisitas";
            this.radioVisitas.Size = new System.Drawing.Size(132, 17);
            this.radioVisitas.TabIndex = 4;
            this.radioVisitas.TabStop = true;
            this.radioVisitas.Text = "Obras x Fotos ( Visitas)";
            this.radioVisitas.UseVisualStyleBackColor = true;
            this.radioVisitas.CheckedChanged += new System.EventHandler(this.radioVisitas_CheckedChanged);
            // 
            // btSair
            // 
            this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSair.Image = ((System.Drawing.Image)(resources.GetObject("btSair.Image")));
            this.btSair.Location = new System.Drawing.Point(914, 5);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(75, 45);
            this.btSair.TabIndex = 3;
            this.btSair.Text = "&Sair";
            this.btSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // radioClientes
            // 
            this.radioClientes.AutoSize = true;
            this.radioClientes.Location = new System.Drawing.Point(283, 20);
            this.radioClientes.Name = "radioClientes";
            this.radioClientes.Size = new System.Drawing.Size(165, 17);
            this.radioClientes.TabIndex = 1;
            this.radioClientes.Text = "Clientes: Pessoas x Empresas";
            this.radioClientes.UseVisualStyleBackColor = true;
            this.radioClientes.CheckedChanged += new System.EventHandler(this.radioClientes_CheckedChanged);
            // 
            // radioStatus
            // 
            this.radioStatus.AutoSize = true;
            this.radioStatus.Location = new System.Drawing.Point(12, 20);
            this.radioStatus.Name = "radioStatus";
            this.radioStatus.Size = new System.Drawing.Size(143, 17);
            this.radioStatus.TabIndex = 0;
            this.radioStatus.Text = "Obras x Status ( por Ano)";
            this.radioStatus.UseVisualStyleBackColor = true;
            this.radioStatus.CheckedChanged += new System.EventHandler(this.radioStatus_CheckedChanged);
            // 
            // comboAno
            // 
            this.comboAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAno.FormattingEnabled = true;
            this.comboAno.Location = new System.Drawing.Point(836, 314);
            this.comboAno.Name = "comboAno";
            this.comboAno.Size = new System.Drawing.Size(141, 21);
            this.comboAno.TabIndex = 2;
            this.comboAno.SelectedIndexChanged += new System.EventHandler(this.comboAno_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(833, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione o Ano";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.PointDepth = 110;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            legend1.Title = "Legenda";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 50);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Label = "#VALY\\n(#PERCENT{P2})";
            series1.LabelFormat = "$#,##0.00;($#,##0.00);Zero\")";
            series1.Legend = "Legend1";
            series1.LegendText = "#VALX";
            series1.Name = "Series1";
            series1.ShadowOffset = 1;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(989, 480);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart2";
            // 
            // GrafObras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSair;
            this.ClientSize = new System.Drawing.Size(989, 530);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboAno);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GrafObras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráficos";
            this.Activated += new System.EventHandler(this.GrafObras_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioStatus;
        private System.Windows.Forms.RadioButton radioClientes;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.ComboBox comboAno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton radioVisitas;
    }
}