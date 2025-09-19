// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

FightGame p1 = CriaPersonagem("teste");


FightGame CriaPersonagem(string name){
    return new FightGame(name);
}