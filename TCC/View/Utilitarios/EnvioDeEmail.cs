using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class EnvioDeEmail : Form
    {
        private AcoesDAO acoesDAO { get; set; }
        private LogsDAO logsDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private List<string> listCaminhos;

        public EnvioDeEmail(string email)
        {
            InitializeComponent();
            textPara.Text = email;

            acoesDAO = new AcoesDAO();
            logsDAO = new LogsDAO();
            usuariosDAO = new UsuariosDAO();

            listCaminhos = new List<string>();

            if (!textPara.Text.Trim().Equals(""))
            {
                this.ActiveControl = textAssunto;
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            #region Validação de dados
            errorProvider.SetError(textPara, string.Empty);
            errorProvider.SetError(textAssunto, string.Empty);
            errorProvider.SetError(textMensagem, string.Empty);

            int verif = 0;

            if (!Variaveis.regexEmail.IsMatch(textPara.Text))
            {
                errorProvider.SetError(textPara, "Informe um e-mail válido");
                verif++;
            }

            if (textAssunto.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textAssunto, "Informe um assunto para a mensagem");
                verif++;
            }

            if (textMensagem.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textMensagem, "Informe a mensagem a ser enviada");
                return;
            }

            if (verif > 0)
            {
                return;
            }
            #endregion

            if (Variaveis.enviarEmail(textPara.Text, textAssunto.Text, textMensagem.Text, listCaminhos))
            {
                textPara.Clear();
                textAssunto.Clear();
                textMensagem.Clear();
                listBoxAnexos.Items.Clear();
                listCaminhos.Clear();

                // Inserção de log de envio de e-mail
                Logs log = new Logs();
                log.Acao = acoesDAO.select(3);
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());
                logsDAO.insert(log);
            }
            else
            {
                MessageBox.Show("Não foi possível enviar o e-mail.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btAnexar_Click(object sender, EventArgs e)
        {
            int idx;

            // Abrir janela de seleção de arquivo para anexar ao e-mail
            try
            {
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName != "")
                {
                    listCaminhos.Add(openFileDialog.FileName);

                    // Pegar string depois da última aparição do caractere '\'
                    idx = openFileDialog.FileName.LastIndexOf('\\');
                    listBoxAnexos.Items.Add(openFileDialog.FileName.Substring(idx + 1));
                }
            }
            catch
            {
                
            }
        }

        private void EnvioDeEmail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    // Deletar, da lista, o anexo selecionado ao apertar a tecla "delete"
                    if (listBoxAnexos.SelectedIndex >= 0)
                    {
                        listBoxAnexos.Items.RemoveAt(listBoxAnexos.SelectedIndex);
                    }
                    break;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}