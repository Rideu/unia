﻿using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using sRectangle = Microsoft.Xna.Framework.Rectangle;
using static System.Math;

namespace UniaCore
{

    public static class Simplex
    {
        internal static Texture2D pixel;
        internal static Texture2D px;
        public static Texture2D rpx;
        public const float fPI = (float)PI;
        public delegate void VoidFunc();

        public static void Init(GraphicsDevice graphicsDevice)
        {
            pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new Color[] { new Color(255, 255, 255, 255) });
            var tc = new Color[]
            {
                new Color(0, 0, 0, 0),
                new Color(255, 255, 255, 255),
                new Color(0, 0, 0, 0)
            };
            px = new Texture2D(graphicsDevice, 1, tc.Length);
            px.SetData(tc);
            tc = new Color[]
            {
                new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0),
                new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0),
                new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(255, 255, 255, 255), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0),
                new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0),
                new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0), new Color(0, 0, 0, 0),
            };
            rpx = new Texture2D(graphicsDevice, 5, 5);
            rpx.SetData(tc);
        }

        public static void DrawLine(this SpriteBatch sb, Vector2 start, Vector2 end, Color col) => DrawLine(start, end, col, sb);


        public static void DrawLine(Vector2 start, Vector2 end, Color col, SpriteBatch sb) => D_L(sb, new Line(start, end), col);


        public static void DrawLine(this SpriteBatch sb, Vector2 start, Vector2 end, Texture2D tex, Color col) => D_L(sb, new Line(start, end), tex, col);


        public static void DrawLine(this SpriteBatch sb, Line line, Color col) => DrawLine(line.Start, line.End, col, sb);


        public static void DrawPath(SpriteBatch sb, Vector2[] pos, Color col)
        {
            for (int i = 1; i < pos.Length; i++)
            {
                DrawLine(pos[i], pos[i - 1], col, sb);
            }
        }

        public static void DrawRect(this SpriteBatch sb, Vector2 pos, Vector2 size, Color col)
        {
            DrawLine(pos, new Vector2(pos.X + size.X, pos.Y), col, sb);
            DrawLine(new Vector2(pos.X + size.X, pos.Y), pos + size, col, sb);
            DrawLine(pos + size, new Vector2(pos.X, pos.Y + size.Y), col, sb);
            DrawLine(new Vector2(pos.X, pos.Y + size.Y), pos, col, sb);
        }

        public static void DrawRect(this SpriteBatch sb, Rectangle rect, Color col)
        {
            Vector2 pos = new Vector2(rect.Location.X, rect.Location.Y);
            Vector2 size = new Vector2(rect.Width, rect.Height);
            DrawRect(sb, pos, size, col);
        }

        public static void DrawFill(this SpriteBatch sb, Rectangle rect, Color col)
        {
            sb.Draw(pixel, rect, col);
        }

        public static void DrawFill(this SpriteBatch sb, Point pos, Point size, Color col)
        {
            sb.Draw(pixel, new Rectangle(pos, size), col);
        }

        public static void DrawFill(this SpriteBatch sb, Vector2 pos, Vector2 size, Color col)
        {
            sb.Draw(pixel, pos, col, 0, size);
        }

        public static void DrawPixel(this SpriteBatch sb, Vector2 pos, Color col)
        {
            sb.Draw(pixel, pos, col);
        }

        public static void DrawCircle(this SpriteBatch sb, Vector2 center, float diameter, Color col, Texture2D special = null, int thick = 15, Matrix? transform = null)
        {
            //var p = new List<Vector2>();
            //var v = (int)((GlobalForms["Test"].GetComponent(3) as MonoSlider).Value * 100);
            //Primitives.Parameters["bounds"].SetValue(new Vector2(diameter * 2, diameter * 2));
            //Primitives.Parameters["val1"].SetValue(thick);
            //sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend/*, effect: Primitives, transformMatrix: transform*/);
            //sb.DrawFill(new Vector2(center.X - diameter , center.Y - diameter ), new Vector2(diameter*2, diameter*2), col);
            DrawPolygon(sb, center, thick - 1, diameter / 2, col);
            //sb.End();
        }

        public static void DrawPolygon(this SpriteBatch sb, Vector2 center, int vertexes, float radius, Color col, Texture2D special = null)
        {
            float rador = 0f;
            radius *= 2;
            while (rador <= Math.PI * 2)
            {
                rador += (float)Math.PI / vertexes;
                DrawLine(
                    new Vector2((float)Math.Cos(rador) * radius + center.X, (float)Math.Sin(rador) * radius + center.Y), new Vector2((float)Math.Cos(rador + (float)Math.PI / vertexes) * radius + center.X, (float)Math.Sin(rador + (float)Math.PI / vertexes) * radius + center.Y),
                    col, sb);
            }
        }

        public static void Draw(this SpriteBatch batch, Texture2D tex, Vector2 p, Color c, float a)
        {
            batch.Draw(tex, p, null, c, a, tex.Center(), 1f, SpriteEffects.None, 0f);
        }

        public static void Draw(this SpriteBatch batch, Texture2D tex, Vector2 p, Color c, float a, float s)
        {
            batch.Draw(tex, p, null, c, a, Vector2.Zero, s, SpriteEffects.None, 0f);
        }

        public static void Draw(this SpriteBatch batch, Texture2D tex, Vector2 p, Color c, float a, float s, Vector2 origin)
        {
            batch.Draw(tex, p, null, c, a, origin, s, SpriteEffects.None, 0f);
        }

        public static void Draw(this SpriteBatch batch, Texture2D tex, Vector2 p, Color c, float a, Vector2 origin, Vector2 scale)
        {
            batch.Draw(tex, p, null, c, a, origin, scale, SpriteEffects.None, 0f);
        }

        public static void Draw(this SpriteBatch batch, Texture2D tex, Vector2 p, Color c, float a, Vector2 s)
        {
            batch.Draw(tex, p, null, c, a, tex.Center(), s, SpriteEffects.None, 0f);
        }

        public static void DrawString(this SpriteBatch batch, SpriteFont font, string text, Vector2 pos, Color col, float a, float s)
        {
            batch.DrawString(font, text, pos, col, a, Vector2.Zero, s, SpriteEffects.None, 0f);
        }


        internal static void D_L(this SpriteBatch batch, Line l, Color col) => batch.Draw(px, l.Start, null, col, l.Angle, new Vector2(0f, 1.5f), new Vector2(l.Length, 1), SpriteEffects.None, 0);


        internal static void D_L(this SpriteBatch batch, Line l, Texture2D tex, Color col) => batch.Draw(tex, l.Start, null, col, l.Angle, new Vector2(0), new Vector2(l.Length, 1), SpriteEffects.None, 0);



        public static float ease(float t)
        {
            return -t * (t - 1) * 4;
        }

        public static Rectangle FitInto(this Rectangle source, Rectangle target)
        {
            if (target.Contains(source))
            {
                return source;
            }
            else
            {
                var lt = source.Location - target.Location;
                if (lt.X < 0)
                    source.Offset(-lt.X, 0);
                if (lt.Y < 0)
                    source.Offset(0, -lt.Y);
                var br = (source.Location + source.Size) - (target.Location + target.Size);
                if (br.X > 0)
                    source.Offset(-br.X, 0);
                if (br.Y > 0)
                    source.Offset(0, -br.Y);
                return source;
            }
        }

        public static Rectangle FitOut(this Rectangle source, Rectangle target)
        {
            if (target.Intersects(source))
            {
                var of = (target.Center - source.Center).ToVector2();
                var c = of.Normal();
                var va = of * (float)source.Height / source.Width;
                var vb = of * -(float)source.Height / source.Width;

                //if (c.X < c.Y)
                {
                    if (of.Y >= va.X && of.Y <= vb.X)
                        source.Offset(-(source.Left - target.Right), 0);
                    else
                    if (of.Y <= va.X && of.Y >= vb.X)
                        source.Offset(-(source.Right - target.Left), 0);
                    else
                    if (of.Y >= va.X && of.Y >= vb.X)
                        source.Offset(0, -(source.Bottom - target.Top));
                    else
                    if (of.Y <= va.X && of.Y <= vb.X)
                        source.Offset(0, -(source.Top - target.Bottom));
                    //if (c.X < 0 && c.Y < 0)
                    //    source.Offset(0, -(source.Bottom - target.Top));
                    //source.Offset(-(source.Right - target.Left), 0);
                }
                //else
                {
                    //if (c.Y > 0)
                    //    source.Offset(0, -(source.Top - target.Bottom));
                    //else
                    //    source.Offset(0, -(source.Bottom - target.Top));

                }
                //else
                //if (c.Y > source.Height / 2)
                //{
                //    source.Offset(0, -(source.Bottom - target.Top));
                //}
                //else
                //{
                //    source.Offset(0, -(source.Top - target.Bottom));
                //}

                //var lt = source.Location - target.Location;
                //if (lt.X < 0)
                //    source.Offset(-(source.Right - target.Left), 0);
                //if (lt.Y < 0)
                //    source.Offset(0, -(source.Bottom - target.Top));
                //var br = (source.Location + source.Size) - (target.Location + target.Size);
                //if (br.X > 0)
                //    source.Offset(-(source.Left - target.Right), 0);
                //if (br.Y > 0)
                //    source.Offset(0, -(source.Top - target.Bottom));
            }
            return source;
        }
        /// <summary>
        /// Submit a sprite to draw in the current batch with white color by default.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        public static void Draw(this SpriteBatch batch, Texture2D texture, Vector2 position) => batch.Draw(texture, position, Color.White);


        public static void Swap<T>(ref T a, ref T b)
        {
            var c = a; a = b; b = c;
        }

        public static bool PtInsideRect(Rectangle rect, Vector2 dot) => rect.Contains(dot);


        public static bool RectColl(Rectangle rect1, Rectangle rect2) => rect1.Intersects(rect2);


        /// <summary>
        /// Returns relative positioned rectangle with texture's size bounds.
        /// </summary>
        public static Rectangle OffsettedTexture(Texture2D texture, Vector2 offset) => new Rectangle((int)offset.X + texture.Bounds.X, (int)offset.Y + texture.Bounds.Y, texture.Width, texture.Height);


        /// <summary>
        /// Returns relative positioned rectangle with source's size bounds.
        /// </summary>
        public static Rectangle OffsettedTexture(Rectangle src, Vector2 offset) => new Rectangle((int)offset.X + src.X, (int)offset.Y + src.Y, src.Width, src.Height);


        //public static Vector2 SetLength(Vector2 target, float len)
        //{
        //    return new Vector2((float)Math.Cos(GetAngle(target) * len), (float)Math.Sin(GetAngle(target) * len));
        //}





        public static float GetLength(Vector2 target) => (float)Math.Sqrt((target.X * target.X) - (target.Y * target.Y));


        public static float AngleBetween(Vector2 v1, Vector2 v2)
        {
            float b;
            return float.IsNaN(b = (float)Acos(Dot(v1, v2) / (v1.Length() * v2.Length()))) ? 0f : b;
        }

        public static float Dot(Vector2 v1, Vector2 v2) => (v1.X * v2.X) + (v1.Y * v2.Y);


        public static float GetAngle(Vector2 start, Vector2 end) => (float)Math.Atan2(end.Y - start.Y, end.X - start.X); // norevert


        public static float GetAngle(Vector2 point) => (float)Math.Atan2(point.Y, point.X);// norevert 

        public static float TryInfinity(float val1, float val2) => float.IsInfinity(val2) ? val1 : val2;


        public static Vector2 NAngle(float angle) => new Vector2((float)Cos(angle), (float)Sin(angle));


        public static float AngleDiff(Vector2 v1, Vector2 v2) => (float)(fPI - Abs(Abs(v2.Angle() - v1.Angle()) - fPI));


        /// <summary>
        /// Use Line().ReflectPoint instead
        /// </summary>
        /// <param name="point"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static Vector2 ReflectNormal(Vector2 point, Line normal) => Vector2.Reflect(-point, normal.GetUnitAngle());








        public static float PtDistLine(Vector2 start, Vector2 end, Vector2 pt) => (float)(((end.Y - start.Y) * pt.X - (end.X - start.X) * pt.Y + end.X * start.Y - end.Y * start.X) / Math.Sqrt(Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.X - start.X, 2)));


        public static Vector2 GetRotatedVector2(float angle, float length) => new Vector2((float)-Cos(angle) * length, (float)Sin(angle) * length);


        public static Vector2 GetFormattedVector2(float angle, float length) => new Vector2((float)Cos(angle) * length, (float)Sin(angle) * length);


        public static bool TexContains(Texture2D tex, Point offset, Point point)
        {
            Rectangle r = tex.Bounds;
            r.Location += offset;
            if (r.Contains(point))
            {
                Point p = (r.Location - point) * new Point(-1);
                Rectangle rr = new Rectangle(0, 0, tex.Bounds.Size.X, tex.Bounds.Size.Y);
                var y = p.Y;
                var sheetbuf = new Color[r.Width];
                // TODO: simplify up to fetch the only one pixel to avoid too much pressure on the void. Same below.
                tex.GetData(0, new Rectangle(0, y, r.Width, 1), sheetbuf, 0, r.Width);
                if (sheetbuf[p.X].A > 0)
                    return true;
            }
            return false;
        }

        public static bool TexContains(Texture2D tex, Vector2 scale, Point offset, Point point)
        {
            Rectangle r = tex.Bounds;
            r.Size = (scale).ToPoint();
            r.Location += offset;

            if (r.Contains(point))
            {
                r.Size = tex.Bounds.Size;
                Point p = (r.Location - point) * new Point(-1);
                p *= (r.Size / scale.ToPoint());
                Rectangle rr = new Rectangle(0, 0, tex.Bounds.Size.X, tex.Bounds.Size.Y);
                var y = p.Y;
                var sheetbuf = new Color[r.Width];
                tex.GetData(0, new Rectangle(0, y, r.Width, 1), sheetbuf, 0, r.Width);
                if (sheetbuf[p.X].A > 0)
                    return true;
            }
            return false;
        }


        public static Vector2 Center(this Texture2D tex)
        {
            return tex.Bounds.Center.ToVector2();
        }


        #region Rectangle


        public static Rectangle OffsetBy(this Rectangle src, Point offset) { src.Location += offset; return src; }

        public static Rectangle OffsetBy(this Rectangle src, float x, float y) { src.Location += new Point((int)x, (int)y); return src; }

        public static Rectangle Rectangle(float x, float y, float w, float h) => new Rectangle((int)x, (int)y, (int)w, (int)h);

        public static Rectangle Intersect(this Rectangle r1, Rectangle r2) => sRectangle.Intersect(r1, r2);

        public static Rectangle InflateBy(this Rectangle r1, float v, float h) { r1.Inflate(v, h); return r1; }

        public static Rectangle InflateBy(this Rectangle r1, float vh) { r1.Inflate(vh, vh); return r1; }

        public static Rectangle Union(this Rectangle r1, Rectangle r2) => sRectangle.Intersect(r1, r2);

        #endregion

        public static class Palette
        {
            static float nhsv(float n, float h, float s, float v)
            {
                var k = (n + h / 60) % 6;
                return v - v * s * Max(Min(Min(k, 4 - k), 1), 0);
            }

            /// <summary>
            /// Converts hue-saturation-value-color to RGB.
            /// </summary>
            /// <param name="h">Hue value (in range of 0-360)</param>
            /// <param name="s">Saturation value (0-1)</param>
            /// <param name="v">Value (0-1)</param>
            /// <returns>RGB color</returns>
            public static Color HSV2RGB(float h, float s, float v)
            {
                return new Color(nhsv(5, h, s, v), nhsv(3, h, s, v), nhsv(1, h, s, v));
            }

            public static Color ToColor(string hex)
            {
                return new Color(
                    int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier),
                    int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier),
                    int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier),
                    int.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
            }

            public static Color ToColor(uint val)
            {
                return new Color(val);
            }

            public static Color LightenGray => new Color(175, 175, 175, 255);

            public static Color DarkenGray => new Color(85, 85, 85, 255);
            public static Color DarkGray => new Color(14, 14, 14, 255);

        }


        public static Vector2 Trunc(this Vector2 v, float val)
        {
            float i;
            return v * (i = (i = val / v.Length()) < 1.0f ? i : 1.0f);
        }

        public static Vector2 Transform(this Vector2 v, Matrix m) => Vector2.Transform(v, m);

        public static Vector2 GetVector2(this Vector3 v) => new Vector2(v.X, v.Y);

        //public static Vector2 ToPoint(this (int, int) t) => new Vector2(t.Item1, t.Item2);

        public static Vector2 Normal(this Vector2 v)
        {
            v.Normalize();
            return v;
        }

        public static Vector3 GetVector3(this Vector2 v) => new Vector3(v, 0);

        public static Vector2 Angle(this float v) => Vector2.Normalize(new Vector2((float)Cos(v), (float)Sin(v)));
        public static float Angle(this Vector2 v) => (float)Atan2(v.Y, v.X);
        public static float Trunc(this float v, float by) => v > by ? by : v;
        public static float Clamp(this float v, float l, float r) => v > r ? r : v < l ? l : v;
        public static bool Inside(this float v, float l, float r) => v > l && v < r;



        public static void Swap<A>(this A from, A to)
        {
            var a = from;
            from = to;
            to = a;
        }

        public static void AddRange<A, B>(this IDictionary<A, B> tgt, IDictionary<A, B> source)
        {
            foreach (var n in source)
            {
                tgt.Add(n.Key, n.Value);
            }
        }

        public static void MoveToStart<A>(this IList<A> list, A item)
        {
            if (list.Contains(item))
            {
                if (!list[0].Equals(item))
                {
                    var i = list.IndexOf(item);
                    var a = list[0];
                    list[0] = item;
                    list[i] = a;
                }
            }
        }

        public static bool DrawGrid;

        public static void Sandbox(SpriteBatch batch)
        {

        }

    }

    public struct Line
    {
        public Vector2 Start, End;
        public float Length
        {
            get
            {
                return Vector2.Distance(Start, End);
            }
            set
            {
                var n = ToVector2;
                n.Normalize();
                End = Start + n * value;
            }
        }
        public float Angle
        {
            get { return GetAngle(); }
            set
            {
                End = Start + Simplex.GetFormattedVector2(value + (float)PI / 2, Length);
            }
        }

        public Vector2 ToVector2 { get { return End - Start; } }

        //public Line(Vector2 start, float length, float angle)
        //{
        //    //TODO: Line: end
        //}

        public Line(Vector2 v1, Vector2 v2)
        {
            Start = v1;
            End = v2;
        }

        public Line(float x1, float y1, float x2, float y2)
        {
            Start = new Vector2(x1, y1); End = new Vector2(x2, y2);
        }


        public float GetNormalAngle() => -(float)Atan2(ToVector2.X, ToVector2.Y);


        public float GetAngle() => (float)Atan2(End.Y - Start.Y, End.X - Start.X);


        public float AngleTo(Line l) => Simplex.AngleBetween(this, l);


        public float NAngleTo(Line l) => MathHelper.WrapAngle(Angle - l.Angle);


        public float PointDistance(Vector2 pt) => Simplex.PtDistLine(Start, End, pt);


        public Vector2 GetUnitAngle() => new Vector2((float)Cos(GetAngle()), (float)Sin(GetAngle()));


        public Vector2 ReflectPoint(Vector2 p) => Vector2.Reflect(-p, GetUnitAngle());


        public Vector2 GetUnitAngle(float additionalangle) => new Vector2((float)Cos(GetAngle() + additionalangle), -(float)Sin(GetAngle() + additionalangle));


        public bool Intersects(Line l) => PointDistance(l.Start) > 0 ^ PointDistance(l.End) > 0; // ^ — XOR, Checks for infinity.


        public bool Intersects(Vector2 p1, Vector2 p2) => Intersects(new Line(p1, p2));


        public void Rotate(float add) => End = Start + Simplex.GetFormattedVector2(Angle + add, Length);
        public Line Rotate(double add) => new Line(Start, Start + Simplex.GetFormattedVector2(Angle + (float)add, Length));


        public static float AngleBetween(Line l1, Line l2) => l1.AngleTo(l2);


        public static Line GetToXLineByOrdinateNormal(Line normal, Vector2 point) => new Line(normal.Start, normal.Start - Simplex.GetRotatedVector2(normal.Angle - (float)PI / 2, normal.PointDistance(point)));

        public static Line AltLength(Line l, float length)
        {
            l.Length = length;
            return l;
        }

        public static implicit operator Vector2(Line l) => l.ToVector2;

        public static Line operator +(Line l, Vector2 v)
        {
            l.Start += v;
            l.End += v;
            return l;
        }


        //public static implicit operator float(Line l)
        //{
        //    return l.Angle;
        //}

        public static implicit operator string(Line l) => l.Start + "<~>" + l.End + "\n<o>" + l.GetNormalAngle() + "<->" + l.Length;

    }

    public static class Calc
    {
        public static float AngleTo(Vector2 point0, Vector2 point1)
        {
            return -(float)(Atan2(point1.X - point0.X, point1.Y - point0.Y));
        }

        public static float AngleTo(Line line)
        {
            return AngleTo(line.Start, line.End);
        }

        public static float AngleBetween(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2)
        {
            return Abs(Abs(Simplex.GetAngle(end1, start1) - Abs(Simplex.GetAngle(end2, start2))));
        }

        public static float AngleBetween(Line l1, Line l2)
        {
            return AngleBetween(l1.Start, l1.End, l2.Start, l2.End);
        }

    }

    //public class VBi2
    //{
    //    private Vector2 V1;
    //    public Vector2 Start
    //    {
    //        set { V1 = value; }
    //        get { return V1; }
    //    }

    //    private Vector2 V2;
    //    public Vector2 End
    //    {
    //        set { V2 = value; }
    //        get { return V2; }
    //    }

    //    public VBi2(Vector2 start, Vector2 end)
    //    {
    //        Start = start;
    //        End = end;
    //    }

    //    public Vector2 ToVector2()
    //    {
    //        return V2 - V1;
    //    }

    //    public float GetAngle()
    //    {
    //        return Simplex.GetAngle(Start, End);
    //    }

    //    public static float AngleBetween(VBi2 v1, VBi2 v2)
    //    {
    //        return Simplex.AngleBetween(v1, v2);
    //    }

    //    public static implicit operator Vector2(VBi2 v)
    //    {
    //        return v.ToVector2();
    //    }

    //    public static VBi2 operator +(VBi2 mv, Vector2 v)
    //    {
    //        mv.Start += v; mv.End += v;
    //        return mv;
    //    }

    //    public static VBi2 operator -(VBi2 mv, Vector2 v)
    //    {
    //        mv.Start -= v; mv.End -= v;
    //        return mv;
    //    }

    //    public static VBi2 operator +(VBi2 mv, float v)
    //    {
    //        mv.Start += new Vector2(v); mv.End += new Vector2(v);
    //        return mv;
    //    }

    //    public static VBi2 operator -(VBi2 mv, float v)
    //    {
    //        mv.Start -= new Vector2(v); mv.End -= new Vector2(v);
    //        return mv;
    //    }

    //    public override string ToString()
    //    {
    //        return " [" + Start.ToString() + "]:[" + End.ToString() + "] (" + GetAngle() + ")";
    //    }
    //}

}
