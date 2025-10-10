namespace Models.BaseShapes;

public class Shape
{
    //Atributos
    public int X;
    public int Y;
    public int xVel;
    public int yVel;
    public int Width;
    public int Height;
    public Color ColorShape;
    public Random Rand = new Random();

    // Construtores

    public Shape(int xLimit, int yLimit)
    {
        Width = Rand.Next(40, 100);
        Height = Rand.Next(40, 100);        
        X = Rand.Next(0, xLimit);
        Y = Rand.Next(0, yLimit);
        ColorShape = ColorGenerate();
        xVel = Rand.Next(-7, 7);
        yVel = Rand.Next(-7, 7);

    }
    //Métodos

    public Color ColorGenerate()
    {
        int red = Rand.Next(0, 255);
        int green = Rand.Next(0, 255);
        int blue = Rand.Next(0, 255);

        return Color.FromArgb(red, green, blue);
    }

    //ToString
    public override string ToString()
    {
        return $"Pos X: {X}, Pos Y: {Y}, Cor: {ColorShape}";

    }
}