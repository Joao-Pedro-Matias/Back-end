namespace Models;

using Models.BaseShapes;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class ScreenSaver : Form
{
    // ******* Declare suas formas geométricas aqui (escopo global) *******
    
    MyRectangle[] Shapes = new MyRectangle[2];

    // ********************************************************************
    private Timer ControlTimer;

    public ScreenSaver()
    {
        this.DoubleBuffered = true;                     // evita flickering
        this.WindowState = FormWindowState.Maximized;   // Maximiza a janela
        // Define a cor de background 
        this.BackColor = Color.Black;
        
        
        this.BackgroundImage = Image.FromFile("Andre.jpeg");
        this.BackgroundImageLayout = ImageLayout.Stretch;               
        
        // Inicializa o temporizador de controle
        ControlTimer = new Timer();
        ControlTimer.Interval = 16;                     // 16 ms = ~60 fps
        // Controle da animação
        ControlTimer.Tick += (s, e) =>
        {
            // ****** Mova suas formas geométricas aqui ******
            foreach (var shape in Shapes)
                shape.Move();

            // ***********************************************
            Invalidate(); // Foça a tela a ser redesenhada.
        }; // Função anônima disparada pelo ControlTimer a cada Interval (ms)
        ControlTimer.Start();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // ****** Instancie suas formas geométricas aqui ******

                
        Shapes[0] = new MyRectangle(ClientSize.Width, ClientSize.Height);
        Shapes[1] = new MyRectangle(ClientSize.Width, ClientSize.Height);

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