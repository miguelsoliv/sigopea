using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;
using TCC.View.Add;

namespace TCC.View.Pesquisas
{
    public partial class PesqTrab : Form
    {
        private ModelDB modelDB;
        private TrabalhadoresDAO trabalhadoresDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private EstadosDAO estadosDAO { get; set; }
        private ObservacoesDAO observacoesDAO { get; set; }
        private Observacoes observacoes;
        private EnvioDeEmail envioDeEmail;
        private AddObservacao addObservacao;
        private DataGridViewImageColumn img, img2;
        private DialogResult resposta;
        private IEnumerable<Trabalhadores> listaTrab;
        private bool check, existe;
        private int idTrabalhador;

        public PesqTrab()
        {
            InitializeComponent();
            modelDB = new ModelDB();
            trabalhadoresDAO = new TrabalhadoresDAO();
            cidadesDAO = new CidadesDAO();
            estadosDAO = new EstadosDAO();
            observacoesDAO = new ObservacoesDAO();
            check = false;
        }

        private void PesqTrab_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas)
            // Adiciona as colunas a serem exibidas (conteúdo, título da coluna)
            dataGridView.Columns.Add("Id", "Código");
            dataGridView.Columns.Add("Nome", "Nome");
            dataGridView.Columns.Add("Email", "E-mail");
            dataGridView.Columns.Add("Estado.Sigla", "UF");
            dataGridView.Columns.Add("Cidade.Nome", "Cidade");
            dataGridView.Columns.Add("Servico", "Serviço");
            dataGridView.Columns.Add("Telefone", "Telefone");

            // Criação da coluna de imagens
            img = new DataGridViewImageColumn();
            img.Image = Variaveis.getEmail();
            dataGridView.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            img2 = new DataGridViewImageColumn();
            img2.Image = Variaveis.getObs();
            dataGridView.Columns.Add(img2);
            img2.HeaderText = "";
            img2.Name = "img2";
            img2.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView.Columns["Id"].Width = 50;
            dataGridView.Columns["Nome"].Width = 200;
            dataGridView.Columns["Estado.Sigla"].Width = 35;
            dataGridView.Columns["Servico"].Width = 200;
            dataGridView.Columns["img"].Width = 35;
            dataGridView.Columns["img2"].Width = 35;
            dataGridView.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            #endregion

