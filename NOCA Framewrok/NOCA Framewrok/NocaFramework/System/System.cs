using System.Collections.Generic;
using System.Text;
using Cosmos.IL2CPU.API.Attribs;
namespace NOCA_Framework.NocaFramework.System
{
    public class System
    {
        
    }

    public static class Console
    {
        /*
         * Beep calls Noca's CoreFramework -> PCSpeaker
         * default Console.Beep(800, 250)
         */

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Beep(uint frequency = 800)
        {
            CoreFramework.Audio.PCSpeaker.Beep(frequency);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="duration"></param>
        public static void Beep(uint frequency, uint duration)
        {
            CoreFramework.Audio.PCSpeaker.Beep(frequency, duration);
        }

        /*
        //io text
        public static bool IsInputRedirected { get; }
        public static int BufferHeight { get; set; }
        public static int BufferWidth { get; set; }
        public static bool CapsLock { get; }
        public static int CursorLeft { get; set; }
        public static int CursorSize { get; set; }
        public static int CursorTop { get; set; }
        public static bool CursorVisible { get; set; }
        //public static TextWriter Error { get; }
        //public static ConsoleColor ForegroundColor { get; set; }
        //public static TextReader In { get; }
        //public static Encoding InputEncoding { get; set; }
        public static bool IsErrorRedirected { get; }
        public static int WindowWidth { get; set; }
        public static bool IsOutputRedirected { get; }
        public static bool KeyAvailable { get; }
        public static int LargestWindowHeight { get; }
        public static int LargestWindowWidth { get; }
        public static bool NumberLock { get; }
        // public static TextWriter Out { get; }
        //public static Encoding OutputEncoding { get; set; }
        public static string Title { get; set; }
        public static bool TreatControlCAsInput { get; set; }
        public static int WindowHeight { get; set; }
        public static int WindowLeft { get; set; }
        public static int WindowTop { get; set; }
        //public static ConsoleColor BackgroundColor { get; set; }
        //public static event ConsoleCancelEventHandler CancelKeyPress;
        //public static void Beep();
        //public static void Beep(int frequency, int duration);
        //public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop);
        // public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor);
        // public static Stream OpenStandardError(int bufferSize);
        // public static Stream OpenStandardError();
        // public static Stream OpenStandardInput(int bufferSize);
        // public static Stream OpenStandardInput();
        // public static Stream OpenStandardOutput(int bufferSize);
        // public static Stream OpenStandardOutput();
        //  public static int Read();
        //  public static ConsoleKeyInfo ReadKey(bool intercept);
        // public static ConsoleKeyInfo ReadKey();
        //public static string ReadLine();
       // public static void ResetColor();
       ///// public static void SetBufferSize(int width, int height);
       // public static void SetCursorPosition(int left, int top);
      //  public static void SetError(TextWriter newError);
       // public static void SetIn(TextReader newIn);
        //public static void SetOut(TextWriter newOut);
       // public static void SetWindowPosition(int left, int top);
        //public static void SetWindowSize(int width, int height);
       // [CLSCompliant(false)]
       // public static void Write(ulong value);
      ////  public static void Write(bool value);
      ///  public static void Write(char value);
      //  public static void Write(char[] buffer);
       // public static void Write(char[] buffer, int index, int count);
      //  public static void Write(double value);
       /// public static void Write(long value);
        //public static void Write(object value);
       // public static void Write(float value);
       // public static void Write(string value);
       // public static void Write(string format, object arg0);
       // public static void Write(string format, object arg0, object arg1);
       // public static void Write(string format, object arg0, object arg1, object arg2);
        //public static void Write(string format, params object[] arg);
       // [CLSCompliant(false)]
       // public static void Write(uint value);
        //public static void Write(decimal value);
       // public static void Write(int value);
       // [CLSCompliant(false)]
       // public static void WriteLine(ulong value);
       // public static void WriteLine(string format, params object[] arg);
       // public static void WriteLine();
       // public static void WriteLine(bool value);
       // public static void WriteLine(char[] buffer);
       // public static void WriteLine(char[] buffer, int index, int count);
        //public static void WriteLine(decimal value);
       // public static void WriteLine(double value);
       // [CLSCompliant(false)]
       // public static void WriteLine(uint value);
        //public static void WriteLine(int value);
       // public static void WriteLine(object value);
        //public static void WriteLine(float value);
       // public static void WriteLine(string value);
        //public static void WriteLine(string format, object arg0);
        //public static void WriteLine(string format, object arg0, object arg1);
        //public static void WriteLine(string format, object arg0, object arg1, object arg2);
        //public static void WriteLine(long value);
        //public static void WriteLine(char value);

        */
    }
}
