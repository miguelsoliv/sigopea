﻿using System.ComponentModel.DataAnnotations;

namespace TCC.Model.Classes
{
    public partial class RegCauProjeto
    {
        [Key]
        public int Id { get; set; }

        public Projetos Projeto { get; set; }

        public RegCau Cau { get; set; }
    }
}