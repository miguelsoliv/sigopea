namespace TCC.Model.Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Agendamentos
    {
        [Key]
        public int Id { get; set; }

        public Projetos Projeto { get; set; }

        public Obras Obra { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [StringLength(45)]
        public string Assunto { get; set; }

        [Column(TypeName = "text")]
        public string Observacao { get; set; }
    }
}