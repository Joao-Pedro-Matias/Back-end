Character c1 = new Character("Goku");
Character c2 = new Character("Vegeta");


Console.Clear();
Console.WriteLine("Que comece a Luta");
Console.WriteLine($"{c1.Name} vs {c2.Name}");

Console.WriteLine(c1);
Console.WriteLine(c2);

Console.WriteLine("Pressione Enter para continuar");
Console.ReadLine();

do
{
    // Limpando a tela e inicializando uma nova rodada
    Console.Clear();
    Console.WriteLine("Nova Rodada: ");

    //Rodada de ataques

    try
    {
        c1.Attack(c2);
        c2.Attack(c1);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }


    // Resultados da rodada
    Console.WriteLine(c1);
    Console.WriteLine(c2);

    //Travar a tela
    Console.WriteLine("Pressione Enter para continuar");
    Console.ReadLine();


    } while (c1.IsAlive && c2.IsAlive);

if (c1.IsAlive)
    Console.WriteLine($"Parabéns, {c1.Name}! Você ganhou");
if (c2.IsAlive)
    Console.WriteLine($"Parabéns,{c2.Name}! Você ganhou");