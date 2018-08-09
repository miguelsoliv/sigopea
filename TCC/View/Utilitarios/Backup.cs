using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCC.Model.Classes;
using TCC.Model.DAO;

namespace TCC.View
{
    public partial class Backup : Form
    {
        private AgendamentosDAO agendDAO { get; set; }
        private CidadesDAO cidadesDAO { get; set; }
        private ClientesDAO clientesDAO { get; set; }
        private FornecedoresDAO fornDAO { get; set; }
        private FotosDAO fotosDAO { get; set; }
        private LogsDAO logsDAO { get; set; }
        private ObrasDAO obrasDAO { get; set; }
        private ObrasFornecedoresDAO ofDAO { get; set; }
        private ObrasTrabalhadoresDAO otDAO { get; set; }
        private ObservacoesDAO obsDAO { get; set; }
        private PalavrasProibidasDAO palavrasDAO { get; set; }
        private ProjetosDAO projetosDAO { get; set; }
        private RegCauDAO regCauDAO { get; set; }
        private RegCauProjetoDAO regCauPDAO { get; set; }
        private RegCreaDAO regCreaDAO { get; set; }
        private RegCreaProjetoDAO regCreaPDAO { get; set; }
        private ResponsavelDAO respDAO { get; set; }
        private TrabalhadoresDAO trabDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }
        private StringBuilder inserts;

        public Backup()
        {
            InitializeComponent();
            agendDAO = new AgendamentosDAO();
            cidadesDAO = new CidadesDAO();
            clientesDAO = new ClientesDAO();
            fornDAO = new FornecedoresDAO();
            fotosDAO = new FotosDAO();
            logsDAO = new LogsDAO();
            obrasDAO = new ObrasDAO();
            ofDAO = new ObrasFornecedoresDAO();
            otDAO = new ObrasTrabalhadoresDAO();
            obsDAO = new ObservacoesDAO();
            palavrasDAO = new PalavrasProibidasDAO();
            projetosDAO = new ProjetosDAO();
            regCauDAO = new RegCauDAO();
            regCauPDAO = new RegCauProjetoDAO();
            regCreaDAO = new RegCreaDAO();
            regCreaPDAO = new RegCreaProjetoDAO();
            respDAO = new ResponsavelDAO();
            trabDAO = new TrabalhadoresDAO();
            usuariosDAO = new UsuariosDAO();
            inserts = new StringBuilder();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);

