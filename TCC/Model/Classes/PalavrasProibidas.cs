namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class PalavrasProibidas
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        public string Palavra { get; set; }
    }
}