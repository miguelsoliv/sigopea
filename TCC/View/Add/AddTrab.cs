using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Add
{
    public partial class AddTrab : Form
    {
        private ObrasDAO obrasDAO { get; set; }
        private ObrasTrabalhadoresDAO otDAO { get; set; }
        private TrabalhadoresDAO trabalhadoresDAO { get; set; }

        public AddTrab(string id)
        {
            InitializeComponent();
            obrasDAO = new ObrasDAO();
            otDAO = new ObrasTrabalhadoresDAO();
            trabalhadoresDAO = new TrabalhadoresDAO();

            textId.Text = id;

            #region Inicialização do dataGridView (criação das colunas)
            dataGridTrab.Columns.Add("Id", "Código");
            dataGridTrab.Columns.Add("Trabalhador.Nome", "Trabalhador");
            dataGridTrab.Columns.Add("Servico", "Serviço");

            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 20;
            dataGridTrab.Columns.Add(checkboxColumn);

            dataGridTrab.Columns["Id"].Width = 45;
            dataGridTrab.Columns["Servico"].Width = 80;
            dataGridTrab.Columns["Trabalhador.Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion

            carregarOT();
        }

        private void carregarOT()
        {
            try
            {
                dataGridTrab.Rows.Clear();

                IEnumerable<ObrasTrabalhadores> listaOT = otDAO.select().Where(x => x.Obra.Id == Convert.ToInt16(textId.Text));

                if (listaOT.Count() < 1)
                {
                    foreach (Trabalhadores trab in trabalhadoresDAO.select())
                    {
                        dataGridTrab.Rows.Add(trab.Id, trab.Nome, trab.Servico);
                    }
                }
                else
                {
                    foreach (Trabalhadores trab in trabalhadoresDAO.select())
                    {
                        bool verif = true;

                        foreach (ObrasTrabalhadores obrasTrab in listaOT)
                        {
                            if (obrasTrab.Trabalhador.Id == trab.Id)
                            {
                                verif = false;
                                break;
                            }
                        }

                        if (verif == true)
                        {
                            dataGridTrab.Rows.Add(trab.Id, trab.Nome, trab.Servico);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridTrab.Rows)
            {
                if (Convert.ToBoolean(row.Cells[3].Value))
                {
                    Obras obra = new Obras();
                    obra = obrasDAO.select().Where(x => x.Id == Convert.ToInt16(textId.Text)).First();
                    Trabalhadores trab = new Trabalhadores();
                    trab = trabalhadoresDAO.select().Where(x => x.Id == Convert.ToInt16(row.Cells[0].Value)).First();
                    ObrasTrabalhadores ot = new ObrasTrabalhadores();
                    ot.Obra = obra;
                    ot.Trabalhador = trab;
                    otDAO.insert(ot);
                }
            }

            carregarOT();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}