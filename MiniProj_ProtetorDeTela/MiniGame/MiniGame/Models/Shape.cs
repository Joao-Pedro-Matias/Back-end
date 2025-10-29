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
    public int Height { get; protected set; }
    protected Color ColorShape;
    protected Random Rand = new Random();
    private int Collision;
    private bool Cima;
    private int Sorteio;

    // Construtores

    public Shape(int x, int y, int width, int height, int xVel, int yVel, Color color, bool cima)   //Construtor do 1º obstáculo
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

    public Shape(int yLimit, int cHeigth, int last)   //Construtor dos obstáculos
    {                
        YVel = 0;
        XVel = 7;
        ColorShape = Color.FromArgb(101, 67, 33);

        Width = 150;
        Height = Rand.Next(yLimit/2, yLimit-cHeigth-100); 

        Sorteio = Rand.Next(0, 2);
        if (Sorteio == 0)
        {
            Y = 0;
            Cima = true;
        }
        else
        {
            Y = yLimit - Height;
            Cima = false;
        }


        X = last + 500;   
               
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

    public Shape(int x, int y)    //Construtor Character
    {
        X = x;
        Y = y;
        XVel = 0;
        YVel = 10;
    }


    //Métodos

    public virtual int[] Move(int[] character) //Move Padrão
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

        return [Collision, X + Width];
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