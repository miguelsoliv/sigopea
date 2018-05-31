namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Cidades
    {
        [Key]
        public int Id { get; set; }

        public Estados Estado { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
    }
}