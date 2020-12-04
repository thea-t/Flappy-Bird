using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FlappyBird
{
    class Score
    {
        SpriteFont m_font;
        int m_score = 0;

        public void Load(ContentManager Content)
        {
            m_font = Content.Load<SpriteFont>("Font");
        }

        public void Update(int increase)
        {
            m_score += increase;
        }

        public void Draw(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            spriteBatch.DrawString(m_font, "Score:" + m_score, new Vector2(xPos, yPos), Color.White);
        }
    }
}
