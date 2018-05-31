using System;
using System.Linq;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Add
{
    public partial class AddReg : Form
    {
        private ProjetosDAO projetosDAO { get; set; }
        private RegCauDAO regCauDAO { get; set; }
        private RegCreaDAO regCreaDAO { get; set; }
        private RegCauProjetoDAO regCauProjDAO { get; set; }
        private RegCreaProjetoDAO regCreaProjDAO { get; set; }
        private RegCauProjeto regCauProj;
        private RegCreaProjeto regCreaProj;
        private RegCau regCau;
        private RegCrea regCrea;
        private int verif;

        public AddReg(string id)
        {
            InitializeComponent();
            textId.Text = id;
            projetosDAO = new ProjetosDAO();
            regCauDAO = new RegCauDAO();
            regCreaDAO = new RegCreaDAO();
            regCauProjDAO = new RegCauProjetoDAO();
            regCreaProjDAO = new RegCreaProjetoDAO();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            #region Validação dos campos
            errorProvider.SetError(textRegistro, string.Empty);
            errorProvider.SetError(comboTipo, string.Empty);
            verif = 0;

            if (textRegistro.Text.Trim().Length <= 6)
            {
                errorProvider.SetError(textRegistro, "Informe um registro com pelo menos 7 caracteres");
                verif++;
            }

            if (comboTipo.SelectedIndex == -1)
            {
                errorProvider.SetError(comboTipo, "Selecione o tipo do registro");
                return;
            }

            if(verif > 0)
            {
                return;
            }
            #endregion

            switch (comboTipo.SelectedIndex){
                case 0:
                    regCau = new RegCau();
                    regCauProj = new RegCauProjeto();
                    regCau.Cau = textRegistro.Text.Trim();
                    regCauProj.Cau = regCau;
                    regCauDAO.insert(regCau);
                    regCauProj.Projeto = projetosDAO.select().Where(x => x.Id == Convert.ToInt16(textId.Text)).First();
                    regCauProjDAO.insert(regCauProj);
                    break;
                case 1:
                    regCrea = new RegCrea();
                    regCreaProj = new RegCreaProjeto();
                    regCrea.Crea = textRegistro.Text.Trim();
                    regCreaProj.Crea = regCrea;
                    regCreaDAO.insert(regCrea);
                    regCreaProj.Projeto = projetosDAO.select().Where(x => x.Id == Convert.ToInt16(textId.Text)).First();
                    regCreaProjDAO.insert(regCreaProj);
                    break;
            }

            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region Botão cancelar
            this.Close();
            #endregion
        }
    }
}