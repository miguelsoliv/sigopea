using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;
using TCC.View.Admin;
using TCC.View.Listagens_Cadastros;
using TCC.View.Movimentos;
using TCC.View.Pesquisas;

namespace TCC.View
{
    public partial class MenuPrincipal : Form
    {
        private AcoesDAO acoesDAO { get; set; }
        private AgendamentosDAO agendDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private FotosDAO fotosDAO { get; set; }
        private LogsDAO logsDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private Usuarios usuario;
        private Logs log;
        private ListClientes listClientes;
        private ListForn listForn;
        private ListTrab listTrab;
        private PesqClientes pesqClientes;
        private PesqTrab pesqTrab;
        private PesqForn pesqForn;
        private MovObras movObras;
        private MovProjetos movProjetos;
        private EnvioDeEmail envioDeEmail;
        private Backup backup;
        private RelObras relObras;
        private GrafObras grafObras;
        private Notificacao not;
        private LogsAdmin logs;
        private PalavrasProibidasAdmin palavrasP;
        private DateTime data;
        private IEnumerable<Logs> listaLogs;
        private static Image emailIm, obsIm, agendIm, fotoIm, trabIm, fornIm, salvarIm, alterarIm, regIm,
        senhaImC = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\passwd_20x20.png"),
        senhaImP = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\passwd_2_20x20.png");
        private bool existe;
        private int dias = -1;

        public MenuPrincipal()
        {
            InitializeComponent();
            acoesDAO = new AcoesDAO();
            agendDAO = new AgendamentosDAO();
            cidadesDAO = new CidadesDAO();
            fotosDAO = new FotosDAO();
            logsDAO = new LogsDAO();
            usuariosDAO = new UsuariosDAO();

            // Tirar borda 3D
            this.SetBevel(false);
        }

        #region Get de imagens (static)
        public static Image imageEmail()
        {
            return emailIm;
        }

        public static Image imageObs()
        {
            return obsIm;
        }

        public static Image imageAgend()
        {
            return agendIm;
        }

        public static Image imageFoto()
        {
            return fotoIm;
        }

        public static Image imageTrab()
        {
            return trabIm;
        }

        public static Image imageForn()
        {
            return fornIm;
        }

        public static Image imageSenhaCinza()
        {
            return senhaImC;
        }

        public static Image imageSenhaPreta()
        {
            return senhaImP;
        }

        public static Image imageSalvar()
        {
            return salvarIm;
        }

        public static Image imageAlterar()
        {
            return alterarIm;
        }

        public static Image imageReg()
        {
            return regIm;
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Agendamentos agend in agendDAO.select())
            {
                data = agend.Data;
                if (data.Subtract(DateTime.Today).Days <= 3 && data.Subtract(DateTime.Today).Days >= 0)
                {
                    dias = DateTime.Today.Subtract(data).Days;
                    break;
                }
            }
            
            emailIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\email_32x32.png");
            obsIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\note_48x48.png");
            agendIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\appointment_32x32.png");
            fotoIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\camera_48x48.png");
            trabIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\worker_24x24.png");
            fornIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\provider_24x24.png");
            salvarIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\save_24x24.png");
            alterarIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\edit_24x24.png");
            regIm = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\images\reg_32x32.png");

            #region Verificar se o usuário já se logou no sistema alguma vez
            listaLogs = logsDAO.select().Where(x => x.Usuario.Id == FormLogin.getIdUsuario());

            if (listaLogs.Count() >= 1)
            {
                log = listaLogs.Last();
                statusLabel.Text = "Último Login: " + log.Data + " - " + log.Hora;
            }
            else
            {
                usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();

                statusLabel.Text = "Bem-vindo(a) " + usuario.Login + "!";
            }
            #endregion

