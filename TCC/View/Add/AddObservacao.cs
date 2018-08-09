using System;
using System.Linq;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Add
{
    public partial class AddObservacao : Form
    {
        private ObservacoesDAO obsDAO { get; set; }
        private ClientesDAO clientesDAO { get; set; }
        private TrabalhadoresDAO trabalhadoresDAO { get; set; }
        private FornecedoresDAO fornecedoresDAO { get; set; }
        private int id;

        public AddObservacao(int tipo, string id, string nome)
        {
            InitializeComponent();
            textPara.Text = nome;
            this.ActiveControl = textObservacao;
            this.id = Convert.ToInt16(id);

            obsDAO = new ObservacoesDAO();

            switch (tipo)
            {
                case 1:
                    this.Text += " - Cliente";
                    clientesDAO = new ClientesDAO();
                    break;
                case 2:
                    this.Text += " - Trabalhador";
                    trabalhadoresDAO = new TrabalhadoresDAO();
                    break;
                case 3:
                    this.Text += " - Fornecedor";
                    fornecedoresDAO = new FornecedoresDAO();
                    break;
            }
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            #region Validação dos campos
            errorProvider.SetError(textObservacao, string.Empty);

            if (textObservacao.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textObservacao, "Informe uma observação");
                textObservacao.Focus();
                return;
            }
            #endregion

            #region Colocar os dados da observação em um objeto
            try
            {
                Observacoes obs = new Observacoes();
                obs.Observacao = textObservacao.Text.Trim();
                obs.Data = Convert.ToDateTime(dateTimePicker.Value.ToShortDateString());

                textObservacao.Clear();
                textObservacao.Focus();

                switch (this.Text)
                {
                    case "Adicionar Observação - Cliente":
                        obs.Cliente = clientesDAO.select().Where(x => x.Id == id).First();
                        obsDAO.insertComCliente(obs);
                        break;
                    case "Adicionar Observação - Trabalhador":
                        obs.Trabalhador = trabalhadoresDAO.select().Where(x => x.Id == id).First();
                        obsDAO.insertComTrab(obs);
                        break;
                    case "Adicionar Observação - Fornecedor":
                        obs.Fornecedor = fornecedoresDAO.select().Where(x => x.Id == id).First();
                        obsDAO.insertComForn(obs);
                        break;
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}