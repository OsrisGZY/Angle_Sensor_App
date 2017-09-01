using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;

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
            Read_count = 0;
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
        public static int Read_count; // groups received : 12 makes up a group

        public static string Hex2Bin(string HexString)
        {
            long a = Convert.ToInt64(HexString, 16);
            string b = Convert.ToString(a, 2);
            return b;
        }

        public static double velue_convert(string angle, int flag)
        {
            string bin_angle = Program.Hex2Bin(angle);
            int bit_number = 32;
            double result = 0;
            switch (flag)
            {
                case 1:
                    bit_number = 32; //angle convert
                    result = Convert.ToInt32(bin_angle, 2);
                    break;
                case 2:
                    bit_number = 24; //sin cos convert
                    if (bin_angle.Length < bit_number)
                        result = Convert.ToInt32(bin_angle, 2);
                    else   //negative number
                    {
                        string temp = "";
                        for (int i = 0; i < bit_number; i++)
                        {
                            temp += (bin_angle[i] == '0') ? '1' : '0';
                        }
                        result = Convert.ToInt32(temp, 2);
                        result = -result;
                    }
                    break;
            }


            if (flag == 1)
                result = result * Math.PI / Math.Pow(2, 30);
            else
                result = result / Math.Pow(2, 23);

            return result;
        }






    }

}
