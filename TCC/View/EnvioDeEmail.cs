using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class EnvioDeEmail : Form
    {
        private AcoesDAO acoesDAO { get; set; }
        private LogsDAO logsDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private Logs log;
        private SmtpClient client;
        private MailMessage mm;
        private Attachment lista;
        private List<string> listCaminhos;
        private Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        private int idx, verif;

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

            verif = 0;
            
            if (!rg.IsMatch(textPara.Text))
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

            if(verif > 0)
            {
                return;
            }
            #endregion

            try
            {
                #region Enviar e-mail
                // Mudar tipo do cursor (Waiting/hourglass)
                Cursor.Current = Cursors.WaitCursor;
                client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 7000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("sigopea@gmail.com", "TCCsigope@2016");

                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] utfBytes = utf8.GetBytes("Message");
                byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
                string msg = iso.GetString(isoBytes);
                Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.Conver‌​t(Encoding.UTF8, Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8.GetBytes("String")));

                mm = new MailMessage("Sistema|Escritorio de Arquitetura sigopea@gmail.com", textPara.Text.Trim(), textAssunto.Text.Trim(), textMensagem.Text.Trim());
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                foreach (string caminho in listCaminhos)
                {
                    lista = new Attachment(caminho);
                    mm.Attachments.Add(lista);
                }

                client.Send(mm);
                // Mudar para a seta normal
                Cursor.Current = Cursors.Default;

                textPara.Clear();
                textAssunto.Clear();
                textMensagem.Clear();
                listBoxAnexos.Items.Clear();
                listCaminhos.Clear();
                #endregion

                #region Inserção de log de envio de e-mail
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 3).First();
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();
                logsDAO.insert(log);
                #endregion
            }
            catch
            {
                MessageBox.Show("Não foi possível enviar o e-mail.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btAnexar_Click(object sender, EventArgs e)
        {
            #region Abrir janela de seleção de arquivo para anexar ao e-mail
            try
            {
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName != "")
                {
                    caminhoAnexos(openFileDialog.FileName);

                    // Pegar string depois da última aparição do caractere '\'
                    idx = openFileDialog.FileName.LastIndexOf('\\');
                    listBoxAnexos.Items.Add(openFileDialog.FileName.Substring(idx + 1));
                }
            }
            catch
            {
                
            }
            #endregion
        }

        private void caminhoAnexos(string path)
        {
            #region Adicionar caminho do anexo em uma lista
            listCaminhos.Add(path);
            #endregion
        }

        private void EnvioDeEmail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    #region Deletar da lista o anexo selecionado ao apertar a tecla "delete"
                    if (listBoxAnexos.SelectedIndex >= 0)
                    {
                        listBoxAnexos.Items.RemoveAt(listBoxAnexos.SelectedIndex);
                    }
                    #endregion
                    break;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region Botão cancelar
            this.Close();
            #endregion
        }
    }
}