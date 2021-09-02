using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBancaria.Dominio
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Cliente cliente): base(cliente)
        {
            // 0.003M == 0,30%
            PercentualRendimento = 0.003M;
        }
        
        public decimal PercentualRendimento { get; private set; }
    }
}
