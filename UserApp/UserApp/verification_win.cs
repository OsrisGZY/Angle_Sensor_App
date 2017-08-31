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
    public partial class verification_win : Form
    {
        public verification_win()
        {
            InitializeComponent();
            radioButton1.Select();
            comboBox1.Text = "1000";
            sample_counts = 1000;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verification_START_Click(object sender, EventArgs e)
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

                sample_position[i] = 20 * Math.PI * i / sample_counts + rnd.NextDouble();
                u1[i] = (Program.fine_sin_amplitude * Math.Sin(sample_position[i]) + Program.fine_sin_offeset) * (1 + Program.fine_envelope * Math.Sin(sample_position[i] / Program.N + Program.fine_Angle_Offset));
                u2[i] = (Program.fine_cos_amplitude * Math.Cos(sample_position[i]) + Program.fine_cos_offeset) * (1 + Program.fine_envelope * Math.Sin(sample_position[i] / Program.N + Program.fine_Angle_Offset));

                U_1 = new MWNumericArray(u1[i]);
                U_2 = new MWNumericArray(u2[i]);
                plot.plot_Point(U_1, U_2);

                progressBar1.Value=(int)(100*(i+1)/sample_counts);
            }

            MessageBox.Show("Data has been acquired");
            progressBar1.Value = 0;


             theta = new MWNumericArray(1, sample_counts, sample_position);
             U_1 = new MWNumericArray(1, sample_counts, u1);
             U_2 = new MWNumericArray(1, sample_counts, u2);

            plot.Plot_Circle(U_1, U_2);

            MWArray[] result_1 = new Fit_Parameter.Class1().Fit_1(4, theta, U_1);
            MWArray[] result_2 = new Fit_Parameter.Class1().Fit_2(4, theta, U_2);
            //   up = (MWNumericArray)new Sensor.Sensor().envelope(theta, U_1);
            Array a = result_1.ToArray();
            Array b = result_2.ToArray();
            double envelope = (double.Parse(a.GetValue(2).ToString()) + double.Parse(b.GetValue(2).ToString())) / 2;
            double alpha = (double.Parse(a.GetValue(3).ToString()) + double.Parse(b.GetValue(3).ToString())) / 2;
            if (Math.Abs(double.Parse(a.GetValue(0).ToString()) - Program.fine_sin_amplitude) > 0.1)
                MessageBox.Show("Bad Installation");
            else if(Math.Abs(double.Parse(a.GetValue(1).ToString()) - Program.fine_sin_offeset) > 0.1)
                MessageBox.Show("Bad Installation");
            else if(Math.Abs(double.Parse(b.GetValue(1).ToString()) - Program.fine_cos_offeset) > 0.1)
                MessageBox.Show("Bad Installation");
            else if (Math.Abs(double.Parse(b.GetValue(0).ToString()) - Program.fine_cos_amplitude) > 0.1)
                MessageBox.Show("Bad Installation");
            else if(Math.Abs(envelope-Program.fine_envelope)>0.1)
                MessageBox.Show("Bad Installation");
            else if(Math.Abs(alpha-Program.fine_Angle_Offset)>0.1)
                MessageBox.Show("Bad Installation");
            else
                MessageBox.Show("Fine Installation");
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            choice = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            choice = 0;

        }

        private void verification_win_Load(object sender, EventArgs e)
        {
        }
        // fine channel or coarse channel 
     
        
        private int choice;
        public bool display; //to show if the win is displayed
        // sample counts
        private int sample_counts;
        double[] u1, u2, sample_position;
        MWArray theta, U_1, U_2;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sample_counts = int.Parse(comboBox1.Text);
        }



    }
}
