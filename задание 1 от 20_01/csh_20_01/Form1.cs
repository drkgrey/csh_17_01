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
       Worker[] a = new Worker[1];
        public Form1()
        {
            InitializeComponent();
            if (Int32.TryParse(input.Text, out int number))
                WorkersList.n = number;
            a = WorkersList.Create();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (Int32.TryParse(input.Text, out int number)) 
            WorkersList.n = number;
            a = WorkersList.Create();
            foreach (var i in WorkersList.Show()) { label1.Text += i; }
        }

        private void Sort_CheckedChanged(object sender, EventArgs e)
        {
            if (Sort.Checked)
            {
                Array.Sort(a, new CompareBySalary());
                label1.Text = "";
                foreach (var i in WorkersList.Show()) { label1.Text += i; }
            }
        }
    }
}
