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

        public PalavrasProibidasAdmin()
        {
            InitializeComponent();
            palavrasDAO = new PalavrasProibidasDAO();
        }

        private void PalavrasProibidasAdmin_Load(object sender, EventArgs e)
        {
            #region Inicialização do dataGridView (criação das colunas)
            dataGridView.Columns.Add("Id", "Código");
            dataGridView.Columns.Add("Palavra", "Palavra");

            dataGridView.Columns["Id"].Width = 50;
            dataGridView.Columns["Palavra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            #endregion
        }

        private void PalavrasProibidasAdmin_Activated(object sender, EventArgs e)
        {
            carregarPalavras();
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            limparCampos();
            groupBoxPalavras.Visible = true;
            textPalavra.Focus();
            groupBoxPalavras.Text = "Inclusão de Palavra Proibida";
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count >= 1)
            {
                groupBoxPalavras.Visible = true;
                textPalavra.Focus();
                groupBoxPalavras.Text = "Alteração de Palavra Proibida";

                carregarInfPalavra();
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

        private void btSalvar_Click(object sender, EventArgs e)
        {
            salvarPalavra();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resposta;

                if (dataGridView.SelectedRows.Count > 1)
                {
                    #region Verificar se há várias palavras proibidas selecionadas
                    resposta = MessageBox.Show("Excluir TODAS as palavras proibidas selecionadas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow r in dataGridView.SelectedRows)
                        {
                            palavrasDAO.delete(Convert.ToInt16(r.Cells["ID"].Value.ToString()));
                        }

                        carregarPalavras();
                    }
                    #endregion
                }
                else
                {
                    #region Excluir a palavra proibida selecionada
                    resposta = MessageBox.Show("Excluir palavra proibida '" + dataGridView.CurrentRow.Cells["Palavra"].Value.ToString() + "'?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resposta == DialogResult.Yes)
                    {
                        palavrasDAO.delete(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
                        carregarPalavras();
                    }
                    #endregion
                }
            }
            catch
            {

            }
        }

        private void ListPalavrasProibidasAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // Caso algum campo do groupBox esteja em foco e o mesmo visível, salva os dados da palavra proibida
                    if (groupBoxPalavras.Visible == true)
                    {
                        if (textPalavra.Focused == true)
                        {
                            salvarPalavra();
                        }
                    }
                    break;
            }
        }

        private void carregarPalavras()
        {
            // Carregar palavras proibidas no dataGridView
            dataGridView.Rows.Clear();

            // preenche as colunas
            foreach (PalavrasProibidas p in palavrasDAO.select())
            {
                dataGridView.Rows.Add(p.Id, p.Palavra);
            }
        }

        private void carregarInfPalavra()
        {
            // Carregar dados da palavra proibida nos itens do groupBox
            PalavrasProibidas p = palavrasDAO.select(Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
            textPalavra.Text = p.Palavra;
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

            PalavrasProibidas palavra = new PalavrasProibidas();
            palavra.Palavra = textPalavra.Text.Trim();

            switch (groupBoxPalavras.Text)
            {
                case "Inclusão de Palavra Proibida":
                    palavrasDAO.insert(palavra);
                    break;
                case "Alteração de Palavra Proibida":
                    palavra.Id = Convert.ToInt16(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    palavrasDAO.update(palavra);
                    break;
            }

            limparCampos();
            carregarPalavras();
        }

        private void limparCampos()
        {
            // Limpar campos do groupBox
            errorProvider.SetError(textPalavra, string.Empty);
            textPalavra.Clear();
            groupBoxPalavras.Visible = false;
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}