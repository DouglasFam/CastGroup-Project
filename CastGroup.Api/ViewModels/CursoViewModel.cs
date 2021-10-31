using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastGroup.Api.ViewModels
{
    public class CursoViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadeAlunos { get; set; }
        public int CodigoCategoria { get; set; }

        [NotMapped]
        public CategoriaViewModel Categoria { get; set; }
    }
}
