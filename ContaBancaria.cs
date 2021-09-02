using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgendaBancaria.Dominio
{
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(0, 9);
            Situacao = SituacaoConta.Criada;
            Cliente = cliente ?? throw new Exception("Cliente deve ser informado");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);
            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }


        private void SetaSenha(string senha)
        {
            senha = senha.ValidaStringVazia();

            //  \d{3}	Corresponder a três dígitos decimais.
            // -	Corresponder a um hífen.
            // \d{2}	Corresponde a dois dígitos decimais.
            // \d{4}	Corresponder a quatro dígitos decimais.
            if (!Regex.IsMatch(senha, @"^\d{3}-\d{2}-\d{4}$"))
            {
                throw new Exception("senha inválida");
            }

            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if(Senha != senha)
            {
                throw new Exception("Senha inválida.");
            }

            if (Saldo < valor)
            {
                throw new Exception("Saldo insuficiente");
            }

            Saldo = Saldo - valor;
        }
        
        public int NumeroConta { get; init; }
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }

    }
}
