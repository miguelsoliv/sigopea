namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Responsavel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(25)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}