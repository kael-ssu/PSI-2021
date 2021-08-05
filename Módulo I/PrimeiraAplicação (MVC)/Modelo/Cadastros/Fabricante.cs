using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Fabricante
    {
        [DisplayName("Id")]
        public long FabricanteId { get; set; }

        [Required(ErrorMessage = "Informe o nome do fabricante")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}