using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;
using TCC.View.Add;

namespace TCC.View.Movimentos
{
    public partial class MovProjetos : Form
    {
        private ModelDB modelDB;
        private ProjetosDAO projetosDAO { get; set; }
        private ClientesDAO clientesDAO { get; set; }
        private EstadosDAO estadosDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private StatusDAO statusDAO { get; set; }
        private AgendamentosDAO agendamentosDAO { get; set; }
        private RegCauDAO regCauDAO { get; set; }
        private RegCauProjetoDAO regCauProjDAO { get; set; }
        private RegCreaDAO regCreaDAO { get; set; }
        private RegCreaProjetoDAO regCreaProjDAO { get; set; }
        private RegCau regCau;
        private RegCauProjeto regCauProj;
        private RegCrea regCrea;
        private RegCreaProjeto regCreaProj;
        private Projetos projeto;
        private DialogResult resposta;
        private IEnumerable<Projetos> listaProjetos;
        private bool existe;
        private string id;
        private int idProjeto;

        public MovProjetos()
        {
            InitializeComponent();
            modelDB = new ModelDB();
            projetosDAO = new ProjetosDAO();
            clientesDAO = new ClientesDAO();
            estadosDAO = new EstadosDAO();
            cidadesDAO = new CidadesDAO();
            statusDAO = new StatusDAO();
            agendamentosDAO = new AgendamentosDAO();
            regCauDAO = new RegCauDAO();
            regCauProjDAO = new RegCauProjetoDAO();
            regCreaDAO = new RegCreaDAO();
            regCreaProjDAO = new RegCreaProjetoDAO();
        }

