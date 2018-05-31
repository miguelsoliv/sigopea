namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class RegCrea
    {
        [Key]
        public int Id { get; set; }

        [StringLength(8)]
        public string Crea { get; set; }
    }
}