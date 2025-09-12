ContaBancaria conta1 = new ContaBancaria(1, "Andrezao");
ContaBancaria conta2 = new ContaBancaria(2, "Mesquitoudleds");

Console.WriteLine(conta1);
Console.WriteLine(conta2);

conta1.Depositar(1, 1000);
conta2.Depositar(2, 2000);
conta2.Sacar(3, 10);


Console.WriteLine(conta1);
Console.WriteLine(conta2);

