namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;

    public partial class Status
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        public string Nome { get; set; }
    }
}