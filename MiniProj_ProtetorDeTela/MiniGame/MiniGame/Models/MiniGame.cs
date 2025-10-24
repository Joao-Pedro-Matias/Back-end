namespace Models;

using Models.BaseShapes;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class MiniGame : Form
{
    // ******* Declare suas formas geométricas aqui (escopo global) *******
    MyCharacter character;
    MyObstacle floor;
    bool spacePressed;
    bool enterPressed;
    int[] Floor;
    int[] HitBoxCharacter;
    int NewObstacle=0;
    int NewObstaclePos;
    MyObstacle obstacle1;
    MyObstacle obstacle2;
    int Collision;
    int[] HitBoxObstacle;
    int Debug;
    MyObstacle[] Obstacles = new MyObstacle[5];





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
        HitBoxCharacter = new int[4];

        ControlTimer.Tick += (s, e) =>                  // Controle da animação
        {
            // ****** Mova suas formas geométricas aqui ******

            

            if (Collision == 0)
            {
                Floor = floor.Move();

                HitBoxCharacter = character.Move(ClientSize.Width, ClientSize.Height, Floor, spacePressed);

                HitBoxObstacle = obstacle1.Move(HitBoxCharacter);
                Collision += HitBoxObstacle[0];
                HitBoxObstacle = obstacle2.Move(HitBoxCharacter);
                Collision += HitBoxObstacle[0];


                int i = 0;
                foreach (var obstacle in Obstacles)
                {
                    HitBoxObstacle = obstacle.Move(HitBoxCharacter);
                    Collision += HitBoxObstacle[0];
                    if (HitBoxObstacle[1] < 0)
                    {
                        NewObstacle++;
                        NewObstaclePos = i;
                    }
                    i++;
                }

                // ***********************************************
                NewOnPaint(NewObstacle, NewObstaclePos, HitBoxObstacle[1]);
                Invalidate(); // Força a tela a ser redesenhada.
                NewObstacle = 0;
            }

            if (enterPressed)
                Debug = 1;

            if (Debug >= 1 && Debug < 40)
            {
                Floor = floor.Move();

                HitBoxCharacter = character.Move(ClientSize.Width, ClientSize.Height, Floor, spacePressed);

                HitBoxObstacle = obstacle1.Move(HitBoxCharacter);
                HitBoxObstacle = obstacle2.Move(HitBoxCharacter);

                foreach (var obstacle in Obstacles)
                {
                    HitBoxObstacle = obstacle.Move(HitBoxCharacter);


                }

                // ***********************************************
                Invalidate(); // Força a tela a ser redesenhada.

                Debug++;
                Collision = 0;
            }
            else
                Debug = 0;

        }; // Função anônima disparada pelo ControlTimer a cada Interval (ms)
        ControlTimer.Start();
    }

    //Verifica se o espaço foi precionado 
    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
            spacePressed = true;

        if (e.KeyCode == Keys.Enter)
            enterPressed = true;

    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
            spacePressed = false;

        if (e.KeyCode == Keys.Enter)
            enterPressed = false;
    }




    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // ****** Instancie suas formas geométricas aqui ******

        character = new MyCharacter(100, 300);

        floor = new MyObstacle(0, ClientSize.Height - 50, ClientSize.Width / 4, 50, 7, 0, Color.FromArgb(101, 67, 33));

        obstacle1 = new MyObstacle(ClientSize.Width / 2, ClientSize.Height / 2, 150, ClientSize.Height / 2, 7, 0, Color.FromArgb(101, 67, 33), false);

        obstacle2 = new MyObstacle(ClientSize.Width / 2 + 500, 0, 150, ClientSize.Height / 2, 7, 0, Color.FromArgb(101, 67, 33), true);

        for (int i = 0; i < Obstacles.Length; i++)
            Obstacles[i] = new MyObstacle(ClientSize.Height, character.Height, ClientSize.Width / 2 + 500 + i * 500);



        // ****************************************************
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // ****** Desenhe suas formas geométricas aqui *******

        character.Draw(e.Graphics);

        floor.Draw(e.Graphics);

        obstacle1.Draw(e.Graphics);

        obstacle2.Draw(e.Graphics);

        foreach (var obstacle in Obstacles)
            obstacle.Draw(e.Graphics);

        // ***************************************************

    }

    protected void NewOnPaint(int newObstacle, int newObstaclePos, int last)
    {
        if (newObstacle != 0)
            Obstacles[newObstaclePos] = new MyObstacle(ClientSize.Height, character.Height, last);
    }
}