using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TCC.Model.Classes;

namespace TCC.View
{
    public partial class GrafObras : Form
    {
        private ModelDB db;

        public GrafObras()
        {
            InitializeComponent();
            db = new ModelDB();
            chart1.Titles.Add("Title");

            try
            {
                comboAno.Items.Clear();

                foreach (var year in db.Obras.Select(x => x.DataInicio.Year).Distinct().ToList())
                {
                    comboAno.Items.Add(year);
                }

                comboAno.SelectedIndex = 0;
            }
            catch
            {

            }

            radioStatus.Checked = true;
        }

        private void gerarGraf(int tipo)
        {
            #region Limpar dados do gráfico
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            #endregion

            switch (tipo)
            {
                case 1:
                    label1.Visible = true;
                    comboAno.Visible = true;
                    chart1.Titles[0].Text = "Gráfico de Obras por Status/Ano";
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    chart1.Series[0].IsVisibleInLegend = true;
                    var check = false;
                    var check2 = false;

                    #region Gráfico: Obras x Status
                    try
                    {
                        var ano = Convert.ToInt16(comboAno.Text);
                        var lista = db.Obras.GroupBy(O => new { O.DataInicio.Year, O.Status.Nome, O.Excluido }).Select(o => new { DataInicio = o.Key.Year, Status = o.Key.Nome, Num = o.Count(), Excluido = o.Key.Excluido }).Where(x => x.Excluido == false && x.Status.Equals("Em Andamento") && x.DataInicio == ano).ToList();

                        foreach (var andamento in lista)
                        {
                            chart1.Series[0].Points.AddXY(andamento.Status, andamento.Num);
                        }

                        if (chart1.Series[0].Points.Count == 1)
                        {
                            chart1.Series[0].Points[0].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.SteelBlue);
                            check = true;
                        }

                        lista = db.Obras.GroupBy(O => new { O.DataInicio.Year, O.Status.Nome, O.Excluido }).Select(o => new { DataInicio = o.Key.Year, Status = o.Key.Nome, Num = o.Count(), Excluido = o.Key.Excluido }).Where(x => x.Excluido == false && x.Status.Equals("Parado") && x.DataInicio == ano).ToList();

                        foreach (var parado in lista)
                        {
                            chart1.Series[0].Points.AddXY(parado.Status, parado.Num);
                        }

                        if (chart1.Series[0].Points.Count == 2)
                        {
                            chart1.Series[0].Points[1].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.Yellow);
                        }
                        else if (chart1.Series[0].Points.Count == 1 && check == false)
                        {
                            chart1.Series[0].Points[0].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.Yellow);
                            check2 = true;
                        }

                        lista = db.Obras.GroupBy(O => new { O.DataInicio.Year, O.Status.Nome, O.Excluido }).Select(o => new { DataInicio = o.Key.Year, Status = o.Key.Nome, Num = o.Count(), Excluido = o.Key.Excluido }).Where(x => x.Excluido == false && x.Status.Equals("Finalizado") && x.DataInicio == ano).ToList();

                        foreach (var finalizado in lista)
                        {
                            chart1.Series[0].Points.AddXY(finalizado.Status, finalizado.Num);
                        }

                        if (chart1.Series[0].Points.Count == 3)
                        {
                            chart1.Series[0].Points[2].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.Red);
                        }
                        else if (chart1.Series[0].Points.Count == 2)
                        {
                            chart1.Series[0].Points[1].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.Red);
                        }
                        else if (chart1.Series[0].Points.Count == 1 && check == false && check2 == false)
                        {
                            chart1.Series[0].Points[0].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.Red);
                        }
                    }
                    catch
                    {

                    }
                    #endregion
                    break;
                case 2:
                    label1.Visible = false;
                    comboAno.Visible = false;
                    chart1.Titles[0].Text = "Gráfico de Clientes por Tipo";
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    chart1.Series[0].IsVisibleInLegend = true;
                    var check3 = false;

                    #region Gráfico: Pessoas x Empresas
                    try
                    {
                        var lista2 = db.Clientes.GroupBy(C => new { C.Cpf, C.Excluido }).Select(c => new { Cpf = c.Key.Cpf, Num = c.Count(), Excluido = c.Key.Excluido }).Where(x => x.Excluido == false && x.Cpf != null).ToList();
                        int valor = 0;

                        foreach (var cliente in lista2)
                        {
                            valor += cliente.Num;
                        }
                        
                        if (valor > 0)
                        {
                            chart1.Series[0].Points.AddXY("Pessoas", valor);
                            chart1.Series[0].Points[0].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.YellowGreen);
                            valor = 0;
                            check3 = true;
                        }

                        var lista3 = db.Clientes.GroupBy(C => new { C.Cnpj, C.Excluido }).Select(c => new { Cnpj = c.Key.Cnpj, Num = c.Count(), Excluido = c.Key.Excluido }).Where(x => x.Excluido == false && x.Cnpj != null).ToList();

                        foreach (var empresa in lista3)
                        {
                            valor += empresa.Num;
                        }

                        if (valor > 0)
                        {
                            chart1.Series[0].Points.AddXY("Empresas", valor);

                            if (check3 == false)
                            {
                                chart1.Series[0].Points[0].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.SlateGray);
                            }
                            else
                            {
                                chart1.Series[0].Points[1].Color = System.Drawing.Color.FromArgb(165, System.Drawing.Color.SlateGray);
                            }
                        }
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Deixar pontos do gráfico transparentes
                    try
                    {
                        chart1.ApplyPaletteColors();

                        foreach (DataPoint point in chart1.Series[0].Points)
                        {
                            point.Color = System.Drawing.Color.FromArgb(165, point.Color);
                        }
                    }
                    catch
                    {

                    }
                    #endregion
                    break;
                case 3:
                    label1.Visible = false;
                    comboAno.Visible = false;
                    chart1.Titles[0].Text = "Gráfico de Obras por Visitas Realizadas";
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    chart1.Series[0].IsVisibleInLegend = false;
                    chart1.ChartAreas[0].AxisX.Title = "Código da Obra";
                    chart1.ChartAreas[0].AxisY.Title = "Número de Visitas Realizadas";
                    chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Stacked;

                    #region Gráfico: Obras x Visita
                    try
                    {
                        var lista4 = db.Fotos.GroupBy(F => new { F.Obra, F.Obra.Status }).Select(f => new { Obra = f.Key.Obra.Id, Status = f.Key.Status, Num = f.Count() }).Where(x => x.Status.Nome == "Em Andamento").ToList();

                        foreach (var cliente in lista4)
                        {
                            chart1.Series[0].Points.AddXY(cliente.Obra, cliente.Num);
                        }
                    }
                    catch
                    {

                    }
                    #endregion
                    break;
            }
        }

        #region Radio buttons
        private void radioStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (radioStatus.Checked)
            {
                gerarGraf(1);
            }
        }

        private void radioClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioClientes.Checked)
            {
                gerarGraf(2);
            }
        }

        private void radioVisitas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVisitas.Checked)
            {
                gerarGraf(3);
            }
        }
        #endregion

        private void comboAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioStatus.Checked)
            {
                gerarGraf(1);
            }
        }

        private void GrafObras_Activated(object sender, EventArgs e)
        {
            try
            {
                comboAno.Items.Clear();

                foreach (var year in db.Obras.Select(x => x.DataInicio.Year).Distinct().ToList())
                {
                    comboAno.Items.Add(year);
                }

                comboAno.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            #region Botão sair
            this.Close();
            #endregion
        }
    }
}