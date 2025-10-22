using System.Drawing;
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
    protected Random Rand = new Random();

    // Construtores

    public Shape(int x, int y, int width, int height, int xVel, int yVel, Color color)
    {
        X = x;
        Y = y;
        XVel = xVel;
        YVel = yVel;
        Width = width;
        Height = height;
        ColorShape = color;
    }

    public Shape(int x, int y, int width, int height, int xVel, int yVel)
    {
        X = x;
        Y = y;
        XVel = xVel;
        YVel = yVel;
        Width = width;
        Height = height;
    }


    public Shape(int xLimit, int yLimit)
    {
        //Altura e Largura Aleatórios
        Width = Rand.Next(50, 150);
        Height = Rand.Next(50, 150);

        //Posição Aleatória
        X = Rand.Next(0, xLimit - Width);
        Y = Rand.Next(0, yLimit - Height);

        //Velocidade != 0
        do
            XVel = Rand.Next(-10, 10);
        while (XVel == 0);

        do
            YVel = Rand.Next(-10, 10);
        while (YVel == 0);

    }
    //Métodos

    public virtual void Move(int xLimit, int yLimit, bool jump) //Move Padrão
    {
        X -= XVel;
    }

    public virtual void Move(int xLimit, int yLimit, int yFloor, bool jump) //Move Character
    {
    }
    
    public virtual int Move()  //Move Floor
    {
        X -= XVel;
        return Y;
    }

    public abstract void Draw(Graphics g);

    //ToString
    public override string ToString()
    {
        return $"Pos X: {X}, Pos Y: {Y}, Cor: {ColorShape}";

    }
}