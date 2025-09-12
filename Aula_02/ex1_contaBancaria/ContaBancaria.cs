public class ContaBancaria
{
    //Atributos

    private int Numero;

    private string Titular;

    private double Saldo;

    // Construtores

    public ContaBancaria(int numero, string titular) {
        Numero = numero;
        Titular = titular;
        Saldo = 0.0;
    }

    //Métodos

    public bool Depositar(int numero, double valor)
    {
        if(Numero!=numero || valor <= 0)
            return false;
        
        Saldo += valor;
        return true;
        
    }

    public bool Sacar(int numero, double valor)
    {
        if(Numero!=numero || valor <= 0 || valor > Saldo)
        Console.Write($" Não foi possível realizar o Saque de ${valor} na conta: {numero}\n\n");
        return false;
        
        Saldo -= valor;
        return true;

    }

    //ToString()

    public override string ToString()
    {
        return $" Conta N: {Numero}\n Titular: {Titular}\n Saldo: {Saldo}\n";
    }
}