﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;


namespace UserApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //settings initialize
            Program.fine_sin_amplitude = Program.fine_cos_amplitude = Program.coarse_sin_amplitude = Program.coarse_cos_amplitude = 1;
            Program.fine_sin_offeset = Program.fine_cos_offeset = Program.coarse_sin_offeset = Program.coarse_cos_offeset = 0;
            Program.fine_envelope = Program.coarse_envelope = 0;
            Program.fine_Angle_Offset = Program.coarse_Angle_Offset = 0;

            Program.zeros_angle = 0;
            Program.zeros_bit = 0;

            f1 = new verification_win();
            f2 = new Calibration();
            f3 = new parameter();
            f4 = new ZeroPosition();

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            count = 0;
            counts_show.Text = count.ToString();
            Program.port = new SerialPort();
            Program.port.PortName = "COM1";
            Program.port.BaudRate = 9600;
            Program.port.DataBits = 8;
            Program.port.Parity = Parity.Even;
            Program.port.StopBits = StopBits.One;
            Program.port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

      private  void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        this.Position_show.Invoke(
            new MethodInvoker(
                delegate
                {

                   string  now =sp.ReadExisting();  //data cleared after been read
                   int n = now.Length;
                   StringBuilder sb = new StringBuilder();
                    
                  for (int i = 0; i < n/2;i++ )
                    {
                        sb.Append(now[2 * i]);
                    } 
                    this.Position_show.Text = sb.ToString();
                    count++;
                    counts_show.Text = count.ToString();
                }
                            )
                                );
    }



        private void Verification_Click(object sender, EventArgs e)
        {
            f1 = new verification_win();
            f1.display = true;
            f1.Show(); 
            
        }

        private void Calibration_Click(object sender, EventArgs e)
        {
            f2 = new Calibration();
            f2.display = true;
            f2.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            sfd.AddExtension = true;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                System.IO.FileStream fs = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                try
                {
                    sw.Write("Fine_A1:          "+Program.fine_sin_amplitude.ToString()+"\r\n");
                    sw.Write("Fine_d1:          " + Program.fine_sin_offeset.ToString() + "\r\n");
                    sw.Write("Fine_A2:          " + Program.fine_cos_amplitude.ToString() + "\r\n");
                    sw.Write("Fine_d2:          " + Program.fine_cos_offeset.ToString() + "\r\n");
                    sw.Write("Fine_Envelope:    " + Program.fine_envelope.ToString() + "\r\n");
                    sw.Write("Fine_AngleOffset: " + Program.fine_Angle_Offset.ToString() + "\r\n");
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    sw.Close();
                    fs.Close();
                }
            }

        }

        private void Parameters_Click(object sender, EventArgs e)
        {
            f3 = new parameter();
            f3.display = true;
            f3.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyrights by Engineering Research Center for Navigation Technology","GZY");
        }

        private void restoreFactorySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.fine_sin_amplitude = Program.fine_cos_amplitude = Program.coarse_sin_amplitude = Program.coarse_cos_amplitude = 1;
            Program.fine_sin_offeset = Program.fine_cos_offeset = Program.coarse_sin_offeset = Program.coarse_cos_offeset = 0;
            Program.fine_envelope = Program.coarse_envelope = 0;
            Program.fine_Angle_Offset = Program.coarse_Angle_Offset = 0;
            if (f1.display == true)
            {
                f1.display = false;
                f1.Close();
            }
           if (f2.display == true)
           {
               f2.display = false;
               f2.Close();
           } 
            if (f3.display == true)
           {
               f3.display = false;
               f3.Close();
           }
            if (f4.display == true)
            {
                f4.display = false;
                f4.Close();
            } 
            
        }

        //parameter set and relative functions
        public verification_win f1;
        public Calibration f2;
        public parameter f3;
        public ZeroPosition f4;
        public int count;

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please communicate with us by email(1455299869@qq.com)", "Support");
        }

        private void setUZPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4 = new ZeroPosition();
            f4.display = true;
            f4.Show();
        }

        private void Reset_Click(object sender, EventArgs e)
        {

            Program.port.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!Program.port.IsOpen)              
                Program.port.Open();
            if (Program.port.IsOpen)
            {
                Random rand = new Random();
                for (int i = 1; i < 10; i++)
                {

                    double a = rand.Next(101);
                    String b = a.ToString() + " " + (a / 3).ToString() + "___";
                    Program.port.WriteLine(b);
                }
            }
            else
                MessageBox.Show("ERROR");

        }





    }
}
