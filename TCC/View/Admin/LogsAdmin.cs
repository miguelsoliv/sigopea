using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Admin
{
    public partial class LogsAdmin : Form
    {
        private AcoesDAO acoesDAO { get; set; }
        private LogsDAO logsDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private IEnumerable<Logs> listaLogs;
        private string data;
        private string[] partes;
        private bool check;

        public LogsAdmin()
        {
            InitializeComponent();
            acoesDAO = new AcoesDAO();
            logsDAO = new LogsDAO();
            usuariosDAO = new UsuariosDAO();
            check = false;
        }

        private void LogsAdmin_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas)
            // Adiciona as colunas a serem exibidas (conteúdo, título da coluna)
            dataGridView.Columns.Add("Id", "Código");
            dataGridView.Columns.Add("Usuarios.Login", "Usuário");
            dataGridView.Columns.Add("Acoes.Descricao", "Ação");
            dataGridView.Columns.Add("DataHora", "Data/Hora");

            // Largura das colunas (o default é 100)
            dataGridView.Columns["Id"].Width = 50;
            dataGridView.Columns["Usuarios.Login"].Width = 200;
            dataGridView.Columns["Acoes.Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns["DataHora"].Width = 110;
            #endregion

            #region Carregar usuários
            comboFUsuario.DataSource = usuariosDAO.select();
            comboFUsuario.ValueMember = "Login";
            comboFUsuario.DisplayMember = "Login";

            // Habilitar o autoComplete
            comboFUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboFUsuario.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion

            #region Carregar ações
            comboFAcao.DataSource = acoesDAO.select();
            comboFAcao.ValueMember = "Descricao";
            comboFAcao.DisplayMember = "Descricao";

            // Habilitar o autoComplete
            comboFAcao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboFAcao.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion
        }

        private void LogsAdmin_Activated(object sender, EventArgs e)
        {
            #region Carregar logs [carregarLogs()]
            carregarLogs();
            #endregion
        }

        private void carregarLogs()
        {
            // limpa as linhas da grid
            dataGridView.Rows.Clear();

            if (check == false)
            {
                #region Carregar logs no dataGridView
                // Check->false: caso tenha feito uma pesquisa, não reseta as linhas do dataGrid até
                // que o usuário aperte no botão "Limpar" ou feche o form
                try
                {
                    // preenche as colunas
                    foreach (Logs l in logsDAO.select())
                    {
                        dataGridView.Rows.Add(l.Id, l.Usuario.Login, l.Acao.Descricao, l.Data+" "+l.Hora);
                    }
                }
                catch
                {

                }
                #endregion
            }
            else
            {
                #region Carregar logs que se encaixam na pesquisa
                try
                {
                    // Caso o usuário queira fazer uma busca só por dia/mês/ano

                    partes = maskedData.Text.Replace(" ", "").Split('/');

                    if (!partes[0].Equals("") && !partes[1].Equals("") && !partes[2].Equals(""))
                    {
                        data = partes[0] + "/" + partes[1] + "/" + partes[2];
                    }
                    else if (!partes[0].Equals("") && !partes[1].Equals(""))
                    {
                        data = partes[0] + "/" + partes[1] + "/";
                    }
                    else if (!partes[1].Equals("") && !partes[2].Equals(""))
                    {
                        data = "/" + partes[1] + "/" + partes[2];
                    }
                    else if (!partes[0].Equals(""))
                    {
                        data = partes[0] + "/";
                    }
                    else if (!partes[1].Equals(""))
                    {
                        data = "/" + partes[1] + "/";
                    }
                    else if (!partes[2].Equals(""))
                    {
                        data = "/" + partes[2];
                    }

                    if (!comboFUsuario.Text.Trim().Equals("") && !comboFAcao.Text.Trim().Equals("") && !maskedData.Text.Equals("  /  /"))
                    {
                        listaLogs = logsDAO.select().Where(x => x.Usuario.Login.ToUpper().Contains(comboFUsuario.Text.Trim().ToUpper()) && x.Acao.Descricao.ToUpper().Contains(comboFAcao.Text.Trim().ToUpper()) && x.Data.Contains(data));
                    }
                    else if (!comboFUsuario.Text.Trim().Equals("") && !comboFAcao.Text.Trim().Equals(""))
                    {
                        listaLogs = logsDAO.select().Where(x => x.Usuario.Login.ToUpper().Contains(comboFUsuario.Text.Trim().ToUpper()) && x.Acao.Descricao.ToUpper().Contains(comboFAcao.Text.Trim().ToUpper()));
                    }
                    else if (!comboFUsuario.Text.Trim().Equals("") && !maskedData.Text.Equals("  /  /"))
                    {
                        listaLogs = logsDAO.select().Where(x => x.Usuario.Login.ToUpper().Contains(comboFUsuario.Text.Trim().ToUpper()) && x.Data.Contains(data));
                    }
                    else if(!comboFAcao.Text.Trim().Equals("") && !maskedData.Text.Equals("  /  /"))
                    {
                        listaLogs = logsDAO.select().Where(x => x.Acao.Descricao.ToUpper().Contains(comboFAcao.Text.Trim().ToUpper()) && x.Data.Contains(data));
                    }
                    else if (!comboFUsuario.Text.Trim().Equals(""))
                    {
                        listaLogs = logsDAO.select().Where(x => x.Usuario.Login.ToUpper().Contains(comboFUsuario.Text.Trim().ToUpper()));
                    }
                    else if (!comboFAcao.Text.Trim().Equals(""))
                    {
                        listaLogs = logsDAO.select().Where(x => x.Acao.Descricao.ToUpper().Contains(comboFAcao.Text.Trim().ToUpper()));
                    }
                    else if (!maskedData.Text.Equals("  /  /"))
                    {
                        listaLogs = logsDAO.select().Where(x => x.Data.Contains(data));
                    }

                    //preenche as colunas
                    foreach (Logs l in listaLogs)
                    {
                        dataGridView.Rows.Add(l.Id, l.Usuario.Login, l.Acao.Descricao, l.Data + " " + l.Hora);
                    }
                }
                catch
                {
                    //MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }

        #region Auto Complete + ComboBox
        private void comboFAcao_DropDown(object sender, EventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões
            // Once the user clicks on the DropDown button PreviewKeyDown event is attached to
            // that ComboBox. When user starts typing, freshly added event is triggered. In that
            // event we check if ComboBox is DroppedDown, if it is, focus that ComboBox. On
            // ComboBox focus DropDown disappeares and that's it.
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboFAcao_PreviewKeyDown);
            #endregion
        }

        // Código relacionado abaixo

        private void comboFAcao_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões²
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboFAcao_PreviewKeyDown;

            if (cbo.DroppedDown)
            {
                cbo.Focus();
            }
            #endregion
        }

        private void comboFUsuario_DropDown(object sender, EventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões
            // Once the user clicks on the DropDown button PreviewKeyDown event is attached to
            // that ComboBox. When user starts typing, freshly added event is triggered. In that
            // event we check if ComboBox is DroppedDown, if it is, focus that ComboBox. On
            // ComboBox focus DropDown disappeares and that's it.
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboFUsuario_PreviewKeyDown);
            #endregion
        }

        // Código relacionado abaixo

        private void comboFUsuario_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões²
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboFUsuario_PreviewKeyDown;

            if (cbo.DroppedDown)
            {
                cbo.Focus();
            }
            #endregion
        }
        #endregion

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            #region Carregar logs que correspondam com os dados da pesquisa
            check = true;
            carregarLogs();
            #endregion
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            #region Limpar pesquisa
            check = false;
            carregarLogs();
            comboFAcao.Text = "";
            comboFUsuario.Text = "";
            maskedData.Clear();
            #endregion
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            #region Botão sair
            this.Close();
            #endregion
        }
    }
}