        private void MovProjetos_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas)
            dataGridView1.Columns.Add("Id", "Código");
            dataGridView1.Columns.Add("Cliente.Nome", "Cliente");
            dataGridView1.Columns.Add("Status.Nome", "Status");
            dataGridView1.Columns.Add("Estado.Sigla", "UF");
            dataGridView1.Columns.Add("Cidade.Nome", "Cidade");
            dataGridView1.Columns.Add("Endereco", "Endereço");
            dataGridView1.Columns.Add("PrazoEstipulado", "Entrega");

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Image = Variaveis.getAgend();
            dataGridView1.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.Image = Variaveis.getReg();
            dataGridView1.Columns.Add(img2);
            img2.HeaderText = "";
            img2.Name = "img2";
            img2.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView1.Columns["Id"].Width = 50;
            dataGridView1.Columns["Cliente.Nome"].Width = 200;
            dataGridView1.Columns["Estado.Sigla"].Width = 35;
            dataGridView1.Columns["PrazoEstipulado"].Width = 70;
            dataGridView1.Columns["img"].Width = 35;
            dataGridView1.Columns["img2"].Width = 35;
            dataGridView1.Columns["Endereco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            #endregion

            #region Carregar status dos projetos
            try
            {
                comboStatus.DataSource = statusDAO.select();
                comboStatus.DisplayMember = "Nome";
                comboStatus.ValueMember = "Id";
            }
            catch
            {
                
            }
            #endregion

            #region Carregar estados no comboBox quando o Form for aberto
            try
            {
                comboUF.DataSource = estadosDAO.select();
                comboUF.DisplayMember = "Sigla";
                comboUF.ValueMember = "Id";
            }
            catch
            {
                
            }
            #endregion

            carregarCidades();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            #region Set the Cell's ToolTipText
            if (e.ColumnIndex == dataGridView1.Columns["img"].Index)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Adicionar Agendamento";
            }
            else if (e.ColumnIndex == dataGridView1.Columns["img2"].Index)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Adicionar Registro CREA/CAU";
            }
            #endregion
        }

        private void MovProjetos_Activated(object sender, EventArgs e)
        {
            carregarProjetos(0);
            carregarClientes();
        }

        private void carregarProjetos(int tipo)
        {
            #region Carregar projetos no dataGridView
            try
            {
                dataGridView1.Rows.Clear();

                switch (tipo)
                {
                    case 0:
                        listaProjetos = projetosDAO.select();
                        break;
                    case 1:
                    case 2:
                    case 3:
                        listaProjetos = projetosDAO.select().Where(x => x.Status.Id == tipo);
                        break;
                }

                foreach (Projetos p in listaProjetos)
                {
                    Cidades cid = cidadesDAO.selectCidade(p.Cidade.Id);
                    dataGridView1.Rows.Add(p.Id, p.Cliente.Nome, p.Status.Nome, cid.Estado.Sigla, p.Cidade.Nome, p.Endereco, p.PrazoEstipulado.ToString("dd/MM/yyyy"));
                }
            }
            catch
            {
                
            }
            #endregion
        }

        private void carregarClientes()
        {
            #region Carregar clientes
            try
            {
                comboCliente.DataSource = clientesDAO.select();
                comboCliente.DisplayMember = "Nome";
                comboCliente.ValueMember = "Id";
            }
            catch
            {
                
            }
            #endregion
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            #region Botão incluir: muda a visibilidade e o nome do groupBox
            tabControlDet.SelectedIndex = 0;
            limparCampos();
            groupBoxProjetos.Visible = true;
            comboCliente.Focus();
            groupBoxProjetos.Text = "Inclusão de Projeto";
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                #region Botão alterar: muda a visibilidade e o nome do groupBox
                tabControlDet.SelectedIndex = 0;
                groupBoxProjetos.Visible = true;
                tabControlDet.SelectedIndex = 0;
                comboCliente.Focus();
                groupBoxProjetos.Text = "Alteração de Projeto";
                #endregion

                carregarInfProjeto();
            }
        }

        private void salvarAgend()
        {
            if (listBoxAgend.SelectedIndex >= 0)
            {
                #region Validação de dados
                errorProvider.SetError(textAssunto, string.Empty);

                if (textAssunto.Text.Trim().Equals(""))
                {
                    errorProvider.SetError(textAssunto, "Informe o assunto do agendamento");
                    return;
                }
                #endregion

                #region Botão alterar agendamento: alterar o assunto/observação do agendamento selecionado
                try
                {
                    Agendamentos agendamento = new Agendamentos();
                    agendamento.Id = Convert.ToInt16(listBoxAgend.Text);
                    agendamento.Assunto = textAssunto.Text.Trim();
                    agendamento.Observacao = textAgend.Text.Trim();
                    agendamentosDAO.update(agendamento);

                    listBoxAgend.SelectedIndex = -1;
                    textAssunto.Text = "";
                    textAgend.Text = "";
                }
                catch
                {

                }
                #endregion
            }
        }

        private void btAlterarAgend_Click(object sender, EventArgs e)
        {
            salvarAgend();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Ao dar dois cliques em alguma "cell" do dataGridView, muda a visibilidade e o nome do groupBox (alteração)
            if (e.RowIndex >= 0 && e.ColumnIndex <= 6)
            {
                tabControlDet.SelectedIndex = 0;
                groupBoxProjetos.Visible = true;
                tabControlDet.SelectedIndex = 0;
                groupBoxProjetos.Text = "Detalhes";
                carregarInfProjeto();
            }
            #endregion
        }

        private void carregarInfAgend(int tipo)
        {
            if (dataGridView1.RowCount >= 1)
            {
                idProjeto = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                switch (tipo)
                {
                    case 0:
                        #region Carregar informações dos agendamentos do projeto selecionado
                        listBoxData.Items.Clear();
                        listBoxAgend.Items.Clear();
                        textAgend.Text = "";
                        textAssunto.Text = "";

                        var lista = modelDB.Agendamentos.GroupBy(x => new { x.Data, x.Projeto.Id }).Select(x => new { Data = x.Key.Data, Projeto = x.Key.Id }).Where(x => x.Projeto.ToString() != null && x.Projeto == idProjeto).ToList();

                        foreach (var agend in lista)
                        {
                            listBoxData.Items.Add(agend.Data);
                        }
                        #endregion
                        break;
                    case 1:
                        #region Carregar agendamentos relacionados com a data selecionada
                        try
                        {
                            listBoxAgend.Items.Clear();
                            textAgend.Text = "";
                            textAssunto.Text = "";

                            foreach (Agendamentos agend in agendamentosDAO.select().Where(x => x.Projeto != null && x.Projeto.Id == idProjeto && x.Data == Convert.ToDateTime(listBoxData.Text)))
                            {
                                listBoxAgend.Items.Add(agend.Id);
                            }
                        }
                        catch
                        {

                        }
                        #endregion
                        break;
                    case 2:
                        #region Carregar texto do agendamento selecionado no textBox
                        try
                        {
                            foreach (Agendamentos agend in agendamentosDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxAgend.Text)))
                            {
                                textAgend.Text = agend.Observacao;
                                textAssunto.Text = agend.Assunto;
                            }
                        }
                        catch
                        {

                        }
                        #endregion
                        break;
                }
            }
        }

        private void carregarInfReg(int tipo)
        {
            if (dataGridView1.RowCount >= 1)
            {
                idProjeto = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                switch (tipo)
                {
                    case 0:
                        #region Carregar informações dos registros do projeto selecionado
                        listBoxCau.Items.Clear();
                        listBoxCauId.Items.Clear();
                        listBoxCrea.Items.Clear();
                        listBoxCreaId.Items.Clear();
                        textRegistro.Text = "";
                        comboTipo.SelectedIndex = -1;

                        if (!groupBoxProjetos.Text.Equals("Inclusão de Projeto"))
                        {
                            foreach (RegCauProjeto cauP in regCauProjDAO.select().Where(x => x.Projeto.Id == idProjeto))
                            {
                                listBoxCau.Items.Add(cauP.Cau.Cau);
                                listBoxCauId.Items.Add(cauP.Cau.Id);
                            }

                            foreach (RegCreaProjeto creaP in regCreaProjDAO.select().Where(x => x.Projeto.Id == idProjeto))
                            {
                                listBoxCrea.Items.Add(creaP.Crea.Crea);
                                listBoxCreaId.Items.Add(creaP.Crea.Id);
                            }
                        }
                        #endregion
                        break;
                    case 1:
                        #region Carregar texto do registro selecionado no textBox
                        try
                        {
                            if (listBoxCrea.SelectedIndex == -1 && listBoxCau.SelectedIndex >= 0)
                            {
                                listBoxCauId.SelectedIndex = listBoxCau.SelectedIndex;

                                foreach (RegCau regCau in regCauDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxCauId.Text)))
                                {
                                    textRegistro.Text = regCau.Cau;
                                    comboTipo.SelectedIndex = 0;
                                }
                            }
                            else if(listBoxCrea.SelectedIndex >= 0 && listBoxCau.SelectedIndex == -1)
                            {
                                listBoxCreaId.SelectedIndex = listBoxCrea.SelectedIndex;

                                foreach (RegCrea regCrea in regCreaDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxCreaId.Text)))
                                {
                                    textRegistro.Text = regCrea.Crea;
                                    comboTipo.SelectedIndex = 1;
                                }
                            }
                        }
                        catch
                        {

                        }
                        #endregion
                        break;
                }
            }
        }

        private void tabControlDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!groupBoxProjetos.Text.Equals("Inclusão de Projeto"))
            {
                limparErros();

                switch (tabControlDet.SelectedIndex)
                {
                    case 0:
                        carregarInfProjeto();
                        break;
                    case 1:
                        carregarInfReg(0);
                        break;
                    case 2:
                        carregarInfAgend(0);
                        break;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (groupBoxProjetos.Visible == true)
            {
                limparErros();

                if (!groupBoxProjetos.Text.Equals("Inclusão de Projeto"))
                {
                    switch (tabControlDet.SelectedIndex)
                    {
                        case 0:
                            carregarInfProjeto();
                            break;
                        case 1:
                            carregarInfReg(0);
                            break;
                        case 2:
                            carregarInfAgend(0);
                            break;
                    }
                }
            }
        }

        private void listBoxData_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarInfAgend(1);
        }

        private void listBoxAgend_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarInfAgend(2);
        }

        private void carregarInfProjeto()
        {
            #region Carregar dados do projeto nos itens do groupBox
            try
            {
                Projetos p = projetosDAO.select(Convert.ToInt16(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
                comboCliente.Focus();

                Cidades cid = cidadesDAO.selectCidade(p.Cidade.Id);
                comboUF.SelectedValue = cid.Estado.Id;

                comboCliente.SelectedValue = p.Cliente.Id;
                comboStatus.SelectedValue = p.Status.Id;
                comboCidade.SelectedValue = p.Cidade.Id;
                textEndereco.Text = p.Endereco;
                textPreco.Text = "" + p.Preco;
                dateTimeInicio.Value = Convert.ToDateTime(p.DataInicio);
                dateTimeEntrega.Value = Convert.ToDateTime(p.PrazoEstipulado);
            }
            catch
            {
                
            }
            #endregion
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            excluirProjeto();
        }

        private void btExcluirAgend_Click(object sender, EventArgs e)
        {
            excluirAgend();
        }

        private void excluirAgend()
        {
            #region Exclusão de agendamento
            if (listBoxAgend.SelectedIndex >= 0)
            {
                resposta = MessageBox.Show("Excluir o agendamento selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        agendamentosDAO.delete(Convert.ToInt16(listBoxAgend.Text));
                        carregarInfAgend(0);
                        carregarInfAgend(1);
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um agendamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void excluirProjeto()
        {
            if (dataGridView1.RowCount >= 1)
            {
                if (dataGridView1.SelectedRows.Count > 1)
                {
                    #region Verificar se há vários projetos selecionados
                    resposta = MessageBox.Show("Excluir TODOS os projetos selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            {
                                projetosDAO.delete(Convert.ToInt16(r.Cells["ID"].Value.ToString()));
                            }
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarProjetos(0);
                    }
                    #endregion
                }
                else
                {
                    #region Excluir o projeto selecionado
                    resposta = MessageBox.Show("Excluir projeto selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            projetosDAO.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarProjetos(0);
                    }
                    #endregion
                }
            }
        }

        private void salvarProjetoComRegistro()
        {
            #region Salvar projeto e registros
            projetosDAO.insert(projeto);

            foreach (var listBoxItem in listBoxCrea.Items)
            {
                regCrea = new RegCrea();
                regCreaProj = new RegCreaProjeto();
                regCrea.Crea = listBoxItem.ToString();
                regCreaProj.Crea = regCrea;
                regCreaDAO.insert(regCrea);
                regCreaProj.Projeto = projetosDAO.select().Last();
                regCreaProjDAO.insert(regCreaProj);
            }

            foreach (var listBoxItem in listBoxCau.Items)
            {
                regCau = new RegCau();
                regCauProj = new RegCauProjeto();
                regCau.Cau = listBoxItem.ToString();
                regCauProj.Cau = regCau;
                regCauDAO.insert(regCau);
                regCauProj.Projeto = projetosDAO.select().Last();
                regCauProjDAO.insert(regCauProj);
            }

            carregarProjetos(0);
            limparCampos();
            #endregion
        }

        private void salvarProjeto()
        {
            #region Validação de campos
            limparErros();
            int verif = 0;

            if(comboCliente.SelectedIndex == -1)
            {
                errorProvider.SetError(comboCliente, "Selecione um cliente");
                verif++;
            }

            if(comboStatus.SelectedIndex == -1)
            {
                errorProvider.SetError(comboStatus, "Selecione um status para o projeto");
                verif++;
            }

            if (textEndereco.Text.Trim().Length <= 10)
            {
                errorProvider.SetError(textEndereco, "Informe um endereço válido para o projeto");
                verif++;
            }

            if (comboUF.SelectedIndex == -1)
            {
                errorProvider.SetError(comboUF, "Selecione uma Unidade da Federação");
                verif++;
            }

            if (comboCidade.SelectedIndex == -1)
            {
                errorProvider.SetError(comboCidade, "Selecione uma cidade");
                verif++;
            }

            try
            {
                double preco = Convert.ToDouble(textPreco.Text);

                if(preco < 30)
                {
                    errorProvider.SetError(textPreco, "Informe um valor válido");
                    textPreco.Focus();
                    return;
                }
            }
            catch
            {
                errorProvider.SetError(textPreco, "Informe o valor cobrado(R$) para realização do projeto");
                textPreco.Focus();
                return;
            }

            if(verif > 0)
            {
                return;
            }
            #endregion

            #region Colocar os dados do projeto em um objeto
            try
            {
                projeto = new Projetos();
                projeto.Cliente = clientesDAO.select(Convert.ToInt16(comboCliente.SelectedValue));
                projeto.Status = statusDAO.select().Where(x => x.Id == Convert.ToInt16(comboStatus.SelectedValue)).First();
                projeto.Endereco = textEndereco.Text.Trim();
                projeto.Cidade = cidadesDAO.selectPorEstado(Convert.ToInt16(comboUF.SelectedValue)).Where(x => x.Id == Convert.ToInt16(comboCidade.SelectedValue)).First();
                projeto.Preco = Convert.ToDecimal(textPreco.Text.Trim());
                projeto.DataInicio = Convert.ToDateTime(dateTimeInicio.Value.ToString("dd/MM/yyyy"));
                projeto.PrazoEstipulado = Convert.ToDateTime(dateTimeEntrega.Value.ToString("dd/MM/yyyy"));
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            switch (groupBoxProjetos.Text)
            {
                case "Inclusão de Projeto":
                    #region Inclusão de projeto com registro
                    if (listBoxCau.Items.Count + listBoxCrea.Items.Count == 0)
                    {
                        try
                        {
                            comboCliente.Enabled = false;
                            comboStatus.Enabled = false;
                            textEndereco.Enabled = false;
                            comboUF.Enabled = false;
                            comboCidade.Enabled = false;
                            textPreco.Enabled = false;
                            dateTimeInicio.Enabled = false;
                            dateTimeEntrega.Enabled = false;
                            btSalvar.Enabled = false;
                            btCancelar.Enabled = false;
                            errorProvider2.SetError(label20, "Para finalizar a inclusão do projeto, cadastre os registros relacionados ao mesmo");
                            errorProvider2.SetError(label28, "Cadastre os registros relacionados ao projeto");
                            tabControlDet.SelectedIndex = 1;
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        salvarProjetoComRegistro();
                    }
                    #endregion
                    break;
                case "Alteração de Projeto":
                    #region Alteração dos dados do projeto
                    try
                    {
                        projeto.Id = Convert.ToInt16(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                        projetosDAO.update(projeto);
                        carregarProjetos(0);
                        limparCampos();
                    }
                    catch
                    {
                        
                    }
                    #endregion
                    break;
            }
        }

        private void limparErros()
        {
            #region Limpar possíveis erros dos controls
            errorProvider.SetError(comboCliente, string.Empty);
            errorProvider.SetError(comboStatus, string.Empty);
            errorProvider.SetError(textEndereco, string.Empty);
            errorProvider.SetError(comboUF, string.Empty);
            errorProvider.SetError(comboCidade, string.Empty);
            errorProvider.SetError(textPreco, string.Empty);
            errorProvider.SetError(textAssunto, string.Empty);
            errorProvider.SetError(textRegistro, string.Empty);
            errorProvider.SetError(comboTipo, string.Empty);
            #endregion
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            salvarProjeto();
        }

        private void salvarRegistro()
        {
            #region Validação de campos
            errorProvider.SetError(textRegistro, string.Empty);
            errorProvider.SetError(comboTipo, string.Empty);
            int verif = 0;

            if (listBoxCau.Items.Count + listBoxCrea.Items.Count == 2 && btSalvarRegistro.Text.Equals("&Salvar"))
            {
                errorProvider.SetError(textRegistro, "Cadastre somente 2 registros por projeto");
                return;
            }

            if (textRegistro.Text.Trim().Length <= 6)
            {
                errorProvider.SetError(textRegistro, "Informe um registro com pelo menos 7 caracteres");
                verif++;
            }

            if(comboTipo.SelectedIndex == -1)
            {
                errorProvider.SetError(comboTipo, "Selecione o tipo do registro");
                return;
            }

            if(verif > 0)
            {
                return; 
            }
            #endregion

            #region Adicionar registros nas listas caso o texto do botão esteja como "&Salvar" || Avisar o usuário para selecionar um registro para alterar
            if (btSalvarRegistro.Text.Equals("&Salvar"))
            {
                switch (comboTipo.SelectedIndex)
                {
                    case 0:
                        listBoxCau.Items.Add(textRegistro.Text.Trim());
                        break;
                    case 1:
                        listBoxCrea.Items.Add(textRegistro.Text.Trim());
                        break;
                }
            }
            else
            {
                if (listBoxCau.SelectedIndex == -1 || listBoxCrea.SelectedIndex == -1)
                {
                    resposta = MessageBox.Show("Selecione um registro para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion

            switch (btSalvarRegistro.Text)
            {
                case "&Salvar":
                    #region Cadastro de registro
                    if (listBoxCau.Items.Count + listBoxCrea.Items.Count < 2)
                    {
                        resposta = MessageBox.Show("Cadastrar outro registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (resposta == DialogResult.No)
                        {
                            if (btSalvar.Enabled)
                            {
                                btSalvarRegistro.Enabled = false;
                                btExcluirReg.Enabled = false;
                                textRegistro.Enabled = false;
                                comboTipo.Enabled = false;
                                btFechar.Enabled = false;
                                errorProvider2.SetError(label20, "Cadastre as informações restantes do projeto");
                                errorProvider2.SetError(label28, "Para finalizar a inclusão do projeto, cadastre as informações restantes do projeto");
                                tabControlDet.SelectedIndex = 0;
                                return;
                            }

                            salvarProjetoComRegistro();
                        }
                        else
                        {
                            textRegistro.Text = "";
                            comboTipo.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        if (btSalvar.Enabled)
                        {
                            btSalvarRegistro.Enabled = false;
                            btExcluirReg.Enabled = false;
                            textRegistro.Enabled = false;
                            comboTipo.Enabled = false;
                            btFechar.Enabled = false;
                            errorProvider2.SetError(label20, "Cadastre as informações restantes do projeto");
                            errorProvider2.SetError(label28, "Para finalizar a inclusão do projeto, cadastre as informações restantes do projeto");
                            tabControlDet.SelectedIndex = 0;
                            return;
                        }

                        salvarProjetoComRegistro();
                    }
                    #endregion
                    break;
                case "&Alterar":
                    #region Alteração de registro
                    try
                    {
                        idProjeto = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                        if (comboTipo.SelectedIndex == 0)
                        {
                            if (listBoxCau.SelectedIndex >= 0)
                            {
                                regCau = regCauDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxCauId.Text)).First();
                                regCau.Cau = textRegistro.Text.Trim();
                                regCauProj = regCauProjDAO.select().Where(x => x.Cau.Id == Convert.ToInt16(listBoxCauId.Text)).First();
                                regCauProj.Cau = regCau;
                                regCauDAO.update(regCau);
                                regCauProjDAO.update(regCauProj);
                            }
                            else
                            {
                                regCreaProj = new RegCreaProjeto();
                                regCreaProj = regCreaProjDAO.select().Where(x => x.Projeto.Id == idProjeto && x.Crea.Id == Convert.ToInt16(listBoxCreaId.Text)).First();
                                regCreaProjDAO.delete(regCreaProj.Id);
                                regCreaDAO.delete(Convert.ToInt16(listBoxCreaId.Text));

                                regCau = new RegCau();
                                regCauProj = new RegCauProjeto();
                                regCau.Cau = textRegistro.Text.Trim();
                                regCauProj.Cau = regCau;
                                regCauDAO.insert(regCau);
                                regCauProj.Projeto = projetosDAO.select().Last();
                                regCauProjDAO.insert(regCauProj);
                            }
                        }
                        else
                        {
                            if (listBoxCrea.SelectedIndex >= 0)
                            {
                                regCrea = regCreaDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxCreaId.Text)).First();
                                regCrea.Crea = textRegistro.Text.Trim();
                                regCreaProj = regCreaProjDAO.select().Where(x => x.Crea.Id == Convert.ToInt16(listBoxCreaId.Text)).First();
                                regCreaProj.Crea = regCrea;
                                regCreaDAO.update(regCrea);
                                regCreaProjDAO.update(regCreaProj);
                            }
                            else
                            {
                                regCauProj = new RegCauProjeto();
                                regCauProj = regCauProjDAO.select().Where(x => x.Projeto.Id == idProjeto && x.Cau.Id == Convert.ToInt16(listBoxCauId.Text)).First();
                                regCauProjDAO.delete(regCauProj.Id);
                                regCauDAO.delete(Convert.ToInt16(listBoxCauId.Text));

                                regCrea = new RegCrea();
                                regCreaProj = new RegCreaProjeto();
                                regCrea.Crea = textRegistro.Text.Trim();
                                regCreaProj.Crea = regCrea;
                                regCreaDAO.insert(regCrea);
                                regCreaProj.Projeto = projetosDAO.select().Last();
                                regCreaProjDAO.insert(regCreaProj);
                            }
                        }
                    }
                    catch
                    {

                    }

                    carregarInfReg(0);
                    #endregion
                    break;
            }
        }

        private void btSalvarRegistro_Click(object sender, EventArgs e)
        {
            salvarRegistro();
        }

        #region Botões fechar e cancelar
        private void btCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            #region Botão fechar do registro: Confirmar cancelamento do cadastro de projeto
            if (groupBoxProjetos.Text.Equals("Inclusão de Projeto"))
            {
                resposta = MessageBox.Show("Cancelar a inclusão do projeto?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    limparCampos();
                }
            }
            else
            {
                limparCampos();
            }
            #endregion
        }

        private void btFechar2_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
        #endregion

        private void comboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarCidades();
        }

        private void carregarCidades()
        {
            #region Carregar cidades no comboBox
            try
            {
                comboCidade.DataSource = cidadesDAO.selectPorEstado(Convert.ToInt16(comboUF.SelectedValue)).ToList();
                comboCidade.DisplayMember = "Nome";
                comboCidade.ValueMember = "Id";
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btExcluirReg_Click(object sender, EventArgs e)
        {
            excluirReg();
        }

        private void excluirReg()
        {
            if (listBoxCrea.SelectedIndex >= 0 || listBoxCau.SelectedIndex >= 0)
            {
                if (listBoxCrea.Items.Count + listBoxCau.Items.Count == 2)
                {
                    resposta = MessageBox.Show("Excluir registro selecionado?", "Atenção", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        idProjeto = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                        if (listBoxCrea.SelectedIndex >= 0)
                        {
                            #region Exclusão de registro CREA
                            try
                            {
                                regCrea = regCreaDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxCreaId.Text)).First();
                                regCreaProj = regCreaProjDAO.select().Where(x => x.Projeto.Id == idProjeto && x.Crea.Id == regCrea.Id).First();
                                regCreaProjDAO.delete(regCreaProj.Id);
                                regCreaDAO.delete(regCrea.Id);
                            }
                            catch
                            {

                            }
                            #endregion
                        }
                        else
                        {
                            #region Exclusão de registro CAU
                            try
                            {
                                regCau = regCauDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxCauId.Text)).First();
                                regCauProj = regCauProjDAO.select().Where(x => x.Projeto.Id == idProjeto && x.Cau.Id == regCau.Id).First();
                                regCauProjDAO.delete(regCauProj.Id);
                                regCauDAO.delete(regCau.Id);
                            }
                            catch
                            {

                            }
                            #endregion
                        }

                        carregarInfReg(0);
                    }
                }
                else
                {
                    MessageBox.Show("Tenha ao menos um registro cadastrado para o projeto.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBoxCau.SelectedIndex = -1;
                    listBoxCrea.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MovProjetos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    #region ESC: se o groupBox estiver visível chama o método limparCampos(), se não estiver, fecha o form
                    if (groupBoxProjetos.Visible == true)
                    {
                        if (groupBoxProjetos.Text.Equals("Inclusão de Projeto") && tabControlDet.SelectedIndex == 1 || groupBoxProjetos.Text.Equals("Inclusão de Projeto") && btSalvar.Enabled == false)
                        {
                            resposta = MessageBox.Show("Cancelar a inclusão do projeto?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (resposta == DialogResult.Yes)
                            {
                                limparCampos();
                            }
                        }
                        else
                        {
                            limparCampos();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                    #endregion
                    break;
                case Keys.Enter:
                    #region Caso algum campo do groupBox esteja em foco e o mesmo visível, salva os dados do projeto
                    if (groupBoxProjetos.Visible == true && !groupBoxProjetos.Text.Equals("Detalhes"))
                    {
                        if (!comboCliente.DroppedDown && !comboStatus.DroppedDown && !comboUF.DroppedDown &&
                            !comboCidade.DroppedDown && !comboTipo.DroppedDown)
                        {
                            if (textPreco.Focused == true || textEndereco.Focused == true ||
                                dateTimeInicio.Focused == true || dateTimeEntrega.Focused == true)
                            {
                                salvarProjeto();
                            }
                            else if (textAssunto.Focused == true)
                            {
                                salvarAgend();
                            }
                            else if (textRegistro.Focused == true || comboTipo.Focused == true)
                            {
                                salvarRegistro();
                            }
                        }
                    }
                    #endregion
                    break;
                case Keys.Delete:
                    #region Excluir observação selecionada ao apertar a tecla Delete
                    if (groupBoxProjetos.Visible == true && !groupBoxProjetos.Text.Equals("Detalhes"))
                    {
                        if (listBoxAgend.SelectedIndex != -1 && listBoxAgend.Focused == true)
                        {
                            excluirAgend();
                        }
                        else if(listBoxCrea.SelectedIndex != -1 && listBoxCrea.Focused == true || listBoxCau.SelectedIndex != -1 && listBoxCau.Focused == true)
                        {
                            excluirReg();
                        }
                    }
                    #endregion
                    break;
            }
        }

        private void limparCampos()
        {
            #region Limpar campos do groupBox
            try
            {
                if(tabControlDet.TabPages.Count == 2)
                {
                    listBoxCau.Items.Clear();
                    listBoxCrea.Items.Clear();
                    btSalvarRegistro.Enabled = true;
                    btExcluirReg.Enabled = true;
                    textRegistro.Enabled = true;
                    comboTipo.Enabled = true;
                    btFechar.Enabled = true;

                    comboCliente.Enabled = true;
                    comboStatus.Enabled = true;
                    textEndereco.Enabled = true;
                    comboUF.Enabled = true;
                    comboCidade.Enabled = true;
                    textPreco.Enabled = true;
                    dateTimeInicio.Enabled = true;
                    dateTimeEntrega.Enabled = true;
                    btSalvar.Enabled = true;
                    btCancelar.Enabled = true;
                    errorProvider2.SetError(label20, string.Empty);
                    errorProvider2.SetError(label28, string.Empty);
                    limparErros();
                }

                if (comboCliente.Items.Count >= 1)
                {
                    comboCliente.SelectedIndex = 0;
                }

                comboCliente.Focus();
                comboStatus.SelectedIndex = 0;
                textPreco.Clear();
                comboUF.SelectedIndex = 0;
                comboCidade.SelectedIndex = 0;
                textEndereco.Clear();
                textPreco.Clear();
                dateTimeInicio.Value = DateTime.Today;
                dateTimeEntrega.Value = DateTime.Today;
                textRegistro.Clear();
                comboTipo.SelectedIndex = -1;
                groupBoxProjetos.Visible = false;
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender; // variável var = só pode ser declarada dentro de um método ou script

            id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                #region Abrir form para adicionar agendamento
                existe = false;
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is AddAgendamento)
                    {
                        openForm.BringToFront();
                        existe = true;
                    }
                }
                if (!existe)
                {
                    AddAgendamento addAgendamento = new AddAgendamento(1, id);
                    addAgendamento.MdiParent = this.ParentForm;
                    addAgendamento.Show();
                }
                #endregion
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 8)
            {
                #region Abrir form para adicionar registro (se o projeto possui somente 1)
                if (regCreaProjDAO.select().Where(x => x.Projeto.Id == Convert.ToInt16(id)).Count() + regCauProjDAO.select().Where(x => x.Projeto.Id == Convert.ToInt16(id)).Count() == 2)
                {
                    resposta = MessageBox.Show("O projeto já possui dois registros cadastrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    groupBoxProjetos.Visible = true;
                    tabControlDet.SelectedIndex = 1;
                    groupBoxProjetos.Text = "Alteração de Projeto";
                    carregarInfReg(0);
                }
                else
                {
                    existe = false;
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm is AddReg)
                        {
                            openForm.BringToFront();
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        AddReg addReg = new AddReg(id);
                        addReg.MdiParent = this.ParentForm;
                        addReg.Show();
                    }
                }
                #endregion
            }
        }

        private void dateTimeInicio_ValueChanged(object sender, EventArgs e)
        {
            #region +1 no dia da entrega sempre que o usuário mudar a data do início do projeto (se início >= entrega)
            if (dateTimeInicio.Value >= dateTimeEntrega.Value)
            {
                dateTimeEntrega.Value = dateTimeInicio.Value.AddDays(1);
            }
            #endregion
        }

        private void dateTimeEntrega_ValueChanged(object sender, EventArgs e)
        {
            #region -1 no dia do início sempre que o usuário mudar a data de entrega do projeto (se início >= entrega)
            if (dateTimeInicio.Value >= dateTimeEntrega.Value)
            {
                dateTimeInicio.Value = dateTimeEntrega.Value.AddDays(-1);
            }
            #endregion
        }

        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Ao mudar o cliente selecionado, muda também a cidade e UF selecionados
            try
            {
                Clientes cliente = clientesDAO.select(Convert.ToInt16(comboCliente.SelectedValue.ToString()));
                Cidades cidade = cidadesDAO.select().Where(x => x.Id == cliente.Cidade.Id).First();
                comboUF.SelectedValue = cidade.Estado.Id;
                comboCidade.SelectedValue = cidade.Id;
            }
            catch
            {

            }
            #endregion
        }

        #region Ao mudar algum radio button selecionado, realizar um filtro
        private void radioTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTodos.Checked == true)
            {
                carregarProjetos(0);
            }
        }

        private void radioEmAnd_CheckedChanged(object sender, EventArgs e)
        {
            if(radioEmAnd.Checked == true)
            {
                carregarProjetos(1);
            }
        }

        private void radioParados_CheckedChanged(object sender, EventArgs e)
        {
            if (radioParados.Checked == true)
            {
                carregarProjetos(2);
            }
        }

        private void radioFinalizados_CheckedChanged(object sender, EventArgs e)
        {
            if(radioFinalizados.Checked == true)
            {
                carregarProjetos(3);
            }
        }
        #endregion

        private void btDetalhes_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount >= 1)
            {
                #region Botão detalhes: muda a visibilidade e o nome do groupBox
                tabControlDet.SelectedIndex = 0;
                groupBoxProjetos.Visible = true;
                groupBoxProjetos.Text = "Detalhes";
                #endregion

                carregarInfProjeto();
            }
        }

        private void groupBoxProjetos_TextChanged(object sender, EventArgs e)
        {
            switch (groupBoxProjetos.Text)
            {
                case "Inclusão de Projeto":
                    #region Deixar visível somente as informações pertinentes a inclusão dos dados iniciais do projeto
                    btSalvar.Enabled = true;
                    btSalvarRegistro.Enabled = true;
                    btExcluirReg.Enabled = true;
                    listBoxCau.Items.Clear();
                    listBoxCauId.Items.Clear();
                    listBoxCrea.Items.Clear();
                    listBoxCreaId.Items.Clear();

                    if (tabControlDet.TabCount == 3)
                    {
                        tabControlDet.TabPages.Remove(tabPage6);
                    }

                    if (btSalvarRegistro.Text.Equals("&Alterar"))
                    {
                        btSalvarRegistro.Text = "&Salvar";
                        btSalvarRegistro.Image = Variaveis.getSalvar();
                    }
                    #endregion
                    break;
                case "Alteração de Projeto":
                    #region Adicionar páginas removidas na hora de incluir um projeto, possibilitando a alteração de agendamentos e etc
                    btSalvar.Enabled = true;
                    btSalvarRegistro.Enabled = true;
                    btExcluirReg.Enabled = true;
                    btExcluirAgend.Enabled = true;
                    btAlterarAgend.Enabled = true;

                    if (btSalvarRegistro.Text.Equals("&Salvar"))
                    {
                        btSalvarRegistro.Text = "&Alterar";
                        btSalvarRegistro.Image = Variaveis.getAlterar();
                    }

                    if (tabControlDet.TabCount < 3)
                    {
                        tabControlDet.TabPages.Add(tabPage6);
                    }
                    #endregion
                    break;
                case "Detalhes":
                    #region Desabilitar botões para salvar/alterar/excluir
                    btSalvar.Enabled = false;
                    btSalvarRegistro.Enabled = false;
                    btExcluirReg.Enabled = false;
                    btExcluirAgend.Enabled = false;
                    btAlterarAgend.Enabled = false;

                    if (btSalvarRegistro.Text.Equals("&Salvar"))
                    {
                        btSalvarRegistro.Text = "&Alterar";
                        btSalvarRegistro.Image = Variaveis.getAlterar();
                    }
                    
                    if (tabControlDet.TabCount < 3)
                    {
                        tabControlDet.TabPages.Add(tabPage6);
                    }
                    #endregion
                    break;
            }
        }

        private void listBoxCrea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxCau.SelectedIndex >= 0 && listBoxCrea.SelectedIndex >= 0)
            {
                listBoxCrea.SelectedIndex = 0;
                listBoxCau.SelectedIndex = -1;
            }

            carregarInfReg(1);
        }

        private void listBoxCau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCau.SelectedIndex >= 0 && listBoxCrea.SelectedIndex >= 0)
            {
                listBoxCrea.SelectedIndex = -1;
                listBoxCau.SelectedIndex = 0;
            }

            carregarInfReg(1);
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}