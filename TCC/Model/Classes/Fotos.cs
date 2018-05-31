namespace TCC.Model.Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Fotos
    {
        [Key]
        public int Id { get; set; }

        public Obras Obra { get; set; }

        [StringLength(5)]
        public string Tipo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Column(TypeName = "text")]
        public string Descricao { get; set; }
    }
}