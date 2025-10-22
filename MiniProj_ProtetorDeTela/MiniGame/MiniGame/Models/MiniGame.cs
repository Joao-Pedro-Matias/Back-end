namespace Models;

using Models.BaseShapes;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class MiniGame : Form
{
    // ******* Declare suas formas geométricas aqui (escopo global) *******
    Shape[] Shapes = new Shape[7];

    MyCharacter c1;
    bool spacePressed = false;


    // ********************************************************************
    private Timer ControlTimer;

    public MiniGame()
    {
        this.DoubleBuffered = true;                     // evita flickering
        this.WindowState = FormWindowState.Maximized;   // Maximiza a janela
        this.KeyPreview = true;                         //Habilita o recebimento de eventos do teclado
        // Define a cor de background 
        this.BackColor = Color.FromArgb(135, 206, 250);

        // Inicializa o temporizador de controle
        ControlTimer = new Timer();
        ControlTimer.Interval = 16;                     // 16 ms =~ 60 fps
        // Controle da animação
        ControlTimer.Tick += (s, e) =>
        {
            // ****** Mova suas formas geométricas aqui ******

            c1.Move(ClientSize.Width, ClientSize.Height, spacePressed);

            // ***********************************************
            Invalidate(); // Força a tela a ser redesenhada.
        }; // Função anônima disparada pelo ControlTimer a cada Interval (ms)
        ControlTimer.Start();
    }


    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
            spacePressed = true;
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
            spacePressed = false;
    }


    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // ****** Instancie suas formas geométricas aqui ******

        c1 = new MyCharacter(100,300,0, 0, 0, 10);

        // ****************************************************
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // ****** Desenhe suas formas geométricas aqui *******

        c1.Draw(e.Graphics);

        // ***************************************************

    }
}