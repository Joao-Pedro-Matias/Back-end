using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Models.BaseShapes;

public class MyRectangle : Shape
{
    //Atributos    
    public int XLimit;
    public int YLimit;

    // Construtores
    public MyRectangle(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
        XLimit = xLimit;
        YLimit = yLimit;
    }

    //Métodos  

    public void Move()
    {
        if (X + Width > XLimit || X < 0)
        {
            xVel *= -1;
            ColorShape = ColorGenerate();
        }

        if (Y + Height > YLimit || Y < 0)
        {
            yVel *= -1;
            ColorShape = ColorGenerate();
        }
            
        X += xVel;
        Y += yVel;
    }

    public void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillRectangle(brush, X, Y, Width, Height);
    }

}