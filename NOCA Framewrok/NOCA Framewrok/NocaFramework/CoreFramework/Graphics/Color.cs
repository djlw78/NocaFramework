using System;
using System.Collections.Generic;
using System.Text;

namespace NOCA_Framework.NocaFramework.CoreFramework.Graphics
{
    public class Color
    {
        public byte r, g, b, a;

        #region colors
        public static Color White = new Color(255, 255, 255);
        public static Color Black = new Color(0, 0, 0);
        public static Color Blue = new Color(0, 0, 255);
        public static Color Red = new Color(255, 0, 0);
        public static Color Green = new Color(0, 255, 0);
        #endregion

        //Orginal = public Color(byte rd, byte gr, byte bl)
        public Color(byte red, byte green, byte blue) //Easier to read & understand.
        {
            r = red;
            g = green;
            b = blue;
            a = 255; //full
        }

        //Orginal = public Color(byte rd, byte gr, byte bl, byte alpha)
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            r = red;
            g = green;
            b = blue;
            a = alpha;
        }

        public uint To_uint()
        {
            return (uint)((this.r << 16) | (this.g << 8) | (this.b));
        }

        public static Color From_uint(uint src) //source?
        {
            double d1 = src % 65025;
            return new Color((byte)(src / 65025), (byte)(d1 / 255), (byte)(d1 % 255));
        }

        public static Color GetAlpha(byte solid, Color par1, Color par2)
        {
            double backr = (double)solid / (double)255;
            return new Color((byte)((par1.r * backr) + (par2.r * (1d - backr))), (byte)((par1.g * backr) + (par2.g * (1d - backr))), (byte)((par1.b * backr) + (par2.b * (1d - backr))));
        }

        // VEC2 class
        public class Vec2
        {
            public static Vec2 sixtyfour = new Vec2(64, 0);
            public static Vec2 zero = new Vec2(0, 0);

            public int x;
            public int y;

            public Vec2(int xpos, int ypos)
            {
                x = xpos;
                y = ypos;
            }

            public Vec2(Vec2 sz)
            {
                x = sz.x;
                y = sz.y;
            }

            public Vec2(Rect rct)
            {
                x = rct.x;
                y = rct.y;
            }

            public Vec2()
            {
                x = 0;
                y = 0;
            }

        }

        public class Point
        {

            public static Point zero = new Point(0, 0);

            public int x;
            public int y;

            public Point(int xpos, int ypos)
            {
                x = xpos;
                y = ypos;
            }

            public Point(Vec2 sz)
            {
                x = sz.x;
                y = sz.y;
            }

            public Point(Rect rct)
            {
                x = rct.x;
                y = rct.y;
            }

            public Point()
            {
                x = 0;
                y = 0;
            }

        }

        public class Size
        {
            public static Size Zero = new Size(0, 0);

            public int Width;
            public int Height;

            public Size(int width, int height)
            {
                Width = width;
                Height = height;

            }

            public Size(Vec2 sz)
            {
                Width = sz.x;
                Height = sz.y;
            }

            public Size(Point sz)
            {
                Width = sz.x;
                Height = sz.y;
            }

            public Size(Rect rct)
            {
                Width = rct.width;
                Height = rct.height;
            }

            public Size()
            {
                this.Width = 0;
                this.Height = 0;
            }

        }

        // RECT class
        public class Rect
        {
            public int x;
            public int y;
            public int width;
            public int height;

            public Rect(int xpos, int ypos, int width, int height)
            {
                x = xpos;
                y = ypos;
                this.width = width;
                this.height = height;
            }
            public Rect(Vec2 sz, Vec2 pt)
            {
                x = pt.x;
                y = pt.y;
                //x = sz.x;
                //y = sz.y;
                width = sz.x;
                height = sz.y;
            }

            public Rect(int xpos, int ypos, Vec2 sz)
            {
                x = xpos;
                y = ypos;
                x = sz.x;
                y = sz.y;
            }

            public Rect(Vec2 pt, int mx, int my)
            {
                x = pt.x;
                y = pt.x;
                x = mx;
                y = my;
            }

            public Rect()
            {
                x = 0;
                y = 0;
                x = 0;
                y = 0;
            }

        }

        class SVGA
        {
            public static Vec2 res = new Vec2(1300, 780);
            public static Cosmos.HAL.Drivers.PCI.Video.VMWareSVGAII svga = new Cosmos.HAL.Drivers.PCI.Video.VMWareSVGAII();

            public static void SetRes(int par1, int par2)
            {
                res = new Vec2(par1, par2);
                svga.SetMode((ushort)par1, (ushort)par2, 32);
            }

            public static void InitMouse()
            {
                svga.DefineCursor();
            }

            public static void MoveMouse(Vec2 pos)
            {
                svga.SetCursor(true, (uint)pos.x, (uint)pos.y);
            }

            public static Vec2 GetRes()
            {
                return res;
            }

            public static void Set(int x, int y, Color col)
            {
                svga.SetPixel((ushort)x, (ushort)y, col.To_uint());
            }

            public static void Set(int x, int y, uint col)
            {
                svga.SetPixel((ushort)x, (ushort)y, col);
            }

            public static Color Get(int x, int y)
            {
                return Color.From_uint(svga.GetPixel((ushort)x, (ushort)y));
            }

            public static uint Get(uint x, uint y)
            {
                return svga.GetPixel((ushort)x, (ushort)y);
            }

            public static void Fill(Vec2 point, Vec2 size, Color par1)
            {
                svga.Fill((ushort)point.x, (ushort)point.y, (ushort)size.x, (ushort)size.y, par1.To_uint());
            }

            public static void Fill(Vec2 point, Vec2 size, uint par1)
            {
                svga.Fill((ushort)point.x, (ushort)point.y, (ushort)size.x, (ushort)size.y, par1);
            }

            public static void Fill(Rect tr, uint par1)
            {
                svga.Fill((ushort)tr.x, (ushort)tr.y, (ushort)tr.x, (ushort)tr.y, par1);
            }

            public static void Clear(Color par1)
            {
                svga.Clear(par1.To_uint());
            }

            public static void Clear(uint par1)
            {
                svga.Clear(par1);
            }

            public static void Update()
            {
                svga.Update((ushort)0, (ushort)0, (ushort)res.x, (ushort)res.y);
            }
        }
    }
}
