using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;
using TCC.View.Add;

namespace TCC.View.Listagens_Cadastros
{
    public partial class ListForn : Form
    {
        private FornecedoresDAO fornecedoresDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private EstadosDAO estadosDAO { get; set; }
        private Fornecedores fornecedor;
        private DialogResult resposta;
        private bool existe;

        public ListForn()
        {
            InitializeComponent();
            fornecedoresDAO = new FornecedoresDAO();
            cidadesDAO = new CidadesDAO();
            estadosDAO = new EstadosDAO();
        }

        private void ListForn_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas) - ListForn
            dataGridView.Columns.Add("Id", "Código");
            dataGridView.Columns.Add("Nome", "Nome");
            dataGridView.Columns.Add("Email", "E-mail");
            dataGridView.Columns.Add("Estado.Sigla", "UF");
            dataGridView.Columns.Add("Cidade.Nome", "Cidade");
            dataGridView.Columns.Add("Endereco", "Endereço");
            dataGridView.Columns.Add("Telefone", "Telefone");

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Image = Variaveis.getEmail();
            dataGridView.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.Image = Variaveis.getObs();
            dataGridView.Columns.Add(img2);
            img2.HeaderText = "";
            img2.Name = "img2";
            img2.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView.Columns["Id"].Width = 50;
            dataGridView.Columns["Nome"].Width = 200;
            dataGridView.Columns["Email"].Width = 200;
            dataGridView.Columns["Estado.Sigla"].Width = 35;
            dataGridView.Columns["img"].Width = 35;
            dataGridView.Columns["img2"].Width = 35;
            dataGridView.Columns["Endereco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

            carregarCidades();
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

        private void ListForn_Activated(object sender, EventArgs e)
        {
            carregarForn();
            dataGridView.Focus();
        }

        private void carregarForn()
        {
            #region Carregar fornecedores no dataGridView
            try
            {
                dataGridView.Rows.Clear();

                // preenche as colunas
                foreach (Fornecedores f in fornecedoresDAO.select())
                {
                    Cidades cid = cidadesDAO.selectCidade(f.Cidade.Id);
                    dataGridView.Rows.Add(f.Id, f.Nome, f.Email, cid.Estado.Sigla, f.Cidade.Nome, f.Endereco, f.Telefone);
                }
            }
            catch
            {

            }
            #endregion
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            #region Botão incluir: muda a visibilidade e o nome do groupBox
            limparCampos();
            groupBoxForn.Visible = true;
            textNome.Focus();
            groupBoxForn.Text = "Inclusão de Fornecedor";
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count >= 1)
            {
                #region Botão alterar: muda a visibilidade e o nome do groupBox
                groupBoxForn.Visible = true;
                textNome.Focus();
                groupBoxForn.Text = "Alteração de Fornecedor";
                #endregion

                carregarInfForn();
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Ao dar dois cliques em alguma "cell" do dataGridView, muda a visibilidade e o nome do groupBox (alteração)
            groupBoxForn.Visible = true;
            textNome.Focus();
            groupBoxForn.Text = "Alteração de Fornecedor";
            #endregion

            carregarInfForn();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            #region Carregar dados do fornecedor no groupBox [carregarInfForn()] quando o usuário mudar o fornecedor selecionado
            if (groupBoxForn.Visible == true)
            {
                groupBoxForn.Text = "Alteração de Fornecedor";
                carregarInfForn();
            }
            #endregion
        }

        private void carregarInfForn()
        {
            #region Carregar dados do fornecedor nos itens do groupBox
            try
            {
                Fornecedores f = fornecedoresDAO.select(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
                textNome.Text = f.Nome;
                textNome.Focus();
                textEmail.Text = f.Email;
                maskedDocumento.Text = f.Cnpj;

                Cidades cid = cidadesDAO.selectCidade(f.Cidade.Id);
                comboUF.SelectedValue = cid.Estado.Id;

                comboCidade.SelectedValue = f.Cidade.Id;
                textEndereco.Text = f.Endereco;
                textTel.Text = f.Telefone;
                textTel2.Text = f.Telefone2;
            }
            catch
            {
                
            }
            #endregion
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            excluirForn();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            #region Excluir fornecedor [excluirForn()] ao pressionar a tecla delete, tendo uma linha selecionada
            if (e.KeyCode == Keys.Delete && groupBoxForn.Visible == false)
            {
                excluirForn();
            }
            #endregion
        }

        private void excluirForn()
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 1)
                {
                    #region Verificar se há vários fornecedores selecionados
                    resposta = MessageBox.Show("Excluir TODOS os fornecedores selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            foreach (DataGridViewRow r in dataGridView.SelectedRows)
                            {
                                fornecedoresDAO.delete(Convert.ToInt16(r.Cells["ID"].Value.ToString()));
                            }
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarForn();
                    }
                    #endregion
                }
                else
                {
                    #region Excluir o fornecedor selecionado
                    resposta = MessageBox.Show("Excluir fornecedor '" + dataGridView.CurrentRow.Cells["Nome"].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            fornecedoresDAO.delete(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        carregarForn();
                    }
                    #endregion
                }
            }
            catch
            {
                
            }
        }

