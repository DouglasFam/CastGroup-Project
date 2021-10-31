using System;
using System.Collections.Generic;
using System.Text;

namespace CastGroup.Domain.Models
{
  public  class Categoria
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Curso> Curso { get; set; }
    }
}
