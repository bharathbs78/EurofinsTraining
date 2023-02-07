﻿using SimpleCalculator.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator.WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fno=int.Parse(textBox1.Text);
            int sno=int.Parse(textBox2.Text);
            int sum=Calculator.FindSum(fno, sno);//referenced by using SimpleCalculator.Business
            MessageBox.Show($"The sum of {fno} and {sno} is {sum}");
        }
    }
}
