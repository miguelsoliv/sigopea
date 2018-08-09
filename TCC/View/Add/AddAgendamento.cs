using System;
using System.Linq;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Add
{
    public partial class AddAgendamento : Form
    {
        private AgendamentosDAO agendDAO { get; set; }
        private ProjetosDAO projetosDAO { get; set; }
        private ObrasDAO obrasDAO { get; set; }

        public AddAgendamento(int tipo, string id)
        {
            InitializeComponent();
            this.ActiveControl = textAssunto;
            textPara.Text = id;

            agendDAO = new AgendamentosDAO();
            
            switch (tipo)
            {
                case 1:
                    this.Text += " - Projeto";
                    projetosDAO = new ProjetosDAO();
                    break;
                case 2:
                    this.Text += " - Obra";
                    label1.Text = "Código da Obra";
                    textPara.Location = new System.Drawing.Point(99, 12);
                    textPara.Size = new System.Drawing.Size(214, 20);
                    obrasDAO = new ObrasDAO();
                    break;
            }
        }

        private void AddAgendamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    salvarAgend();
                    break;
            }
        }

        private void salvarAgend()
        {
            #region Validação dos campos
            errorProvider.SetError(textAssunto, string.Empty);

            if (textAssunto.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textAssunto, "Informe um assunto para o agendamento");
                textAssunto.Focus();
                return;
            }
            #endregion

            #region Colocar os dados do agendamento em um objeto
            try
            {
                Agendamentos agend = new Agendamentos();
                agend.Assunto = textAssunto.Text.Trim();
                agend.Observacao = textObservacao.Text.Trim();
                agend.Data = Convert.ToDateTime(dateTimePicker.Value.ToShortDateString());

                textObservacao.Clear();
                textAssunto.Clear();
                textAssunto.Focus();

                switch (this.Text)
                {
                    case "Adicionar Agendamento - Projeto":
                        agend.Projeto = projetosDAO.select().Where(x => x.Id == Convert.ToInt16(textPara.Text)).First();
                        agendDAO.insertComProjeto(agend);
                        break;
                    case "Adicionar Agendamento - Obra":
                        agend.Obra = obrasDAO.select().Where(x => x.Id == Convert.ToInt16(textPara.Text)).First();
                        agendDAO.insertComObra(agend);
                        break;
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            salvarAgend();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}