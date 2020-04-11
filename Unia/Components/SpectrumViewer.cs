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
using UniaCore.Peripherals;
using NAudio;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;
using static UniaCore.Helper;
using UniaCore.Components;
using GrayLib;
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
using TwoMGFX;

namespace UniaCore.Components
{
    public class SpectrumViewer : Viewer
    {
        public Spectrum spectrum;

        Dictionary<string, string> ShaderLib = new Dictionary<string, string>();
        Effect e, ray;

        class MyLogger : ContentBuildLogger
        {
            public override void LogMessage(string message, params object[] messageArgs) { }
            public override void LogImportantMessage(string message, params object[] messageArgs) { }
            public override void LogWarning(string helpLink, ContentIdentity contentIdentity, string message, params object[] messageArgs) { }
        }

        class MyProcessorContext : ContentProcessorContext
        {
            public override string BuildConfiguration => string.Empty;
            public override string IntermediateDirectory => string.Empty;
            public override string OutputDirectory => string.Empty;
            public override string OutputFilename => string.Empty;

            public override OpaqueDataDictionary Parameters => parameters;
            OpaqueDataDictionary parameters = new OpaqueDataDictionary();

            public override ContentBuildLogger Logger => logger;
            ContentBuildLogger logger = new MyLogger();

            public override ContentIdentity SourceIdentity => new ContentIdentity { SourceFilename = "myshader.fx" };

            public override TargetPlatform TargetPlatform => TargetPlatform.Windows;
            public override GraphicsProfile TargetProfile => GraphicsProfile.Reach;

            public override void AddDependency(string filename)
            {
                throw new System.NotImplementedException();
            }

            public override void AddOutputFile(string filename)
            {
                throw new System.NotImplementedException();
            }

            public override TOutput BuildAndLoadAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName)
            {
                throw new System.NotImplementedException();
            }

            public override ExternalReference<TOutput> BuildAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName, string assetName)
            {
                throw new System.NotImplementedException();
            }

            public override TOutput Convert<TInput, TOutput>(TInput input, string processorName, OpaqueDataDictionary processorParameters)
            {
                throw new System.NotImplementedException();
            }
        }

        public Effect ProcessEffect(string path)
        {

            var ep = new EffectProcessor();
            EffectContent ec = new EffectContent();
            //var f = File.Create("Resources/bxaa.fx");
            ec.Identity = new ContentIdentity() { SourceFilename = path };
            var pc = new MyProcessorContext();
            try
            {
                var c = ep.Process(ec, pc);
                var e = new Effect(GraphicsDevice, c.GetEffectCode());
                e.Name = "primary_shader";
                return e;
            }
            catch (Exception e)
            {
                string err;
                //if ((err = e.Message.Replace("\\\\", "\\")).Contains(collMaker.effectpath))
                {
                    //collMaker.richTextBox2.AppendText(err);
                    //var lc = Regex.Matches(err, @"(?<=\()\d+|\d+(?=\))");
                    //var l = int.Parse(lc[0].Value);
                    //var c = int.Parse(lc[1].Value);
                    //int start = collMaker.richTextBox1.GetFirstCharIndexFromLine(l);
                    //int firstcharindex = collMaker.richTextBox1.GetFirstCharIndexFromLine(l - 1);

                    //int currentline = collMaker.richTextBox1.GetLineFromCharIndex(firstcharindex);

                    //string currentlinetext = collMaker.richTextBox1.Lines[currentline];

                    //collMaker.richTextBox1.Select(firstcharindex, currentlinetext.Length);
                    ////collMaker.richTextBox1.Select( = collMaker.richTextBox1.Lines[int.Parse(l)-1];
                    //collMaker.richTextBox1.SelectionColor = System.Drawing.Color.DarkRed;
                    //collMaker.richTextBox1.Select(0, 0);
                }
                //else
                //    collMaker.richTextBox2.AppendText(e.Message);
                //collMaker.errfound = true;
                //int length = collMaker.richTextBox1.Lines[c].Length;

                //collMaker.richTextBox1.Select(start, length);
                //collMaker.richTextBox1.Sele
                //collMaker.richTextBox1.
            }
            return null;
        }

        public Color EmitColor;
        public float Peak;


        protected override void Initialize()
        {
            base.Initialize();
            Simplex.Init(GraphicsDevice);
            rt = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            rays = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            buf1 = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            var assembly = Assembly.GetExecutingAssembly();
            var rsc = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry n in rsc)
            {
                if (n.Value.GetType() == typeof(byte[]))
                    using (StreamReader reader = new StreamReader(new MemoryStream((byte[])n.Value)))
                    {
                        ShaderLib.Add($"{n.Key.ToString()}", "Resources/" + n.Key.ToString() + ".fx");
                    }
            }

            e = ProcessEffect(ShaderLib["bxaa"]);
            ray = ProcessEffect(ShaderLib["rays"]);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        RenderTarget2D rt, rays, buf1;

        protected override void Draw(GameTime gameTime)
        {
            if (DesignMode)
                return;

            base.Draw(gameTime);
            GraphicsDevice.Clear(BackColor.ToXNA());
            spectrum.DrawSpectrum(spriteBatch, rt, rays, buf1, e, ray);
        }
    }
}
