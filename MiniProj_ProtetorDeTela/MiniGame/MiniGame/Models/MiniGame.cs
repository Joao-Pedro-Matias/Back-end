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

    MyCharacter character;
    MyRectangle floor;
    bool spacePressed = false;
    int[] Floor;
    int[] Character;
    MyRectangle tree;
    bool Collision;




    // ********************************************************************
    private Timer ControlTimer;

    public MiniGame()
    {
        this.DoubleBuffered = true;                     // evita flickering
        this.WindowState = FormWindowState.Maximized;   // Maximiza a janela
        this.KeyPreview = true;                         //Habilita o recebimento de eventos do teclado
        this.BackColor = Color.FromArgb(135, 206, 250); // Define a cor de background

        ControlTimer = new Timer();                     // Inicializa o temporizador de controle
        ControlTimer.Interval = 16;                     // 16 ms =~ 60 fps


        Floor = new int[2];
        Character = new int[4];

        ControlTimer.Tick += (s, e) =>                  // Controle da animação
        {
            // ****** Mova suas formas geométricas aqui ******

            if (!Collision)
            {

                Floor = floor.Move();

                Character = character.Move(ClientSize.Width, ClientSize.Height, Floor, spacePressed);

                Collision = tree.Move(Character);


                // ***********************************************
                Invalidate(); // Força a tela a ser redesenhada.

            }
        }; // Função anônima disparada pelo ControlTimer a cada Interval (ms)
        ControlTimer.Start();
    }

    //Verifica se o espaço foi precionado 
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

        character = new MyCharacter(100, 300, 0, 0, 0, 10);

        floor = new MyRectangle(0, ClientSize.Height - 50, ClientSize.Width / 4, 50, 3, 0, Color.FromArgb(101, 67, 33));

        tree = new MyRectangle(ClientSize.Width / 2, ClientSize.Height / 2, 50, ClientSize.Height / 2, 3, 0, Color.FromArgb(101, 67, 33));

        // ****************************************************
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // ****** Desenhe suas formas geométricas aqui *******

        character.Draw(e.Graphics);

        floor.Draw(e.Graphics);

        tree.Draw(e.Graphics);

        // ***************************************************

    }
}