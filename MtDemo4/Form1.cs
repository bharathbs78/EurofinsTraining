using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtDemo4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            foreach(var file in Directory.GetFiles(@"C:\Users\Admin\Desktop\Image"))
            {
                Image img=Image.FromFile(file);
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                FileInfo fileInfo= new FileInfo(file);
                img.Save($@"C:\Users\Admin\Desktop\SavedImages\{fileInfo.Name}");
            }
            MessageBox.Show($" Elapsed seconds {sw.ElapsedMilliseconds}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                Stopwatch sw = Stopwatch.StartNew();
                Parallel.ForEach(Directory.GetFiles(@"C:\Users\Admin\Desktop\Image"), file =>
                {
                    {
                        Image img = Image.FromFile(file);
                        img.RotateFlip(RotateFlipType.Rotate180FlipX);
                        FileInfo fileInfo = new FileInfo(file);
                        img.Save($@"C:\Users\Admin\Desktop\SavedImages\{fileInfo.Name}");
                    }
                });
                MessageBox.Show($" Elapsed seconds {sw.ElapsedMilliseconds}");
            });
        }
    }
}
