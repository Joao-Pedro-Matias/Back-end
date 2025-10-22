using System.Reflection;
using System.Security;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Models.BaseShapes;

public class MyCharacter : Shape
{
    private Image Photo;
    private int Jump;

    public MyCharacter(int x, int y, int width, int height, int xVel, int yVel) : base(x, y, width, height, xVel, yVel)
    {
        Photo = Image.FromFile("./Fotos/AndreMochila.png");

        Width = Math.Max(20, Photo.Width / 7);
        Height = Math.Max(20, Photo.Height / 7);
    }

    public override int Move(int xLimit, int yLimit, int yFloor, bool jump)
    {

        if (jump)
            Jump = 1;                               //Verifica se o espaço foi precionado

            
        if (Y + Height + 20 < yLimit)
            if (YVel<=10)
                YVel++;                               //Gravidade(Parando antes de sair da tela)

        if (Jump >= 1)
        {
            YVel = -6;
            Jump++;
            if (Jump >= 10)
                Jump = 0;
        }

        if (YVel > 0)
            Photo = Image.FromFile("./Fotos/AndreMochila.png");
        else
            Photo = Image.FromFile("./Fotos/AndreMochilaHigh.png");


        Y += YVel;
            
        return 0;
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(Photo, X, Y, Width, Height);
    }
}