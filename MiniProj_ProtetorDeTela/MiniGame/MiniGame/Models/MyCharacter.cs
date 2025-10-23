using System.Reflection;
using System.Security;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Models.BaseShapes;

public class MyCharacter : Shape
{
    private Image Photo;
    private int Jump;

    public MyCharacter(int x, int y, int yVel) : base(x, y, yVel)
    {
        Photo = Image.FromFile("./Fotos/AndreMochila.png");

        Width = Math.Max(20, Photo.Width / 10);
        Height = Math.Max(20, Photo.Height / 10);
    }

    public override int[] Move(int xLimit, int yLimit, int[] floor, bool jump)
    {

        if (jump)       //Verifica se o espaço foi precionado
            Jump = 1;


        if (YVel <= 10) //Gravidade(Max=10)         
            YVel++;

        if (Y + Height > floor[1] && X + 35 < floor[0])
            YVel = 0;

        if (Jump >= 1)
        {
            YVel = -6;
            Jump++;
            if (Jump >= 10)
                Jump = 0;
        }

        if (YVel >= 0)
            Photo = Image.FromFile("./Fotos/AndreMochila.png");
        else
            Photo = Image.FromFile("./Fotos/AndreMochilaHigh.png");

        Y += YVel;

        return [X+35, X + Width-30, Y+15, Y + Height];
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(Photo, X, Y, Width, Height);
    }
}