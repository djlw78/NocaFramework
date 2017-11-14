using System;
using System.Collections.Generic;
using System.Text;

namespace NOCA_Framework.NocaFramework.CoreFramework.Audio
{
    public class IDT
    {
        public delegate void ISR();

        public static ISR[] idt = new ISR[0xFF];

        public static void Remap()
        {
            CDDI.outb(0x20, 0x11);
            CDDI.outb(0xA0, 0x11);
            CDDI.outb(0x21, 0x20);
            CDDI.outb(0xA1, 0x28);
            CDDI.outb(0x21, 0x04);
            CDDI.outb(0xA1, 0x02);
            CDDI.outb(0x21, 0x01);
            CDDI.outb(0xA1, 0x01);
            CDDI.outb(0x21, 0x0);
            CDDI.outb(0xA1, 0x0);
        }

        private void idt_handler()
        {
            int num = 0;
            if (idt[num] != null)
            {
                idt[num]();
            }
        }

        public static void SetGate(byte int_num, ISR handler)
        {
            idt[int_num] = handler;
        }

    }
}
