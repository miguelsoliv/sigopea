namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;
    public partial class RegCau
    {
        [Key]
        public int Id { get; set; }

        [StringLength(8)]
        public string Cau { get; set; }
    }
}