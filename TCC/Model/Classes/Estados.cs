namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Estados
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Nome { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }
    }
}