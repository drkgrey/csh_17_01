using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csh_20_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            int number;
            if (Int32.TryParse(input.Text, out number)) 
            WorkersList.n = number;
            
            foreach (var i in WorkersList.Show()) { label1.Text += i; }
        }
    }
}
