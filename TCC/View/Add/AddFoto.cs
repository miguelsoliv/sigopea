using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View.Add
{
    public partial class AddFoto : Form
    {
        private ObrasDAO obrasDAO { get; set; }
        private FotosDAO fotosDAO { get; set; }
        private Obras obra;
        private Fotos fotos;
        private ImageCodecInfo[] codecs;
        private string path = @"C:\xampp\htdocs\fotos\", codecName;
        private int verif;

        public AddFoto(string id)
        {
            InitializeComponent();
            textId.Text = id;

            obrasDAO = new ObrasDAO();
            fotosDAO = new FotosDAO();

            #region Criação do filtro do openFileDialog (só aceita arquivos do tipo imagem)
            // Configure open file dialog box 
            codecs = ImageCodecInfo.GetImageEncoders();
            openFileDialog.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog.Filter, "", "Arquivos de Imagem", "*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG");

            foreach (var c in codecs)
            {
                codecName = c.CodecName.Substring(8).Replace("Codec", "").Trim();
                openFileDialog.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog.Filter, "|", "Arquivos "+codecName, c.FilenameExtension);
            }

            openFileDialog.FilterIndex = 1;
            #endregion
        }

        private void btFoto_Click(object sender, EventArgs e)
        {
            #region Abrir openFileDialog e, se o usuário selecionar uma imagem, carrega a imagem selecionada no pictureBox
            try
            {
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName != "")
                {
                    pictureBoxFoto.Load(openFileDialog.FileName);
                }
            }
            catch
            {
                
            }
            #endregion
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            #region Validação de dados
            errorProvider.SetError(label2, string.Empty);
            errorProvider.SetError(textDesc, string.Empty);

            verif = 0;

            if (openFileDialog.FileName == "")
            {
                errorProvider.SetError(label2, "Selecione uma foto");
                verif++;
            }

            if (textDesc.Text.Trim().Length < 5)
            {
                errorProvider.SetError(textDesc, "Informe uma descrição válida para a foto");
                return;
            }

            if(verif > 0)
            {
                return;
            }
            #endregion

            #region Colocar dados em um objeto
            try
            {
                fotos = new Fotos();
                fotos.Descricao = textDesc.Text.Trim();
                fotos.Data = DateTime.Today;
                fotos.Obra = obrasDAO.select(Convert.ToInt16(textId.Text)).First();
                fotos.Tipo = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.') + 1);
                fotosDAO.insert(fotos);
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            #region Copiar imagem para a pasta de fotos
            fotos = fotosDAO.select().Last();
            File.Copy(openFileDialog.FileName, path + fotos.Id + "." + fotos.Tipo, true);

            textDesc.Text = "";
            openFileDialog.FileName = "";
            pictureBoxFoto.Image = null;
            #endregion

            // GET:
            try
            {
                obra = obrasDAO.select().Where(x => x.Id == fotos.Obra.Id).First();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/fotos/wsAndroid/insertFotos.php?id=" + obra.Cliente.Id + "&tipo=" + fotos.Tipo + "&data=" + String.Format("{0:yyyy-MM-dd/}", fotos.Data) + "&desc=" + fotos.Descricao);
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region Botão cancelar
            this.Close();
            #endregion
        }
    }
}