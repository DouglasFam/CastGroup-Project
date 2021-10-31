using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CastGroup.Domain.Models
{
    public class Curso : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadeAlunos { get; set; }
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
