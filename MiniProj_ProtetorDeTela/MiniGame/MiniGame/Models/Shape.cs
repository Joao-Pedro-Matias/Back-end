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
    private int Collision;
    private bool Cima;

    // Construtores

    public Shape(int x, int y, int width, int height, int xVel, int yVel, Color color, bool cima)
    {
        X = x;
        Y = y;
        XVel = xVel;
        YVel = yVel;
        Width = width;
        Height = height;
        ColorShape = color;
        Cima = cima;
    }

    public Shape(int x, int y, int width, int height, int xVel, int yVel, Color color) // Construtor Floor
    {
        X = x;
        Y = y;
        XVel = xVel;
        YVel = yVel;
        Width = width;
        Height = height;
        ColorShape = color;
    }

    public Shape(int x, int y, int yVel)    //Construtor Character
    {
        X = x;
        Y = y;
        XVel = 0;
        YVel = yVel;
    }


    //Métodos

    public virtual int Move(int[] character) //Move Padrão
    {
        Collision = 0;

        if (!Cima)
        {
            if (character[1] >= X && character[1] <= X + Width && character[3] >= Y)         //Verifica se ele bateu na ponta esquerda da árvore    
                Collision++;

            if (character[0] >= X && character[0] <= X + Width && character[3] >= Y)         //Verifica se ele bateu em cima da árvore    
                Collision++;
        }
        else
        {
            if (character[1] >= X && character[1] <= X + Width && character[2] <= Y + Height)         //Verifica se ele bateu na ponta esquerda da árvore    
                Collision++;

            if (character[0] >= X && character[0] <= X + Width && character[2] <= Y + Height)         //Verifica se ele bateu embaixo da árvore    
                Collision++;
        }

        X -= XVel;

        return Collision;
    }

    public virtual int[] Move(int xLimit, int yLimit, int[] floor, bool jump) //Move Character
    {
        return [0];
    }

    public virtual int[] Move()  //Move Floor
    {
        if (X + Width >= 0)
            X -= XVel;

        return [X + Width, Y];
    }

    public abstract void Draw(Graphics g);

    //ToString
    public override string ToString()
    {
        return $"Pos X: {X}, Pos Y: {Y}, Cor: {ColorShape}";

    }
}