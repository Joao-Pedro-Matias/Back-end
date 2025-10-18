namespace Models.BaseShapes;

public class MyEllipse : Shape
{
    public MyEllipse(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
    }

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillEllipse(brush, X, Y, Width, Height);
    }
}