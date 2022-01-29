using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static String al = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        String chText = "";
        int key;
        int len = al.Length;
        String dch = "";

        static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                while (b != 0)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }

                return a;
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.textBox1.AutoSize = false;
            this.textBox1.Height = 100;
            this.textBox3.AutoSize = false;
            this.textBox3.Height = 100;
            this.textBox4.AutoSize = false;
            this.textBox4.Height = 100;
            this.textBox5.AutoSize = false;
            this.textBox5.Height = 100;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox1.Text = textBox1.Text.ToUpper();
            if (radioButton2.Checked)
            {
                key = int.Parse(textBox2.Text);
            }
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    for (int j = 0; j < al.Length; j++)
                    {
                        if (al[j] == textBox1.Text[i])
                        {                            
                            chText += al[((j+1) * key) % al.Length];
                            break;
                        }
                        else if (GCD(key, 32) != 1)
                    {
                        textBox4.Text = "Введите верный ключ";
                    }

                    }
                }
            if (GCD(key, 32) == 1)
            {
                textBox4.Text = chText;
                textBox3.Text = chText;
                
            }
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Random rnd = new Random();
                key = rnd.Next(0, 31);

                while (GCD(key, 32) != 1)
                    key = rnd.Next(0, 31);
                textBox2.Text = key.ToString();
                

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            key = int.Parse(textBox2.Text);
            for (int i = 0; i < textBox3.Text.Length; i++) {
                for (int z = 0; z < len; z++)
                {
                    if (al[z] == textBox3.Text[i])
                    {
                        for (int f = 0; f < len; f++)
                        {
                            int temp = ((f * (len) + z) % key);
                            if (temp == 0)
                            {
                                int r = (f * (len) + z) / key;
                                dch += al[r-1];
                               
                                break;

                            }
                        }
                    }
                }
               
            }
            textBox5.Text = dch;
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chText = "";
            textBox1.Text = "";
            dch = "";
            textBox5.Text = dch;
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
