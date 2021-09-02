using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBancaria.Dominio
{
    public static class MaiordeIdade
    {
        public static bool VerificarIdade(int idade)
        {
            if (idade >=18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
