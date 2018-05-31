namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Clientes
    {
        [Key]
        public int Id { get; set; }

        public Cidades Cidade { get; set; } // tipo nomeDaClasse nomeVariavel { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(32)]
        public string Senha { get; set; }

        [StringLength(14)]
        public string Cpf { get; set; }

        [StringLength(18)]
        public string Cnpj { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [StringLength(25)]
        public string Telefone { get; set; }

        [StringLength(25)]
        public string Telefone2 { get; set; }

        public bool Excluido { get; set; }
    }
}