            #region Carregar cidades no comboBox
            try
            {
                comboFCidade.DataSource = cidadesDAO.select().ToList();
                comboFCidade.ValueMember = "Nome";
                comboFCidade.DisplayMember = "Nome";

                // Habilitar o autoComplete
                comboFCidade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboFCidade.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboFCidade.Text = "";
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            #region Carregar serviços no comboBox
            try
            {
                comboFServico.DataSource = trabalhadoresDAO.select().ToList();
                comboFServico.ValueMember = "Servico";
                comboFServico.DisplayMember = "Servico";

                // Habilitar o autoComplete
                comboFServico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboFServico.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboFServico.Text = "";
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            #region Set the Cell's ToolTipText
            if (e.ColumnIndex == dataGridView.Columns["img"].Index)
            {
                var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Enviar E-mail";
            }
            else if (e.ColumnIndex == dataGridView.Columns["img2"].Index)
            {
                var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Adicionar Observação";
            }
            #endregion
        }

        private void PesqTrab_Activated(object sender, EventArgs e)
        {
            carregarTrabalhadores();
        }

        private void carregarTrabalhadores()
        {
            dataGridView.Rows.Clear();

            // Check->false: caso tenha feito uma pesquisa, não reseta as linhas do dataGrid até
            // que o usuário aperte no botão "Limpar" ou feche o form
            if (check == false)
            {
                #region Carregar trabalhadores no dataGridView
                try
                {
                    // preenche as colunas
                    foreach (Trabalhadores t in trabalhadoresDAO.select())
                    {
                        Cidades cid = cidadesDAO.selectCidade(t.Cidade.Id);
                        dataGridView.Rows.Add(t.Id, t.Nome, t.Email, cid.Estado.Sigla, t.Cidade.Nome, t.Servico, t.Telefone);
                    }
                }
                catch
                {

                }
                #endregion
            }
            else
            {
                #region Carregar trabalhadores que se encaixam na pesquisa
                try
                {
                    if (!comboFServico.Text.Trim().Equals("") && !comboFCidade.Text.Trim().Equals(""))
                    {
                        listaTrab = trabalhadoresDAO.select().Where(x => x.Servico.ToUpper().Contains(comboFServico.Text.Trim().ToUpper()) && x.Cidade.Nome.ToUpper().Contains(comboFCidade.Text.Trim().ToUpper()));
                    }
                    else if (!comboFServico.Text.Trim().Equals(""))
                    {
                        listaTrab = trabalhadoresDAO.select().Where(x => x.Servico.ToUpper().Contains(comboFServico.Text.Trim().ToUpper()));
                    }
                    else if (!comboFCidade.Text.Trim().Equals(""))
                    {
                        listaTrab = trabalhadoresDAO.select().Where(x => x.Cidade.Nome.ToUpper().Contains(comboFCidade.Text.Trim().ToUpper()));
                    }

                    // preenche as colunas
                    foreach (Trabalhadores t in listaTrab)
                    {
                        Cidades cid = cidadesDAO.selectCidade(t.Cidade.Id);
                        dataGridView.Rows.Add(t.Id, t.Nome, t.Email, cid.Estado.Sigla, t.Cidade.Nome, t.Servico, t.Telefone);
                    }
                }
                catch
                {

                }
                #endregion
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            // Limpar pesquisa
            check = false;
            carregarTrabalhadores();
            comboFServico.Text = "";
            comboFCidade.Text = "";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            #region Carregar trabalhadores que correspondam com os dados da pesquisa
            if (!comboFServico.Text.Trim().Equals("") || !comboFCidade.Text.Trim().Equals(""))
            {
                check = true;
                carregarTrabalhadores();
            }
            #endregion
        }

        private void carregarInfTrabalhador()
        {
            #region Carregar dados do trabalhador nos itens do groupBox
            try
            {
                Trabalhadores t = trabalhadoresDAO.select(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));

                textNome.Text = t.Nome;
                textNome.Focus();
                textEmail.Text = t.Email;

                if (t.Cpf.Length < 14)
                {
                    textDocumento.Text = "";
                }
                else
                {
                    textDocumento.Text = t.Cpf;
                }

                Cidades cid = cidadesDAO.selectCidade(t.Cidade.Id);
                textUF.Text = cid.Estado.Nome;

                textServico.Text = t.Servico;
                textCidade.Text = t.Cidade.Nome;
                textEndereco.Text = t.Endereco;
                textTel.Text = t.Telefone;
                textTel2.Text = t.Telefone2;
            }
            catch
            {

            }
            #endregion
        }

        private void carregarInfObservacoes(int tipo)
        {
            idTrabalhador = Convert.ToInt16(dataGridView.CurrentRow.Cells["Id"].Value.ToString());

            switch (tipo)
            {
                case 0:
                    #region Carregar informações das observações do trabalhador selecionado
                    listBoxData.Items.Clear();
                    listBoxObs.Items.Clear();
                    textObservacao.Text = "";

                    var lista = modelDB.Observacoes.GroupBy(x => new { x.Data, x.Trabalhador.Id }).Select(x => new { Data = x.Key.Data, Trabalhador = x.Key.Id }).Where(x => x.Trabalhador.ToString() != null && x.Trabalhador == idTrabalhador).ToList();

                    foreach (var obs in lista)
                    {
                        listBoxData.Items.Add(obs.Data);
                    }
                    #endregion
                    break;
                case 1:
                    #region Carregar observações relacionadas com a data selecionada
                    try
                    {
                        listBoxObs.Items.Clear();
                        textObservacao.Text = "";

                        foreach (Observacoes obs in observacoesDAO.select().Where(x => x.Trabalhador != null && x.Trabalhador.Id == idTrabalhador && x.Data == Convert.ToDateTime(listBoxData.Text)))
                        {
                            listBoxObs.Items.Add(obs.Id);
                        }
                    }
                    catch
                    {

                    }
                    #endregion
                    break;
                case 2:
                    #region Carregar texto da observação selecionada no textBox
                    try
                    {
                        foreach (Observacoes obs in observacoesDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxObs.Text)))
                        {
                            textObservacao.Text = obs.Observacao;
                        }
                    }
                    catch
                    {

                    }
                    #endregion
                    break;
            }
        }

        private void btDetalhes_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count >= 1)
            {
                #region Botão detalhes: mudar visibilidade e carregar informações do trabalhador
                groupBoxTrab.Visible = true;
                carregarInfTrabalhador();
                #endregion
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    carregarInfTrabalhador();
                    break;
                case 1:
                    carregarInfObservacoes(0);
                    break;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (groupBoxTrab.Visible == true)
            {
                switch (tabControl.SelectedIndex)
                {
                    case 0:
                        carregarInfTrabalhador();
                        break;
                    case 1:
                        carregarInfObservacoes(0);
                        break;
                }
            }
        }

        private void listBoxData_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Carregar observações relacionadas à data selecionada
            carregarInfObservacoes(1);

            if (listBoxObs.SelectedIndex == -1)
            {
                btAlterar.Enabled = false;
            }
        }

        private void listBoxObs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Carregar texto da observação selecionada
            carregarInfObservacoes(2);

            if (listBoxObs.SelectedIndex >= 0)
            {
                btAlterar.Enabled = true;
            }
        }

        #region Auto Complete + ComboBox
        private void comboFCidade_DropDown(object sender, EventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões
            // Once the user clicks on the DropDown button PreviewKeyDown event is attached to
            // that ComboBox. When user starts typing, freshly added event is triggered. In that
            // event we check if ComboBox is DroppedDown, if it is, focus that ComboBox. On
            // ComboBox focus DropDown disappeares and that's it.
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboFCidade_PreviewKeyDown);
            #endregion
        }

        // Código relacionado abaixo

        private void comboFCidade_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões²
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboFCidade_PreviewKeyDown;

            if (cbo.DroppedDown)
            {
                cbo.Focus();
            }
            #endregion
        }

        private void comboFServico_DropDown(object sender, EventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões
            // Once the user clicks on the DropDown button PreviewKeyDown event is attached to
            // that ComboBox. When user starts typing, freshly added event is triggered. In that
            // event we check if ComboBox is DroppedDown, if it is, focus that ComboBox. On
            // ComboBox focus DropDown disappeares and that's it.
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboFServico_PreviewKeyDown);
            #endregion
        }

        // Código relacionado abaixo²

        private void comboFServico_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões²
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboFServico_PreviewKeyDown;

            if (cbo.DroppedDown)
            {
                cbo.Focus();
            }
            #endregion
        }
        #endregion

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Ao dar dois cliques em alguma "cell" do dataGridView, muda a visibilidade do groupBox
            if (e.RowIndex >= 0 && e.ColumnIndex <= 6)
            {
                tabControl.SelectedIndex = 0;
                groupBoxTrab.Visible = true;
                carregarInfTrabalhador();
            }
            #endregion
        }

        #region Botões fechar
        private void btFechar_Click(object sender, EventArgs e)
        {
            #region Botão fechar: mudar visibilidade
            groupBoxTrab.Visible = false;
            btAlterar.Enabled = false;
            #endregion
        }

        private void btFechar2_Click(object sender, EventArgs e)
        {
            #region Botão fechar_2: mudar visibilidade
            groupBoxTrab.Visible = false;
            btAlterar.Enabled = false;
            #endregion
        }
        #endregion

        private void PesqTrab_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    #region Carregar trabalhadores que correspondem com os dados da pesquisa ao apertar enter
                    if (!comboFCidade.DroppedDown && !comboFServico.DroppedDown)
                    {
                        if (!comboFServico.Text.Trim().Equals("") || !comboFCidade.Text.Trim().Equals(""))
                        {
                            if (comboFServico.Focused == true || comboFCidade.Focused == true)
                            {
                                check = true;
                                carregarTrabalhadores();
                            }
                        }
                    }
                    #endregion
                    break;
                case Keys.Escape:
                    #region Mudar visibilidade do groupBox ao apertar a tecla ESC
                    if (groupBoxTrab.Visible == true)
                    {
                        groupBoxTrab.Visible = false;
                        btAlterar.Enabled = false;
                    }
                    else
                    {
                        this.Close();
                    }
                    #endregion
                    break;
                case Keys.Delete:
                    #region Excluir observação selecionada ao apertar a tecla Delete
                    if (listBoxObs.SelectedIndex != -1 && listBoxObs.Focused == true)
                    {
                        excluirObs();
                    }
                    #endregion
                    break;
            }
        }

        private void excluirObs()
        {
            #region Exclusão de observação
            if (listBoxObs.SelectedIndex >= 0)
            {
                resposta = MessageBox.Show("Excluir a observação selecionada?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        observacoesDAO.delete(Convert.ToInt16(listBoxObs.Text));
                        carregarInfObservacoes(0);
                        carregarInfObservacoes(1);
                        btAlterar.Enabled = false;
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma observação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            excluirObs();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            #region Validação da observação
            if (textObservacao.Text.Trim().Equals(""))
            {
                MessageBox.Show("Informe uma observação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textObservacao.Focus();
                return;
            }
            #endregion

            #region Botão alterar: alterar o texto da observação selecionada
            try
            {
                observacoes = new Observacoes();
                observacoes.Id = Convert.ToInt16(listBoxObs.Text);
                observacoes.Observacao = textObservacao.Text.Trim();
                observacoesDAO.update(observacoes);

                listBoxObs.SelectedIndex = -1;
                textObservacao.Text = "";
            }
            catch
            {

            }
            #endregion
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender; // variável var = só pode ser declarada dentro de um método ou script

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                #region Abrir form de envio de e-mail
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
                    envioDeEmail = new EnvioDeEmail(dataGridView.CurrentRow.Cells["Email"].Value.ToString());
                    envioDeEmail.MdiParent = this.ParentForm;
                    envioDeEmail.Show();
                }
                #endregion
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 8)
            {
                #region Abrir form para adicionar observação
                existe = false;
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is AddObservacao)
                    {
                        openForm.BringToFront();
                        existe = true;
                    }
                }
                if (!existe)
                {
                    addObservacao = new AddObservacao(2, dataGridView.CurrentRow.Cells["ID"].Value.ToString(), dataGridView.CurrentRow.Cells["Nome"].Value.ToString());
                    addObservacao.MdiParent = this.ParentForm;
                    addObservacao.Show();
                }
                #endregion
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            #region Botão sair
            this.Close();
            #endregion
        }
    }
}