            #region Inserção de log de entrada de usuário
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 1).First();
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();
                logsDAO.insert(log);
            }
            catch
            {

            }
            #endregion

            System.Threading.Thread.Sleep(1500);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is Carregando)
                {
                    openForm.Opacity = 0;
                    openForm.Enabled = false;
                }
            }

            #region Deixar itens de menu "Logs" e "Palavras Proibidas" visíveis somente para o admin
            if (FormLogin.getTipoUsuario() == 1)
            {
                logsToolStripMenuItem.Available = true;
                palavrasProibidasToolStripMenuItem.Available = true;
            }
            else
            {
                logsToolStripMenuItem.Available = false;
                palavrasProibidasToolStripMenuItem.Available = false;
            }
            #endregion

            this.Opacity = 100;
            this.ShowInTaskbar = true;

            if (dias >= 0 && dias <= 3)
            {
                panel1.Visible = true;
                not = new Notificacao(dias);
                not.TopLevel = false;
                not.Top = 358;
                panel2.Controls.Add(not);
                not.Show();
                timer1.Start();
            }

            this.Focus();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void clientesStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir lista de clientes
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is ListClientes)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                listClientes = new ListClientes();
                listClientes.MdiParent = this;
                listClientes.Show();
            }
            #endregion
        }

        private void trabalhadoresStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir lista de trabalhadores
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is ListTrab)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                listTrab = new ListTrab();
                listTrab.MdiParent = this;
                listTrab.Show();
            }
            #endregion
        }

        private void fornecedoresStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir lista de fornecedores
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is ListForn)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                listForn = new ListForn();
                listForn.MdiParent = this;
                listForn.Show();
            }
            #endregion
        }

        private void pesqClientesStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir pesquisa de clientes
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is PesqClientes)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                pesqClientes = new PesqClientes();
                pesqClientes.MdiParent = this;
                pesqClientes.Show();
            }
            #endregion
        }

        private void pesqTrabalhadoresStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir pesquisa de trabalhadores
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is PesqTrab)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                pesqTrab = new PesqTrab();
                pesqTrab.MdiParent = this;
                pesqTrab.Show();
            }
            #endregion
        }

        private void pesqFornecedoresStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir pesquisa de trabalhadores
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is PesqForn)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                pesqForn = new PesqForn();
                pesqForn.MdiParent = this;
                pesqForn.Show();
            }
            #endregion
        }

        private void obrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir movimentos de obras
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is MovObras)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                movObras = new MovObras();
                movObras.MdiParent = this;
                movObras.Show();
            }
            #endregion
        }

        private void projetosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir movimentos de projetos
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is MovProjetos)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                movProjetos = new MovProjetos();
                movProjetos.MdiParent = this;
                movProjetos.Show();
            }
            #endregion
        }

        private void enviarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir envio de e-mail
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is EnvioDeEmail)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                envioDeEmail = new EnvioDeEmail("");
                envioDeEmail.MdiParent = this;
                envioDeEmail.Show();
            }
            #endregion
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir backup
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is Backup)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                backup = new Backup();
                backup.MdiParent = this;
                backup.Show();
            }
            #endregion
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir relatórios
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is RelObras)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                relObras = new RelObras();
                relObras.MdiParent = this;
                relObras.Show();
            }
            #endregion
        }

        private void gráficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir gráficos
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is GrafObras)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                grafObras = new GrafObras();
                grafObras.MdiParent = this;
                grafObras.Show();
            }
            #endregion
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir logs
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is LogsAdmin)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                logs = new LogsAdmin();
                logs.MdiParent = this;
                logs.Show();
            }
            #endregion
        }

        private void palavrasProibidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Abrir palavras proibidas
            existe = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is PalavrasProibidasAdmin)
                {
                    openForm.BringToFront();
                    existe = true;
                }
            }
            if (!existe)
            {
                palavrasP = new PalavrasProibidasAdmin();
                palavrasP.MdiParent = this;
                palavrasP.Show();
            }
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Fazer form de notificação subir
            if(not.Top <= 98)
            {
                timer2.Start();
                timer1.Stop();
            }
            else
            {
                not.Top -= 10;
            }
            #endregion
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            #region Deixar form de notificação x segundos parado e depois startar o timer3 para fazê-lo descer
            timer3.Start();
            #endregion
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            #region Fazer form de notificação descer
            if (not.Top >= 358)
            {
                panel1.Visible = false;
                timer3.Stop();
            }
            else
            {
                not.Top += 10;
            }
            #endregion
        }

        private void panel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            #region Mudar visibilidade do painel quando o form de notificação for fechado
            panel1.Visible = false;
            #endregion
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Inserção de log de saída de usuário
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 2).First();
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();
                logsDAO.insert(log);
            }
            catch
            {

            }
            #endregion
        }
    }
}