using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class FormLogin : Form
    {
        private PalavrasProibidasDAO palavrasDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private Carregando loading;
        private bool loginOk;

        public FormLogin()
        {
            InitializeComponent();
            palavrasDAO = new PalavrasProibidasDAO();
            usuariosDAO = new UsuariosDAO();

            // Focar o textLogin ao abrir o form
            ActiveControl = textLogin;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Usuarios usuarios = usuariosDAO.selectLogin(textLogin.Text, Variaveis.gerarHashMD5(textSenha.Text));

            if (usuarios != null)
            {
                loginOk = true;
                Variaveis.setIdUsuario(usuarios.Id);
            }

            Thread.Sleep(500);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!loginOk)
            {
                loading.Hide();
                Opacity = 100;
                ShowInTaskbar = true;

                MessageBox.Show("Usuário ou senha inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSenha.Focus();
            }
            else
            {
                DialogResult = DialogResult.OK;
                MenuPrincipal menu = new MenuPrincipal(textLogin.Text, 1);
                menu.Show();
                //Dispose();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Set database programatically
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Variaveis.prepararImagens();
            Variaveis.insertsIniciais();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            logar();
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // Logar ou cadastrar usuário ao pressionar a teclar enter
                    if (tabControl.SelectedIndex == 0)
                    {
                        logar();
                    }
                    else
                    {
                        cadastrar();
                    }

                    // Stop the 'Ding' when pressing Enter
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            cadastrar();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                textLogin.Focus();
            }
            else
            {
                textCadEmail.Focus();
            }
        }

        private void pictureBoxPol_MouseHover(object sender, EventArgs e)
        {
            // Exibição do toolTip sobre a política de senha por 30 segundos
            // (pega o texto do tooltip informado no control entre parênteses)
            // (seleciona o control que deseja aplicar um tempo de vida maior para o tooltip)
            // (informa o tempo que o tooltip ficará visível, em milissegundos)
            toolTipPolitica.Show(toolTipPolitica.GetToolTip(pictureBoxPol).ToString(), pictureBoxPol, 30000);
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            while (true)
            {
                string senha = Variaveis.gerarSenhaAleatoria();

                if (validarSenha(senha, 0) == true)
                {
                    textCadSenha.Text = senha;
                    break;
                }
            }
        }

        private void textBoxFundo_Enter(object sender, EventArgs e)
        {
            // Focar o textBox do cadastro de senha caso o usuário consiga focar o textBox de fundo
            textCadSenha.Focus();
        }

        private void pictureBoxSenha_Click(object sender, EventArgs e)
        {
            // Mostrar/Ocultar senha e mudar a imagem exibida ao clicar na imagem
            if (textCadSenha.PasswordChar != '•')
            {
                pictureBoxSenha.Image = Variaveis.getSenhaOculta();
                textCadSenha.PasswordChar = '•';
            }
            else
            {
                pictureBoxSenha.Image = Variaveis.getSenhaVisivel();
                textCadSenha.PasswordChar = '\0';
            }
        }

        private void linkEsqueceu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abrir form de recuperação de dados (ShowDialog -> impede que o usuário clique no form pai)
            new RecupDados().ShowDialog();
        }

        private void logar()
        {
            loading = new Carregando();
            loading.Show();
            loginOk = false;
            backgroundWorker1.RunWorkerAsync();

            Opacity = 0;
        }

        private bool validar()
        {
            #region Validação dos campos
            errorProvider.SetError(textCadEmail, string.Empty);
            errorProvider.SetError(textCadLogin, string.Empty);
            errorProvider.SetError(textBoxFundo, string.Empty);
            errorProvider.SetError(textCadConfSenha, string.Empty);

            int verif = 0;

            if (!usuariosDAO.validacaoEmail(textCadEmail.Text))
            {
                errorProvider.SetError(textCadEmail, "E-mail já cadastrado");
                verif++;
            }
            else if (!Variaveis.regexEmail.IsMatch(textCadEmail.Text))
            {
                errorProvider.SetError(textCadEmail, "Informe um e-mail válido");
                verif++;
            }

            if (!usuariosDAO.validacaoLogin(textCadLogin.Text))
            {
                errorProvider.SetError(textCadLogin, "Login já cadastrado");
                verif++;
            }
            else if (textCadLogin.Text.Trim().Length < 4 || textCadLogin.Text.Trim().Length > 100)
            {
                errorProvider.SetError(textCadLogin, "Informe um login entre 4 e 100 caracteres");
                verif++;
            }

            if (textCadSenha.Text.Trim().Length < 5 || textCadSenha.Text.Trim().Length > 25)
            {
                errorProvider.SetError(textBoxFundo, "Informe uma senha entre 5 e 25 caracteres");
                verif++;
            }

            if (textCadConfSenha.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textCadConfSenha, "Confirme sua senha");
                return false;
            }
            else if (!textCadConfSenha.Text.Trim().Equals(textCadSenha.Text))
            {
                errorProvider.SetError(textCadConfSenha, "Você confirmou uma senha diferente da informada anteriormente");
                return false;
            }

            if (verif > 0)
            {
                return false;
            }

            return true;
            #endregion
        }

        private void cadastrar()
        {
            if (validar() == true)
            {
                if (validarSenha(textCadSenha.Text, 1) == false)
                {
                    return;
                }

                Usuarios usuario = new Usuarios();
                usuario.Tipo = 3;
                usuario.Email = textCadEmail.Text.Trim();
                usuario.Login = textCadLogin.Text.Trim();
                usuario.Senha = Variaveis.gerarHashMD5(textCadSenha.Text);
                usuariosDAO.insert(usuario);

                tabControl.SelectedIndex = 0;
                MessageBox.Show("Cadastro realizado com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textCadEmail.Clear();
                textCadLogin.Clear();
                textCadSenha.Clear();
                textCadConfSenha.Clear();
                textSenha.PasswordChar = '•';
            }
        }

        private bool validarSenha(string senha, int instancia)
        {
            /* 
             * instancia = 0 : método acessado para validar a senha aleatória
             * instancia = 1 : método acessado para validar a senha no cadastro de usuário (gerando mensagens de erro)
             */

            #region Verificar se a senha possui 3 das 4 categorias informadas na política de senha
            int categoria = 0;

            if (!Variaveis.regexEsp.IsMatch(textCadSenha.Text))
            {
                // Senha possui caractere especial
                categoria++;
            }

            if (textCadSenha.Text.Any(c => char.IsDigit(c)))
            {
                // Senha possui números
                categoria++;
            }

            if (textCadSenha.Text.Any(c => char.IsUpper(c)))
            {
                // Senha possui letras maiúsculas
                categoria++;
            }

            if (textCadSenha.Text.Any(c => char.IsLower(c)))
            {
                // Senha possui letras minúsculas
                categoria++;
            }

            if (categoria < 3)
            {
                if (instancia == 1)
                {
                    errorProvider.SetError(textBoxFundo, "A senha deve conter três das quatro categorias informadas na política de senha");
                }

                return false;
            }
            #endregion

            #region Validar senha de acordo com as palavras proibidas do banco, sequências de 4 caracteres e nome de login
            PalavrasProibidas[] stringArray = palavrasDAO.select().ToArray();

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

            foreach (string palavra in Variaveis.sequencia)
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

            if (senha.Contains(textCadLogin.Text.Trim()) && !textCadLogin.Text.Trim().Equals("") && instancia == 1)
            {
                // Nome de login informado
                errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                return false;
            }

            return true;
            #endregion
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }
    }
}