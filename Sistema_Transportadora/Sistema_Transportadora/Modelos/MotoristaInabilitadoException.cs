using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Modelos
{
    public class MotoristaInabilitadoException:Exception
    {
        public MotoristaInabilitadoException():base("O motorista não esta activo ou não tem carta adequado ") {}
        public MotoristaInabilitadoException(string mensagem):base(mensagem) {}
    }
}
