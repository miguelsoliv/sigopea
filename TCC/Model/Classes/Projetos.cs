namespace TCC.Model.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Projetos
    {
        [Key]
        public int Id { get; set; }

        public Cidades Cidade { get; set; }

        public Clientes Cliente { get; set; }

        public Status Status { get; set; }

        public decimal Preco { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataFim { get; set; }

        [Column(TypeName = "date")]
        public DateTime PrazoEstipulado { get; set; }

        public bool Excluido { get; set; }
    }
}