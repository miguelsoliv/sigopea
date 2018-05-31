using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class FormLogin : Form
    {
        private PalavrasProibidasDAO palavrasDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private PalavrasProibidas[] stringArray;
        private Usuarios usuario;
        private RecupDados recupDados;
        private Carregando loading;
        private IEnumerable<Usuarios> usuarios;
        private Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        private Regex regexEsp = new Regex("^[a-zA-Z0-9 ]*$");
        private Random tamanho, random;
        private char[] identifier;
        private bool existe;
        private int verif;
        private static int idUsuario, tipoUsuario, categoria;
        public static readonly string[] sequencia = {
            "abcd", "bcde", "cdef", "defg", "efgh", "fghi", "ghij", "hijk", "ijkl", "jklm", "klmn", "lmno", "mnop",
            "nopq", "opqr", "pqrs", "qrst", "rstu", "stuv", "tuvw", "uvwx", "vwxy", "wxyz", "xyza", "yzab" ,"zabc",
            "0123", "1234", "2345", "3456", "4567", "5678", "6789", "7890", "8901", "9012",
            "0987", "9876", "8765", "7654", "6543" ,"5432" ,"4321", "3210", "2109", "1098"};
        private static readonly char[] availableCharacters = {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N','O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '-', '_', '#', '$'};

        public FormLogin()
        {
            InitializeComponent();
            palavrasDAO = new PalavrasProibidasDAO();
            usuariosDAO = new UsuariosDAO();

            // Focar o textLogin ao abrir o form
            this.ActiveControl = textLogin;
            loading = new Carregando();
            random = new Random();
        }

        public static int getIdUsuario()
        {
            return idUsuario;
        }

        public static int getTipoUsuario()
        {
            return tipoUsuario;
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            #region Botão entrar [logar()]
            logar();
            #endregion
        }

        private void logar()
        {
            #region Método para o usuário entrar/logar no sistema
            usuarios = usuariosDAO.select().Where(u => u.Login == textLogin.Text.Trim() && u.Senha == getMD5Hash(textSenha.Text));

            if (usuarios.Count() == 1)
            {
                loading.Show();
                usuario = usuarios.First();
                idUsuario = usuario.Id;
                tipoUsuario = usuario.Tipo;
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSenha.Focus();
            }
            #endregion
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    #region Logar ou cadastrar usuário ao pressionar a teclar enter
                    if (tabControl.SelectedIndex == 0)
                    {
                        logar();
                    }
                    else
                    {
                        cadastrar();
                    }
                    #endregion
                    break;
                case Keys.Escape:
                    #region Fechar o form ao ser pressionado a tecla ESC
                    this.DialogResult = DialogResult.Cancel;
                    this.Dispose();
                    #endregion
                    break;
            }
        }

        public static string getMD5Hash(string input)
        {
            #region Realizar SALT
            input += "$ktT1! #B";
            #endregion

            #region Gerar hash MD5 baseado na string informada
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            foreach (byte b in md5.ComputeHash(inputBytes))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
            #endregion
        }

        private bool validar()
        {
            #region Validação dos campos
            errorProvider.SetError(textCadEmail, string.Empty);
            errorProvider.SetError(textCadLogin, string.Empty);
            errorProvider.SetError(textBoxFundo, string.Empty);
            errorProvider.SetError(textCadConfSenha, string.Empty);

            verif = 0;

            if (usuariosDAO.select().Where(x => x.Email.ToUpper() == textCadEmail.Text.Trim().ToUpper()).Count() == 1)
            {
                errorProvider.SetError(textCadEmail, "E-mail já cadastrado");
                verif++;
            }
            else if (!rg.IsMatch(textCadEmail.Text))
            {
                errorProvider.SetError(textCadEmail, "Digite um e-mail válido");
                verif++;
            }

            if (usuariosDAO.select().Where(x => x.Login.ToUpper() == textCadLogin.Text.Trim().ToUpper()).Count() == 1)
            {
                errorProvider.SetError(textCadLogin, "Login já cadastrado");
                verif++;
            }
            else if (textCadLogin.Text.Trim().Length < 4 || textCadLogin.Text.Trim().Length > 100)
            {
                errorProvider.SetError(textCadLogin, "Informe um login entre 4 e 100 caracteres");
                verif++;
            }

            if (textCadSenha.Text.Length < 5 || textCadSenha.Text.Length > 25)
            {
                errorProvider.SetError(textBoxFundo, "Informe uma senha entre 5 e 25 caracteres");
                verif++;
            }

            if (textCadConfSenha.Text.Equals(""))
            {
                errorProvider.SetError(textCadConfSenha, "Confirme sua senha");
                return false;
            }
            else if (!textCadConfSenha.Text.Equals(textCadSenha.Text))
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

                if (!regexEsp.IsMatch(textCadSenha.Text))
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
                    errorProvider.SetError(textBoxFundo, "A senha deve conter três das quatro categorias informadas na política de senha");
                    return;
                }
                #endregion

                #region Validação da senha de acordo com as palavras proibidas e sequências (verificação com nome de login do usuário)
                if (validarSenha(textCadSenha.Text, 1) == false)
                {
                    return;
                }
                #endregion

                #region Inserção de usuário
                try
                {
                    usuario = new Usuarios();
                    usuario.Tipo = 3;
                    usuario.Email = textCadEmail.Text.Trim();
                    usuario.Login = textCadLogin.Text.Trim();
                    usuario.Senha = getMD5Hash(textCadSenha.Text);
                    usuariosDAO.insert(usuario);

                    tabControl.SelectedIndex = 0;
                    MessageBox.Show("Cadastro realizado com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {

                }
                #endregion

                #region Limpar campos depois de se cadastrar com sucesso
                textCadEmail.Clear();
                textCadLogin.Clear();
                textCadSenha.Clear();
                textCadConfSenha.Clear();
                textSenha.PasswordChar = '•';
                #endregion
            }
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            #region Botão cadastrar [cadastrar()]
            cadastrar();
            #endregion
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Focar o primeiro campo de cada tabControl ao mudar de index
            if (tabControl.SelectedIndex == 0)
            {
                textLogin.Focus();
            }
            else
            {
                textCadEmail.Focus();
            }
            #endregion
        }

        private void pictureBoxPol_MouseHover(object sender, EventArgs e)
        {
            #region Exibição do toolTip por 20 segundos (exibindo a política de senha)
            // (pega o texto do tooltip informado no control entre parênteses)
            // (seleciona o control que deseja aplicar um tempo de viva maior para o tooltip)
            // (informa o tempo que o tooltip ficará visível, em milissegundos)
            toolTipPolitica.Show(toolTipPolitica.GetToolTip(pictureBoxPol).ToString(), this.pictureBoxPol, 20000);
            #endregion
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            #region Gerar um número aleatório para ser o tamanho da senha aleatória, que será gerada depois
            tamanho = new Random();
            textCadSenha.Text = gerarSenhaRandom(tamanho.Next(5, 21));
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

            foreach(string palavra in sequencia)
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

            if (senha.Contains(textCadLogin.Text) && !textCadLogin.Text.Equals("") && instancia == 1)
            {
                // Nome de login informado
                errorProvider.SetError(textBoxFundo, "Palavra proibida digitada na senha");
                return false;
            }

            return true;
            #endregion
        }

        /*	
            What are the pros and cons of using System.Security.Cryptography.RNGCryptoServiceProvider vs System.Random?
            I know that RNGCryptoServiceProvider is 'more random', i.e. less predictable for hackers. Any other pros or cons?

            Pros
            RNGCryptoServiceProvider is a stronger cryptographically random number, meaning it would be better for determining
            encryption keys and the likes.

            Cons
            Random is faster because it is a simpler calculation; when used in simulations or long calculations where cryptographic
            randomness isn't important, this should be used.
        */

        private string gerarSenhaRandom(int length)
        {
            #region Gerar senha aleatória
            while (true)
            {
                identifier = new char[length];
                for (int i = 0; i < identifier.Length; i++)
                {
                    identifier[i] = availableCharacters[random.Next(availableCharacters.Length)];
                }
                // Gerando senha aleatória com RNGCryptoServiceProvider
                //byte[] randomData = new byte[length];

                //RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                //rng.GetBytes(randomData);

                //for (int idx = 0; idx < identifier.Length; idx++)
                //{
                //    int pos = randomData[idx] % availableCharacters.Length;
                //    identifier[idx] = availableCharacters[pos];
                //}

                if (validarSenha(new string(identifier), 0) == true)
                {
                    return new string(identifier);
                }
            }
            #endregion
        }

        private void textBoxFundo_Enter(object sender, EventArgs e)
        {
            #region Focar o textBox do cadastro de senha caso o usuário consiga focar o textBox de fundo
            textCadSenha.Focus();
            #endregion
        }

        private void pictureBoxSenha_Click(object sender, EventArgs e)
        {
            #region Mostrar/Ocultar senha e mudar a imagem exibida ao clicar na imagem
            if (textCadSenha.PasswordChar != '•')
            {
                pictureBoxSenha.Image = MenuPrincipal.imageSenhaCinza();
                textCadSenha.PasswordChar = '•';
            }
            else
            {
                pictureBoxSenha.Image = MenuPrincipal.imageSenhaPreta();
                textCadSenha.PasswordChar = '\0';
            }
            #endregion
        }

        private void FormLogin_Activated(object sender, EventArgs e)
        {
            #region Verificar se o form de recuperação de dados está aberto
            try
            {
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is RecupDados)
                    {
                        openForm.Close();
                    }
                }
            }
            catch
            {

            }
            #endregion
        }

        private void linkEsqueceu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Abrir form de recuperação de dados
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is RecupDados)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                recupDados = new RecupDados();
                recupDados.MdiParent = this.ParentForm;
                recupDados.Show();
            }
            #endregion
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            #region Botão sair
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
            #endregion
        }
    }
}

#region Classe para mudar a cor da progressBar [comentada]
//public static class ModifyProgressBarColor
//{
//    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
//    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
//    public static void SetState(this ProgressBar pBar, int state)
//    {
//        SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
//    }

//    // Para instanciar:
//    // 1 = normal (green); 2 = error (red); 3 = warning (yellow)
//    //ModifyProgressBarColor.SetState(progressBar1, 1);
//    //ModifyProgressBarColor.SetState(progressBar2, 3);
//    //ModifyProgressBarColor.SetState(progressBar3, 2);
//}
#endregion