using System.Dynamic;

namespace Models.BaseShapes;

public abstract class Shape
{
    //Atributos
    protected int X;
    protected int Y;
    protected int XVel;
    protected int YVel;
    protected int Width;
    protected int Height;
    protected Color ColorShape;
    private Random Rand = new Random();

    public bool Collision;



    // Construtores

    public Shape(int x, int y, Color color, int width, int height, int xVel, int yVel)
    {
        X = x;
        Y = y;
        XVel = xVel;
        YVel = yVel;
        Width = width;
        Height = height;
        ColorShape = color;
    }

    public Shape(int xLimit, int yLimit)
    {
        //Altura e Largura Aleatórios
        Width = Rand.Next(50, 250);
        Height = Rand.Next(50, 250);

        //Posição Aleatória
        X = Rand.Next(0, xLimit - Width);
        Y = Rand.Next(0, yLimit - Height);

        //Cor Aleatória
        ColorShape = ColorGenerate();

        //Velocidade != 0
        do
            XVel = Rand.Next(-10, 10);
        while (XVel == 0);

        do
            YVel = Rand.Next(-10, 10);
        while (YVel == 0);

    }
    //Métodos

    public bool Move(int xLimit, int yLimit)
    {
        Collision = false;
        
        if (X + Width > xLimit + XVel && XVel > 0)
        {
            XVel *= -1;
            ColorShape = ColorGenerate();
        }

        if (X < 0 - XVel && XVel < 0)
        {
            XVel *= -1;
            ColorShape = ColorGenerate();

        }


        if (Y + Height > yLimit + YVel && YVel > 0)
        {
            YVel *= -1;
            ColorShape = ColorGenerate();
        }

        if (Y < 0 - YVel && YVel < 0)
        {
            YVel *= -1;
            ColorShape = ColorGenerate();
        }

        X += XVel;
        Y += YVel;

        return Collision;
    }

    private Color ColorGenerate()
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