using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtDemo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawRedRect(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                // Red Rectangles
                Graphics red = panel1.CreateGraphics();
                Random random = new Random();
                for (int i = 0; i <= 1000; i++)
                {
                    int x = random.Next(panel1.Width);
                    int y = random.Next(panel1.Height);
                    red.DrawRectangle(Pens.Red, x, y, 20, 40);
                    Thread.Sleep(100);
                }
            });
            t.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Blue Rectangles
            Task t2 = new Task(() =>
            {
                Graphics blue = panel2.CreateGraphics();
                Random random = new Random();
                for (int i = 0; i <= 1000; i++)
                {
                    int x = random.Next(panel2.Width);
                    int y = random.Next(panel2.Height);
                    blue.DrawRectangle(Pens.Blue, x, y, 20, 40);
                    Thread.Sleep(100);
                }
            });
            t2.Start();
        }
    }
}