            using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
            {
                #region Criação das tabelas
                sw.WriteLine("CREATE TABLE Estados(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Nome VARCHAR(20) NOT NULL,\n" +
                    "Sigla VARCHAR(2) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Cidades(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Estado_Id INT NOT NULL,\n" +
                    "Nome VARCHAR(50) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Status(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Nome VARCHAR(15) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Acoes(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Descricao VARCHAR(35) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE PalavrasProibidas(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Palavra VARCHAR(25) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Usuarios(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Tipo INT NOT NULL,\n" +
                    "Login VARCHAR(50) NOT NULL,\n" +
                    "Senha VARCHAR(32) NOT NULL,\n" +
                    "Email VARCHAR(100) NOT NULL,\n" +
                    "Excluido BIT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Clientes(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Cidade_Id INT NOT NULL,\n" +
                    "Nome VARCHAR(100) NOT NULL,\n" +
                    "Email VARCHAR(100) NOT NULL,\n" +
                    "Senha VARCHAR(32),\n" +
                    "Cpf VARCHAR(14),\n" +
                    "Cnpj VARCHAR(18)\n," +
                    "Endereco VARCHAR(100),\n" +
                    "Telefone VARCHAR(25),\n" +
                    "Telefone2 VARCHAR(25),\n" +
                    "Excluido BIT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Logs(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Usuario_Id INT NOT NULL,\n" +
                    "Acao_Id INT NOT NULL,\n" +
                    "Data VARCHAR(10) NOT NULL,\n" +
                    "Hora VARCHAR(5) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Fornecedores(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Cidade_Id INT NOT NULL,\n" +
                    "Nome VARCHAR(100) NOT NULL,\n" +
                    "Email VARCHAR(100),\n" +
                    "Cnpj VARCHAR(18),\n" +
                    "Endereco VARCHAR(100) NOT NULL,\n" +
                    "Telefone VARCHAR(25),\n" +
                    "Telefone2 VARCHAR(25),\n" +
                    "Excluido BIT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Trabalhadores(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Cidade_Id INT NOT NULL,\n" +
                    "Nome VARCHAR(100) NOT NULL,\n" +
                    "Email VARCHAR(100),\n" +
                    "Servico VARCHAR(25) NOT NULL,\n" +
                    "Cpf VARCHAR(14),\n" +
                    "Endereco VARCHAR(100),\n" +
                    "Telefone VARCHAR(25) NOT NULL,\n" +
                    "Telefone2 VARCHAR(25),\n" +
                    "Excluido BIT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Projetos(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Cidade_Id INT NOT NULL,\n" +
                    "Cliente_Id INT NOT NULL,\n" +
                    "Status_Id INT NOT NULL,\n" +
                    "Preco DECIMAL NOT NULL,\n" +
                    "Endereco VARCHAR(100) NOT NULL,\n" +
                    "DataInicio DATE NOT NULL,\n" +
                    "DataFim DATE,\n" +
                    "PrazoEstipulado DATE NOT NULL,\n" +
                    "Excluido BIT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE RegCrea(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Crea VARCHAR(8) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE RegCau(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Cau VARCHAR(8) NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE RegCreaProjeto(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Projeto_Id INT NOT NULL,\n" +
                    "Crea_Id INT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE RegCauProjeto(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Projeto_Id INT NOT NULL,\n" +
                    "Cau_Id INT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Responsavel(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Nome VARCHAR(100) NOT NULL,\n" +
                    "Telefone VARCHAR(25),\n" +
                    "Email VARCHAR(100),\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Obras(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Cidade_Id INT NOT NULL,\n" +
                    "Cliente_Id INT NOT NULL,\n" +
                    "Responsavel_Id INT,\n" +
                    "Status_Id INT NOT NULL,\n" +
                    "Preco DECIMAL NOT NULL,\n" +
                    "Endereco VARCHAR(100) NOT NULL,\n" +
                    "DataInicio DATE NOT NULL,\n" +
                    "DataFim DATE,\n" +
                    "PrazoEstipulado DATE NOT NULL,\n" +
                    "Excluido BIT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Observacoes(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Cliente_Id INT,\n" +
                    "Fornecedor_Id INT,\n" +
                    "Trabalhador_Id INT,\n" +
                    "Data DATE NOT NULL,\n" +
                    "Observacao TEXT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Agendamentos(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Projeto_Id INT,\n" +
                    "Obra_Id INT,\n" +
                    "Data DATE NOT NULL,\n" +
                    "Assunto VARCHAR(45) NOT NULL,\n" +
                    "Observacao TEXT,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE ObrasFornecedores(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Obra_Id INT NOT NULL,\n" +
                    "Fornecedor_Id INT NOT NULL,\n" +
                    "Observacao TEXT,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE ObrasTrabalhadores(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Obra_Id INT NOT NULL,\n" +
                    "Trabalhador_Id INT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");

                sw.WriteLine("\nCREATE TABLE Fotos(\n" +
                    "Id INT NOT NULL IDENTITY,\n" +
                    "Obra_Id INT NOT NULL,\n" +
                    "Tipo VARCHAR(5) NOT NULL,\n" +
                    "Data DATE NOT NULL,\n" +
                    "Descricao TEXT NOT NULL,\n" +
                    "PRIMARY KEY(Id)\n" +
                    ");\n");
                #endregion

                #region Chaves estrangeiras
                sw.WriteLine("\nALTER TABLE Clientes\n" +
                    "ADD CONSTRAINT Clientes_FK\n" +
                    "FOREIGN KEY(Cidade_Id) REFERENCES Cidades(Id);\n");

                sw.WriteLine("\nALTER TABLE Projetos\n" +
                    "ADD CONSTRAINT Projetos_FK\n" +
                    "FOREIGN KEY(Cliente_Id)REFERENCES Clientes(Id);\n" +
                    "ALTER TABLE Projetos\n" +
                    "ADD CONSTRAINT Projetos_FK2\n" +
                    "FOREIGN KEY(Cidade_Id)REFERENCES Cidades(Id);\n" +
                    "ALTER TABLE Projetos\n" +
                    "ADD CONSTRAINT Projetos_FK3\n" +
                    "FOREIGN KEY(Status_Id)REFERENCES Status(Id);\n");

                sw.WriteLine("\nALTER TABLE Obras\n" +
                    "ADD CONSTRAINT Obras_FK\n" +
                    "FOREIGN KEY(Cliente_Id)REFERENCES Clientes(Id);\n" +
                    "ALTER TABLE Obras\n" +
                    "ADD CONSTRAINT Obras_FK2\n" +
                    "FOREIGN KEY(Responsavel_Id)REFERENCES Responsavel(Id);\n" +
                    "ALTER TABLE Obras\n" +
                    "ADD CONSTRAINT Obras_FK3\n" +
                    "FOREIGN KEY(Cidade_Id)REFERENCES Cidades(Id);\n" +
                    "ALTER TABLE Obras\n" +
                    "ADD CONSTRAINT Obras_FK4\n" +
                    "FOREIGN KEY(Status_Id)REFERENCES Status(Id);\n");

                sw.WriteLine("\nALTER TABLE Agendamentos\n" +
                    "ADD CONSTRAINT Agendamentos_FK\n" +
                    "FOREIGN KEY(Projeto_Id)REFERENCES Projetos(Id);\n" +
                    "ALTER TABLE Agendamentos\n" +
                    "ADD CONSTRAINT Agendamentos_FK2\n" +
                    "FOREIGN KEY(Obra_Id)REFERENCES Obras(Id);\n");

                sw.WriteLine("\nALTER TABLE Trabalhadores\n" +
                    "ADD CONSTRAINT Trabalhadores_FK\n" +
                    "FOREIGN KEY(Cidade_Id)REFERENCES Cidades(Id);\n");

                sw.WriteLine("\nALTER TABLE Fornecedores\n" +
                    "ADD CONSTRAINT Fornecedores_FK\n" +
                    "FOREIGN KEY(Cidade_Id)REFERENCES Cidades(Id);\n");

                sw.WriteLine("\nALTER TABLE Observacoes\n" +
                    "ADD CONSTRAINT Observacoes_FK\n" +
                    "FOREIGN KEY(Fornecedor_Id)REFERENCES Fornecedores(Id);\n" +
                    "ALTER TABLE Observacoes\n" +
                    "ADD CONSTRAINT Observacoes_FK2\n" +
                    "FOREIGN KEY(Trabalhador_Id)REFERENCES Trabalhadores(Id);\n" +
                    "ALTER TABLE Observacoes\n" +
                    "ADD CONSTRAINT Observacoes_FK3\n" +
                    "FOREIGN KEY(Cliente_Id)REFERENCES Clientes(Id);\n");

                sw.WriteLine("\nALTER TABLE Fotos\n" +
                    "ADD CONSTRAINT Fotos_FK\n" +
                    "FOREIGN KEY(Obra_Id)REFERENCES Obras(Id);\n");

                sw.WriteLine("\nALTER TABLE Cidades\n" +
                   "ADD CONSTRAINT Cidades_FK\n" +
                    "FOREIGN KEY(Estado_Id)REFERENCES Estados(Id);\n");

                sw.WriteLine("\nALTER TABLE ObrasFornecedores\n" +
                    "ADD CONSTRAINT ObrasFornecedores_FK\n" +
                    "FOREIGN KEY(Obra_Id)REFERENCES Obras(Id);\n" +
                    "ALTER TABLE ObrasFornecedores\n" +
                    "ADD CONSTRAINT ObrasFornecedores_FK2\n" +
                    "FOREIGN KEY(Fornecedor_Id)REFERENCES Fornecedores(Id);\n");

                sw.WriteLine("\nALTER TABLE ObrasTrabalhadores\n" +
                    "ADD CONSTRAINT ObrasTrabalhadores_FK\n" +
                    "FOREIGN KEY(Obra_Id)REFERENCES Obras(Id);\n" +
                    "ALTER TABLE ObrasTrabalhadores\n" +
                    "ADD CONSTRAINT ObrasTrabalhadores_FK2\n" +
                    "FOREIGN KEY(Trabalhador_Id)REFERENCES Trabalhadores(Id);\n");

                sw.WriteLine("\nALTER TABLE RegCreaProjeto\n" +
                    "ADD CONSTRAINT RegCreaProjeto_FK\n" +
                    "FOREIGN KEY(Projeto_Id)REFERENCES Projetos(Id);\n" +
                    "ALTER TABLE RegCreaProjeto\n" +
                    "ADD CONSTRAINT RegCreaProjeto_FK2\n" +
                    "FOREIGN KEY(Crea_Id)REFERENCES RegCrea(Id);\n");

                sw.WriteLine("\nALTER TABLE RegCauProjeto\n" +
                    "ADD CONSTRAINT RegCauProjeto_FK\n" +
                    "FOREIGN KEY(Projeto_Id)REFERENCES Projetos(Id);\n" +
                    "ALTER TABLE RegCauProjeto\n" +
                    "ADD CONSTRAINT RegCauProjeto_FK2\n" +
                    "FOREIGN KEY(Cau_Id)REFERENCES RegCau(Id);\n");
                #endregion

                #region Inserts
                if (cidadesDAO.select().Count() > 0)
                {
                    int limite = 0; // SQL só insere 1000 linhas por vez
                    sw.WriteLine("INSERT INTO Cidades(Nome, Estado_Id) VALUES");
                    foreach (Cidades cidades in cidadesDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Cidades(Nome, Estado_Id) VALUES\n");
                            inserts.Append("('" + cidades.Nome + "', " + cidades.Estado.Id + "),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("('" + cidades.Nome + "', " + cidades.Estado.Id + "),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (palavrasDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO PalavrasProibidas(Palavra) VALUES");
                    foreach (PalavrasProibidas palavras in palavrasDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO PalavrasProibidas(Palavra) VALUES\n");
                            inserts.Append("('" + palavras.Palavra + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("('" + palavras.Palavra + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (usuariosDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Usuarios(Tipo, Login, Senha, Email, Excluido) VALUES");
                    foreach (Usuarios usuarios in usuariosDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Usuarios(Tipo, Login, Senha, Email, Excluido) VALUES\n");
                            inserts.Append("(" + usuarios.Tipo + ", '" + usuarios.Login + "', '" + usuarios.Senha + "', '" +
                                usuarios.Email + "', '" + usuarios.Excluido + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + usuarios.Tipo + ", '" + usuarios.Login + "', '" + usuarios.Senha + "', '" +
                                usuarios.Email + "', '" + usuarios.Excluido + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (clientesDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Clientes(Cidade_Id, Nome, Email, Senha, Cpf, Cnpj, Endereco, Telefone, Telefone2, Excluido) VALUES");
                    foreach (Clientes clientes in clientesDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Clientes(Cidade_Id, Nome, Email, Senha, Cpf, Cnpj, Endereco, Telefone, Telefone2, Excluido) VALUES\n");
                            inserts.Append("(" + clientes.Cidade.Id + ", '" + clientes.Nome + "', '" + clientes.Email + "', '" +
                                clientes.Senha + "', '" + clientes.Cpf + "', '" + clientes.Cnpj + "', '" + clientes.Endereco + "', '" +
                                clientes.Telefone + "', '" + clientes.Telefone2 + "', '" + clientes.Excluido + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + clientes.Cidade.Id + ", '" + clientes.Nome + "', '" + clientes.Email + "', '" +
                                clientes.Senha + "', '" + clientes.Cpf + "', '" + clientes.Cnpj + "', '" + clientes.Endereco + "', '" +
                                clientes.Telefone + "', '" + clientes.Telefone2 + "', '" + clientes.Excluido + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (logsDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Logs(Usuario_Id, Acao_Id, Data, Hora) VALUES");
                    foreach (Logs logs in logsDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Logs(Usuario_Id, Acao_Id, Data, Hora) VALUES\n");
                            inserts.Append("(" + logs.Usuario.Id + ", '" + logs.Acao.Id + "', '" + logs.Data + "', '" +
                                logs.Hora + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + logs.Usuario.Id + ", '" + logs.Acao.Id + "', '" + logs.Data + "', '" +
                                logs.Hora + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (fornDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Fornecedores(Cidade_Id, Cnpj, Email, Endereco, Excluido, Nome, Telefone, Telefone2) VALUES");
                    foreach (Fornecedores forn in fornDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Fornecedores(Cidade_Id, Cnpj, Email, Endereco, Excluido, Nome, Telefone, Telefone2) VALUES\n");
                            inserts.Append("(" + forn.Cidade.Id + ", '" + forn.Cnpj + "', '" + forn.Email + "', '" +
                                forn.Endereco + "', '" + forn.Excluido + "', '" + forn.Nome + "', '" + forn.Telefone + "', '" +
                                forn.Telefone2 + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + forn.Cidade.Id + ", '" + forn.Cnpj + "', '" + forn.Email + "', '" +
                                forn.Endereco + "', '" + forn.Excluido + "', '" + forn.Nome + "', '" + forn.Telefone + "', '" +
                                forn.Telefone2 + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(trabDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Trabalhadores(Cidade_Id, Cpf, Email, Endereco, Excluido, Nome, Telefone, Telefone2, Servico) VALUES");
                    foreach (Trabalhadores trab in trabDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Trabalhadores(Cidade_Id, Cpf, Email, Endereco, Excluido, Nome, Telefone, Telefone2, Servico) VALUES\n");
                            inserts.Append("(" + trab.Cidade.Id + ", '" + trab.Cpf + "', '" + trab.Email + "', '" +
                                trab.Endereco + "', '" + trab.Excluido + "', '" + trab.Nome + "', '" + trab.Telefone + "', '" +
                                trab.Telefone2 + "', '" + trab.Servico + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + trab.Cidade.Id + ", '" + trab.Cpf + "', '" + trab.Email + "', '" +
                                trab.Endereco + "', '" + trab.Excluido + "', '" + trab.Nome + "', '" + trab.Telefone + "', '" +
                                trab.Telefone2 + "', '" + trab.Servico + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(projetosDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Projetos(Cidade_Id, Cliente_Id, DataFim, DataInicio, Endereco, Excluido, PrazoEstipulado, Preco, Status_Id) VALUES");
                    foreach (Projetos projeto in projetosDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Projetos(Cidade_Id, Cliente_Id, DataFim, DataInicio, Endereco, Excluido, PrazoEstipulado, Preco, Status_Id) VALUES\n");
                            inserts.Append("(" + projeto.Cidade.Id + ", " + projeto.Cliente.Id + ", '" + projeto.DataFim.ToString("MM-dd-yyyy") + "', '" +
                                projeto.DataInicio.ToString("MM-dd-yyyy") + "', '" + projeto.Endereco + "', '" + projeto.Excluido + "', '" +
                                projeto.PrazoEstipulado.ToString("MM-dd-yyyy") + "', '" + projeto.Preco.ToString().Replace(",", ".") + "', " + projeto.Status.Id + "),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + projeto.Cidade.Id + ", " + projeto.Cliente.Id + ", '" + projeto.DataFim.ToString("MM-dd-yyyy") + "', '" +
                                projeto.DataInicio.ToString("MM-dd-yyyy") + "', '" + projeto.Endereco + "', '" + projeto.Excluido + "', '" +
                                projeto.PrazoEstipulado.ToString("MM-dd-yyyy") + "', '" + projeto.Preco.ToString().Replace(",", ".") + "', " + projeto.Status.Id + "),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(regCreaDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO RegCrea(Crea) VALUES");
                    foreach (RegCrea crea in regCreaDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO RegCrea(Crea) VALUES\n");
                            inserts.Append("('" + crea.Crea + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("('" + crea.Crea + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (regCauDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO RegCau(Cau) VALUES");
                    foreach (RegCau cau in regCauDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO RegCau(Cau) VALUES\n");
                            inserts.Append("('" + cau.Cau + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("('" + cau.Cau + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(regCreaPDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO RegCreaProjeto(Crea_Id, Projeto_Id) VALUES");
                    foreach (RegCreaProjeto creaP in regCreaPDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO RegCreaProjeto(Crea_Id, Projeto_Id) VALUES\n");
                            inserts.Append("(" + creaP.Crea.Id + ", " + creaP.Projeto.Id + "),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + creaP.Crea.Id + ", " + creaP.Projeto.Id + "),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (regCauPDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO RegCauProjeto(Cau_Id, Projeto_Id) VALUES");
                    foreach (RegCauProjeto cauP in regCauPDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO RegCauProjeto(Cau_Id, Projeto_Id) VALUES\n");
                            inserts.Append("(" + cauP.Cau.Id + ", " + cauP.Projeto.Id + "),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + cauP.Cau.Id + ", " + cauP.Projeto.Id + "),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(respDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Responsavel(Email, Nome, Telefone) VALUES");
                    foreach (Responsavel resp in respDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Responsavel(Email, Nome, Telefone) VALUES\n");
                            inserts.Append("('" + resp.Email + "', '" + resp.Nome + "', '" + resp.Telefone + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("('" + resp.Email + "', '" + resp.Nome + "', '" + resp.Telefone + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(obrasDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Obras(Cidade_Id, Cliente_Id, DataFim, DataInicio, Endereco, Excluido, PrazoEstipulado, Preco, Responsavel_Id, Status_Id) VALUES");
                    foreach (Obras obra in obrasDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            try
                            {
                                inserts.Append("INSERT INTO Obras(Cidade_Id, Cliente_Id, DataFim, DataInicio, Endereco, Excluido, PrazoEstipulado, Preco, Responsavel_Id, Status_Id) VALUES\n");
                                inserts.Append("(" + obra.Cidade.Id + ", " + obra.Cliente.Id + ", '" + obra.DataFim.ToString("MM-dd-yyyy") + "', '" +
                                    obra.DataInicio.ToString("MM-dd-yyyy") + "', '" + obra.Endereco + "', '" + obra.Excluido + "', '" + obra.PrazoEstipulado.ToString("MM-dd-yyyy") + "', '" +
                                    obra.Preco.ToString().Replace(",", ".") + "', " + obra.Responsavel.Id + ", " + obra.Status.Id + "),\n");
                            }
                            catch
                            {
                                inserts.Append("INSERT INTO Obras(Cidade_Id, Cliente_Id, DataFim, DataInicio, Endereco, Excluido, PrazoEstipulado, Preco, Responsavel_Id, Status_Id) VALUES\n");
                                inserts.Append("(" + obra.Cidade.Id + ", " + obra.Cliente.Id + ", '" + obra.DataFim.ToString("MM-dd-yyyy") + "', '" +
                                    obra.DataInicio.ToString("MM-dd-yyyy") + "', '" + obra.Endereco + "', '" + obra.Excluido + "', '" + obra.PrazoEstipulado.ToString("MM-dd-yyyy") + "', '" +
                                    obra.Preco.ToString().Replace(",", ".") + "', null, " + obra.Status.Id + "),\n");
                            }
                            limite = 0;
                        }
                        else
                        {
                            try
                            {
                                inserts.Append("(" + obra.Cidade.Id + ", " + obra.Cliente.Id + ", '" + obra.DataFim.ToString("MM-dd-yyyy") + "', '" +
                                    obra.DataInicio.ToString("MM-dd-yyyy") + "', '" + obra.Endereco + "', '" + obra.Excluido + "', '" + obra.PrazoEstipulado.ToString("MM-dd-yyyy") + "', '" +
                                    obra.Preco.ToString().Replace(",", ".") + "', " + obra.Responsavel.Id + ", " + obra.Status.Id + "),\n");
                            }
                            catch
                            {
                                inserts.Append("(" + obra.Cidade.Id + ", " + obra.Cliente.Id + ", '" + obra.DataFim.ToString("MM-dd-yyyy") + "', '" +
                                    obra.DataInicio.ToString("MM-dd-yyyy") + "', '" + obra.Endereco + "', '" + obra.Excluido + "', '" + obra.PrazoEstipulado.ToString("MM-dd-yyyy") + "', '" +
                                    obra.Preco.ToString().Replace(",", ".") + "', null, " + obra.Status.Id + "),\n");
                            }
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (obsDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Observacoes(Cliente_Id, Data, Fornecedor_Id, Observacao, Trabalhador_Id) VALUES");
                    foreach (Observacoes obs in obsDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Observacoes(Cliente_Id, Data, Fornecedor_Id, Observacao, Trabalhador_Id) VALUES\n");

                            if (obs.Cliente == null && obs.Fornecedor == null)
                            {
                                inserts.Append("(null, '" + obs.Data.ToString("MM-dd-yyyy") + "', null, '" +
                                    obs.Observacao + "', " + obs.Trabalhador.Id + "),\n");
                            }
                            if (obs.Cliente == null && obs.Trabalhador == null)
                            {
                                inserts.Append("(null, '" + obs.Data.ToString("MM-dd-yyyy") + "', " + obs.Fornecedor.Id + ", '" +
                                    obs.Observacao + "', null),\n");
                            }
                            if (obs.Fornecedor == null && obs.Trabalhador == null)
                            {
                                inserts.Append("(" + obs.Cliente.Id + ", '" + obs.Data.ToString("MM-dd-yyyy") + "', null, '" +
                                    obs.Observacao + "', null),\n");
                            }

                            limite = 0;
                        }
                        else
                        {
                            if (obs.Cliente == null && obs.Fornecedor == null)
                            {
                                inserts.Append("(null, '" + obs.Data.ToString("MM-dd-yyyy") + "', null, '" +
                                    obs.Observacao + "', " + obs.Trabalhador.Id + "),\n");
                            }
                            if (obs.Cliente == null && obs.Trabalhador == null)
                            {
                                inserts.Append("(null, '" + obs.Data.ToString("MM-dd-yyyy") + "', " + obs.Fornecedor.Id + ", '" +
                                    obs.Observacao + "', null),\n");
                            }
                            if (obs.Fornecedor == null && obs.Trabalhador == null)
                            {
                                inserts.Append("(" + obs.Cliente.Id + ", '" + obs.Data.ToString("MM-dd-yyyy") + "', null, '" +
                                    obs.Observacao + "', null),\n");
                            }

                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (agendDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Agendamentos(Assunto, Data, Obra_Id, Observacao, Projeto_Id) VALUES");
                    foreach (Agendamentos agend in agendDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            try
                            {
                                inserts.Append("INSERT INTO Agendamentos(Assunto, Data, Obra_Id, Observacao, Projeto_Id) VALUES\n");
                                inserts.Append("('" + agend.Assunto + "', '" + agend.Data.ToString("MM-dd-yyyy") + "', " + agend.Obra.Id + ", '" +
                                    agend.Observacao + "', null),\n");
                            }
                            catch
                            {
                                inserts.Append("('" + agend.Assunto + "', '" + agend.Data.ToString("MM-dd-yyyy") + "', null, '" +
                                    agend.Observacao + "', " + agend.Projeto.Id + "),\n");
                            }
                            limite = 0;
                        }
                        else
                        {
                            try
                            {
                                inserts.Append("('" + agend.Assunto + "', '" + agend.Data.ToString("MM-dd-yyyy") + "', " + agend.Obra.Id + ", '" +
                                    agend.Observacao + "', null),\n");
                            }
                            catch
                            {
                                inserts.Append("('" + agend.Assunto + "', '" + agend.Data.ToString("MM-dd-yyyy") + "', null, '" +
                                    agend.Observacao + "', " + agend.Projeto.Id + "),\n");
                            }
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(ofDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO ObrasFornecedores(Fornecedor_Id, Obra_Id, Observacao) VALUES");
                    foreach (ObrasFornecedores of in ofDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO ObrasFornecedores(Fornecedor_Id, Obra_Id, Observacao) VALUES\n");
                            inserts.Append("(" + of.Fornecedor.Id + ", " + of.Obra.Id + ", '" + of.Observacao + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + of.Fornecedor.Id + ", " + of.Obra.Id + ", '" + of.Observacao + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if (otDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO ObrasTrabalhadores(Trabalhador_Id, Obra_Id) VALUES");
                    foreach (ObrasTrabalhadores ot in otDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO ObrasTrabalhadores(Trabalhador_Id, Obra_Id) VALUES\n");
                            inserts.Append("(" + ot.Trabalhador.Id + ", " + ot.Obra.Id + "),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("(" + ot.Trabalhador.Id + ", " + ot.Obra.Id + "),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }

                if(fotosDAO.select().Count() > 0)
                {
                    int limite = 0;
                    sw.WriteLine("INSERT INTO Fotos(Data, Descricao, Obra_Id, Tipo) VALUES");
                    foreach (Fotos fotos in fotosDAO.select())
                    {
                        if (limite >= 990)
                        {
                            arrumarBuilder(sw);
                            inserts.Append("INSERT INTO Fotos(Data, Descricao, Obra_Id, Tipo) VALUES\n");
                            inserts.Append("('" + fotos.Data.ToString("MM-dd-yyyy") + "', '" + fotos.Descricao + "', " + fotos.Obra.Id + ", '" +
                                fotos.Tipo + "'),\n");
                            limite = 0;
                        }
                        else
                        {
                            inserts.Append("('" + fotos.Data.ToString("MM-dd-yyyy") + "', '" + fotos.Descricao + "', " + fotos.Obra.Id + ", '" +
                                fotos.Tipo + "'),\n");
                            limite++;
                        }
                    }

                    arrumarBuilder(sw);
                }
                #endregion
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            label1.Visible = false;
            pictureBox.Visible = false;
            btGerar.Enabled = true;
            MessageBox.Show("Arquivo gerado com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            // Abrir saveFileDialog para o usuário selecionar onde salvar o arquivo de backup
            // Nome padrão
            saveFileDialog.FileName = "backupSIGOPEA_" + DateTime.Now.ToString("dd_MM_yyyy");
            // Adicionar filtros - também pode ser feito nas propriedades
            saveFileDialog.Filter = "Arquivos SQL (*.sql)|*.sql";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                label1.Visible = true;
                pictureBox.Visible = true;
                btGerar.Enabled = false;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void arrumarBuilder(StreamWriter sw)
        {
            try
            {
                inserts.Length -= 2;
                inserts.Append(";");
                sw.WriteLine(inserts);
                sw.WriteLine(sw.NewLine);
                inserts.Clear();
            }
            catch
            {

            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}