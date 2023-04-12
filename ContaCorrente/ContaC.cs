using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    class Movimentacao
    {
        public decimal Valor { get; set; }
        public bool Credito { get; set; }

        public Movimentacao(decimal valor, bool credito)
        {
            Valor = valor;
            Credito = credito;
        }
    }

    class ContaCorrente
    {
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public bool Especial { get; set; }
        public decimal Limite { get; set; }
        private List<Movimentacao> Movimentacoes { get; set; }

        public ContaCorrente(int numero, decimal saldo = 0, bool especial = false, decimal limite = 0)
        {
            Numero = numero;
            Saldo = saldo;
            Especial = especial;
            Limite = limite;
            Movimentacoes = new List<Movimentacao>();
        }

        public void Saque(decimal valor)
        {
            if (Saldo + Limite >= valor)
            {
                Saldo -= valor;
                Movimentacoes.Add(new Movimentacao(valor, false));
                Console.WriteLine("Saque realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para efetuar o saque.");
            }
        }

        public void Deposito(decimal valor)
        {
            Saldo += valor;
            Movimentacoes.Add(new Movimentacao(valor, true));
            Console.WriteLine("Depósito realizado com sucesso!");
        }

        public void VisualizarSaldo()
        {
            Console.WriteLine($"Saldo atual: R${Saldo}");
        }

        public void VisualizarExtrato()
        {
            Console.WriteLine($"Extrato da conta {Numero}:");
            foreach (var movimentacao in Movimentacoes)
            {
                if (movimentacao.Credito)
                {
                    Console.WriteLine($"Crédito: R${movimentacao.Valor}");
                }
                else
                {
                    Console.WriteLine($"Débito: R${movimentacao.Valor}");
                }
            }
        }

        public void Transferencia(decimal valor, ContaCorrente contaDestino)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Movimentacoes.Add(new Movimentacao(valor, false));
                contaDestino.Deposito(valor);
                Console.WriteLine("Transferência realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para efetuar a transferência.");
            }
        }
    }
}
