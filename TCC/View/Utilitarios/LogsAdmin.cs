using System;
using System.Collections.Generic;
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
        private bool check;

        public LogsAdmin()
        {
            InitializeComponent();
            acoesDAO = new AcoesDAO();
            logsDAO = new LogsDAO();
            usuariosDAO = new UsuariosDAO();
            check = false;
            dateTimePicker.MaxDate = DateTime.Today;
        }

        private void LogsAdmin_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas)
            dataGridView.Columns.Add("Id", "Código");
            dataGridView.Columns.Add("Usuarios.Login", "Usuário");
            dataGridView.Columns.Add("Acoes.Descricao", "Ação");
            dataGridView.Columns.Add("DataHora", "Data/Hora");

            dataGridView.Columns["Id"].Width = 50;
            dataGridView.Columns["Usuarios.Login"].Width = 200;
            dataGridView.Columns["Acoes.Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns["DataHora"].Width = 120;
            #endregion

            // Carregar usuários
            comboFUsuario.DataSource = usuariosDAO.select();
            comboFUsuario.ValueMember = "Login";
            comboFUsuario.DisplayMember = "Login";

            // Carregar ações
            comboFAcao.DataSource = acoesDAO.select();
            comboFAcao.ValueMember = "Descricao";
            comboFAcao.DisplayMember = "Descricao";
        }

        private void LogsAdmin_Activated(object sender, EventArgs e)
        {
            carregarLogs();
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
            if (comboFUsuario.Text.Trim().Equals("") && comboFAcao.Text.Trim().Equals("") && !checkData.Checked)
            {
                return;
            }

            check = true;
            carregarLogs();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            if (!check)
            {
                return;
            }

            // Limpar pesquisa
            check = false;
            carregarLogs();
            comboFAcao.Text = "";
            comboFUsuario.Text = "";
            dateTimePicker.Value = DateTime.Today;
        }

        private void checkData_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker.Enabled = checkData.Checked ? true : false;
        }

        private void carregarLogs()
        {
            dataGridView.Rows.Clear();

            // Carregar logs
            if (check == false)
            {
                foreach (Logs l in logsDAO.select())
                {
                    dataGridView.Rows.Add(l.Id, l.Usuario.Login, l.Acao.Descricao, l.Data.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }
            // Carregar logs que se encaixam na pesquisa
            else
            {
                IEnumerable<Logs> listaLogs;

                if (!comboFUsuario.Text.Trim().Equals("") && !comboFAcao.Text.Trim().Equals(""))
                {
                    if (checkData.Checked)
                    {
                        listaLogs = logsDAO.selectTudo(comboFUsuario.Text, comboFAcao.Text, dateTimePicker.Value);
                    }
                    else
                    {
                        listaLogs = logsDAO.selectUsuarioAcao(comboFUsuario.Text, comboFAcao.Text);
                    }
                }
                else if (!comboFUsuario.Text.Trim().Equals(""))
                {
                    if (checkData.Checked)
                    {
                        listaLogs = logsDAO.selectUsuarioData(comboFUsuario.Text, dateTimePicker.Value);
                    }
                    else
                    {
                        listaLogs = logsDAO.selectUsuario(comboFUsuario.Text);
                    }
                }
                else if (!comboFAcao.Text.Trim().Equals(""))
                {
                    if (checkData.Checked)
                    {
                        listaLogs = logsDAO.selectAcaoData(comboFAcao.Text, dateTimePicker.Value);
                    }
                    else
                    {
                        listaLogs = logsDAO.selectAcao(comboFAcao.Text);
                    }
                }
                else
                {
                    listaLogs = logsDAO.selectData(dateTimePicker.Value);
                }

                foreach (Logs l in listaLogs)
                {
                    dataGridView.Rows.Add(l.Id, l.Usuario.Login, l.Acao.Descricao, l.Data.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}