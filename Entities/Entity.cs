using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Entities
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool IsMoving;
        public int speed;

        public int runFramesVertical;
        public int runFramesHorizontal;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;
        public int flipY;
        public int flipX;

        public int size;

        public Image spriteSheet;

        public Entity(int posX, int posY, int runFramesVertical, int runFramesHorizontal, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.runFramesVertical = runFramesVertical;
            this.runFramesHorizontal = runFramesHorizontal;
            this.spriteSheet = spriteSheet;
            size = 64;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = 1;
            flipY = 1;
            flipX = 1;
            speed = 1;
        }

        public void move()
        {
            posX += dirX;
            posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentAnimation <= 1)
            {
                currentAnimation += 2;
            }
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX - flipX * size / 2, posY - flipY*size/2), new Size(flipX*size, flipY*size)), size*currentFrame, size*(currentAnimation-2), size, size, GraphicsUnit.Pixel);
            if (currentFrame < currentLimit - 1)
            {
                currentFrame++;
            }
            else currentFrame = 0;
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;
            switch (currentAnimation)
            {
                case 0:
                    currentLimit = 1;
                    break;
                case 1:
                    currentLimit = 1; 
                    break;
                case 2:
                    currentLimit = runFramesVertical;
                    break;
                case 3:
                    currentLimit = runFramesHorizontal;
                    break;
            }
        }
    }
}
