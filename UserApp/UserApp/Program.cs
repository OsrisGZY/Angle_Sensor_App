using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace UserApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            N = 32;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Main());
        }
        public static double fine_sin_offeset, fine_cos_offeset, fine_sin_amplitude, fine_cos_amplitude, fine_envelope, fine_Angle_Offset;
        public static double coarse_sin_offeset, coarse_cos_offeset, coarse_sin_amplitude, coarse_cos_amplitude, coarse_envelope, coarse_Angle_Offset;
        public static int N;
        public static double zeros_angle;
        public static int zeros_bit;

        public static SerialPort port;
    }
}
