using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird
{
    //how to draw textures from other classes https://community.monogame.net/t/drawing-from-a-new-class-is-not-working/11878/5
    class Parallax : DrawableGameComponent
    {
        SpriteBatch m_SpriteBatch;
        PlayerSprite m_PlayerSprite;//jamie
        Score m_Score;//William
        Collider m_Collider;//joseph

        //store data

        Texture2D staticImage;
        Texture2D cloudImage;
        Texture2D mountain1Image;
        Texture2D mountain2Image;
        Texture2D mountain3Image;
        Texture2D m_BirdImage;
        Texture2D m_ColliderImage;

        Vector2 cloudPos;
        Vector2 mountain1Pos;
        Vector2 mountain2Pos;
        Vector2 mountain3Pos;


        float speed0 = 0.5f;
        float speed1 = 1;
        float speed2 = 2;
        float speed3 = 3;

        //empty constructor
        public Parallax(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            m_SpriteBatch = new SpriteBatch(GraphicsDevice);

            //load the textures
            staticImage = Game.Content.Load<Texture2D>("Sky");
            mountain1Image = Game.Content.Load<Texture2D>("Mountains1");
            mountain2Image = Game.Content.Load<Texture2D>("Mountains2");
            mountain3Image = Game.Content.Load<Texture2D>("Mountains3");
            cloudImage = Game.Content.Load<Texture2D>("Clouds");
            m_BirdImage = Game.Content.Load<Texture2D>("Bird1");
            m_ColliderImage = Game.Content.Load<Texture2D>("ColumnSprite");

            //creating instances of classes
            m_PlayerSprite = new PlayerSprite(m_BirdImage);//jamie
            m_Score = new Score(); //william
            m_Score.Load(Game.Content);
            m_Collider = new Collider(m_ColliderImage);//joseph
        }

        //call everyone's update functions
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            m_PlayerSprite.Update();
            m_Score.Update(1);
            m_Collider.Update(new Rectangle((int)m_PlayerSprite.Position.X, (int)m_PlayerSprite.Position.Y, m_BirdImage.Width, m_BirdImage.Height), new Rectangle((int)m_Collider.pipeX, (int)m_Collider.pipeY, m_ColliderImage.Width, m_ColliderImage.Height));
            m_Collider.pipeX -= 5;
            if (m_Collider.collide == true)
            {
                m_Score.Update(-10);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            //increment pos
            cloudPos += new Vector2(-1, 0) * speed0;
            mountain1Pos += new Vector2(-1, 0) * speed1;
            mountain2Pos += new Vector2(-1, 0) * speed2;
            mountain3Pos += new Vector2(-1, 0) * speed3;

            //draw the textures
            m_SpriteBatch.Begin();
            m_SpriteBatch.Draw(staticImage, new Vector2(0, 0));

            //m1
            m_SpriteBatch.Draw(mountain1Image, mountain1Pos);
            if (mountain1Pos.X <= 0)
            {
                m_SpriteBatch.Draw(mountain1Image, new Vector2(mountain1Pos.X + mountain1Image.Width, mountain1Pos.Y));
            }
            if(mountain1Pos.X <= -mountain1Image.Width)
            {
                mountain1Pos = new Vector2(0,0);
            }

            //m2
            m_SpriteBatch.Draw(mountain2Image, mountain2Pos);
            if (mountain2Pos.X <= 0)
            {
                m_SpriteBatch.Draw(mountain2Image, new Vector2(mountain2Pos.X + mountain2Image.Width, mountain2Pos.Y));
            }
            if (mountain2Pos.X <= -mountain2Image.Width)
            {
                mountain2Pos = new Vector2(0, 0);
            }

            //c
            m_SpriteBatch.Draw(cloudImage, cloudPos);
            if (cloudPos.X <= 0)
            {
                m_SpriteBatch.Draw(cloudImage, new Vector2(cloudPos.X + cloudImage.Width, cloudPos.Y));
            }
            if (cloudPos.X <= -cloudImage.Width)
            {
                cloudPos = new Vector2(0, 0);
            }

            //m3
            m_SpriteBatch.Draw(mountain3Image, mountain3Pos);
            if (mountain3Pos.X <= 0)
            {
                m_SpriteBatch.Draw(mountain3Image, new Vector2(mountain3Pos.X + mountain3Image.Width, mountain3Pos.Y));
            }

            if (mountain3Pos.X <= -mountain3Image.Width)
            {
                mountain3Pos = new Vector2(0, 0);
            }

            //collider
            m_Collider.Draw(m_SpriteBatch);

            //bird
            m_PlayerSprite.Draw(m_SpriteBatch);
            
            //score
            m_Score.Draw(m_SpriteBatch, 1000,750);

            m_SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}