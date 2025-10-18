namespace Models;

using Models.BaseShapes;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class ScreenSaver : Form
{
    // ******* Declare suas formas geométricas aqui (escopo global) *******
    Shape[] Shapes = new Shape[5];


    // ********************************************************************
    private Timer ControlTimer;

    public ScreenSaver()
    {
        this.DoubleBuffered = true;                     // evita flickering
        this.WindowState = FormWindowState.Maximized;   // Maximiza a janela
        // Define a cor de background 
        this.BackColor = Color.Black;

        /*
        this.BackgroundImage = Image.FromFile("./Fotos/Andre1.jpeg");
        this.BackgroundImageLayout = ImageLayout.Stretch;  
        */


        // Inicializa o temporizador de controle
        ControlTimer = new Timer();
        ControlTimer.Interval = 16;                     // 16 ms =~ 60 fps
        // Controle da animação
        ControlTimer.Tick += (s, e) =>
        {
            // ****** Mova suas formas geométricas aqui ******

            foreach (var shape in Shapes)
                shape.Move(ClientSize.Width, ClientSize.Height);

            // ***********************************************
            Invalidate(); // Força a tela a ser redesenhada.
        }; // Função anônima disparada pelo ControlTimer a cada Interval (ms)
        ControlTimer.Start();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // ****** Instancie suas formas geométricas aqui ******

        int Len = Shapes.Length;

        if (Len % 4 != 0)
        {
            if (Shapes.Length % 4 == 1)
            {
                Shapes[Shapes.Length - 1] = new MyRectangle(ClientSize.Width, ClientSize.Height);
                Len--;
            }

            if (Shapes.Length % 4 == 2)
            {
                Shapes[Shapes.Length - 1] = new MyRectangle(ClientSize.Width, ClientSize.Height);
                Shapes[Shapes.Length - 2] = new MySquare(ClientSize.Width, ClientSize.Height);
                Len =-2;
            }
            
            if (Shapes.Length % 4 == 3)
            {
                Shapes[Shapes.Length - 1] = new MyRectangle(ClientSize.Width, ClientSize.Height);
                Shapes[Shapes.Length - 2] = new MySquare(ClientSize.Width, ClientSize.Height);
                Shapes[Shapes.Length - 3] = new MyCircle(ClientSize.Width, ClientSize.Height);
                Len =-3;
            }
        }

        for (int i = 0; i < Len / 4; i++)
        {
            Shapes[i] = new MyRectangle(ClientSize.Width, ClientSize.Height);
            Shapes[i + (Len / 4)] = new MySquare(ClientSize.Width, ClientSize.Height);
            Shapes[i + ((Len / 4) * 2)] = new MyEllipse(ClientSize.Width, ClientSize.Height);
            Shapes[i + ((Len / 4) * 3)] = new MyCircle(ClientSize.Width, ClientSize.Height);
        }




        // ****************************************************
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // ****** Desenhe suas formas geométricas aqui *******

        foreach (var shape in Shapes)
            shape.Draw(e.Graphics);

        // ***************************************************

    }
}