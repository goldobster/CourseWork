using CourseWork.Entities;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Image tankSheet;
        public Entity player;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.dirX = 0;
            player.dirY = 0;
            player.IsMoving = false;
            player.SetAnimationConfiguration(player.currentAnimation-2);
        }
        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -player.speed;
                    player.flipY = 1;
                    player.SetAnimationConfiguration(2);
                    break;
                case Keys.S:
                    player.dirY = player.speed;
                    player.flipY = -1;
                    player.SetAnimationConfiguration(2);
                    break;
                case Keys.A:
                    player.dirX = -player.speed;
                    player.flipX = -1;
                    player.SetAnimationConfiguration(3);
                    break;
                case Keys.D:
                    player.dirX = player.speed;
                    player.flipX = 1;
                    player.SetAnimationConfiguration(3);
                    break;


            }
            player.IsMoving = true;
            
        }
        
        public void Init()
        {
            tankSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\MainTank.png"));
            player = new Entity(100, 100, Hero.runFramesVertical, Hero.runFramesHorizontal, tankSheet);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (player.IsMoving)
            {
                player.move();
            }
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            player.PlayAnimation(g);
        }
    }
} 
