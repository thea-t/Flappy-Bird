using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//William
namespace FlappyBird
{
    class Score
    {
        SpriteFont m_font;
        int m_score = 0;

        //loads the font
        public void Load(ContentManager Content)
        {
            m_font = Content.Load<SpriteFont>("Font");
        }

        //score update
        public void Update(int increase)
        {
            m_score += increase;
        }

        //draw score
        public void Draw(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            spriteBatch.DrawString(m_font, "Score:" + m_score, new Vector2(xPos, yPos), Color.White);
        }
    }
}
