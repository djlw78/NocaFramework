using System;
using System.Collections.Generic;
using System.Text;

namespace NOCA_Framework.NocaFramework.CoreFramework.Drivers.Screen.Handlers
{
    class CosmosVGA
    {
        private static Screen.Resolutions CurrentRes;
        private static Drivers.CosmosVGA VGA = new Drivers.CosmosVGA();

        public static void SetMode(Screen.Resolutions Res)
        {
            CurrentRes = Res;
            if (CurrentRes == Screen.Resolutions.Resolution1_320)
            {
                VGA.SetMode(320, 200);
            }
            else if (CurrentRes == Screen.Resolutions.Resolution2_640)
            {
                VGA.SetMode(640, 400);
            }
        }

        public static void Clear(int Color)
        {
            VGA.Clear(Color);
        }

        public static void Update()
        {
            VGA.Update();
        }

        public static void SetPixel(int x, int y, int Color)
        {
            VGA.SetPixel(x, y, Color);
        }
    }
}
