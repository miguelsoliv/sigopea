using System.ComponentModel.DataAnnotations;

namespace TCC.Model.Classes
{
    public partial class ObrasTrabalhadores
    {
        [Key]
        public int Id { get; set; }

        public Obras Obra { get; set; }

        public Trabalhadores Trabalhador { get; set; }
    }
}