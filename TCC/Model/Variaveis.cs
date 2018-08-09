using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.Model
{
    class Variaveis
    {
        private static int idUsuario;
        private static Bitmap senhaOculta, senhaVisivel, email, obs, agend, foto, trab, forn, salvar, alterar, reg;

        // Inserts iniciais
        private static readonly string[] insertEstados = {
            "Acre", "Alagoas", "Amazonas", "Amapá", "Bahia", "Ceará", "Distrito Federal", "Espírito Santo",
            "Goiás", "Maranhão", "Minas Gerais", "Mato Grosso do Sul", "Mato Grosso", "Pará", "Paraíba",
            "Pernambuco", "Piauí", "Paraná", "Rio de Janeiro", "Rio Grande do Norte", "Rondônia",
            "Roraima", "Rio Grande do Sul", "Santa Catarina", "Sergipe", "São Paulo", "Tocantins" };

        private static readonly string[] insertSiglas = {
            "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT",
            "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" };

        private static readonly string[] insertStatus = { "Em Andamento", "Parado", "Finalizado" };

        private static readonly string[] insertAcoes = {
            "Entrada no Sistema", "Saída do Sistema", "Envio de E-mail", "Geração de Backup", "Inclusão de Cliente",
            "Alteração de Cliente", "Exclusão de Cliente", "Inclusão de Fornecedor", "Alteração de Fornecedor",
            "Exclusão de Fornecedor", "Inclusão de Trabalhador", "Alteração de Trabalhador", "Exclusão de Trabalhador",
            "Inclusão de Agendamento", "Alteração de Agendamento", "Exclusão de Agendamento",
            "Inclusão de Observação", "Alteração de Observação", "Exclusão de Observação", "Inclusão de Foto",
            "Alteração de Foto", "Exclusão de Foto", "Alteração de Registro CREA", "Exclusão de Registro CREA",
            "Alteração de Registro CAU", "Exclusão de Registro CAU", "Inserção de Registro CREA_Projeto",
            "Exclusão de Registro CREA_Projeto", "Inserção de Registro CAU_Projeto", "Exclusão de Registro CAU_Projeto",
            "Inclusão de Projeto", "Alteração de Projeto", "Exclusão de Projeto", "Inclusão de Obra",
            "Alteração de Obra", "Exclusão de Obra", "Inclusão de Obra_Fornecedor", "Exclusão de Obra_Fornecedor",
            "Inclusão de Obra_Trabalhador", "Exclusão de Obra_Trabalhador" };

        public static void insertsIniciais()
        {
            StatusDAO statusDAO = new StatusDAO();

            if (statusDAO.checarInserts() == 0)
            {
                for (int i = 0; i < insertStatus.Length; i++)
                {
                    Status status = new Status();
                    status.Nome = insertStatus[i];
                    statusDAO.insert(status);
                }

                EstadosDAO estadosDAO = new EstadosDAO();

                for (int i = 0; i < insertEstados.Length; i++)
                {
                    Estados estado = new Estados();
                    estado.Nome = insertEstados[i];
                    estado.Sigla = insertSiglas[i];
                    estadosDAO.insert(estado);
                }

                AcoesDAO acoesDAO = new AcoesDAO();

                for (int i = 0; i < insertAcoes.Length; i++)
                {
                    Acoes acao = new Acoes();
                    acao.Descricao = insertAcoes[i];
                    acoesDAO.insert(acao);
                }
            }
        }

        public static void prepararImagens()
        {
            ResXResourceSet resxSet = new ResXResourceSet(@"C:\Users\migue\Desktop\SIGOPEA\TCC\View\RecupDados.resx");

            senhaOculta = (Bitmap)resxSet.GetObject("passwd_20x20", true);
            senhaVisivel = (Bitmap)resxSet.GetObject("passwd_2_20x20", true);
            email = (Bitmap)resxSet.GetObject("email_32x32.png", true);
            obs = (Bitmap)resxSet.GetObject("note_48x48.png", true);
            agend = (Bitmap)resxSet.GetObject("appointment_32x32.png", true);
            foto = (Bitmap)resxSet.GetObject("camera_48x48.png", true);
            trab = (Bitmap)resxSet.GetObject("worker_24x24.png", true);
            forn = (Bitmap)resxSet.GetObject("provider_24x24.png", true);
            salvar = (Bitmap)resxSet.GetObject("save_24x24.png", true);
            alterar = (Bitmap)resxSet.GetObject("edit_24x24.png", true);
            reg = (Bitmap)resxSet.GetObject("reg_32x32.png", true);
        }

        public static int getIdUsuario()
        {
            return idUsuario;
        }

        public static void setIdUsuario(int id)
        {
            idUsuario = id;
        }

        #region Get de images
        public static Bitmap getSenhaOculta()
        {
            return senhaOculta;
        }

        public static Bitmap getSenhaVisivel()
        {
            return senhaVisivel;
        }

        public static Bitmap getEmail()
        {
            return email;
        }

        public static Bitmap getObs()
        {
            return obs;
        }

        public static Bitmap getAgend()
        {
            return agend;
        }

        public static Bitmap getFoto()
        {
            return foto;
        }

        public static Bitmap getTrab()
        {
            return trab;
        }

        public static Bitmap getForn()
        {
            return forn;
        }

        public static Bitmap getSalvar()
        {
            return salvar;
        }

        public static Bitmap getAlterar()
        {
            return alterar;
        }

        public static Bitmap getReg()
        {
            return reg;
        }
        #endregion

        /*
         * ^ : start of string
         * [ : beginning of character group
         * a-z : any lowercase letter
         * A-Z : any uppercase letter
         * 0-9 : any digit
         * _ : underscore
         * ] : end of character group
         * * : zero or more of the given characters
         * $ : end of string
         * If you don't want to allow empty strings, use + instead of *
         */

        // Regex para validação de e-mail
        public static readonly Regex regexEmail = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        
        // Regex somente com caracteres especiais
        public static readonly Regex regexEsp = new Regex("^[a-zA-Z0-9 ]*$");
        
        // Não permitir sequências na senha
        public static readonly string[] sequencia = {
            "abcd", "bcde", "cdef", "defg", "efgh", "fghi", "ghij", "hijk", "ijkl", "jklm", "klmn", "lmno", "mnop",
            "nopq", "opqr", "pqrs", "qrst", "rstu", "stuv", "tuvw", "uvwx", "vwxy", "wxyz", "xyza", "yzab" ,"zabc",
            "0123", "1234", "2345", "3456", "4567", "5678", "6789", "7890", "8901", "9012",
            "0987", "9876", "8765", "7654", "6543" ,"5432" ,"4321", "3210", "2109", "1098"};
        
        // Caracteres utilizados na hora de criar a senha aleatória
        public static readonly char[] availableCharacters = {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N','O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '-', '_', '#', '$'};

        public static bool enviarEmail(string email, string assunto, string mensagem, List<string> anexos)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SmtpClient client = new SmtpClient();
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

                MailMessage mm = new MailMessage("Sistema|Escritorio de Arquitetura sigopea@gmail.com", email.Trim(), assunto.Trim(), mensagem.Trim());
                mm.BodyEncoding = Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                if (anexos != null)
                {
                    foreach (string anexo in anexos)
                    {
                        mm.Attachments.Add(new Attachment(anexo));
                    }
                }

                client.Send(mm);
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Utilizar criptografia MD5 nas senhas de usuários
        public static string gerarHashMD5(string input)
        {
            input.Trim();
            // Realizar SALT
            input += "$ktT1! #B";

            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            foreach (byte b in md5.ComputeHash(inputBytes))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        /*	
         * What are the pros and cons of using System.Security.Cryptography.RNGCryptoServiceProvider vs System.Random?
         * RNGCryptoServiceProvider is 'more random', i.e. less predictable for hackers.
         * - Pros
         * RNGCryptoServiceProvider is a stronger cryptographically random number, meaning it would be better for determining
         * encryption keys and the likes.
         * - Cons
         * Random is faster because it is a simpler calculation; when used in simulations or long calculations where cryptographic
         * randomness isn't important, this should be used.
         */
        public static string gerarSenhaAleatoria()
        {
            Random random = new Random();
            // Gerar tamanho aleatório para a senha, sendo o número mínimo 5
            char[] identifier = new char[new Random().Next(5, 21)];

            for (int i = 0; i < identifier.Length; i++)
            {
                identifier[i] = availableCharacters[random.Next(availableCharacters.Length)];
            }

            #region Gerando senha aleatória com RNGCryptoServiceProvider
            /*byte[] randomData = new byte[length];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomData);

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                int pos = randomData[idx] % availableCharacters.Length;
                identifier[idx] = availableCharacters[pos];
            }*/
            #endregion

            return new string(identifier);
        }
    }

    public static class ModifyProgressBarColor
    {
        #region Classe para mudar a cor da progressBar [comentado]
        /*[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        // Para instanciar:
        // 1 = normal (green); 2 = error (red); 3 = warning (yellow)
        //ModifyProgressBarColor.SetState(progressBar1, 1);
        //ModifyProgressBarColor.SetState(progressBar2, 3);
        //ModifyProgressBarColor.SetState(progressBar3, 2);
        */
        #endregion
    }
}