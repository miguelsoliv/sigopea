using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;
using TCC.View.Add;

namespace TCC.View.Movimentos
{
    public partial class MovObras : Form
    {
        private ModelDB modelDB;
        private ObrasDAO obrasDAO { get; set; }
        private ClientesDAO clientesDAO { get; set; }
        private EstadosDAO estadosDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private StatusDAO statusDAO { get; set; }
        private AgendamentosDAO agendamentosDAO { get; set; }
        private FotosDAO fotosDAO { get; set; }
        private ObrasFornecedoresDAO ofDAO { get; set; }
        private ObrasTrabalhadoresDAO otDAO { get; set; }
        private ResponsavelDAO respDAO { get; set; }
        private Obras obra;
        private Fotos foto;
        private Responsavel resp;
        private DialogResult resposta;
        private IEnumerable<Obras> listaObras;
        private bool existe;
        private string id, path = @"C:\xampp\htdocs\fotos\";
        private int idObra;

        public MovObras()
        {
            InitializeComponent();
            modelDB = new ModelDB();
            obrasDAO = new ObrasDAO();
            clientesDAO = new ClientesDAO();
            estadosDAO = new EstadosDAO();
            cidadesDAO = new CidadesDAO();
            statusDAO = new StatusDAO();
            agendamentosDAO = new AgendamentosDAO();
            fotosDAO = new FotosDAO();
            otDAO = new ObrasTrabalhadoresDAO();
            ofDAO = new ObrasFornecedoresDAO();
            respDAO = new ResponsavelDAO();
        }

