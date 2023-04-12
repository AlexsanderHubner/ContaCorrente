namespace ContaCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(1, 1000, false, 500);
            ContaCorrente conta2 = new ContaCorrente(2, 500, false, 300);

            conta1.Saque(200);

            conta2.Deposito(100);

            conta1.VisualizarSaldo();

            conta2.VisualizarExtrato();

            conta1.Transferencia(300, conta2);
        }
    }
}