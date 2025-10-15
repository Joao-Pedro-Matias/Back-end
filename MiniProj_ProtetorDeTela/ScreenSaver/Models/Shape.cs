namespace Models.BaseShapes;

public abstract class Shape
{
    //Atributos
    protected int X;
    protected int Y;
    protected int XLimit;
    protected int YLimit;
    protected int XVel;
    protected int YVel;
    protected int Width;
    protected int Height;
    protected Color ColorShape;
    protected Random Rand = new Random();

    // Construtores

    public Shape(int xLimit, int yLimit)
    {
        XLimit = xLimit;
        YLimit = yLimit;
        
        Width = Rand.Next(40, 100);
        Height = Rand.Next(40, 100);


        X = Rand.Next(0, XLimit);
        Y = Rand.Next(0, YLimit);
        ColorShape = ColorGenerate();

        XVel = Rand.Next(-10, 10);
        YVel = Rand.Next(-10, 10);

    }
    //Métodos
    
    public void Move()
    {
        if (X + Width > XLimit || X < 0)
        {
            XVel *= -1;
            ColorShape = ColorGenerate();
        }

        if (Y + Height > YLimit || Y < 0)
        {
            YVel *= -1;
            ColorShape = ColorGenerate();
        }
            
        X += XVel;
        Y += YVel;
    }

    private Color ColorGenerate()
    {
        int red = Rand.Next(0, 255);
        int green = Rand.Next(0, 255);
        int blue = Rand.Next(0, 255);

        return Color.FromArgb(red, green, blue);
    }

    //ToString
    public override string ToString()
    {
        return $"Pos X: {X}, Pos Y: {Y}, Cor: {ColorShape}";

    }
}