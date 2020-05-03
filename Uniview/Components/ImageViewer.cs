using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Resources;

//using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Net.NetworkInformation;
using Threads = System.Threading;
using System.Net;
using System.IO;
using GrayLib;
using static GrayLib.Simplex;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Builder;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization;

namespace Uniview.Components
{
    public class ImageViewer : Viewer
    {
        SpriteBatch batch;
        protected override void Initialize()
        {
            Simplex.Init(GraphicsDevice);

            batch = new SpriteBatch(GraphicsDevice);
            PrimaryViewport = GraphicsDevice.Viewport;

            base.Initialize();
        }

        public event EventHandler<Point> ResizeRequired;

        Texture2D current_image;
        public Texture2D ShowImage(string path)
        {
            current_image?.Dispose();

            current_image = Texture2D.FromStream(GraphicsDevice, File.OpenRead(path));
            offset = Vector2.Zero;

            if (current_image.Bounds.Width > PrimaryViewport.Bounds.Width || current_image.Bounds.Height > PrimaryViewport.Bounds.Height)
            {
                ResizeRequired?.Invoke(this, current_image.Bounds.Size);
            }
            return current_image;
        }

        Vector2 offset;
        MouseState mss;
        Viewport PrimaryViewport;

        Vector2 offsetPos;
        bool lockOffsetPos;
        float scale = 1;

        protected override void Update(GameTime gameTime)
        {
            PrimaryViewport = GraphicsDevice.Viewport;
            //GraphicsDevice.Viewport = PrimaryViewport;
            GraphicsDevice.PresentationParameters.BackBufferWidth = PrimaryViewport.Width;
            GraphicsDevice.PresentationParameters.BackBufferHeight = PrimaryViewport.Height;
            EControl.Update(this);
            if (EControl.LeftPressed() && !lockOffsetPos)
            {
                Cursor = Cursors.Cross;
                offsetPos = EControl.MousePos - offset;
                lockOffsetPos = true;
            }

            if (EControl.LeftPressed() && lockOffsetPos)
                offset = EControl.MousePos - offsetPos;


            if (!EControl.LeftPressed() && lockOffsetPos)
            {
                Cursor = Cursors.Default;
                lockOffsetPos = false;
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            if (DesignMode)
                return;

            GraphicsDevice.Clear(BackColor.ToXNA());

            if (current_image != null)
            {
                var imageb = current_image.Bounds;
                var viewb = PrimaryViewport.Bounds;

                var position = new Vector2(viewb.Width / 2 - imageb.Width / 2, viewb.Height / 2 - imageb.Height / 2);

                batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
                {
                    var cpos = offset + position;
                    var boundmarker = current_image.Bounds.OffsetBy(cpos.ToPoint());
                    batch.DrawRect(boundmarker, Color.Gray);

                    batch.Draw(current_image, cpos, Color.White, 0, scale);
                }
                batch.End();

            }

            base.Draw(gameTime);
        }
    }
}
