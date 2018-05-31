using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;
using TCC.View.Add;

namespace TCC.View.Listagens_Cadastros
{
    public partial class ListTrab : Form
    {
        private TrabalhadoresDAO trabalhadoresDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private EstadosDAO estadosDAO { get; set; }
        private Trabalhadores trabalhador;
        private EnvioDeEmail envioDeEmail;
        private AddObservacao addObservacao;
        private DialogResult resposta;
        private Regex rg;
        private DataGridViewImageColumn img, img2;
        private bool existe;
        private int i, j, verif;

        public ListTrab()
        {
            InitializeComponent();
            trabalhadoresDAO = new TrabalhadoresDAO();
            cidadesDAO = new CidadesDAO();
            estadosDAO = new EstadosDAO();
        }

        private void ListTrab_Load(object sender, EventArgs e)
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
            img.Image = MenuPrincipal.imageEmail();
            dataGridView.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            img2 = new DataGridViewImageColumn();
            img2.Image = MenuPrincipal.imageObs();
            dataGridView.Columns.Add(img2);
            img2.HeaderText = "";
            img2.Name = "img2";
            img2.ImageLayout = DataGridViewImageCellLayout.Zoom;

            // Largura das colunas (o default é 100)
            dataGridView.Columns["Id"].Width = 50;
            dataGridView.Columns["Email"].Width = 200;
            dataGridView.Columns["Estado.Sigla"].Width = 35;
            dataGridView.Columns["Servico"].Width = 130;
            dataGridView.Columns["img"].Width = 35;
            dataGridView.Columns["img2"].Width = 35;
            dataGridView.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
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
                //MessageBox.Show(ex.Message);
            }
            #endregion

            #region Carregar cidades [carregarCidades()]
            carregarCidades();
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

        private void ListTrab_Activated(object sender, EventArgs e)
        {
            #region Carregar trabalhadores quando o form for focado [carregarTrabalhadores()]
            carregarTrabalhadores();
            dataGridView.Focus();
            #endregion
        }

