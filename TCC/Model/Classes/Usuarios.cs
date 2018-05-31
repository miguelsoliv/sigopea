namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Usuarios
    {
        [Key]
        public int Id { get; set; }

        public int Tipo { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(32)]
        public string Senha { get; set; }

        public bool Excluido { get; set; }
    }
}