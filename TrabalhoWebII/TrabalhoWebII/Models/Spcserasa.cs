using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoWebII.Models
{
    public class Spcserasa
    {
            
        [Key]
        public int Idprotesto { get; set; }
        public int data { get; set; }

        public IList<Pessoa> Pessoas { get; set; }
        public IList<Empresa> Empresas { get; set; }


    }
}