        private bool validarDocumento(string documento)
        {
            // Deixar somente os números do documento
            documento = Regex.Replace(documento, @"[^\d]", "");
            #region Verificar se o documento não é uma sequência de números repetidos
            switch (documento)
            {
                case "00000000000000":
                case "11111111111111":
                case "22222222222222":
                case "33333333333333":
                case "44444444444444":
                case "55555555555555":
                case "66666666666666":
                case "77777777777777":
                case "88888888888888":
                case "99999999999999":
                    return false;
            }
            #endregion

            #region Validação de CNPJ
            int primeiroDigitoVerif = 0, segundoDigitoVerif = 0, soma = 0, j = 0;

            for (int i = 5; i >= 2; i--)
            {
                soma += i * Convert.ToInt16(documento[j].ToString());
                j++;
            }

            for (int i = 9; i >= 2; i--)
            {
                soma += i * Convert.ToInt16(documento[j].ToString());
                j++;
            }

            if ((soma % 11) >= 2)
            {
                primeiroDigitoVerif = 11 - (soma % 11);
            }

            if (primeiroDigitoVerif != Convert.ToInt16(documento[documento.Length - 2].ToString()))
            {
                return false;
            }
            else
            {
                j = 0;
                soma = 0;

                for (int i = 6; i >= 2; i--)
                {
                    soma += i * Convert.ToInt16(documento[j].ToString());
                    j++;
                }

                for (int i = 9; i > 2; i--)
                {
                    soma += i * Convert.ToInt16(documento[j].ToString());
                    j++;
                }

                soma += 2 * primeiroDigitoVerif;

                if ((soma % 11) >= 2)
                {
                    segundoDigitoVerif = 11 - (soma % 11);
                }

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

        private void salvarFornecedor()
        {
            #region Validação de campos
            errorProvider.SetError(textNome, string.Empty);
            errorProvider.SetError(textEmail, string.Empty);
            errorProvider.SetError(maskedDocumento, string.Empty);
            errorProvider.SetError(comboUF, string.Empty);
            errorProvider.SetError(comboCidade, string.Empty);
            errorProvider.SetError(textEndereco, string.Empty);

            int verif = 0;

            if (textNome.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textNome, "Digite um nome válido");
                verif++;
            }

            if (!textEmail.Text.Trim().Equals(""))
            {
                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (!rg.IsMatch(textEmail.Text))
                {
                    errorProvider.SetError(textEmail, "Digite um e-mail válido");
                    verif++;
                }
            }

            // Substituir espaços em branco por ""(nada)
            if (Regex.Replace(maskedDocumento.Text, @"\s+", "").Length > 4 && Regex.Replace(maskedDocumento.Text, @"\s+", "").Length <= 17)
            {
                errorProvider.SetError(maskedDocumento, "Informe um CNPJ válido");
                verif++;
            }

            if (maskedDocumento.MaskCompleted == true)
            {
                if (validarDocumento(maskedDocumento.Text) == false)
                {
                    errorProvider.SetError(maskedDocumento, "Informe um CNPJ válido");
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

            if (textEndereco.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textEndereco, "Digite um endereço válido");
                textEndereco.Focus();
                return;
            }

            if(verif > 0)
            {
                return;
            }
            #endregion

            #region Colocar os dados do fornecedor em um objeto
            try
            {
                fornecedor = new Fornecedores();
                fornecedor.Nome = textNome.Text.Trim();
                fornecedor.Endereco = textEndereco.Text.Trim();
                fornecedor.Cidade = cidadesDAO.selectPorEstado(Convert.ToInt16(comboUF.SelectedValue)).Where(x => x.Id == Convert.ToInt16(comboCidade.SelectedValue)).First();
                fornecedor.Email = textEmail.Text.Trim();
                fornecedor.Cnpj = maskedDocumento.Text;

                if (!textTel.Text.Trim().Equals("") && !textTel2.Text.Trim().Equals(""))
                {
                    fornecedor.Telefone = textTel.Text;
                    fornecedor.Telefone2 = textTel2.Text;
                }
                else if (!textTel.Text.Trim().Equals(""))
                {
                    fornecedor.Telefone = textTel.Text;
                }
                else
                {
                    fornecedor.Telefone = textTel2.Text;
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            switch (groupBoxForn.Text)
            {
                case "Inclusão de Fornecedor":
                    #region Inclusão de fornecedor
                    try
                    {
                        fornecedoresDAO.insert(fornecedor);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion
                    break;
                case "Alteração de Fornecedor":
                    #region Alteração dos dados do fornecedor
                    try
                    {
                        fornecedor.Id = Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                        fornecedoresDAO.update(fornecedor);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion
                    break;
            }

            limparCampos();
            carregarForn();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            salvarFornecedor();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

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

        private void ListForn_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    #region ESC: se o groupBox estiver visível chama o método limparCampos(), se não estiver, fecha o form
                    if (groupBoxForn.Visible == true)
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
                    if (groupBoxForn.Visible == true)
                    {
                        if (!comboUF.DroppedDown && !comboCidade.DroppedDown)
                        {
                            if (textNome.Focused == true || textEmail.Focused == true || maskedDocumento.Focused == true
                            || comboUF.Focused == true || comboCidade.Focused == true || textEndereco.Focused == true
                            || textTel.Focused == true || textTel2.Focused == true)
                            {
                                salvarFornecedor();
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
                errorProvider.SetError(maskedDocumento, string.Empty);
                errorProvider.SetError(comboUF, string.Empty);
                errorProvider.SetError(comboCidade, string.Empty);
                errorProvider.SetError(textEndereco, string.Empty);

                textNome.Clear();
                textNome.Focus();
                textEndereco.Clear();
                comboUF.SelectedIndex = 0;
                comboCidade.SelectedIndex = 0;
                maskedDocumento.Clear();
                textTel.Clear();
                textTel2.Clear();
                textEmail.Clear();
                groupBoxForn.Visible = false;
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
                    EnvioDeEmail envioDeEmail = new EnvioDeEmail(dataGridView.CurrentRow.Cells["Email"].Value.ToString());
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
                    AddObservacao addObservacao = new AddObservacao(3, dataGridView.CurrentRow.Cells["ID"].Value.ToString(), dataGridView.CurrentRow.Cells["Nome"].Value.ToString());
                    addObservacao.MdiParent = this.ParentForm;
                    addObservacao.Show();
                }
                #endregion
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}