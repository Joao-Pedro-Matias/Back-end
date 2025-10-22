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

    public override void Move(int xLimit, int yLimit, int yFloor, bool jump)
    {

        if (jump)
            Jump = 1;                               //Verifica se o espaço foi precionado


        if (YVel <= 10)  //Gravidade(Max=10)         
            YVel++;
            
        if (Y + 200 > yFloor)
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
            
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(Photo, X, Y, Width, Height);
    }
}