using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{
    class PlayerSprite
    {
        private Texture2D Texture;
        public Vector2 Position;
        public Vector2 Origin;
        public float Rotation;

        public float FallRate = 5f;
        public float RotaVelo = 3f;

        public PlayerSprite(Texture2D texture)
        {
            Texture = texture;
            Position = new Vector2(100,100);//added
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Position.Y -= 30;

            }
            Position.Y += FallRate;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, null, Origin, Rotation, null, Color.White, SpriteEffects.None, 1f);
        }
    }
}
