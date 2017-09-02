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
using System.IO.Ports;
using System.Threading;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;


namespace UserApp
{
    public partial class Analyse : Form
    {
        public Analyse()
        {
            InitializeComponent();
            closing = true;
 
        }

        private void Analyse_Load(object sender, EventArgs e)
        {

        }
        public bool display;

        private void button2_Click(object sender, EventArgs e)
        {
            closing = false;

            Program.port = new SerialPort();
            Program.port.PortName = "COM4";
            Program.port.BaudRate = 115200;
            Program.port.DataBits = 8;
            Program.port.Parity = Parity.None;
            Program.port.StopBits = StopBits.One;
            Program.port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            Program.Read_count = 0;
            Program.port.Open();
        }


        public bool closing;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(1);
            SerialPort sp = (SerialPort)sender;

            if (closing)
            {
                sp.DiscardInBuffer();
                return;
            }

            closing = true;
            this.COUNT.Invoke(
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
                               while (search)
                               {
                                   if (now.Substring(26, 2) == "55")
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
                  COUNT.Text = Program.Read_count.ToString();

                  bt = null;

              }
               ));



        }

        public string angle_value, sin_value, cos_value;
        public Plot_User plot;

        private void count_TextChanged(object sender, EventArgs e)
        {

  
            double c = Program.velue_convert(angle_value, 1);
            double num = Program.Read_count;

            ANGLE.Text = c.ToString();
            plot = new Plot_User();
            plot.plot_Point(num, c);
            plot.Dispose();

            Thread.Sleep(10);
            closing = false;
  

        }

        private void button1_Click(object sender, EventArgs e)
        {

           this.Close();
        }

        private void Analyse_Click(object sender, EventArgs e)
        {
            if (!closing)
            {
                closing = true;
                Program.port.Close();
                Thread.Sleep(10);
                MessageBox.Show("Press EXIT to exit!");
            }
        }


         






    }

}
