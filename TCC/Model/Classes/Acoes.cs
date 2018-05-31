namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Acoes
    {
        [Key]
        public int Id { get; set; }

        [StringLength(35)]
        public string Descricao { get; set; }
    }
}