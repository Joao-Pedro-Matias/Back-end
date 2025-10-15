using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Models.BaseShapes;

public class MyRectangle : Shape
{
    //Atributos    

    // Construtorest 
    public MyRectangle(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
    }


    //Métodos     

    public void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillRectangle(brush, X, Y, Width, Height);
    }

}