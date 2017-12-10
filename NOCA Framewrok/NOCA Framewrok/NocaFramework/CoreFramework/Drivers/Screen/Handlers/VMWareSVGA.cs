using System;
using System.Collections.Generic;
using System.Text;

namespace NOCA_Framework.NocaFramework.CoreFramework.Drivers.Screen.Handlers
{
    class VMWareSVGA
    {
        private static Screen.Resolutions CurrentRes;
        private static Drivers.VMWareSVGA SVGA = new Drivers.VMWareSVGA();

        public static void SetMode(Screen.Resolutions Res)
        {
            CurrentRes = Res;
            if (CurrentRes == Screen.Resolutions.Resolution1_320)
            {
                SVGA.SetMode(320, 200);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution2_640)
            {
                SVGA.SetMode(640, 400);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution3_800)
            {
                SVGA.SetMode(800, 600);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution4_1024)
            {
                SVGA.SetMode(1024, 768);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution5_1280)
            {
                SVGA.SetMode(1280, 1024);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution6_1600)
            {
                SVGA.SetMode(1600, 1200);
            }
        }

        public static void Clear(int Color)
        {
            SVGA.Clear((uint)Color);
        }

        public static void Update()
        {
            if (CurrentRes == Screen.Resolutions.Resolution1_320)
            {
                SVGA.Update(0, 0, 320, 200);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution2_640)
            {
                SVGA.Update(0, 0, 640, 400);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution3_800)
            {
                SVGA.Update(0, 0, 800, 600);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution4_1024)
            {
                SVGA.Update(0, 0, 1024, 768);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution5_1280)
            {
                SVGA.Update(0, 0, 1280, 1024);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution6_1600)
            {
                SVGA.Update(0, 0, 1600, 1200);
            }
        }

        public static void SetPixel(int x, int y, int Color)
        {
            SVGA.SetPixel((ushort)x, (ushort)y, (uint)Color);
        }

        public static void Fill(int x, int y, int width, int length, int color)
        {
            SVGA.Fill((ushort)x, (ushort)y, (ushort)width, (ushort)length, (uint)color);
        }
    }
}
