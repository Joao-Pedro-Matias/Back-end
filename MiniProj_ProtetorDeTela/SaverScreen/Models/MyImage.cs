using System.Reflection;
using System.Security;
using System.Drawing;

namespace Models.BaseShapes;

public class MyImage : Shape
{
    private Image Photo;

    public MyImage(int xLimit, int yLimit) : base(xLimit, yLimit)
    {
        Photo = Image.FromFile("./Fotos/Andre1.jpeg");

        Width = Photo.Width;
        Height = Photo.Height;
    }

    public override void Move(int xLimit, int yLimit)
    {
        if (X + Width > xLimit + XVel && XVel > 0)
        {
            XVel *= -1;
            ImageGenerate();
        }

        if (X < 0 - XVel && XVel < 0)
        {
            XVel *= -1;
            ImageGenerate();
        }

        if (Y + Height > yLimit + YVel && YVel > 0)
        {
            YVel *= -1;
            ImageGenerate();
        }

        if (Y < 0 - YVel && YVel < 0)
        {
            YVel *= -1;
            ImageGenerate();
        }

        X += XVel;
        Y += YVel;
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(Photo, X, Y, Width, Height);
    }

    public void ImageGenerate()
    {
        Image[] Images = new Image[5];
        double Area;
        double NewWidth = 0;
        double NewHeight = 0;

        Images[0] = Image.FromFile("./Fotos/Andre1.jpeg");
        Images[1] = Image.FromFile("./Fotos/Andre2.jpeg");
        Images[2] = Image.FromFile("./Fotos/Andre4.jpeg");
        Images[3] = Image.FromFile("./Fotos/Dogs.jpeg");
        Images[4] = Image.FromFile("./Fotos/Fofinho.jpeg");

        Photo = Images[Rand.Next(0, 5)];

        Area = Photo.Width * Photo.Height;

        for (double i = 1; Area > 40000; i+=0.1)
        {
            NewWidth = Photo.Width / i;
            NewHeight = Photo.Height / i;
            Area = NewWidth * NewHeight;
        }

        Width = (int)NewWidth;
        Height = (int)NewHeight;

    }
}