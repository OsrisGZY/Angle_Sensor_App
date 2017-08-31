using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Fit_Parameter;
using Plot_Circle;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace UserApp
{
    public partial class Calibration : Form
    {
        public Calibration()
        {
            InitializeComponent();
            sample_counts = 5000;

        }



        private void Calibration_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.fine_sin_offeset.ToString();
            textBox2.Text = Program.fine_cos_offeset.ToString();
            textBox3.Text = Program.coarse_sin_offeset.ToString();
            textBox4.Text = Program.coarse_cos_offeset.ToString();
            textBox5.Text = Program.fine_sin_amplitude.ToString();
            textBox6.Text = Program.fine_cos_amplitude.ToString();
            textBox7.Text = Program.coarse_sin_amplitude.ToString();
            textBox8.Text = Program.coarse_cos_amplitude.ToString();
            textBox17.Text = Program.fine_envelope.ToString();
            textBox19.Text = Program.coarse_envelope.ToString();
            comboBox1.Text = sample_counts.ToString();
            textBox21.Text = Program.fine_Angle_Offset.ToString();
            textBox22.Text = Program.coarse_Angle_Offset.ToString();

        }
        // user variables
        public bool display; //to show if the win is displayed
        public int sample_counts;
        double[] u1, u2, sample_position;
        MWArray theta, U_1, U_2;
        // public Sensor GZY_algorithm;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sample_counts = int.Parse(comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //data acquire or born
            sample_position = new double[sample_counts];
            u1 = new double[sample_counts];
            u2 = new double[sample_counts];

            Random rnd = new Random();
            sample_position[0] = 0;
            u1[0] = (Program.fine_sin_amplitude * Math.Sin(sample_position[0]) + Program.fine_sin_offeset) * (1 + Program.fine_envelope * Math.Sin(sample_position[0] / Program.N + Program.fine_Angle_Offset));
            u2[0] = (Program.fine_cos_amplitude * Math.Cos(sample_position[0]) + Program.fine_cos_offeset) * (1 + Program.fine_envelope * Math.Sin(sample_position[0] / Program.N + Program.fine_Angle_Offset));

            theta = new MWNumericArray(sample_position[0]);
            U_1 = new MWNumericArray(u1[0]);
            U_2 = new MWNumericArray(u2[0]);
            Plot_User plot = new Plot_User();
            plot.plot_Point(U_1, U_2);

            progressBar1.Value = 0;

            for (int i = 1; i < sample_counts; i++)
            {

                sample_position[i] = 200 * Math.PI * i / sample_counts + rnd.NextDouble() ;
                u1[i] = (Program.fine_sin_amplitude * Math.Sin(sample_position[i]) + Program.fine_sin_offeset) * (1 + Program.fine_envelope * Math.Sin(sample_position[i] / Program.N + Program.fine_Angle_Offset));
                u2[i] = (Program.fine_cos_amplitude * Math.Cos(sample_position[i]) + Program.fine_cos_offeset) * (1 + Program.fine_envelope * Math.Sin(sample_position[i] / Program.N + Program.fine_Angle_Offset));

                U_1 = new MWNumericArray(u1[i]);
                U_2 = new MWNumericArray(u2[i]);
                plot.plot_Point(U_1, U_2);

                progressBar1.Value = (int)(100 * (i + 1) / sample_counts);
            }

            MessageBox.Show("Data has been acquired");
            progressBar1.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MWNumericArray theta = new MWNumericArray(1, sample_counts, sample_position);
            MWNumericArray U_1 = new MWNumericArray(1, sample_counts, u1);
            MWNumericArray U_2 = new MWNumericArray(1, sample_counts, u2);

            Plot_User plot = new Plot_User();
            plot.Plot_Circle(U_1, U_2);

            MWArray[] result_1 = new Fit_Parameter.Class1().Fit_1(4, theta, U_1);
            MWArray[] result_2 = new Fit_Parameter.Class1().Fit_2(4, theta, U_2);
            //   up = (MWNumericArray)new Sensor.Sensor().envelope(theta, U_1);
            Array a = result_1.ToArray();
            Array b = result_2.ToArray();
            double envelope = (double.Parse(a.GetValue(2).ToString()) + double.Parse(b.GetValue(2).ToString())) / 2;
            double alpha = (double.Parse(a.GetValue(3).ToString()) + double.Parse(b.GetValue(3).ToString())) / 2;

            textBox13.Text = a.GetValue(0).ToString();  //A_1
            textBox9.Text = a.GetValue(1).ToString();  //d_1
            textBox14.Text = b.GetValue(0).ToString();  //A_2
            textBox10.Text = b.GetValue(1).ToString();  //d_2
            textBox18.Text = envelope.ToString();  //a_0
            textBox23.Text = alpha.ToString();  //alpha  

            theta.Dispose();
            U_1.Dispose();
            U_2.Dispose();

        }
    }
}
  