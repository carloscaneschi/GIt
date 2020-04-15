using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoWebII.Models
{
    public class Pessoa
    {
        [Key]
        public int IDpessoa { get; set; }
        public int Cpf { get; set; }
        public int Rg { get; set; }
        public int Fone { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }

        public int Idprotesto { get; set; }
        public Spcserasa Spcserasa { get; set; }

    }
}