using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TCC.Model;
using TCC.Model.Classes;
using TCC.Model.DAO;
using TCC.View.Add;

namespace TCC.View.Listagens_Cadastros
{
    public partial class ListClientes : Form
    {
        private ClientesDAO clientesDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private EstadosDAO estadosDAO { get; set; }
        private Clientes cliente;
        private DialogResult resposta;
        private bool existe;
        private string cpf, cnpj;   

        public ListClientes()
        {
            InitializeComponent();
            clientesDAO = new ClientesDAO();
            cidadesDAO = new CidadesDAO();
            estadosDAO = new EstadosDAO();
        }

        private void ListClientes_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas)
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

        private void ListClientes_Activated(object sender, EventArgs e)
        {
            carregarClientes();
            dataGridView.Focus();
        }

        private void carregarClientes()
        {
            #region Carregar clientes no dataGridView
            try
            {
                dataGridView.Rows.Clear();

                // preenche as colunas
                foreach (Clientes c in clientesDAO.select())
                {
                    Cidades cid = cidadesDAO.selectCidade(c.Cidade.Id);
                    dataGridView.Rows.Add(c.Id, c.Nome, c.Email, cid.Estado.Sigla, c.Cidade.Nome, c.Endereco, c.Telefone);
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
            groupBoxClientes.Visible = true;
            textNome.Focus();
            groupBoxClientes.Text = "Inclusão de Cliente";
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count >= 1)
            {
                #region Botão alterar: muda a visibilidade e o nome do groupBox
                groupBoxClientes.Visible = true;
                textNome.Focus();
                groupBoxClientes.Text = "Alteração de Cliente";
                #endregion

                carregarInfCliente();
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Ao dar dois cliques em alguma "cell" do dataGridView, muda a visibilidade e o nome do groupBox (alteração)
            if (e.RowIndex >= 0 && e.ColumnIndex <= 6)
            {
                groupBoxClientes.Visible = true;
                textNome.Focus();
                groupBoxClientes.Text = "Alteração de Cliente";
                carregarInfCliente();
            }
            #endregion
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            #region Carregar dados do cliente no groupBox [carregarInfCliente()] quando o usuário mudar o cliente selecionado
            if (groupBoxClientes.Visible == true)
            {
                groupBoxClientes.Text = "Alteração de Cliente";
                carregarInfCliente();
            }
            #endregion
        }

        private void carregarInfCliente()
        {
            #region Carregar dados do cliente nos itens do groupBox
            try
            {
                Clientes c = clientesDAO.select(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
                textNome.Text = c.Nome;
                textNome.Focus();
                textEmail.Text = c.Email;

                if (c.Cpf == null)
                {
                    checkEmpresa.Checked = true;
                    maskedDocumento.Text = c.Cnpj;
                }
                else
                {
                    checkEmpresa.Checked = false;
                    maskedDocumento.Text = c.Cpf;
                }

                Cidades cid = cidadesDAO.selectCidade(c.Cidade.Id);
                comboUF.SelectedValue = cid.Estado.Id;

                comboCidade.SelectedValue = c.Cidade.Id;
                textEndereco.Text = c.Endereco;
                textTel.Text = c.Telefone;
                textTel2.Text = c.Telefone2;
            }
            catch
            {

            }
            #endregion
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            excluirCliente();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            #region Excluir cliente [excluirCliente()] ao pressionar a tecla delete, tendo uma linha selecionada
            if (e.KeyCode == Keys.Delete && groupBoxClientes.Visible == false)
            {
                excluirCliente();
            }
            #endregion
        }

        private void excluirCliente()
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 1)
                {
                    #region Verificar se há vários clientes selecionados
                    resposta = MessageBox.Show("Excluir TODOS os clientes selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            foreach (DataGridViewRow r in dataGridView.SelectedRows)
                            {
                                clientesDAO.delete(Convert.ToInt16(r.Cells["ID"].Value.ToString()));
                            }

                            carregarClientes();
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Excluir o cliente selecionado
                    resposta = MessageBox.Show("Excluir cliente '" + dataGridView.CurrentRow.Cells["Nome"].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            clientesDAO.delete(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
                            carregarClientes();
                        }
                        catch
                        {
                            //MessageBox.Show(ex.Message);
                        }
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

            if (tipo.Equals("CPF"))
            {
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
                int primeiroDigitoVerif, segundoDigitoVerif, soma = 0, j = 0;

                for (int i = 10; i >= 2; i--)
                {
                    soma += i * Convert.ToInt16(documento[j].ToString());
                    j++;
                }
                   
                primeiroDigitoVerif = 11 - (soma % 11);

                if (primeiroDigitoVerif == 10 || primeiroDigitoVerif == 11)
                {
                    primeiroDigitoVerif = 0;
                }

                if (primeiroDigitoVerif != Convert.ToInt16(documento[documento.Length-2].ToString()))
                {
                    return false;
                }
                else
                {
                    j = 0;
                    soma = 0;

                    for (int i = 11; i > 2; i--)
                    {
                        soma += i * Convert.ToInt16(documento[j].ToString());
                        j++;
                    }

                    soma += 2 * primeiroDigitoVerif;
                    segundoDigitoVerif = 11 - (soma % 11);

                    if (segundoDigitoVerif != Convert.ToInt16(documento[documento.Length-1].ToString()))
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
            else
            {
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

                if (primeiroDigitoVerif != Convert.ToInt16(documento[documento.Length-2].ToString()))
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

                    if (segundoDigitoVerif != Convert.ToInt16(documento[documento.Length-1].ToString()))
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
        }

        private void salvarCliente()
        {
            #region Validação de campos
            errorProvider.SetError(textNome, string.Empty);
            errorProvider.SetError(textEmail, string.Empty);
            errorProvider.SetError(maskedDocumento, string.Empty);
            errorProvider.SetError(comboUF, string.Empty);
            errorProvider.SetError(comboCidade, string.Empty);

            int verif = 0;

            if (textNome.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textNome, "Digite um nome válido");
                verif++;
            }

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(textEmail.Text))
            {
                errorProvider.SetError(textEmail, "Digite um e-mail válido");
                verif++;
            }

            if (checkEmpresa.Checked)
            {
                if (maskedDocumento.MaskCompleted == true)
                {
                    if (validarDocumento("CNPJ", maskedDocumento.Text) == false)
                    {
                        errorProvider.SetError(maskedDocumento, "Informe um CNPJ válido");
                        verif++;
                    }
                }
                else
                {
                    errorProvider.SetError(maskedDocumento, "Informe um CNPJ");
                    verif++;
                }
            }
            else
            {
                if (maskedDocumento.MaskCompleted == true)
                {
                    if (validarDocumento("CPF", maskedDocumento.Text) == false)
                    {
                        errorProvider.SetError(maskedDocumento, "Informe um CPF válido");
                        verif++;
                    }
                }
                else
                {
                    errorProvider.SetError(maskedDocumento, "Informe um CPF");
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
                return;
            }

            if(verif > 0)
            {
                return;
            }
            #endregion

            #region Colocar os dados do cliente em um objeto
            try
            {
                cliente = new Clientes();
                cliente.Nome = textNome.Text.Trim();
                maskedDocumento.Mask = null;
                cliente.Senha = Variaveis.gerarHashMD5(maskedDocumento.Text);

                if (checkEmpresa.Checked)
                {
                    maskedDocumento.Mask = "00,000,000/0000-00";
                    cliente.Cnpj = maskedDocumento.Text;
                }
                else
                {
                    maskedDocumento.Mask = "000,000,000-00";
                    cliente.Cpf = maskedDocumento.Text;
                }

                cliente.Endereco = textEndereco.Text.Trim();
                cliente.Cidade = cidadesDAO.selectPorEstado(Convert.ToInt16(comboUF.SelectedValue)).Where(x => x.Id == Convert.ToInt16(comboCidade.SelectedValue)).First();
                cliente.Email = textEmail.Text.Trim();
                cliente.Excluido = false;

                if (!textTel.Text.Trim().Equals("") && !textTel2.Text.Trim().Equals(""))
                {
                    cliente.Telefone = textTel.Text;
                    cliente.Telefone2 = textTel2.Text;
                }
                else if (!textTel.Text.Trim().Equals(""))
                {
                    cliente.Telefone = textTel.Text;
                }
                else
                {
                    cliente.Telefone = textTel2.Text;
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            switch (groupBoxClientes.Text)
            {
                case "Inclusão de Cliente":
                    #region Inclusão de cliente
                    try
                    {
                        clientesDAO.insert(cliente);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion

                    // GET:
                    try
                    {
                        cliente = clientesDAO.select().Last();
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create
                            ("http://localhost/fotos/wsAndroid/insertClientes.php?email=" + cliente.Email + "&senha=" + cliente.Senha);
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                        }
                    }
                    catch
                    {
                        
                    }
                    break;
                case "Alteração de Cliente":
                    #region Alteração dos dados do cliente
                    try
                    {
                        cliente.Id = Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                        clientesDAO.update(cliente);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion
                    break;
            }

            limparCampos();
            carregarClientes();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            salvarCliente();
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

        private void checkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            #region Mudar formato do documento(CPF ou CNPJ) [mudarFormato()]
            if (checkEmpresa.Checked)
            {
                mudarFormato("CNPJ");
            }
            else
            {
                mudarFormato("CPF");
            }
            #endregion
        }

        private void mudarFormato(string tipo)
        {
            #region Mudar o nome do label, a máscara do documento e sua localização
            if (checkEmpresa.Checked)
            {
                // Antes de mudar o formato do documento, deixa armazenado o texto do documento antigo(nesse caso: CPF)
                cpf = maskedDocumento.Text;
                label2.Text = "CNPJ";
                maskedDocumento.Mask = "00,000,000/0000-00";
                maskedDocumento.Location = new Point(157, 79);
                maskedDocumento.Text = cnpj;
                maskedDocumento.Size = new Size(126, 20);
                label10.Location = new Point(289, 82);
            }
            else
            {
                // Antes de mudar o formato do documento, deixa armazenado o texto do documento antigo(nesse caso: CNPJ)
                cnpj = maskedDocumento.Text;
                label2.Text = "CPF";
                maskedDocumento.Mask = "000,000,000-00";
                maskedDocumento.Location = new Point(150, 79);
                maskedDocumento.Text = cpf;
                maskedDocumento.Size = new Size(100, 20);
                label10.Location = new Point(256, 82);
            }

            maskedDocumento.Focus();
            #endregion
        }

        private void ListClientes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    #region ESC: se o groupBox estiver visível chama o método limparCampos(), se não estiver, fecha o form
                    if (groupBoxClientes.Visible == true)
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
                    #region Caso algum campo do groupBox esteja em foco e o mesmo visível, salva os dados do cliente
                    if (groupBoxClientes.Visible == true)
                    {
                        if (!comboUF.DroppedDown && !comboCidade.DroppedDown)
                        {
                            if (textNome.Focused == true || textEmail.Focused == true || maskedDocumento.Focused == true
                                || comboUF.Focused == true || comboCidade.Focused == true || textEndereco.Focused == true
                                || textTel.Focused == true || textTel2.Focused == true)
                            {
                                salvarCliente();
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

                textNome.Clear();
                textNome.Focus();
                maskedDocumento.Clear();
                textEndereco.Clear();
                checkEmpresa.Checked = false;
                comboUF.SelectedIndex = 0;
                comboCidade.SelectedIndex = 0;
                textTel.Clear();
                textTel2.Clear();
                textEmail.Clear();
                groupBoxClientes.Visible = false;
                cpf = "";
                cnpj = "";
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
                    AddObservacao addObservacao = new AddObservacao(1, dataGridView.CurrentRow.Cells["ID"].Value.ToString(), dataGridView.CurrentRow.Cells["Nome"].Value.ToString());
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