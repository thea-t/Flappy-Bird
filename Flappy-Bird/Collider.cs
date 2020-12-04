using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    //Joseph G.
    class Collider
    {
        private Texture2D m_pipe;
        public Vector2 m_position;
        public float pipeX = 1000;
        public float pipeY = 500;
        public bool collide = false;
        public Collider(Texture2D pipe)
        {
            m_pipe = pipe;
          //  Rectangle pipeRec = new Rectangle(70, 20, 100, 200);
        }


        public void Update(Rectangle birdRec, Rectangle pipeRec) //bird rec is a place holder for the sprite rec
        {
            if (birdRec.Intersects(pipeRec))
            {
                //end game 
                collide = true;
            }
            if (birdRec.Intersects(pipeRec) == false)
            {
                //end game 
                collide = false;
            }
            



        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(m_pipe, new Vector2(pipeX, pipeY), new Rectangle(0, 0, m_pipe.Width, m_pipe.Height), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
        }
    }
}
