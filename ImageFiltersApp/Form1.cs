using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFiltersApp
{
    public partial class Form1 : Form
    {
        private Bitmap? originalImage;
		public static readonly object locker = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var file = openFileDialog1.FileName;
                originalImage = new Bitmap(file);
                pictureBoxOriginal.Image = originalImage;
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Najpierw zaladuj obrazek!");
                return;
            }

            Bitmap bmpGray = new Bitmap(originalImage.Width, originalImage.Height);
            Bitmap bmpNeg = new Bitmap(originalImage.Width, originalImage.Height);
            Bitmap bmpThresh = new Bitmap(originalImage.Width, originalImage.Height);
            Bitmap bmpMirror = new Bitmap(originalImage.Width, originalImage.Height);

            buttonProcess.Enabled = false;

            Thread t1 = new Thread(() => ApplyGrayscale(new Bitmap(originalImage), bmpGray));
            Thread t2 = new Thread(() => ApplyNegative(new Bitmap(originalImage), bmpNeg));
            Thread t3 = new Thread(() => ApplyThreshold(new Bitmap(originalImage), bmpThresh));
            Thread t4 = new Thread(() => ApplyMirror(new Bitmap(originalImage), bmpMirror));

            t1.Start(); t2.Start(); t3.Start(); t4.Start();

            Task.Run(() =>
            {
                t1.Join(); t2.Join(); t3.Join(); t4.Join();

                this.Invoke((MethodInvoker)delegate
                {
                    pictureBoxGray.Image = bmpGray;
                    pictureBoxNegative.Image = bmpNeg;
                    pictureBoxThreshold.Image = bmpThresh;
                    pictureBoxMirror.Image = bmpMirror;
                    buttonProcess.Enabled = true;
                });
            });
        }

        private void ApplyGrayscale(Bitmap src, Bitmap dest)
        {
            for (int x = 0; x < src.Width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    Color p;

                    lock (locker)
                    {

                        p = src.GetPixel(x, y);

                        int avg = (p.R + p.G + p.B) / 3;
                        dest.SetPixel(x, y, Color.FromArgb(p.A, avg, avg, avg));
                    }
                }
            }
        }

        private void ApplyNegative(Bitmap src, Bitmap dest)
        {
            for (int x = 0; x < src.Width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    Color p;

                    lock (locker)
                    {
                        p = src.GetPixel(x, y);
                        dest.SetPixel(x, y, Color.FromArgb(p.A, 255 - p.R, 255 - p.G, 255 - p.B));
                    }
                }
            }
        }

        private void ApplyThreshold(Bitmap src, Bitmap dest)
        {
            for (int x = 0; x < src.Width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    Color p;

                    lock (locker)
                    {
                        p = src.GetPixel(x, y);
                        int avg = (p.R + p.G + p.B) / 3;
                        int value = avg > 160 ? 255 : 0;
                        dest.SetPixel(x, y, Color.FromArgb(p.A, value, value, value));
                    }
                }
            }
        }

        private void ApplyMirror(Bitmap src, Bitmap dest)
        {
            int width = src.Width;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    Color p;

                    lock (locker)
                    {
                        p = src.GetPixel(x, y);
                        dest.SetPixel(width - 1 - x, y, p);
                    }
                }
            }
        }
    }
}
