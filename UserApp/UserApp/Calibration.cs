using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Threading;

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
            sample_counts = 200;

        }

  //      private bool listening=false;
        private bool closing = false;

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

            Program.Read_count = 0;

        }
        // user variables
        public bool display; //to show if the win is displayed
        public int sample_counts;
        double[] u1, u2, sample_position;
    //     MWArray theta, U_1, U_2;
 

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sample_counts = int.Parse(comboBox1.Text);
        }

        // data acquire
        private void button2_Click(object sender, EventArgs e)
        {
            //data acquire or born
            sample_position = new double[sample_counts];
            u1 = new double[sample_counts];
            u2 = new double[sample_counts];
           
            closing = false;

            Program.port = new SerialPort();
            Program.port.PortName = "COM4";
            Program.port.BaudRate = 115200;
            Program.port.DataBits = 8;
            Program.port.Parity = Parity.None;
            Program.port.StopBits = StopBits.One;
            Program.port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            Program.Read_count = 0;
            if (Program.port.IsOpen)
                MessageBox.Show("COM4 is now been ocupied");
            else
            {
                Program.port.Open();
            }
            Plot_User plot = new Plot_User();
            progressBar1.Value = 0;

            sample_position = new double[sample_counts];
            u1 = new double[sample_counts];
            u2 = new double[sample_counts];
        }

        //analyse
        private void button3_Click(object sender, EventArgs e)   
        {
            Program.port.Close();

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

        private void DataReceivedHandler( object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(1);
                SerialPort sp = (SerialPort)sender;
            
                if (closing)
                {
                    sp.DiscardInBuffer();
                    return;
                }
               
                closing = true;
                this.temp.Invoke(
              new MethodInvoker(
                  delegate
                  {

                      string now = "";// sp.ReadExisting();  //data cleared after been read
                      int n = sp.BytesToRead;
                      Byte[] bt = new Byte[n];
                      sp.Read(bt, 0, n);
                      for (int i = 0; i < bt.Length; i++)
                      {
                          //           now += ("0x" + bt[i].ToString("X2") + "");
                          now += bt[i].ToString("X2");
                      }

                      int index = now.IndexOf("AA"); ; // now.IndexOf("AA");
                      now = now.Substring(index);
                      bool search = true;
                      while(search)
                      {
                          if(now.Substring(26,2)=="55")
                          {
                              now = now.Substring(0, 28);
                              search = false;
                          }
                          else
                          {
                              now = now.Substring(2);
                              index = now.IndexOf("AA");
                              now = now.Substring(index);
                          }

                      }

                          angle_value = now.Substring(2, 8);
                          sin_value = now.Substring(10, 8);
                          cos_value = now.Substring(18, 8);
                         
                      sp.DiscardInBuffer();

                      Program.Read_count = Program.Read_count + 1;
                      temp.Text =now;
                     
                      bt = null;

                      count.Text = Program.Read_count.ToString();


                  }
                   ));
       

           
        }

        public string angle_value, sin_value, cos_value;
        public Plot_User plot;

      

        private void count_TextChanged(object sender, EventArgs e)
        {
            
            double a = Program.velue_convert(sin_value, 2);
            double b = Program.velue_convert(cos_value, 2);
            double c=Program.velue_convert(angle_value,1);
            double num=Program.Read_count;
            temp.Text = c.ToString();

            plot = new Plot_User();
            plot.plot_Point(b, a);
            plot.Dispose();

            Thread.Sleep(2);

            u1[Program.Read_count - 1] = a;
            u2[Program.Read_count - 1] = b;
            sample_position[Program.Read_count - 1] = c;
                  
                    progressBar1.Value = (int)(100 * Program.Read_count / sample_counts);

                    if (Program.Read_count == sample_counts)
                    {

                        if (Program.port.IsOpen)
                        {
                            closing = true;
                        }
                        MessageBox.Show("Data has been acquired");
                        progressBar1.Value = 0;
                        Program.Read_count = 0;

                    }
                  else
                      closing = false;

        }
    


    }
}
  