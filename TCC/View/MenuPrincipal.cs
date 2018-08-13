using System;
using System.ComponentModel;
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
        private Notificacao not;
        private string login;
        private bool existe;
        private int tipoUsuario, dias = -1;

        public MenuPrincipal(string login, int tipoUsuario)
        {
            InitializeComponent();
            acoesDAO = new AcoesDAO();
            agendDAO = new AgendamentosDAO();
            cidadesDAO = new CidadesDAO();
            fotosDAO = new FotosDAO();
            logsDAO = new LogsDAO();
            usuariosDAO = new UsuariosDAO();

            this.login = login;
            this.tipoUsuario = tipoUsuario;

            // Tirar borda 3D
            this.SetBevel(false);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Agendamentos agend in agendDAO.select())
            {
                DateTime data = agend.Data;
                if (data.Subtract(DateTime.Today).Days <= 3 && data.Subtract(DateTime.Today).Days >= 0)
                {
                    dias = DateTime.Today.Subtract(data).Days;
                    break;
                }
            }

            // Verificar se o usuário já se logou no sistema alguma vez
            Logs log = logsDAO.usuarioJaLogou();

            if (log != null)
            {
                //statusLabel.Text = "Último Login: " + log.Data + " - " + log.Hora;
                statusLabel.Text = "Último Login: " + log.Data;
            }
            else
            {
                statusLabel.Text = "Bem-vindo(a) " + login + "!";
            }

            // Inserção de log de entrada de usuário
            logsDAO.insert(1);

            System.Threading.Thread.Sleep(1000);
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

            // Deixar itens de menu "Logs" e "Palavras Proibidas" visíveis somente para o admin
            if (tipoUsuario == 1)
            {
                logsToolStripMenuItem.Available = true;
                palavrasProibidasToolStripMenuItem.Available = true;
            }
            else
            {
                logsToolStripMenuItem.Available = false;
                palavrasProibidasToolStripMenuItem.Available = false;
            }

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
                ListClientes listClientes = new ListClientes();
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
                ListTrab listTrab = new ListTrab();
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
                ListForn listForn = new ListForn();
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
                PesqClientes pesqClientes = new PesqClientes();
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
                PesqTrab pesqTrab = new PesqTrab();
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
                PesqForn pesqForn = new PesqForn();
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
                MovObras movObras = new MovObras();
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
                MovProjetos movProjetos = new MovProjetos();
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
                EnvioDeEmail envioDeEmail = new EnvioDeEmail("");
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
                Backup backup = new Backup();
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
                RelObras relObras = new RelObras();
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
                GrafObras grafObras = new GrafObras();
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
                LogsAdmin logs = new LogsAdmin();
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
                PalavrasProibidasAdmin palavrasP = new PalavrasProibidasAdmin();
                palavrasP.MdiParent = this;
                palavrasP.Show();
            }
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Fazer form de notificação subir
            if(not.Top <= 98)
            {
                timer2.Start();
                timer1.Stop();
            }
            else
            {
                not.Top -= 10;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Deixar form de notificação x segundos parado e depois startar o timer3 para fazê-lo descer
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // Fazer form de notificação descer
            if (not.Top >= 358)
            {
                panel1.Visible = false;
                timer3.Stop();
            }
            else
            {
                not.Top += 10;
            }
        }

        private void panel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            // Mudar visibilidade do painel quando o form de notificação for fechado
            panel1.Visible = false;
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Inserção de log de saída de usuário
            logsDAO.insert(2);
        }
    }
}