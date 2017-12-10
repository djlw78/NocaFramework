using System.Collections.Generic;
using System.Text;
using Cosmos.IL2CPU.API.Attribs;
using s = System;
namespace NOCA_Framework.NocaFramework.System
{
    public class System
    {
        
    }

    [Plug(Target = typeof(global::System.Console))]
    public static class ConsoleImpl
    {
        /*
         * Beep calls Noca's CoreFramework -> PCSpeaker
         * default Console.Beep(800, 250)
         */

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        
        public static bool Beep()
        {
            CoreFramework.Audio.PCSpeaker.Beep(800);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="duration"></param>
        public static void Beep(int frequency, int duration)
        {
            CoreFramework.Audio.PCSpeaker.Beep((uint)frequency, (uint)duration);
        }

    }
}
