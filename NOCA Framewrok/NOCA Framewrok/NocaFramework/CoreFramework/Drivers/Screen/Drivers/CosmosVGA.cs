﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NOCA_Framework.NocaFramework.CoreFramework.Drivers.Screen.Drivers
{
    class CosmosVGA
    {
        private Graphics.Frame Buffer = new Graphics.Frame(0, 0);
        private Cosmos.HAL.VGAScreen VGA = new Cosmos.HAL.VGAScreen();
        public int Width = 320;
        public int Height = 200;

        public void SetMode(int width, int height)
        {
            if (width == 320 && height == 200)
            {
                VGA.SetGraphicsMode(Cosmos.HAL.VGAScreen.ScreenSize.Size320x200, Cosmos.HAL.VGAScreen.ColorDepth.BitDepth8); //320x200x8
                this.Width = width;
                this.Height = height;
            }

            //Initilize the new Buffer.
            this.Buffer = new Graphics.Frame(this.Width, this.Height);
        }

        public void SetPixel(int x, int y, int color)
        {
            Buffer.SetPixel((uint)color, FindPixel((uint)x, (uint)y, (uint)Buffer.Width, (uint)Buffer.Height));
        }

        public void Update()
        {
            RestoreFrame(0, 0, Buffer);
        }

        public void Clear(int color)
        {
            uint width = (uint)Buffer.Height;
            uint height = (uint)Buffer.Width;

            if (width > height)
            {
                for (uint x = 0; x < height; x++)
                {
                    for (uint y = 0; y < width; y++)
                    {
                        SetPixel((int)x, (int)y, color);
                    }
                }
            }

            if (width == height)
            {
                for (uint x = 0; x < height; x++)
                {
                    for (uint y = 0; y < width; y++)
                    {
                        SetPixel((int)x, (int)y, color);
                    }

                }
            }

            if (width < height)
            {

                for (uint y = 0; y < width; y++)
                {
                    for (uint x = 0; x < height; x++)
                    {
                        SetPixel((int)x, (int)y, color);
                    }
                }
            }

        }

        #region " Extra "
        private uint Found = 0;

        /*
         * This is used to calculate the position of a pixel based off of a X and Y in a buffer, or as we call them Frame's.
         */

        private uint FindPixel(uint xpos, uint ypos, uint width, uint height)
        {
            /*
             * Ok so we store the pixl in the buffer in a few different ways
             * but to find out what number in the array will be that pixel
             * we loop through a for event, well thats bad, because it will slow
             * down the system, this exquation will find it for ten times faster. 
             */

            uint Width2 = height;
            uint Height2 = width;

            if (Width2 > Height2)
            {
                /*
                 * This does not work and I will have to fix it.
                 */
                Found = xpos * Width2 + ypos;
                return Found;
            }

            if (Width2 < Height2)
            {
                /*
                 * This implentation works.
                 */
                Found = ypos * Height2 + xpos;
                return Found;
            }

            if (Width2 == Height2)
            {
                /*
                 * I believe this one works.
                 */
                Found = ypos * Height2 + xpos;
                return Found;
            }

            return 0;
        }

        #endregion

        #region " Do not change this code it will result in harsh consiquences. "

        /*
         * If I create a frame,  and set it to 16x32 the size will really be 16x32, but the way I coded this, you have
         * to invert it, so 16x32 would really be 32x16. It's the way the code works. So it's confusing just forget
         * I told you this, because you may accidently invert the actually size on the frame, and you dont want to do that.
         */

        public void RestoreFrame(uint xpos, uint ypos, Graphics.Frame image)
        {
            //inverted.
            uint width = (uint)image.Height;
            uint height = (uint)image.Width;

            if (width > height)
            {
                uint n = 0;
                for (uint x = 0; x < height; x++)
                {
                    for (uint y = 0; y < width; y++)
                    {
                        //Commented out this: xpos + x, ypos + y,
                        VGA.SetPixel320x200x8(xpos + x, ypos + y, image.GetPixel(n));
                        n += 1;
                    }

                }
            }

            if (width == height)
            {
                uint n = 0;
                for (uint x = 0; x < height; x++)
                {
                    for (uint y = 0; y < width; y++)
                    {
                        //Commented out this: xpos + x, ypos + y,
                        VGA.SetPixel320x200x8(xpos + x, ypos + y, image.GetPixel(n));
                        n += 1;
                    }

                }
            }

            if (width < height)
            {
                uint n = 0;
                for (uint y = 0; y < width; y++)
                {
                    for (uint x = 0; x < height; x++)
                    {
                        //Commented out this: xpos + x, ypos + y,
                        VGA.SetPixel(xpos + x, ypos + y, image.GetPixel(n));
                        n += 1;
                    }

                }
            }

        }
        public void RestoreFrameIntoBuffer(uint xpos, uint ypos, Graphics.Frame image)
        {
            //inverted.
            uint width = (uint)image.Height;
            uint height = (uint)image.Width;

            if (width > height)
            {
                uint n = 0;
                for (uint x = 0; x < height; x++)
                {
                    for (uint y = 0; y < width; y++)
                    {
                        //Commented out this: xpos + x, ypos + y,
                        SetPixel((int)(xpos + x), (int)(ypos + y), (int)image.GetPixel(n));
                        n += 1;
                    }

                }
            }

            if (width == height)
            {
                uint n = 0;
                for (uint x = 0; x < height; x++)
                {
                    for (uint y = 0; y < width; y++)
                    {
                        //Commented out this: xpos + x, ypos + y,
                        SetPixel((int)(xpos + x), (int)(ypos + y), (int)image.GetPixel(n));
                        n += 1;
                    }

                }
            }

            if (width < height)
            {
                uint n = 0;
                for (uint y = 0; y < width; y++)
                {
                    for (uint x = 0; x < height; x++)
                    {
                        //Commented out this: xpos + x, ypos + y,
                        SetPixel((int)(xpos + x), (int)(ypos + y), (int)image.GetPixel(n));
                        n += 1;
                    }

                }
            }

        }

        #endregion

    }
}
