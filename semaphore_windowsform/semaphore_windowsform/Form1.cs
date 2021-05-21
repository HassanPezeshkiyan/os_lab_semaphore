using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace semaphore_windowsform
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread_1 = new Thread(adding_lb1);
            thread_1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread_2 = new Thread(adding_lb2);
            thread_2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void adding_lb1()
        {
            for(int i=0; i<10; i++)
            listBox1.Items.Add("item"+" "+listBox1.Items.Count.ToString());
        }

        private void adding_lb2()
        {
            for (int i = 0; i < 10; i++)
                listBox2.Items.Add("item" + " " + listBox2.Items.Count.ToString());
        }
    }
}
