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
    public partial class ZeroPosition : Form
    {
        public ZeroPosition()
        {
            InitializeComponent();
            state = 0;
        }
        //user variables
        public bool display;
        private int state;
        private void ZeroPosition_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.zeros_angle.ToString();
            textBox2.Text = Program.zeros_bit.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text=="")
                MessageBox.Show("Error: Blank exsits!");
            else
            {
                Program.zeros_angle = double.Parse(textBox1.Text);
                Program.zeros_bit = int.Parse(textBox2.Text);
                this.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(this.state==0)
               {
                 this.state = 1;
                 textBox2.Text = ((int)(double.Parse(textBox1.Text)/360*Math.Pow(2,24))).ToString();
                }
            this.state = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.state == 0)
            {
                this.state = 2;
                textBox1.Text = ((int.Parse(textBox2.Text))*360/Math.Pow(2,24)).ToString();
            }
            this.state = 0;
        }

    }
}
