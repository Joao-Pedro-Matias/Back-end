using System.Reflection;
using System.Security;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Models.BaseShapes;

public class MyCharacter : Shape
{
    private Image Photo;
    private int Jump;

    public MyCharacter(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
        Photo = Image.FromFile("./Fotos/Andre4.jpeg");

        Width = Math.Max(20, Photo.Width / 7);
        Height = Math.Max(20, Photo.Height / 7);
    }

    public override void Move(int xLimit, int yLimit, bool jump)
    {

        if (jump)
            Jump = 1;                               //Verifica se o espaço foi precionado

            
        if (Y + Height + 20 < yLimit && YVel <= 10)
            YVel++;
        else
            YVel = 0;                               //Gravidade(Parando antes de sair da tela)

        if (Jump >= 1)
        {
            YVel = -6;
            Jump++;
            if (Jump >= 10)
                Jump = 0;
        }


            Y += YVel;
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(Photo, X, Y, Width, Height);
    }
}