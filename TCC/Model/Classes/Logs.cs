namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Logs
    {
        [Key]
        public int Id { get; set; }

        public Usuarios Usuario { get; set; }

        public Acoes Acao { get; set; }

        [StringLength(10)]
        public string Data { get; set; }

        [StringLength(5)]
        public string Hora { get; set; }
    }
}