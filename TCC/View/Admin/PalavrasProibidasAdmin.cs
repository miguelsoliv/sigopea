using System;
using System.Drawing;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Admin
{
    public partial class PalavrasProibidasAdmin : Form
    {
        private PalavrasProibidasDAO palavrasDAO { get; set; }
        private PalavrasProibidas palavra;
        private DialogResult resposta;

        public PalavrasProibidasAdmin()
        {
            InitializeComponent();
            palavrasDAO = new PalavrasProibidasDAO();
        }

        private void PalavrasProibidasAdmin_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas)
            // Adiciona as colunas a serem exibidas (conteúdo, título da coluna)
            dataGridView.Columns.Add("Id", "Código");
            dataGridView.Columns.Add("Palavra", "Palavra");

            // Largura das colunas (o default é 100)
            dataGridView.Columns["Id"].Width = 50;
            dataGridView.Columns["Palavra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            #endregion
        }

        private void PalavrasProibidasAdmin_Activated(object sender, EventArgs e)
        {
            #region Carregar palavras proibidas quando o form for focado [carregarPalavras()]
            carregarPalavras();
            #endregion
        }

        private void carregarPalavras()
        {
            #region Carregar palavras proibidas no dataGridView
            try
            {
                // limpa as linhas da grid
                dataGridView.Rows.Clear();

                // preenche as colunas
                foreach (PalavrasProibidas p in palavrasDAO.select())
                {
                    dataGridView.Rows.Add(p.Id, p.Palavra);
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
            groupBoxPalavras.Visible = true;
            textPalavra.Focus();
            groupBoxPalavras.Text = "Inclusão de Palavra Proibida";
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count >= 1)
            {
                #region Botão alterar: muda a visibilidade e o nome do groupBox
                groupBoxPalavras.Visible = true;
                textPalavra.Focus();
                groupBoxPalavras.Text = "Alteração de Palavra Proibida";
                #endregion

                #region Carregar dados da palavra proibida no groupBox [carregarInfPalavra()]
                carregarInfPalavra();
                #endregion
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Ao dar dois cliques em alguma "cell" do dataGridView, muda a visibilidade e o nome do groupBox (alteração)
            if (e.RowIndex >= 0 && e.ColumnIndex <= 6)
            {
                groupBoxPalavras.Visible = true;
                textPalavra.Focus();
                groupBoxPalavras.Text = "Alteração de Palavra Proibida";
                carregarInfPalavra();
            }
            #endregion
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            #region Carregar dados da palavra proibida no groupBox [carregarInfPalavra()] quando o administrador mudar a palavra selecionada
            if (groupBoxPalavras.Visible == true)
            {
                groupBoxPalavras.Text = "Alteração de Palavra Proibida";
                carregarInfPalavra();
            }
            #endregion
        }

        private void carregarInfPalavra()
        {
            #region Carregar dados da palavra proibida nos itens do groupBox
            try
            {
                foreach (PalavrasProibidas p in palavrasDAO.select(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString())))
                {
                    textPalavra.Text = p.Palavra;
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void salvarPalavra()
        {
            #region Validação de campos
            errorProvider.SetError(textPalavra, string.Empty);

            if (textPalavra.Text.Trim().Equals(""))
            {
                errorProvider.SetError(textPalavra, "Digite uma palavra válida");
                textPalavra.Focus();
                return;
            }
            #endregion

            #region Colocar os dados da palavra proibida em um objeto
            try
            {
                palavra = new PalavrasProibidas();
                palavra.Palavra = textPalavra.Text.Trim();
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            switch (groupBoxPalavras.Text)
            {
                case "Inclusão de Palavra Proibida":
                    #region Inclusão de palavra proibida
                    try
                    {
                        palavrasDAO.insert(palavra);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion
                    break;
                case "Alteração de Palavra Proibida":
                    #region Alteração dos dados da palavra proibida
                    try
                    {
                        palavra.Id = Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                        palavrasDAO.update(palavra);
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message);
                    }
                    #endregion
                    break;
            }

            limparCampos();
            carregarPalavras();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            #region Botão salvar [salvarPalavra()]
            salvarPalavra();
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region Botão cancelar [limparCampos()]
            limparCampos();
            #endregion
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            #region Excluir palavra proibida clicando no botão excluir [excluirPalavra()]
            excluirPalavra();
            #endregion
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            #region Excluir palavra proibida [excluirPalavra()] ao pressionar a tecla delete, tendo uma linha selecionada
            if (e.KeyCode == Keys.Delete && groupBoxPalavras.Visible == false)
            {
                excluirPalavra();
            }
            #endregion
        }

        private void excluirPalavra()
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 1)
                {
                    #region Verificar se há várias palavras proibidas selecionadas
                    resposta = MessageBox.Show("Excluir TODAS as palavras proibidas selecionadas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            foreach (DataGridViewRow r in dataGridView.SelectedRows)
                            {
                                palavrasDAO.delete(Convert.ToInt16(r.Cells["ID"].Value.ToString()));
                            }

                            carregarPalavras();
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
                    #region Excluir a palavra proibida selecionada
                    resposta = MessageBox.Show("Excluir palavra proibida '" + dataGridView.CurrentRow.Cells["Palavra"].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        try
                        {
                            palavrasDAO.delete(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
                            carregarPalavras();
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

        private void ListPalavrasProibidasAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    #region ESC: se o groupBox estiver visível chama o método limparCampos(), se não estiver, fecha o form
                    if (groupBoxPalavras.Visible == true)
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
                    #region Caso algum campo do groupBox esteja em foco e o mesmo visível, salva os dados da palavra proibida
                    if (groupBoxPalavras.Visible == true)
                    {
                        if (textPalavra.Focused == true)
                        {
                            salvarPalavra();
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
                errorProvider.SetError(textPalavra, string.Empty);
                textPalavra.Clear();
                groupBoxPalavras.Visible = false;
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
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