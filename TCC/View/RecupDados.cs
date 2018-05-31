using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class RecupDados : Form
    {
        private PalavrasProibidasDAO palavrasDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private ClientesDAO clientesDAO { get; set; }
        private PalavrasProibidas[] stringArray;
        private Clientes cliente;
        private MD5 md5;
        private SmtpClient client;
        private MailMessage mm;
        private byte[] inputBytes, hash;
        private StringBuilder sb;
        private Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        private Regex regexEsp = new Regex("^[a-zA-Z0-9 ]*$");
        private string senhaHash, mensagem, login;
        private int verif, categoria;

        public RecupDados()
        {
            palavrasDAO = new PalavrasProibidasDAO();
            usuariosDAO = new UsuariosDAO();
            clientesDAO = new ClientesDAO();
            InitializeComponent();
        }

        private void textBoxFundo_Enter(object sender, EventArgs e)
        {
            #region Focar o textBox da senha nova caso o usuário consiga focar o textBox de fundo
            textSenhaNova.Focus();
            #endregion
        }

        private string getMD5Hash(string input)
        {
            #region Gerar hash MD5 baseado na string informada
            md5 = MD5.Create();
            inputBytes = Encoding.ASCII.GetBytes(input);
            hash = md5.ComputeHash(inputBytes);
            sb = new StringBuilder();

            foreach (Byte b in md5.ComputeHash(inputBytes))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
            #endregion
        }

        private void btRecuperar_Click(object sender, EventArgs e)
        {
            #region Validação dos campos
            errorProvider.SetError(textEmail, string.Empty);
            errorProvider.SetError(textSenhaAntiga, string.Empty);
            errorProvider.SetError(textBoxFundo, string.Empty);
            errorProvider.SetError(textConfSenha, string.Empty);

            verif = 0;

            if (!rg.IsMatch(textEmail.Text))
            {
                errorProvider.SetError(textEmail, "Informe um e-mail válido");
                verif++;
            }

            if (textSenhaAntiga.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textSenhaAntiga, "Informe a senha antiga da conta");
                verif++;
            }

            if (textSenhaNova.Text.Length < 5 || textSenhaNova.Text.Length > 25)
            {
                errorProvider.SetError(textBoxFundo, "Informe uma senha entre 5 e 25 caracteres");
                verif++;
            }

            if (textConfSenha.Text.Equals(""))
            {
                errorProvider.SetError(textConfSenha, "Confirme sua nova senha");
                return;
            }
            else if (!textConfSenha.Text.Equals(textSenhaNova.Text))
            {
                errorProvider.SetError(textConfSenha, "Você confirmou uma senha diferente da informada anteriormente");
                return;
            }

            if(verif > 0)
            {
                return;
            }

            senhaHash = getMD5Hash(textSenhaAntiga.Text);

            if (usuariosDAO.select().Where(x => x.Email.ToUpper() == textEmail.Text.Trim().ToUpper() && x.Senha == senhaHash).Count() == 0)
            {
                MessageBox.Show("E-mail ou senha antiga inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                login = usuariosDAO.select().Where(x => x.Email.ToUpper() == textEmail.Text.Trim().ToUpper() && x.Senha == senhaHash).First().Login;
            }
            #endregion

            #region Verificar se a senha possui 3 das 4 categorias informadas na política de senha
            /*
                ^ : start of string
                [ : beginning of character group
                a-z : any lowercase letter
                A-Z : any uppercase letter
                0-9 : any digit
                _ : underscore
                ] : end of character group
                * : zero or more of the given characters
                $ : end of string
                If you don't want to allow empty strings, use + instead of *.
            */
            categoria = 0;

            if (!regexEsp.IsMatch(textSenhaNova.Text))
            {
                // Senha possui caractere especial
                categoria++;
            }

            if (textSenhaNova.Text.Any(c => char.IsDigit(c)))
            {
                // Senha possui números
                categoria++;
            }

            if (textSenhaNova.Text.Any(c => char.IsUpper(c)))
            {
                // Senha possui letras maiúsculas
                categoria++;
            }

            if (textSenhaNova.Text.Any(c => char.IsLower(c)))
            {
                // Senha possui letras minúsculas
                categoria++;
            }

            if (categoria < 3)
            {
                errorProvider.SetError(textBoxFundo, "A senha deve conter três das quatro categorias informadas na política de senha");
                return;
            }
            #endregion

            #region Validação da senha de acordo com as palavras proibidas e sequências (verificação com nome de login do usuário)
            if (validarSenha(textSenhaNova.Text, 1) == false)
            {
                return;
            }
            #endregion

            try
            {
                #region Enviar um e-mail para o cliente, informando que foi realizada uma troca de senha
                Cursor.Current = Cursors.WaitCursor;
                client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 7000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("sigopea@gmail.com", "TCCsigope@2016");

                mensagem = "Foi realizada uma troca de senha na sua conta (" + System.DateTime.Today + ").";

                mm = new MailMessage("Sistema|Escritorio de Arquitetura sigopea@gmail.com", textEmail.Text.Trim(), "Troca de Senha", mensagem);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                // Mudar para a seta normal
                Cursor.Current = Cursors.Default;
                #endregion
            }
            catch
            {
                //MessageBox.Show(ex.Message());
            }

            #region Alteração da senha do cliente
            try
            {
                cliente = new Clientes();

                foreach (Clientes c in clientesDAO.select().Where(x => x.Email == textEmail.Text.Trim()))
                {
                    cliente.Id = c.Id;
                    cliente.Senha = getMD5Hash(textSenhaNova.Text);
                }

                clientesDAO.update(cliente);
                MessageBox.Show("Senha alterada com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Erro ao realizar a troca de senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private bool validarSenha(string senha, int instancia)
        {
            #region Validar senha de acordo com as palavras proibidas do banco, sequências de 4 caracteres e nome de login
            stringArray = palavrasDAO.select().ToArray();

            foreach (PalavrasProibidas palavraPr in stringArray)
            {
                if (senha.Contains(palavraPr.Palavra))
                {
                    if (instancia == 1)
                    {
                        errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                    }
                    return false;
                }
            }

            foreach (string palavra in FormLogin.sequencia)
            {
                if (senha.Contains(palavra))
                {
                    if (instancia == 1)
                    {
                        // Sequência informada
                        errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                    }
                    return false;
                }
            }

            if (senha.Contains(login) && !login.Equals("") && instancia == 1)
            {
                // Nome de login informado
                errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                return false;
            }

            return true;
            #endregion
        }

        private void pictureBoxSenha_Click(object sender, EventArgs e)
        {
            #region Mostrar/Ocultar senha e mudar a imagem exibida ao clicar na imagem
            if (textSenhaNova.PasswordChar != '•')
            {
                pictureBoxSenha.Image = MenuPrincipal.imageSenhaCinza();
                textSenhaNova.PasswordChar = '•';
            }
            else
            {
                pictureBoxSenha.Image = MenuPrincipal.imageSenhaPreta();
                textSenhaNova.PasswordChar = '\0';
            }
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region Botão cancelar
            this.Close();
            #endregion
        }
    }
}