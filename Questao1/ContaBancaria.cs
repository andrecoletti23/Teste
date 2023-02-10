using System.Globalization;

namespace Questao1
{
    class ContaBancaria {
      public class Conta
    {
        public int Numero { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        private const double TaxaSaque = 3.50;

        public Conta(int numero, string titular, double saldo)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldo;
        }

        public Conta(int numero, string titular) : this(numero, titular, 0) { }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
 
            Saldo -= valor + TaxaSaque;
        }

        public override string ToString()
        {
            return "Conta " + Numero + ", Titular: " + Titular + ", Saldo: $ " + Saldo.ToString("F2");
        }
       
    }
}
