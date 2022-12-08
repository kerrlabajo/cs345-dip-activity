using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPActivity
{
    public partial class DIPActPart1Form : Form
    {
        private Bitmap loaded, processed;
        public DIPActPart1Form()
        {
            InitializeComponent();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox2.Image.Save(saveFileDialog1.FileName);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, pixel);
                }

            }
            pictureBox2.Image = processed;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    processed.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }

            }
            pictureBox2.Image = processed;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, Color.FromArgb(255-pixel.R, 255 - pixel.G, 255 - pixel.B));
                }

            }
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] data = new int[256];
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    loaded.SetPixel(x, y, Color.FromArgb(grey, grey, grey));

                    Color greyed = loaded.GetPixel(x, y);                   
                    data[greyed.R]++;
                }

            }
            processed = new Bitmap(256, 800);
            for (int x = 0; x < processed.Width; x++)
            {
                for(int y = 0; y < processed.Height; y++)
                {
                    processed.SetPixel(x, y, Color.White);
                }
            }
            for(int x = 0; x < processed.Width; x++)
            {
                for(int y = 0; y < Math.Min(data[x] / 5, processed.Height - 1); y++)
                {
                    processed.SetPixel(x, processed.Height - 1 - y, Color.Black);
                }
            }
            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double sepiaR, sepiaG, sepiaB;
            int tempR, tempG, tempB;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);

                    sepiaR = (pixel.R * 0.393) + (pixel.G * 0.769) + (pixel.B * 0.189);
                    sepiaG = (pixel.R * 0.349) + (pixel.G * 0.686) + (pixel.B * 0.168);
                    sepiaB = (pixel.R * 0.272) + (pixel.G * 0.534) + (pixel.B * 0.131);

                    if (sepiaR > 255)
                    {
                        tempR = 255;
                    }
                    else
                    {
                        tempR = (int)sepiaR;
                    }

                    if (sepiaG > 255)
                    {
                        tempG = 255;
                    }
                    else
                    {
                        tempG = (int)sepiaG;
                    }

                    if (sepiaB > 255)
                    {
                        tempB = 255;
                    }
                    else
                    {
                        tempB = (int)sepiaB;
                    }
                    processed.SetPixel(x, y, Color.FromArgb(tempR, tempG, tempB));
                }

            }
            pictureBox2.Image = processed;
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DIPActPart2Form().Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}
