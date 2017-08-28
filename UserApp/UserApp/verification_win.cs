using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserApp
{
    public partial class verification_win : Form
    {
        public verification_win()
        {
            InitializeComponent();
            current_count = 1;
            radioButton1.Select();
            comboBox1.Text = "100";
            is_clear = true;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verification_START_Click(object sender, EventArgs e)
        {
         // Original Point (245,220)
            // x=x0+(45+rand(0~10))cosN; y=y0+(45+rand(0~10))sinN;
            int  x0=251,y0=270;
            while (current_count <= sample_counts)
            {
                //if clear hasn't benn done start can't work
                if (!is_clear)
                {
                    MessageBox.Show("Clear Button shoud been click before start!","Attention");
                    break;
                }
            Graphics g = pictureBox1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Red);
            Brush brush2 = new SolidBrush(Color.Yellow);
            Random rand =new Random();
            if (current_count == sample_counts)
            {
                int xx = x0;
                int yy = y0;
                Rectangle rect = new Rectangle(xx - 5, yy - 5, 10, 10);
                g.FillEllipse(brush, rect);

            }
            else
            {
                int radio_1 = 100 +rand.Next(11);
                int radio_2 = 100 +rand.Next(11);


                double x = x0 + radio_1 * Math.Cos(Math.PI * sample_counts * 2 / current_count);
                double y = y0 + radio_2 * Math.Sin(Math.PI * sample_counts * 2 / current_count);

                int xx = (int)Math.Ceiling(x);
                int yy = (int)Math.Ceiling(y);

                Rectangle rect = new Rectangle(xx - 3, yy - 3, 6, 6);

                 radio_1 = 150 + 2*rand.Next(11);
                 radio_2 = 150 + 2*rand.Next(11);


                 x = x0 + radio_1 * Math.Cos(Math.PI * sample_counts * 2 / current_count);
                 y = y0 + radio_2 * Math.Sin(Math.PI * sample_counts * 2 / current_count);

                 xx = (int)Math.Ceiling(x);
                 yy = (int)Math.Ceiling(y);

                 Rectangle rect2 = new Rectangle(xx - 3, yy - 3, 6, 6);

                g.FillEllipse(brush, rect);
                g.FillEllipse(brush2, rect2);

            }

    

                current_count += 1;

                brush.Dispose();
                g.Dispose();
                
            }

            current_count = 1;
            is_clear = false;
            timer1.Enabled = true;
        }

        private void verification_clear_Click(object sender, EventArgs e)
        {
            is_clear = true;
            pictureBox1.Image = null;
            if(choice==1)
                 pictureBox1.Image = global::UserApp.Properties.Resources.verification;
            else
                pictureBox1.Image = global::UserApp.Properties.Resources.verification_coarse;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = global::UserApp.Properties.Resources.verification;
            choice = 1;
            current_count = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = global::UserApp.Properties.Resources.verification_coarse;
            choice = 0;
            current_count = 1;

        }

        private void verification_win_Load(object sender, EventArgs e)
        {
        }
        // fine channel or coarse channel 
     
        
        private int choice;
        public bool display; //to show if the win is displayed
        // sample counts
        private int sample_counts=0;
        private int current_count;

        private bool is_clear;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sample_counts = int.Parse(comboBox1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if(progressBar1.Value==100)
            {
                timer1.Enabled = false;
                MessageBox.Show("Data get!", "GZY");
                progressBar1.Value = 0;
            }
        }

     /*   private void verification_win_MouseMove(object sender, MouseEventArgs e)
        {
            this.label4.Text = e.X.ToString() + ","+ e.Y.ToString();
        } */
    }
}
