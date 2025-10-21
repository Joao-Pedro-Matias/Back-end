using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Models.BaseShapes;

public class MyRectangle : Shape
{
    //Atributos    

    // Construtores 
    public MyRectangle(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
    }

    //Métodos     

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillRectangle(brush, X, Y, Width, Height);
    }

}