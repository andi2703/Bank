using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads
{
    public partial class Form1 : Form
    {
        Bank bank = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                bank = Serializer<Bank>.Load("bank.xml");
            }
            catch
            {
                bank = new Bank { Money = 100000, Name = "Alfa", Percent = 10 };
            }
            textBox1.Text = bank.Money.ToString();
            textBox2.Text = bank.Name;
            textBox3.Text = bank.Percent.ToString();
            bank.PropertyChanged += Bank_PropertyChanged;
        }

        private void Bank_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bank.Money = Convert.ToInt32(textBox1.Text);
            ShowProp();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bank.Name = textBox2.Text;
            ShowProp();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bank.Percent = Convert.ToInt32(textBox3.Text);
            ShowProp();
        }

        void ShowProp()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            label4.Text = bank.property + " сохранено";
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label4.Text = "";
            (sender as Timer).Stop();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
