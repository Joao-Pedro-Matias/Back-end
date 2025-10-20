using Models.BaseShapes;

public class MySquare : MyRectangle
{

    public MySquare(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
        Height = Width;
    }

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(ColorShape);
        g.FillRectangle(brush, X, Y, Width, Height);
    }

}