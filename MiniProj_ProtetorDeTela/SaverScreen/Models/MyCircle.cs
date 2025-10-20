using Models.BaseShapes;

public class MyCircle : MyEllipse
{
    public MyCircle(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
        Width = Height;
    }

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillEllipse(brush, X, Y, Width, Height);
    }
}