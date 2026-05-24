using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Modelos
{
    public class Rota_N_esxisteException:Exception
    {
        public Rota_N_esxisteException():base("A Rota que tentaste usar não existe no sistema coloca outra Rota") { }
        public Rota_N_esxisteException(string message):base(message) { }
    }
}
