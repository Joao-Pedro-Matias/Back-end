using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Models.BaseShapes;

public class MyObstacle : Shape
{
    //Atributos    

    // Construtores 
    public MyObstacle(int x, int y, int width, int height, int xVel, int yVel, Color color, bool cima) : base(x, y, width, height, xVel, yVel, color, cima)
    {
    }
    public MyObstacle(int x, int y, int width, int height, int xVel, int yVel, Color color) : base(x, y, width, height, xVel, yVel, color)
    {
    }

    //Métodos     

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillRectangle(brush, X, Y, Width, Height);
    }

}