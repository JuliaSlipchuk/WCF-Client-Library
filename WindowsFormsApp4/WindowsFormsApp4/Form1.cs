using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null && textBox1.Text != "" && Regex.IsMatch(textBox1.Text, @"^\d{1,}$"))
                {

                    label1.Text = client.F4(Int32.Parse(textBox1.Text)).ToString();
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                    label1.Text = "You are failed!";
                }
            }
            catch(Exception)
            {
                label1.Text = "You are failed!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.GetAllElements().ToString() != "null")
                {
                    dataGridView1.DataSource = client.GetAllElements();
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }
            catch(Exception)
            {
                label1.Text = "You are failed!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.GetElementById(Int32.Parse(textBox2.Text)).ToString() != "null" && Regex.IsMatch(textBox2.Text, @"^\d{1,}$"))
                {
                    dataGridView2.DataSource = client.GetElementById(Int32.Parse(textBox2.Text));
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }
            catch(Exception)
            {
                label1.Text = "You are failed!";
            }
        }
    }
}
