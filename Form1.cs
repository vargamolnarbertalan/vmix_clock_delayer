using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace vmix_delay
{
    public partial class Form1 : Form
    {
        public static DateTime now;
        public static DateTime outputTime;
        public static TimeSpan delay;
        

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            delay = TimeSpan.Parse(textBox1.Text);            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {    
            
            now = DateTime.Now;
            outputTime = now + delay;
            try
            {
                FileStream fs = new FileStream("vmix_delay_time.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                fs.SetLength(0);
                sw.Write(outputTime.ToString("HH:mm"));
                sw.Close();
            }
            catch (IOException)
            {
                output.Text ="catched exception";
            }
            
            output.Text = outputTime.ToString("HH:mm:ss");            
        }
    }
}
