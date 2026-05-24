using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Modelos
{
    internal class VeiculoIndisponivelException:Exception
    {
        public VeiculoIndisponivelException():base("O Veiculo esta dispononivel para viagem") { }
        public VeiculoIndisponivelException(string message) : base(message) { }
    }
}
