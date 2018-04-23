using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_367_form.ver1._6_pre_beta
{
    public partial class start_form : Form
    {
        public start_form()
        {
            InitializeComponent();
        }

        private void start_form_Load(object sender, EventArgs e)
        {
            //listBox1.Items.Add("                    СЕРВЕР | ПРОТОКОЛ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                //utp                
                Program.utp = true;
                Program.ip_port = st(richTextBox1.Text);
                //Program.port_server = Convert.ToInt32(st(richTextBox2.Text));
            }
            else
            {
                //tcp
                Program.utp = false;
                Program.ip_port = st(richTextBox1.Text);
                //Program.port_server = Convert.ToInt32(st(richTextBox2.Text));
            }
            Close();
        }
        private static string st(string str)
        {
            List<char> ch = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' '
                    && str[i] != '\n')
                    ch.Add(str[i]);
            }
            return new string(ch.ToArray());
        }
    }
}
