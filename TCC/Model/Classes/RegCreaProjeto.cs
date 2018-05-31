using System.ComponentModel.DataAnnotations;

namespace TCC.Model.Classes
{
    public partial class RegCreaProjeto
    {
        [Key]
        public int Id { get; set; }

        public Projetos Projeto { get; set; }

        public RegCrea Crea { get; set; }
    }
}