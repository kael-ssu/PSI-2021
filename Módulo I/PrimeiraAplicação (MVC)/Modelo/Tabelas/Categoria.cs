using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Modelo.Cadastros;

namespace Modelo.Tabelas
{
    public class Categoria
    {
        [DisplayName("Id")]
        public long CategoriaId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}