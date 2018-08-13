namespace TCC.Model.Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Logs
    {
        [Key]
        public int Id { get; set; }

        public Usuarios Usuario { get; set; }

        public Acoes Acao { get; set; }

        public DateTime Data { get; set; }
    }
}