        #region Auto Complete + ComboBox
        private void comboServico_DropDown(object sender, EventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões
            // Once the user clicks on the DropDown button PreviewKeyDown event is attached to
            // that ComboBox. When user starts typing, freshly added event is triggered. In that
            // event we check if ComboBox is DroppedDown, if it is, focus that ComboBox. On
            // ComboBox focus DropDown disappeares and that's it.
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboServico_PreviewKeyDown);
            #endregion
        }

        // Código relacionado abaixo

        private void comboServico_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            #region Habilitar auto complete mode e não deixar o dropdown list aparecer junto com a lista de sugestões²
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboServico_PreviewKeyDown;

            if (cbo.DroppedDown)
            {
                cbo.Focus();
            }
            #endregion
        }
        #endregion

        private void carregarTrabalhadores()
        {
            #region Carregar trabalhadores no dataGridView
            try
            {
                // limpa as linhas da grid
                dataGridView.Rows.Clear();

                // preenche as colunas
                foreach (Trabalhadores t in trabalhadoresDAO.select())
                {
                    foreach (Cidades cid in cidadesDAO.selectCidade(t.Cidade.Id))
                    {
                        dataGridView.Rows.Add(t.Id, t.Nome, t.Email, cid.Estado.Sigla, t.Cidade.Nome, t.Servico, t.Telefone);
                    }

                }
            }
            catch
            {

            }
            #endregion

            #region Carregar serviços no comboBox
            try
            {
                comboServico.DataSource = trabalhadoresDAO.select().ToList();
                comboServico.ValueMember = "Servico";
                comboServico.DisplayMember = "Servico";

                // Habilitar o autoComplete
                comboServico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboServico.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            limparCampos();
            groupBoxTrab.Visible = true;
            comboServico.Text = "";
            textNome.Focus();
            groupBoxTrab.Text = "Inclusão de Trabalhador";
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count >= 1)
            {
                #region Botão alterar: muda a visibilidade e o nome do groupBox
                groupBoxTrab.Visible = true;
                textNome.Focus();
                groupBoxTrab.Text = "Alteração de Trabalhador";
                #endregion

                #region Carregar dados do trabalhador no groupBox [carregarInfTrabalhador()]
                carregarInfTrabalhador();
                #endregion
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Ao dar dois cliques em alguma "cell" do dataGridView, muda a visibilidade e o nome do groupBox (alteração)
            if (e.RowIndex >= 0 && e.ColumnIndex <= 6)
            {
                groupBoxTrab.Visible = true;
                textNome.Focus();
                groupBoxTrab.Text = "Alteração de Trabalhador";
                carregarInfTrabalhador();
            }
            #endregion
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            #region Carregar dados do trabalhador no groupBox [carregarInfTrabalhador()] quando o usuário mudar o trabalhador selecionado
            if (groupBoxTrab.Visible == true)
            {
                groupBoxTrab.Text = "Alteração de Trabalhador";
                carregarInfTrabalhador();
            }
            #endregion
        }

        private void carregarInfTrabalhador()
        {
            #region Carregar dados do trabalhador nos itens do groupBox
            try
            {
                foreach (Trabalhadores t in trabalhadoresDAO.select(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString())))
                {
                    textNome.Text = t.Nome;
                    textNome.Focus();
                    textEmail.Text = t.Email;
                    maskedDocumento.Text = t.Cpf;

                    foreach (Cidades cid in cidadesDAO.selectCidade(t.Cidade.Id))
                    {
                        comboUF.SelectedValue = cid.Estado.Id;
                    }

                    comboServico.Text = t.Servico;
                    comboCidade.SelectedValue = t.Cidade.Id;
                    textEndereco.Text = t.Endereco;
                    textTel.Text = t.Telefone;
                    textTel2.Text = t.Telefone2;
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            #region Excluir trabalhador clicando no botão excluir [excluirTrabalhador()]
            excluirTrabalhador();
            #endregion
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            #region Excluir trabalhador [excluirTrabalhador()] ao pressionar a tecla delete, tendo uma linha selecionada
            if (e.KeyCode == Keys.Delete && groupBoxTrab.Visible == false)
            {
                excluirTrabalhador();
            }
            #endregion
        }

        private void excluirTrabalhador()
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 1)
                {
                    #region Verificar se há vários trabalhadores selecionados
                    resposta = MessageBox.Show("Excluir TODOS os trabalhadores selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            foreach (DataGridViewRow r in dataGridView.SelectedRows)
                            {
                                trabalhadoresDAO.delete(Convert.ToInt16(r.Cells["ID"].Value.ToString()));
                            }
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarTrabalhadores();
                    }
                    #endregion
                }
                else
                {
                    #region Excluir o trabalhador selecionado
                    resposta = MessageBox.Show("Excluir trabalhador '" + dataGridView.CurrentRow.Cells["Nome"].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            trabalhadoresDAO.delete(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString())); 
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarTrabalhadores();
                    }
                    #endregion
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private bool validarDocumento(string tipo, string documento)
        {
            // Deixar somente os números do documento
            documento = Regex.Replace(documento, @"[^\d]", "");

            #region Verificar se o documento não é uma sequência de números repetidos
            switch (documento)
            {
                case "00000000000":
                case "11111111111":
                case "22222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999":
                    return false;
            }
            #endregion

            #region Validação de CPF
            int primeiroDigitoVerif, segundoDigitoVerif, soma = 0;
            j = 0;

            for (i = 10; i >= 2; i--)
            {
                soma += i * Convert.ToInt16(documento[j].ToString());
                j++;
            }

            primeiroDigitoVerif = 11 - (soma % 11);

            if (primeiroDigitoVerif == 10 || primeiroDigitoVerif == 11)
            {
                primeiroDigitoVerif = 0;
            }

            if (primeiroDigitoVerif != Convert.ToInt16(documento[documento.Length - 2].ToString()))
            {
                return false;
            }
            else
            {
                j = 0;
                soma = 0;

                for (i = 11; i > 2; i--)
                {
                    soma += i * Convert.ToInt16(documento[j].ToString());
                    j++;
                }

                soma += 2 * primeiroDigitoVerif;
                segundoDigitoVerif = 11 - (soma % 11);

                if (segundoDigitoVerif != Convert.ToInt16(documento[documento.Length - 1].ToString()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            #endregion
        }

        private void salvarTrabalhador()
        {
            #region Validação de campos
            errorProvider.SetError(textNome, string.Empty);
            errorProvider.SetError(textEmail, string.Empty);
            errorProvider.SetError(comboServico, string.Empty);
            errorProvider.SetError(maskedDocumento, string.Empty);
            errorProvider.SetError(comboUF, string.Empty);
            errorProvider.SetError(comboCidade, string.Empty);
            errorProvider.SetError(textTel, string.Empty);

            verif = 0;

            if (textNome.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textNome, "Digite um nome válido");
                verif++;
            }

            if (!textEmail.Text.Trim().Equals(""))
            {
                rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (!rg.IsMatch(textEmail.Text))
                {
                    errorProvider.SetError(textEmail, "Digite um e-mail válido");
                    verif++;
                }
            }

            if (comboServico.Text.Trim().Equals(""))
            {
                errorProvider.SetError(comboServico, "Informe o serviço que o profissional oferece");
                verif++;
            }

            // Substituir espaços em branco por ""(nada)
            if (Regex.Replace(maskedDocumento.Text, @"\s+", "").Length > 3 && Regex.Replace(maskedDocumento.Text, @"\s+", "").Length <= 13)
            {
                errorProvider.SetError(maskedDocumento, "Informe um CPF válido");
                verif++;
            }

            if (maskedDocumento.MaskCompleted == true)
            {
                if (validarDocumento("CPF", maskedDocumento.Text) == false)
                {
                    errorProvider.SetError(maskedDocumento, "Informe um CPF válido");
                    verif++;
                }
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

            if (textTel.Text.Trim().Equals("") && textTel2.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textTel, "Digite um número de telefone válido");
                textTel.Focus();
                return;
            }

            if(verif > 0)
            {
                return;
            }
            #endregion

            #region Colocar os dados do trabalhador em um objeto
            try
            {
                trabalhador = new Trabalhadores();
                trabalhador.Nome = textNome.Text.Trim();
                trabalhador.Servico = comboServico.Text.Trim();
                trabalhador.Cpf = maskedDocumento.Text;
                trabalhador.Endereco = textEndereco.Text.Trim();
                trabalhador.Cidade = cidadesDAO.selectPorEstado(Convert.ToInt16(comboUF.SelectedValue)).Where(x => x.Id == Convert.ToInt16(comboCidade.SelectedValue)).First();
                trabalhador.Email = textEmail.Text.Trim();

                if (!textTel.Text.Trim().Equals("") && !textTel2.Text.Trim().Equals(""))
                {
                    trabalhador.Telefone = textTel.Text;
                    trabalhador.Telefone2 = textTel2.Text;
                }
                else if (!textTel.Text.Trim().Equals(""))
                {
                    trabalhador.Telefone = textTel.Text;
                }
                else
                {
                    trabalhador.Telefone = textTel2.Text;
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            switch (groupBoxTrab.Text)
            {
                case "Inclusão de Trabalhador":
                    #region Inclusão de trabalhador
                    try
                    {
                        trabalhadoresDAO.insert(trabalhador);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion
                    break;
                case "Alteração de Trabalhador":
                    #region Alteração dos dados do trabalhador
                    try
                    {
                        trabalhador.Id = Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                        trabalhadoresDAO.update(trabalhador);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion
                    break;
            }

            limparCampos();
            carregarTrabalhadores();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            #region Botão salvar [salvarTrabalhador()]
            salvarTrabalhador();
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region Botão cancelar [limparCampos()]
            limparCampos();
            #endregion
        }

        private void comboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Carregar cidades [carregarCidades()]
            carregarCidades();
            #endregion
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

        private void ListTrab_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    #region ESC: se o groupBox estiver visível chama o método limparCampos(), se não estiver, fecha o form
                    if (groupBoxTrab.Visible == true)
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
                    #region Caso algum campo do groupBox esteja em foco e o mesmo visível, salva os dados do trabalhador
                    if (groupBoxTrab.Visible == true)
                    {
                        if (!comboUF.DroppedDown && !comboCidade.DroppedDown && !comboServico.DroppedDown)
                        {
                            if (textNome.Focused == true || textEmail.Focused == true || comboServico.Focused == true
                                || maskedDocumento.Focused == true || comboUF.Focused == true || comboCidade.Focused == true
                                || textEndereco.Focused == true || textTel.Focused == true || textTel2.Focused == true)
                            {
                                salvarTrabalhador();
                            }
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
                errorProvider.SetError(textNome, string.Empty);
                errorProvider.SetError(textEmail, string.Empty);
                errorProvider.SetError(comboServico, string.Empty);
                errorProvider.SetError(maskedDocumento, string.Empty);
                errorProvider.SetError(comboUF, string.Empty);
                errorProvider.SetError(comboCidade, string.Empty);
                errorProvider.SetError(textTel, string.Empty);

                textNome.Clear();
                textNome.Focus();
                maskedDocumento.Clear();
                textEndereco.Clear();
                comboUF.SelectedIndex = 0;
                comboCidade.SelectedIndex = 0;
                textTel.Clear();
                textTel2.Clear();
                textEmail.Clear();
                comboServico.Text = "";
                groupBoxTrab.Visible = false;
            }
            catch
            {
                //MessageBox.Show(ex.Message);
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