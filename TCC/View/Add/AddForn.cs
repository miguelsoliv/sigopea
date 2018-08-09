using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Add
{
    public partial class AddForn : Form
    {
        private ObrasDAO obrasDAO { get; set; }
        private ObrasFornecedoresDAO ofDAO { get; set; }
        private FornecedoresDAO fornecedoresDAO { get; set; }

        public AddForn(string id)
        {
            InitializeComponent();
            obrasDAO = new ObrasDAO();
            ofDAO = new ObrasFornecedoresDAO();
            fornecedoresDAO = new FornecedoresDAO();

            textId.Text = id;

            #region Inicialização do dataGridView (criação das colunas)
            dataGridForn.Columns.Add("Id", "Código");
            dataGridForn.Columns.Add("Fornecedor.Nome", "Fornecedor");

            DataGridViewCheckBoxColumn checkboxColumn2 = new DataGridViewCheckBoxColumn();
            checkboxColumn2.Width = 20;
            dataGridForn.Columns.Add(checkboxColumn2);

            dataGridForn.Columns["Id"].Width = 45;
            dataGridForn.Columns["Fornecedor.Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion

            carregarOF();
        }

        private void carregarOF()
        {
            try
            {
                dataGridForn.Rows.Clear();

                IEnumerable<ObrasFornecedores> listaOF = ofDAO.select().Where(x => x.Obra.Id == Convert.ToInt16(textId.Text));

                if (listaOF.Count() < 1)
                {
                    foreach (Fornecedores forn in fornecedoresDAO.select())
                    {
                        dataGridForn.Rows.Add(forn.Id, forn.Nome);
                    }
                }
                else
                {
                    foreach (Fornecedores forn in fornecedoresDAO.select())
                    {
                        bool verif = true;

                        foreach (ObrasFornecedores obrasForn in listaOF)
                        {
                            if (obrasForn.Fornecedor.Id == forn.Id)
                            {
                                verif = false;
                                break;
                            }
                        }

                        if (verif == true)
                        {
                            dataGridForn.Rows.Add(forn.Id, forn.Nome);
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
            foreach (DataGridViewRow row in dataGridForn.Rows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value))
                {
                    Obras obra = new Obras();
                    obra = obrasDAO.select().Where(x => x.Id == Convert.ToInt16(textId.Text)).First();
                    Fornecedores forn = new Fornecedores();
                    forn = fornecedoresDAO.select().Where(x => x.Id == Convert.ToInt16(row.Cells[0].Value)).First();
                    ObrasFornecedores of = new ObrasFornecedores();
                    of.Obra = obra;
                    of.Fornecedor = forn;
                    of.Observacao = textObs.Text;
                    ofDAO.insert(of);
                }
            }

            carregarOF();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}