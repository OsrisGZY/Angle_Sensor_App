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
    public partial class parameter : Form
    {
        public parameter()
        {
            InitializeComponent();
        }

        //user variables
        public bool display; //to show if the win is displayed


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
                MessageBox.Show("Blank error:none-value parameters exist!");
            else
            {
                Program.fine_sin_offeset = double.Parse(textBox1.Text);
                Program.fine_cos_offeset = double.Parse(textBox2.Text);
                Program.fine_sin_amplitude = double.Parse(textBox3.Text);
                Program.fine_cos_amplitude = double.Parse(textBox4.Text);
                Program.fine_envelope = double.Parse(textBox5.Text);
                Program.fine_Angle_Offset = double.Parse(textBox6.Text);
                Program.coarse_sin_offeset = double.Parse(textBox7.Text);
                Program.coarse_cos_offeset = double.Parse(textBox8.Text);
                Program.coarse_sin_amplitude = double.Parse(textBox9.Text);
                Program.coarse_cos_amplitude = double.Parse(textBox10.Text);
                Program.coarse_envelope = double.Parse(textBox11.Text);
                Program.coarse_Angle_Offset = double.Parse(textBox12.Text);

                MessageBox.Show("Parameters have been reset!");
                this.Close();
            }
        }


        private void parameter_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.fine_sin_offeset.ToString();
            textBox2.Text = Program.fine_cos_offeset.ToString();
            textBox3.Text = Program.fine_sin_amplitude.ToString();
            textBox4.Text = Program.fine_cos_amplitude.ToString();
            textBox5.Text = Program.fine_envelope.ToString();
            textBox6.Text = Program.fine_Angle_Offset.ToString();
            textBox7.Text = Program.coarse_sin_offeset.ToString();
            textBox8.Text = Program.coarse_cos_offeset.ToString();
            textBox9.Text = Program.coarse_sin_amplitude.ToString();
            textBox10.Text = Program.coarse_cos_amplitude.ToString();
            textBox11.Text = Program.coarse_envelope.ToString();
            textBox12.Text = Program.coarse_Angle_Offset.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //允许输入数字、小数点、删除键和负号  
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox1.Text = "";
                e.Handled = true;
            }
            if (e.KeyChar == (char)('-'))
            {
                if (textBox1.Text != "")
                {
                    MessageBox.Show("请输入正确的数字");
                    this.textBox1.Text = "";
                    e.Handled = true;
                }
            }
            //小数点只能输入一次  
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox1.Text = "";
                e.Handled = true;
            }
            //第一位不能为小数点  
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox1.Text = "";
                e.Handled = true;
            }
            //第一位是0，第二位必须为小数点  
            if (e.KeyChar != (char)('.') && ((TextBox)sender).Text == "0")
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox1.Text = "";
                e.Handled = true;
            }
            //第一位是负号，第二位不能为小数点  
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox1.Text = "";
                e.Handled = true;
            }
        }

    

    }
}
