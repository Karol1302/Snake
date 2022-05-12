using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Snake : Form
    {
        int cols = 50, rows = 25, score = 0, dx = 0, dy = 0, front = 0, back = 0;

        Piece [] snake = new Piece[1250];
        List<int> avaiable = new List<int>();
        bool[,] visit;
        Random R =  new Random();
        Timer T = new Timer();  

        public Snake()
        {

            InitializeComponent();
            intial();
            launchTimer();
        }

        private void launchTimer()
        {
            T.Interval = 50;
            T.Tick += move;
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            switch(e.KeyCode)
            {
                case Keys.Right:
                    dx = 20;
                    break;
                case Keys.Up:
                    dy = -20;
                    break;
                case Keys.Left:
                    dx = -20;
                    break;
                case Keys.Down:
                    dy = 20;
                    break;

            }
        }

        private void move(object sender, EventArgs e)
        {
            int x = snake[front].Location.X, y = snake[front].Location.Y;
            if (dx == 0 && dy == 0) return;
            if(gameover(x + dx, y + dy))
            {
                T.Stop();
                MessageBox.Show("Game Over!");
                return;
            }
            if(collisionfood(x + dx, y + dy))
            {
                score += 1;
                scorelbl.Text = "Score: " + score.ToString();
                if (hits((y + dy) / 20, (x + dx) / 20)) return;
                Piece head = new Piece(x + dx, y + dy);
                front = (front - 1 + 1250) / 1250;
                snake[front] = head;
                visit[head.Location.Y / 20, head.Location.X / 20] = true;
                Controls.Add(head);
                RandomFood();
            }
            else
            {
                if (hits((y + dy) / 20, (x + dx) / 20)) return;
                visit[snake[back].Location.Y / 20, Location.X / 20] = false;
                front = (front - 1 + 1250) % 1250;
                snake[front] = snake[back];
                snake[front].Location = new Point(x + dx, y + dy);
                back = (back - 1 + 1250) % 1250;
                visit[(y + dy) / 20, (x - dx) / 20] = true;
            }
        }

        private void RandomFood()
        {
            avaiable.Clear();
            for(int i = 0; i < rows; i++)
                for(int j = 0; j < cols; j++)
                    if(!visit[i,j])avaiable.Add(i + cols + j);
            int idx = R.Next(avaiable.Count) % avaiable.Count;
            food.Left = (avaiable[idx] * 20) % Width;
            food.Top = (avaiable[idx] * 20) % Width * 20;

        }

        private bool hits(int x, int y)
        {
            if(visit[x, y])
            {
                T.Stop();
                MessageBox.Show("Snake hits his body!");
                return true;
            }
            return false;
            
        }

        private bool collisionfood(int x, int y)
        {
            return x == food.Location.X && y == food.Location.Y;
        }

        private bool gameover(int x, int y)
        {
            return x < 0 || y < 0 || x > 980 || y > 480;
        }

        private void intial()
        {
            visit = new bool [rows, cols];
            Piece head = new Piece((R.Next() % cols) * 20,(R.Next() % rows) * 20 );
            food.Location = new Point((R.Next() % cols) * 20, (R.Next() % rows) * 20);
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    visit[i,j] = false;
                    avaiable.Add(i * cols +j);

                }
            }
            visit[head.Location.Y / 20, head.Location.X / 20] = true;
            avaiable.Remove(head.Location.Y / 20 * cols + head.Location.X / 20);  
            Controls.Add(head); snake[front] = head;


        }
    }
}
