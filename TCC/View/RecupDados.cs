using System;
using System.Linq;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class RecupDados : Form
    {
        private UsuariosDAO usuariosDAO { get; set; }
        private PalavrasProibidasDAO palavrasDAO { get; set; }
        private string login;

        public RecupDados()
        {
            InitializeComponent();
            palavrasDAO = new PalavrasProibidasDAO();
            usuariosDAO = new UsuariosDAO();
        }

        private void textBoxFundo_Enter(object sender, EventArgs e)
        {
            // Focar o textBox da senha nova caso o usuário consiga focar o textBox de fundo
            textSenhaNova.Focus();
        }

        private void btRecuperar_Click(object sender, EventArgs e)
        {
            #region Validação dos campos
            errorProvider.SetError(textEmail, string.Empty);
            errorProvider.SetError(textSenhaAntiga, string.Empty);
            errorProvider.SetError(textBoxFundo, string.Empty);
            errorProvider.SetError(textConfSenha, string.Empty);

            int verif = 0;

            if (!Variaveis.regexEmail.IsMatch(textEmail.Text))
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

            if (verif > 0)
            {
                return;
            }

            Usuarios usuario = usuariosDAO.selectEmail(textEmail.Text, Variaveis.gerarHashMD5(textSenhaAntiga.Text));

            if (usuario == null)
            {
                MessageBox.Show("E-mail ou senha antiga inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                login = usuario.Login;
            }
            #endregion

            // Validação da senha de acordo com as palavras proibidas e sequências (verificação com nome de login do usuário)
            if (validarSenha(textSenhaNova.Text) == false)
            {
                return;
            }

            Variaveis.enviarEmail(textEmail.Text, "Troca de Senha",
                    "Foi realizada uma troca de senha na sua conta (" + DateTime.Today + ").", null);

            // Alteração da senha do usuário
            usuario.Senha = Variaveis.gerarHashMD5(textSenhaNova.Text);
            usuariosDAO.update(usuario);

            MessageBox.Show("Senha alterada com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBoxSenha_Click(object sender, EventArgs e)
        {
            // Mostrar/Ocultar senha e mudar a imagem exibida ao clicar na imagem
            if (textSenhaNova.PasswordChar != '•')
            {
                pictureBoxSenha.Image = Variaveis.getSenhaOculta();
                textSenhaNova.PasswordChar = '•';
            }
            else
            {
                pictureBoxSenha.Image = Variaveis.getSenhaVisivel();
                textSenhaNova.PasswordChar = '\0';
            }
        }

        private bool validarSenha(string senha)
        {
            #region Verificar se a senha possui 3 das 4 categorias informadas na política de senha
            int categoria = 0;

            if (!Variaveis.regexEsp.IsMatch(textSenhaNova.Text))
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
                return false;
            }
            #endregion

            #region Validar senha de acordo com as palavras proibidas do banco, sequências de 4 caracteres e nome de login
            PalavrasProibidas[] stringArray = palavrasDAO.select().ToArray();

            foreach (PalavrasProibidas palavraPr in stringArray)
            {
                if (senha.Contains(palavraPr.Palavra))
                {
                    errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                    return false;
                }
            }

            foreach (string palavra in Variaveis.sequencia)
            {
                if (senha.Contains(palavra))
                {
                    // Sequência informada
                    errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                    return false;
                }
            }

            if (senha.Contains(login) && !login.Equals(""))
            {
                // Nome de login informado
                errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                return false;
            }

            return true;
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}