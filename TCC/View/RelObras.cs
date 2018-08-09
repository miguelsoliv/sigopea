using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class RelObras : Form
    {
        private ObrasDAO obrasDAO { get; set; }
        private ProjetosDAO projDAO { get; set; }
        private FotosDAO fotosDAO { get; set; }
        private AgendamentosDAO agendDAO { get; set; }
        private string path;

        public RelObras()
        {
            InitializeComponent();
            obrasDAO = new ObrasDAO();
            projDAO = new ProjetosDAO();
            fotosDAO = new FotosDAO();
            agendDAO = new AgendamentosDAO();
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\rel\";
            radioUltimaFoto.Checked = true;
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            if (radioUltimaFoto.Checked)
            {
                gerarRel(1);
                System.Diagnostics.Process.Start(path + "relFotos.html");
            }
            else if (radioAgendObra.Checked)
            {
                gerarRel(2);
                System.Diagnostics.Process.Start(path + "relAgendObras.html");
            }
            else if (radioAgendProj.Checked)
            {
                gerarRel(3);
                System.Diagnostics.Process.Start(path + "relAgendProj.html");
            }
        }

        private void radioUltimaFoto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioUltimaFoto.Checked)
            {
                gerarRel(1);
                webBrowser.Navigate(path + "relFotos.html");
            }
        }

        private void radioAgendObra_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAgendObra.Checked)
            {
                gerarRel(2);
                webBrowser.Navigate(path + "relAgendObras.html");
            }
        }

        private void radioAgendProj_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAgendProj.Checked)
            {
                gerarRel(3);
                webBrowser.Navigate(path + "relAgendProj.html");
            }
        }

        private void gerarRel(int tipo)
        {
            StreamWriter wr;

            switch (tipo)
            {
                case 1:
                    #region Gerar relatório da última última foto cadastrada para as obras
                    wr = new StreamWriter(path + "relFotos.html");

                    wr.WriteLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"/>");
                    wr.WriteLine("<html>");
                    wr.WriteLine("<head>");
                    wr.WriteLine("<meta name='viewport' content='width=device-width, initial-scale=1'>");
                    wr.WriteLine("<meta charset='utf-8'>");
                    wr.WriteLine("<link rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'>");
                    wr.WriteLine("<script src='https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js'></script>");
                    wr.WriteLine("<script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script>");
                    wr.WriteLine("<div class='container'>");
                    wr.WriteLine("<h2>Relatório da Última Foto Cadastrada para as Obras</h2>");

                    wr.WriteLine("<div class='table-responsive'>");
                    wr.WriteLine("<table class='table table-hover'>");
                    wr.WriteLine("<thead>");
                    wr.WriteLine("<tr>");
                    wr.WriteLine("<th>Código Obra</th>");
                    wr.WriteLine("<th>Cliente</th>");
                    wr.WriteLine("<th>Endereço</th>");
                    wr.WriteLine("<th>Data Última Foto</th>");
                    wr.WriteLine("<th>Foto</th>");
                    wr.WriteLine("</tr>");
                    wr.WriteLine("</thead>");
                    wr.WriteLine("</tbody>");

                    try
                    {
                        foreach (Obras obra in obrasDAO.select())
                        {
                            wr.WriteLine("<tr><td>" + obra.Id + "</td>");
                            wr.WriteLine("<td>" + obra.Cliente.Nome + "</td>");
                            wr.WriteLine("<td>" + obra.Endereco + "</td>");

                            try
                            {
                                Fotos foto = fotosDAO.select().Where(x => x.Obra.Id == obra.Id).Last();
                                wr.WriteLine("<td>" + foto.Data.ToString("dd/MM/yyyy") + "</td>");
                                wr.WriteLine("<td><img src='" + @"C:\xampp\htdocs\fotos\" + foto.Id + "." + foto.Tipo + "' width=100 height=80></td></tr>");
                            }
                            catch
                            {
                                wr.WriteLine("<td>" + "-" + "</td>");
                                wr.WriteLine("<td>" + "Não possui foto cadastrada" + "</td></tr>");
                            }
                        }
                    }
                    catch
                    {

                    }

                    wr.WriteLine("</tbody>");
                    wr.WriteLine("</table>");
                    wr.WriteLine("</div>");
                    wr.WriteLine("</div>");
                    wr.WriteLine("</body>");
                    wr.WriteLine("</html>");

                    wr.Close();
                    #endregion
                    break;
                case 2:
                    #region Gerar relatório dos agendamentos das obras que estão por vir
                    wr = new StreamWriter(path + "relAgendObras.html");

                    wr.WriteLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"/>");
                    wr.WriteLine("<html>");
                    wr.WriteLine("<head>");
                    wr.WriteLine("<meta name='viewport' content='width=device-width, initial-scale=1'>");
                    wr.WriteLine("<meta charset='utf-8'>");
                    wr.WriteLine("<link rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'>");
                    wr.WriteLine("<script src='https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js'></script>");
                    wr.WriteLine("<script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script>");
                    wr.WriteLine("<div class='container'>");
                    wr.WriteLine("<h2>Relatório dos Agendamentos Futuros das Obras</h2>");

                    wr.WriteLine("<div class='table-responsive'>");
                    wr.WriteLine("<table class='table table-hover'>");
                    wr.WriteLine("<thead>");
                    wr.WriteLine("<tr>");
                    wr.WriteLine("<th>Código Obra</th>");
                    wr.WriteLine("<th>Cliente</th>");
                    wr.WriteLine("<th>Endereço</th>");
                    wr.WriteLine("<th>Data Agendamento</th>");
                    wr.WriteLine("<th>Assunto Agendamento</th>");
                    wr.WriteLine("<th>Observação Agendamento</th>");
                    wr.WriteLine("</tr>");
                    wr.WriteLine("</thead>");
                    wr.WriteLine("</tbody>");

                    try
                    {
                        foreach (Agendamentos agend in agendDAO.select().Where(x => x.Data >= DateTime.Today && x.Obra != null))
                        {
                            wr.WriteLine("<tr><td>" + agend.Obra.Id + "</td>");

                            try
                            {
                                Obras obras = obrasDAO.select().Where(x => x.Id == agend.Obra.Id).First();
                                wr.WriteLine("<td>" + obras.Cliente.Nome + "</td>");
                            }
                            catch
                            {

                            }

                            wr.WriteLine("<td>" + agend.Obra.Endereco + "</td>");
                            wr.WriteLine("<td>" + agend.Data.ToString("dd/MM/yyyy") + "</td>");
                            wr.WriteLine("<td>" + agend.Assunto + "</td>");
                            wr.WriteLine("<td>" + agend.Observacao + "</td>");
                        }
                    }
                    catch
                    {

                    }

                    wr.WriteLine("</tbody>");
                    wr.WriteLine("</table>");
                    wr.WriteLine("</div>");
                    wr.WriteLine("</div>");
                    wr.WriteLine("</body>");
                    wr.WriteLine("</html>");

                    wr.Close();
                    #endregion
                    break;
                case 3:
                    #region Gerar relatório dos agendamentos dos projetos que estão por vir
                    wr = new StreamWriter(path + "relAgendProj.html");

                    wr.WriteLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"/>");
                    wr.WriteLine("<html>");
                    wr.WriteLine("<head>");
                    wr.WriteLine("<meta name='viewport' content='width=device-width, initial-scale=1'>");
                    wr.WriteLine("<meta charset='utf-8'>");
                    wr.WriteLine("<link rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'>");
                    wr.WriteLine("<script src='https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js'></script>");
                    wr.WriteLine("<script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script>");
                    wr.WriteLine("<div class='container'>");
                    wr.WriteLine("<h2>Relatório dos Agendamentos Futuros dos Projetos</h2>");

                    wr.WriteLine("<div class='table-responsive'>");
                    wr.WriteLine("<table class='table table-hover'>");
                    wr.WriteLine("<thead>");
                    wr.WriteLine("<tr>");
                    wr.WriteLine("<th>Código Projeto</th>");
                    wr.WriteLine("<th>Cliente</th>");
                    wr.WriteLine("<th>Endereço</th>");
                    wr.WriteLine("<th>Data Agendamento</th>");
                    wr.WriteLine("<th>Assunto Agendamento</th>");
                    wr.WriteLine("<th>Observação Agendamento</th>");
                    wr.WriteLine("</tr>");
                    wr.WriteLine("</thead>");
                    wr.WriteLine("</tbody>");

                    try
                    {
                        foreach (Agendamentos agend in agendDAO.select().Where(x => x.Data >= DateTime.Today && x.Projeto != null))
                        {
                            wr.WriteLine("<tr><td>" + agend.Projeto.Id + "</td>");

                            try
                            {
                                Projetos projetos = projDAO.select().Where(x => x.Id == agend.Projeto.Id).First();
                                wr.WriteLine("<td>" + projetos.Cliente.Nome + "</td>");
                            }
                            catch
                            {

                            }

                            wr.WriteLine("<td>" + agend.Projeto.Endereco + "</td>");
                            wr.WriteLine("<td>" + agend.Data.ToString("dd/MM/yyyy") + "</td>");
                            wr.WriteLine("<td>" + agend.Assunto + "</td>");
                            wr.WriteLine("<td>" + agend.Observacao + "</td>");
                        }
                    }
                    catch
                    {

                    }

                    wr.WriteLine("</tbody>");
                    wr.WriteLine("</table>");
                    wr.WriteLine("</div>");
                    wr.WriteLine("</div>");
                    wr.WriteLine("</body>");
                    wr.WriteLine("</html>");

                    wr.Close();
                    #endregion
                    break;
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}