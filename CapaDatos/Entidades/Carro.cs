using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entidades
{
    public class Carro
    {
        public int IdCarro { get; set; }
        public string Marca { set; get; }
        public string Modelo { set; get; }
        public string Pais { get; set; }
        public decimal Costo { get; set; }

       
    }
}
