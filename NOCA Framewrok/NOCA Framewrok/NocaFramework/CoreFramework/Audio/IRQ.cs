using System;
using System.Collections.Generic;
using System.Text;

namespace NOCA_Framework.NocaFramework.CoreFramework.Audio
{
    public class IRQ
    {
        public static void SetMask(byte IRQLine)
        {
            ushort port;
            byte value;

            if (IRQLine < 8)
            {
                port = 0x20 + 1;
            }
            else
            {
                port = 0xA0 + 1;
                IRQLine -= 8;
            }
            value = (byte)(CDDI.inb(port) | (1 << IRQLine));
            CDDI.outb(port, value);
        }

        public static void ClearMask(byte IRQLine)
        {
            ushort port;
            byte value;

            if (IRQLine < 8)
            {
                port = 0x20 + 1;
            }
            else
            {
                port = 0xA0 + 1;
                IRQLine -= 8;
            }
            value = (byte)(CDDI.inb(port) & ~(1 << IRQLine));
            CDDI.outb(port, value);
        }
    }
}