using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "jpg Files|*.jpg|png Files|*.png";
            op.ShowDialog();
            Bitmap bmp = (Bitmap)Bitmap.FromFile(op.FileName);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    byte gray=(byte)(.299*c.R+.587*c.G+.114*c.B);
                    bmp.SetPixel(x, y, Color.FromArgb(gray,gray,gray));
                }
            }
            pictureBox2.Image = bmp;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sa = new SaveFileDialog();
            sa.Filter = "jpg File|*.jpg|png File|*.PNG";
            sa.ShowDialog();
            Bitmap f = new Bitmap(this.Width,this.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            DrawToBitmap(f, new Rectangle(0,0,this.Width,this.Height));
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.Save(sa.FileName);
        }
    }
}