        private void MovObras_Load(object sender, EventArgs e)
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
            img.Image = Variaveis.getTrab();
            dataGridView1.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.Image = Variaveis.getForn();
            dataGridView1.Columns.Add(img2);
            img2.HeaderText = "";
            img2.Name = "img2";
            img2.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn img3 = new DataGridViewImageColumn();
            img3.Image = Variaveis.getAgend();
            dataGridView1.Columns.Add(img3);
            img3.HeaderText = "";
            img3.Name = "img3";
            img3.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn img4 = new DataGridViewImageColumn();
            img4.Image = Variaveis.getFoto();
            dataGridView1.Columns.Add(img4);
            img4.HeaderText = "";
            img4.Name = "img4";
            img4.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView1.Columns["Id"].Width = 50;
            dataGridView1.Columns["Cliente.Nome"].Width = 200;
            dataGridView1.Columns["Estado.Sigla"].Width = 35;
            dataGridView1.Columns["PrazoEstipulado"].Width = 70;
            dataGridView1.Columns["img"].Width = 35;
            dataGridView1.Columns["img2"].Width = 35;
            dataGridView1.Columns["img3"].Width = 35;
            dataGridView1.Columns["img4"].Width = 35;
            dataGridView1.Columns["Endereco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            #endregion

            #region Carregar status das obras
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
                cell.ToolTipText = "Adicionar Trabalhadores para a Obra";
            }
            else if (e.ColumnIndex == dataGridView1.Columns["img2"].Index)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Adicionar Fornecedores para a Obra";
            }
            else if (e.ColumnIndex == dataGridView1.Columns["img3"].Index)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Adicionar Agendamento";
            }
            else if (e.ColumnIndex == dataGridView1.Columns["img4"].Index)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Adicionar Foto";
            }
            #endregion
        }

        private void MovObras_Activated(object sender, EventArgs e)
        {
            carregarObras(0);
            carregarClientes();
        }

        private void carregarObras(int tipo)
        {
            #region Carregar obras no dataGridView
            try
            {
                dataGridView1.Rows.Clear();

                switch (tipo)
                {
                    case 0:
                        listaObras = obrasDAO.select();
                        break;
                    case 1:
                    case 2:
                    case 3:
                        listaObras = obrasDAO.select().Where(x => x.Status.Id == tipo);
                        break;
                }

                foreach (Obras o in listaObras)
                {
                    Cidades cid = cidadesDAO.selectCidade(o.Cidade.Id);
                    dataGridView1.Rows.Add(o.Id, o.Cliente.Nome, o.Status.Nome, cid.Estado.Sigla, o.Cidade.Nome, o.Endereco, o.PrazoEstipulado.ToString("dd/MM/yyyy"));
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
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            #region Botão incluir: muda a visibilidade e o nome do groupBox
            tabControlDet.SelectedIndex = 0;
            limparCampos();
            groupBoxObras.Visible = true;
            comboCliente.Focus();
            groupBoxObras.Text = "Inclusão de Obra";
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                #region Botão alterar: muda a visibilidade e o nome do groupBox
                tabControlDet.SelectedIndex = 0;
                groupBoxObras.Visible = true;
                comboCliente.Focus();
                groupBoxObras.Text = "Alteração de Obra";
                #endregion

                carregarInfObra();
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
            #region Ao dar dois cliques em alguma "cell" do dataGridView, muda a visibilidade e o nome do groupBox (detalhes)
            if (e.RowIndex >= 0 && e.ColumnIndex <= 6)
            {
                tabControlDet.SelectedIndex = 0;
                groupBoxObras.Visible = true;
                groupBoxObras.Text = "Detalhes";
                carregarInfObra();
            }
            #endregion
        }

        private void carregarInfAgend(int tipo)
        {
            idObra = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

            switch (tipo)
            {
                case 0:
                    #region Carregar informações dos agendamentos do projeto selecionado
                    listBoxData.Items.Clear();
                    listBoxAgend.Items.Clear();
                    textAgend.Text = "";
                    textAssunto.Text = "";

                    var lista = modelDB.Agendamentos.GroupBy(x => new { x.Data, x.Obra.Id }).Select(x => new { Data = x.Key.Data, Obra = x.Key.Id }).Where(x => x.Obra.ToString() != null && x.Obra == idObra).ToList();

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

                        foreach (Agendamentos agend in agendamentosDAO.select().Where(x => x.Obra != null && x.Obra.Id == idObra && x.Data == Convert.ToDateTime(listBoxData.Text)))
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

        private void carregarInfResp()
        {
            idObra = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

            #region Carregar informações do responsável da obra selecionada
            listBoxResp.Items.Clear();
            textRespEmail.Text = "";
            textRespNome.Text = "";
            textRespTel.Text = "";

            try
            {
                foreach (Obras obra in obrasDAO.select().Where(x => x.Id == idObra))
                {
                    listBoxResp.Items.Add(obra.Responsavel.Nome);
                }

                listBoxResp.SelectedIndex = 0;
            }
            catch
            {

            }
            #endregion

            if (listBoxResp.Items.Count == 0)
            {
                btSalvarResp.Text = "&Salvar";
                btSalvarResp.Image = Variaveis.getSalvar();
            }
            else
            {
                btSalvarResp.Text = "&Alterar";
                btSalvarResp.Image = Variaveis.getAlterar();
            }
        }

        private void carregarInfFoto()
        {
            idObra = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

            #region Carregar informações das fotos da obra selecionada
            listBoxFoto.Items.Clear();
            textDesc.Text = "";
            pictureBoxFoto.Image = null;

            var lista = fotosDAO.select().Where(x => x.Obra.Id == idObra);

            foreach (var agend in lista)
            {
                listBoxFoto.Items.Add(agend.Id);
            }
            #endregion
        }

        private void carregarInfPessoas()
        {
            idObra = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

            #region Carregar informações dos fornecedores e trabalhadores relacionados com a obra selecionada
            listBoxForn.Items.Clear();
            listBoxTrab.Items.Clear();
            listBoxIdForn.Items.Clear();
            listBoxIdTrab.Items.Clear();
            textObs.Text = "";

            var lista = otDAO.select().Where(x => x.Obra.Id == idObra).OrderBy(x => x.Trabalhador.Nome);
            var lista2 = ofDAO.select().Where(x => x.Obra.Id == idObra).OrderBy(x => x.Fornecedor.Nome);

            foreach (var ot in lista)
            {
                listBoxTrab.Items.Add(ot.Trabalhador.Nome);
                listBoxIdTrab.Items.Add(ot.Trabalhador.Id);
            }

            foreach (var of in lista2)
            {
                listBoxForn.Items.Add(of.Fornecedor.Nome);
                listBoxIdForn.Items.Add(of.Fornecedor.Id);
            }
            #endregion
        }

        private void tabControlDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            limparErros();

            if (!groupBoxObras.Text.Equals("Inclusão de Obra"))
            {
                switch (tabControlDet.SelectedIndex)
                {
                    case 0:
                        carregarInfObra();
                        break;
                    case 1:
                        carregarInfAgend(0);
                        break;
                    case 2:
                        carregarInfPessoas();
                        break;
                    case 3:
                        carregarInfFoto();
                        break;
                    case 4:
                        carregarInfResp();
                        break;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (groupBoxObras.Visible == true)
            {
                limparErros();

                if (!groupBoxObras.Text.Equals("Inclusão de Obra"))
                {
                    switch (tabControlDet.SelectedIndex)
                    {
                        case 0:
                            carregarInfObra();
                            break;
                        case 1:
                            carregarInfAgend(0);
                            break;
                        case 2:
                            carregarInfPessoas();
                            break;
                        case 3:
                            carregarInfFoto();
                            break;
                        case 4:
                            carregarInfResp();
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

        private void listBoxFoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Carregar texto e imagem da foto selecionada no textBox
            try
            {
                foreach (Fotos foto in fotosDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxFoto.Text)))
                {
                    textDesc.Text = foto.Descricao;
                    pictureBoxFoto.Load(path + foto.Id + "." + foto.Tipo);
                }
            }
            catch
            {

            }
            #endregion
        }

        private void carregarInfObra()
        {
            #region Carregar dados da obra nos itens do groupBox
            try
            {
                Obras o = obrasDAO.select(Convert.ToInt16(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
                comboCliente.Focus();

                Cidades cid = cidadesDAO.selectCidade(o.Cidade.Id);
                comboUF.SelectedValue = cid.Estado.Id;

                comboCliente.SelectedValue = o.Cliente.Id;
                comboStatus.SelectedValue = o.Status.Id;
                comboCidade.SelectedValue = o.Cidade.Id;
                textEndereco.Text = o.Endereco;
                textPreco.Text = "" + o.Preco;
                dateTimeInicio.Value = Convert.ToDateTime(o.DataInicio);
                dateTimeEntrega.Value = Convert.ToDateTime(o.PrazoEstipulado);
            }
            catch
            {
                
            }
            #endregion
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            excluirObra();
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
                MessageBox.Show("Selecione uma observação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void excluirPessoa()
        {
            #region Exclusão de pessoa relacionada com a obra (trabalhador/fornecedor)
            if (listBoxForn.SelectedIndex >= 0 || listBoxTrab.SelectedIndex >= 0)
            {
                if(listBoxForn.SelectedIndex >= 0 && listBoxTrab.SelectedIndex >= 0)
                {
                    resposta = MessageBox.Show("Excluir o trabalhador e fornecedor selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                }
                else if(listBoxForn.SelectedIndex >= 0)
                {
                    resposta = MessageBox.Show("Excluir o fornecedor selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                }
                else if(listBoxTrab.SelectedIndex >= 0)
                {
                    resposta = MessageBox.Show("Excluir o trabalhador selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                }
                
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        idObra = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                        if (listBoxTrab.SelectedIndex >= 0)
                        {
                            otDAO.delete(Convert.ToInt16(listBoxIdTrab.Text), idObra);
                        }

                        if (listBoxForn.SelectedIndex >= 0)
                        {
                            ofDAO.delete(Convert.ToInt16(listBoxIdForn.Text), idObra);
                        }
                    }
                    catch
                    {

                    }

                    carregarInfPessoas();
                }
            }
            else
            {
                MessageBox.Show("Selecione um trabalhador ou fornecedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void btExcluirPessoa_Click(object sender, EventArgs e)
        {
            excluirPessoa();
        }

        private void btAlterarOF_Click(object sender, EventArgs e)
        {
            #region Botão alterar observação do fornecedor
            if (listBoxForn.SelectedIndex >= 0)
            {
                try
                {
                    ObrasFornecedores of = new ObrasFornecedores();
                    of = ofDAO.select().Where(x => x.Fornecedor.Id == Convert.ToInt16(listBoxIdForn.Text) && x.Obra.Id == Convert.ToInt16(idObra)).First();
                    of.Observacao = textObs.Text.Trim();
                    ofDAO.update(of);

                    listBoxForn.SelectedIndex = -1;
                    textObs.Text = "";
                }
                catch
                {

                }
            }
            #endregion
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && groupBoxObras.Visible == false)
            {
                excluirObra();
            }
        }

        private void excluirObra()
        {
            if (dataGridView1.RowCount >= 1)
            {
                if (dataGridView1.SelectedRows.Count > 1)
                {
                    #region Verificar se há várias obras selecionadas
                    resposta = MessageBox.Show("Excluir TODAS as obras selecionadas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            {
                                obrasDAO.delete(Convert.ToInt16(r.Cells["ID"].Value.ToString()));
                            } 
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarObras(0);
                    }
                    #endregion
                }
                else
                {
                    #region Excluir a obra selecionada
                    resposta = MessageBox.Show("Excluir obra selecionada?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            obrasDAO.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarObras(0);
                    }
                    #endregion
                }
            }
        }
        
        private void salvarObra(int tipo)
        {
            #region Validação de campos
            limparErros();
            int verif = 0;

            if (comboCliente.SelectedIndex == -1)
            {
                errorProvider.SetError(comboCliente, "Selecione um cliente");
                verif++;
            }

            if (comboStatus.SelectedIndex == -1)
            {
                errorProvider.SetError(comboStatus, "Selecione um status para a obra");
                verif++;
            }

            if (textEndereco.Text.Trim().Length <= 10)
            {
                errorProvider.SetError(textEndereco, "Informe um endereço válido para a obra");
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

                if (preco < 30)
                {
                    errorProvider.SetError(textPreco, "Informe um valor válido");
                    textPreco.Focus();
                    return;
                }
            }
            catch
            {
                errorProvider.SetError(textPreco, "Informe o valor cobrado(R$) para realização da obra");
                textPreco.Focus();
                return;
            }

            if(verif > 0)
            {
                return;
            }
            #endregion

            #region Colocar os dados da obra em um objeto
            try
            {
                obra = new Obras();
                obra.Cliente = clientesDAO.select(Convert.ToInt16(comboCliente.SelectedValue));
                obra.Status = statusDAO.select().Where(x => x.Id == Convert.ToInt16(comboStatus.SelectedValue)).First();
                obra.Endereco = textEndereco.Text.Trim();
                obra.Cidade = cidadesDAO.selectPorEstado(Convert.ToInt16(comboUF.SelectedValue)).Where(x => x.Id == Convert.ToInt16(comboCidade.SelectedValue)).First();
                obra.Preco = Convert.ToDecimal(textPreco.Text.Trim());
                obra.DataInicio = Convert.ToDateTime(dateTimeInicio.Value.ToString("dd/MM/yyyy"));
                obra.PrazoEstipulado = Convert.ToDateTime(dateTimeEntrega.Value.ToString("dd/MM/yyyy"));
            }
            catch
            {

            }
            #endregion

            if (tipo == 1)
            {
                try
                {
                    obra.Responsavel = respDAO.select().Last();
                }
                catch
                {
                    
                }
            }

            switch (groupBoxObras.Text)
            {
                case "Inclusão de Obra":
                    #region Inclusão de obra
                    try
                    {
                        obrasDAO.insert(obra);
                    }
                    catch
                    {
                        
                    }
                    #endregion
                    break;
                case "Alteração de Obra":
                    #region Alteração dos dados da obra
                    try
                    {
                        obra.Id = Convert.ToInt16(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                        obrasDAO.update(obra);
                    }
                    catch
                    {

                    }
                    #endregion
                    break;
            }

            limparCampos();
            carregarObras(0);
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
            errorProvider.SetError(textDesc, string.Empty);
            #endregion
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            #region Botão salvar obra
            if (tabControlDet.TabCount <= 2)
            {
                resposta = MessageBox.Show("Cadastrar um responsável pela obra?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        btSalvar.Enabled = false;
                        btCancelar.Enabled = false;
                        comboCliente.Enabled = false;
                        comboStatus.Enabled = false;
                        textEndereco.Enabled = false;
                        comboUF.Enabled = false;
                        comboCidade.Enabled = false;
                        textPreco.Enabled = false;
                        dateTimeInicio.Enabled = false;
                        dateTimeEntrega.Enabled = false;
                        tabControlDet.SelectedIndex = 1;
                    }
                    catch
                    {

                    }
                }
                else
                {
                    salvarObra(0);
                }
            }
            else
            {
                salvarObra(0);
            }
            #endregion
        }

        #region Botões fechar e cancelar
        private void btCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btFechar2_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btFechar3_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btFechar4_Click(object sender, EventArgs e)
        {
            #region Botão fechar_4
            if (!btSalvar.Enabled && groupBoxObras.Text.Equals("Inclusão de Obra"))
            {
                resposta = MessageBox.Show("Cancelar cadastro de responsável pela obra?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        salvarObra(0);
                        limparCampos();
                        carregarObras(0);
                    }
                    catch
                    {
                        
                    }
                }
                else
                {
                    return;
                }
            }

            limparCampos();
            #endregion
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

        private void MovObras_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    #region ESC: se o groupBox estiver visível chama o método limparCampos(), se não estiver, fecha o form
                    if (groupBoxObras.Visible == true)
                    {
                        limparCampos();
                    }
                    else
                    {
                        this.Close();
                    }
                    #endregion
                    break;
                case Keys.Enter:
                    #region Caso algum campo do groupBox esteja em foco e o mesmo visível, salva os dados da obra/agendamento
                    if (groupBoxObras.Visible == true && !groupBoxObras.Text.Equals("Detalhes"))
                    {
                        if (!comboCliente.DroppedDown && !comboStatus.DroppedDown && !comboUF.DroppedDown &&
                            !comboCidade.DroppedDown)
                        {
                            if (comboCliente.Focused == true || comboStatus.Focused == true || textPreco.Focused == true
                            || comboUF.Focused == true || comboCidade.Focused == true || textEndereco.Focused == true
                            || dateTimeInicio.Focused == true || dateTimeEntrega.Focused == true)
                            {
                                salvarObra(0);
                            }
                            else if (textAssunto.Focused == true)
                            {
                                salvarAgend();
                            }
                        }
                    }
                    #endregion
                    break;
                case Keys.Delete:
                    #region Excluir observação/fornecedor/trabalhador/foto selecionada ao apertar a tecla Delete
                    if (groupBoxObras.Visible == true && !groupBoxObras.Text.Equals("Detalhes"))
                    {
                        if (listBoxAgend.SelectedIndex != -1 && listBoxAgend.Focused == true)
                        {
                            excluirAgend();
                        }
                        else if (listBoxForn.SelectedIndex != -1 && listBoxForn.Focused == true || listBoxTrab.SelectedIndex != -1 && listBoxTrab.Focused == true)
                        {
                            excluirPessoa();
                        }
                        else if (listBoxFoto.SelectedIndex != -1 && listBoxFoto.Focused == true)
                        {
                            excluirFoto();
                        }
                    }
                    #endregion
                    break;
            }
        }

        private void limparCampos()
        {
            #region Limpar campos do groupBox
            limparErros();

            try
            {
                if(btSalvar.Enabled == false)
                {
                    btSalvar.Enabled = true;
                    comboCliente.Enabled = true;
                    comboStatus.Enabled = true;
                    textEndereco.Enabled = true;
                    comboUF.Enabled = true;
                    comboCidade.Enabled = true;
                    textPreco.Enabled = true;
                    dateTimeEntrega.Enabled = true;
                    dateTimeInicio.Enabled = true;
                }

                if (comboCliente.Items.Count >= 1)
                {
                    comboCliente.SelectedIndex = 0;
                }

                btCancelar.Enabled = true;
                textRespEmail.Clear();
                textRespNome.Clear();
                textRespTel.Clear();
                comboCliente.Focus();
                comboStatus.SelectedIndex = 0;
                textPreco.Clear();
                comboUF.SelectedIndex = 0;
                comboCidade.SelectedIndex = 0;
                textEndereco.Clear();
                textPreco.Clear();
                dateTimeInicio.Value = DateTime.Today;
                dateTimeEntrega.Value = DateTime.Today;
                groupBoxObras.Visible = false;
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
                #region Abrir form para adicionar trabalhadores
                existe = false;
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is AddTrab)
                    {
                        openForm.BringToFront();
                        existe = true;
                    }
                }
                if (!existe)
                {
                    AddTrab addTrab = new AddTrab(id);
                    addTrab.MdiParent = this.ParentForm;
                    addTrab.Show();
                }
                #endregion
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 8)
            {
                #region Abrir form para adicionar fornecedores
                existe = false;
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is AddForn)
                    {
                        openForm.BringToFront();
                        existe = true;
                    }
                }
                if (!existe)
                {
                    AddForn addForn = new AddForn(id);
                    addForn.MdiParent = this.ParentForm;
                    addForn.Show();
                }
                #endregion
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 9)
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
                    AddAgendamento addAgendamento = new AddAgendamento(2, id);
                    addAgendamento.MdiParent = this.ParentForm;
                    addAgendamento.Show();
                }
                #endregion
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 10)
            {
                #region Abrir form para adicionar fotos
                existe = false;
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is AddFoto)
                    {
                        openForm.BringToFront();
                        existe = true;
                    }
                }
                if (!existe)
                {
                    AddFoto addFoto = new AddFoto(id);
                    addFoto.MdiParent = this.ParentForm;
                    addFoto.Show();
                }
                #endregion
            }
        }

        private void dateTimeInicio_ValueChanged(object sender, EventArgs e)
        {
            #region +1 no dia da entrega sempre que o usuário mudar a data do início da obra (se início >= entrega)
            if (dateTimeInicio.Value >= dateTimeEntrega.Value)
            {
                dateTimeEntrega.Value = dateTimeInicio.Value.AddDays(1);
            }
            #endregion
        }

        private void dateTimeEntrega_ValueChanged(object sender, EventArgs e)
        {
            #region -1 no dia do início sempre que o usuário mudar a data de entrega da obra (se início >= entrega)
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

        private void btAlterarFoto_Click(object sender, EventArgs e)
        {
            if (listBoxFoto.SelectedIndex >= 0)
            {
                #region Validação de dados
                errorProvider.SetError(textDesc, string.Empty);

                if (textDesc.Text.Trim().Equals(""))
                {
                    errorProvider.SetError(textDesc, "Informe uma descrição para a foto");
                    return;
                }
                #endregion

                #region Botão alterar descrição: alterar a descrição da foto selecionada
                try
                {
                    foto = new Fotos();
                    foto.Id = Convert.ToInt16(listBoxFoto.Text);
                    foto.Descricao = textDesc.Text.Trim();
                    fotosDAO.update(foto);
                }
                catch
                {

                }

                listBoxFoto.SelectedIndex = -1;
                pictureBoxFoto.Image = null;
                textDesc.Text = "";
                #endregion

                // GET:
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create
                        ("http://localhost/fotos/wsAndroid/updateFotos.php?id=" + foto.Id + "&desc=" + foto.Descricao);
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
                catch
                {
                    
                }
            }
        }

        private void excluirFoto()
        {
            if (listBoxFoto.SelectedIndex >= 0)
            {
                resposta = MessageBox.Show("Excluir a foto selecionada?", "Atenção", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    foto = fotosDAO.select().Where(x => x.Id == Convert.ToInt16(listBoxFoto.Text)).First();

                    // GET:
                    try
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create
                            ("http://localhost/fotos/wsAndroid/removeFotos.php?id=" + foto.Id);
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                        }
                    }
                    catch
                    {
                        
                    }

                    #region Excluir foto
                    try
                    {
                        fotosDAO.delete(foto.Id);
                        textDesc.Text = "";
                        listBoxFoto.SelectedIndex = -1;
                        pictureBoxFoto.Image = null;
                    }
                    catch
                    {

                    }

                    carregarInfFoto();
                    #endregion
                }
            }
        }

        private void salvarResp()
        {
            switch (btSalvarResp.Text)
            {
                case "&Salvar":
                    #region Cadastro de responsável
                    if (btSalvar.Enabled)
                    {
                        MessageBox.Show("Cadastre as informações da obra antes", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControlDet.SelectedIndex = 0;
                        return;
                    }

                    try
                    {
                        resp = new Responsavel();
                        resp.Email = textRespEmail.Text.Trim();
                        resp.Nome = textRespNome.Text.Trim();
                        resp.Telefone = textRespTel.Text.Trim();
                        respDAO.insert(resp);
                        salvarObra(1);
                        carregarObras(0);
                    }
                    catch
                    {
                        
                    }
                    #endregion
                    break;
                case "&Alterar":
                    #region Alteração de responsável
                    try
                    {
                        id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                        obra = obrasDAO.select().Where(x => x.Id == Convert.ToInt16(id)).First();

                        resp = new Responsavel();
                        resp.Id = Convert.ToInt16(obra.Responsavel.Id);
                        resp.Nome = textRespNome.Text.Trim();
                        resp.Email = textRespEmail.Text.Trim();
                        resp.Telefone = textRespTel.Text.Trim();
                        respDAO.update(resp);

                        carregarInfResp();
                    }
                    catch
                    {

                    }
                    #endregion
                    break;
            }
        }

        private void btSalvarResp_Click(object sender, EventArgs e)
        {
            salvarResp();
        }

        private void btExcluirFoto_Click(object sender, EventArgs e)
        {
            excluirFoto();
        }

        private void btLimparOFOT_Click(object sender, EventArgs e)
        {
            #region Limpar seleção dos listBox dos trabalhadores e fornecedores
            listBoxForn.SelectedIndex = -1;
            listBoxTrab.SelectedIndex = -1;
            #endregion
        }

        private void listBoxForn_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Carregar texto da observação selecionada do fornecedor no textBox
            listBoxIdForn.SelectedIndex = listBoxForn.SelectedIndex;

            try
            {
                foreach (ObrasFornecedores of in ofDAO.select().Where(x => x.Fornecedor.Id == Convert.ToInt16(listBoxIdForn.Text)))
                {
                    textObs.Text = of.Observacao;
                }
            }
            catch
            {

            }
            #endregion
        }

        private void listBoxTrab_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxIdTrab.SelectedIndex = listBoxTrab.SelectedIndex;
        }

        private void listBoxResp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                foreach (Obras obra in obrasDAO.select().Where(x => x.Id == Convert.ToInt16(id)))
                {
                    resp = respDAO.select().Where(x => x.Id == obra.Responsavel.Id).First();
                    textRespEmail.Text = resp.Email;
                    textRespNome.Text = resp.Nome;
                    textRespTel.Text = resp.Telefone;
                }
            }
            catch
            {

            }
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            if(pictureBoxFoto.Image != null)
            {
                pictureZoom.BringToFront();
                pictureZoom.Image = pictureBoxFoto.Image;
                groupBoxObras.Visible = false;
            }
        }

        private void pictureZoom_Click(object sender, EventArgs e)
        {
            if (pictureZoom.Image != null)
            {
                pictureZoom.SendToBack();
                pictureZoom.Image = null;
                groupBoxObras.Visible = true;
            }
        }

        #region Ao mudar algum radio button selecionado, realizar um filtro
        private void radioTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTodas.Checked == true)
            {
                carregarObras(0);
            }
        }

        private void radioEmAnd_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEmAnd.Checked == true)
            {
                carregarObras(1);
            }
        }

        private void radioParadas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioParadas.Checked == true)
            {
                carregarObras(2);
            }
        }

        private void radioFinalizadas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFinalizadas.Checked == true)
            {
                carregarObras(3);
            }
        }
        #endregion

        private void groupBoxObras_TextChanged(object sender, EventArgs e)
        {
            switch (groupBoxObras.Text)
            {
                case "Inclusão de Obra":
                    #region Deixar visível somente as informações pertinentes a inclusão dos dados iniciais da obra
                    btSalvar.Enabled = true;
                    btSalvarResp.Enabled = true;
                    btExcluirResp.Enabled = true;
                    btSalvarResp.Text = "&Salvar";
                    btSalvarResp.Image = Variaveis.getSalvar();
                    tabControlDet.TabPages.Remove(tabPage5);
                    tabControlDet.TabPages.Remove(tabPage6);
                    tabControlDet.TabPages.Remove(tabPage7);
                    #endregion
                    break;
                case "Alteração de Obra":
                    #region Adicionar páginas removidas na hora de incluir uma obra, possibilitando a alteração de agendamentos e etc
                    btSalvar.Enabled = true;
                    btExcluirAgend.Enabled = true;
                    btAlterarAgend.Enabled = true;
                    btExcluirPessoa.Enabled = true;
                    btAlterarOF.Enabled = true;
                    btExcluirFoto.Enabled = true;
                    btAlterarFoto.Enabled = true;
                    btSalvarResp.Enabled = true;
                    btExcluirResp.Enabled = true;
                    btSalvarResp.Text = "&Alterar";
                    btSalvarResp.Image = Variaveis.getAlterar();

                    if (tabControlDet.TabCount < 4) 
                    {
                        tabControlDet.TabPages.Remove(tabPage8);
                        tabControlDet.TabPages.Add(tabPage5);
                        tabControlDet.TabPages.Add(tabPage6);
                        tabControlDet.TabPages.Add(tabPage7);
                        tabControlDet.TabPages.Add(tabPage8);
                    }
                    #endregion
                    break;
                case "Detalhes":
                    #region Desabilitar botões para salvar/alterar/excluir e adicionar páginas excluídas (se necessário)
                    btSalvar.Enabled = false;
                    btExcluirAgend.Enabled = false;
                    btAlterarAgend.Enabled = false;
                    btExcluirPessoa.Enabled = false;
                    btAlterarOF.Enabled = false;
                    btExcluirFoto.Enabled = false;
                    btAlterarFoto.Enabled = false;
                    btSalvarResp.Enabled = false;
                    btExcluirResp.Enabled = false;

                    if (tabControlDet.TabCount < 4)
                    {
                        tabControlDet.TabPages.Remove(tabPage8);
                        tabControlDet.TabPages.Add(tabPage5);
                        tabControlDet.TabPages.Add(tabPage6);
                        tabControlDet.TabPages.Add(tabPage7);
                        tabControlDet.TabPages.Add(tabPage8);
                    }
                    #endregion
                    break;
            }
        }

        private void btDetalhes_Click(object sender, EventArgs e)
        {
            #region Botão detalhes: muda a visibilidade e o nome do groupBox
            tabControlDet.SelectedIndex = 0;
            groupBoxObras.Visible = true;
            groupBoxObras.Text = "Detalhes";
            #endregion

            carregarInfObra();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}