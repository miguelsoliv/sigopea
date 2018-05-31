namespace TCC.Model.Classes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ObrasFornecedores
    {
        [Key]
        public int Id { get; set; }

        public Obras Obra { get; set; }

        public Fornecedores Fornecedor { get; set; }

        [Column(TypeName = "text")]
        public string Observacao { get; set; }
    }
}