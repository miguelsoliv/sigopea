namespace TCC.Model.Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Observacoes
    {
        [Key]
        public int Id { get; set; }

        public Clientes Cliente { get; set; }

        public Fornecedores Fornecedor { get; set; }

        public Trabalhadores Trabalhador { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Column(TypeName = "text")]
        public string Observacao { get; set; }
    }
}