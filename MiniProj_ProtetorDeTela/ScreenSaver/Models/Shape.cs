namespace Models.BaseShapes;

public class Shape
{
    //Atributos
    public int X;
    public int Y;
    public Color ColorShape;

    // Construtores

    public Shape(int x, int y, Color color)
    {
        X = x;
        Y = y;
        ColorShape = color;
    }
    //Métodos

    //ToString
    public override string ToString()
    {
        return $"Pos X: {X}, Pos Y: {Y}, Cor: {ColorShape}";

    }
}