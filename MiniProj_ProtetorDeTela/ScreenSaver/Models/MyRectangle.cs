namespace Models.BaseShapes;

public class MyRectangle : Shape
{
    //Atrubutos
    public int Width;
    public int Height;

    // Construtores
    public MyRectangle(int x, int y, Color color, int width, int height) : base(x, y, color)
    {
        Width = width;
        Height = height;

    }

    //Métodos  

    public void Move(int xLimit, int yLimit)
    {
        X++;
        Y++;
    }

    public void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillRectangle(brush, X, Y, Width, Height);
    }

}