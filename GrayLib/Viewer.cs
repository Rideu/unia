using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;

using static System.Math;


namespace GrayLib
{
    public partial class Viewer : Renderer
    {
        public ContentManager Content;
        public SpriteBatch spriteBatch;
        public Viewport MonoViewport;
        public Texture2D Sample;
        public new Color BackColor;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MonoViewport = new Viewport(0, 0, Size.Width, Size.Height);
            Content = new ContentManager(Services, "Content");

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Viewport = MonoViewport = new Viewport(0, 0, Size.Width, Size.Height);
            base.Update();
        }

        public float rs, ars;
        public Vector2 Scaling = new Vector2(1f, 0f);



        public int FPS;
        float Elapse;
        int FramesPassed;

        protected override void Draw(GameTime gameTime)
        {

            //GraphicsDevice.Clear(BackColor);
            FramesPassed++;
        }
    }
}
