using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastGroup.Api.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        [NotMapped]
        public IEnumerable<CursoViewModel> Curso { get; set; }
    }
}
