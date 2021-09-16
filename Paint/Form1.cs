using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
namespace Paint
{
    public partial class Form1 : Form
    {

        Graphics g;
        int x;
        int y;
        bool draw;
        Pen p;
        int psize = 1; //declaring pen size
        bool islight = true;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            
            p = new Pen(Color.Black, psize);
            
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            maxim.Maximizing(this);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            x = -1;
            y = -1;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw && x != -1 && y != -1)
            {
                g.DrawLine(p, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            p.Width = Int32.Parse(textBox1.Text.ToString());
            if (textBox1.Text == null)
            {
                MessageBox.Show("You must type a value");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            DialogResult window =  cd.ShowDialog();
            if (window == DialogResult.OK)
            {
                p.Color = cd.Color;
                button4.BackColor = cd.Color;
                Color c = cd.Color;
                string ColorName = c.Name.ToString();

                label2.Text = "Name/Hex code: "+ColorName;
            }
        }
        ColorDialog cd = new ColorDialog();
        private void button5_Click(object sender, EventArgs e)
        {
            
            DialogResult window2 = cd2.ShowDialog();
            if (window2 == DialogResult.OK)
            {
                pictureBox1.BackColor = cd2.Color;
                button5.BackColor = cd2.Color;
                Color c2 = cd2.Color;
                string Colorname2 = c2.Name.ToString();
                label3.Text = "Name/Hex code: " + Colorname2;

            }
        }
        ColorDialog cd2 = new ColorDialog();


        private void button6_Click(object sender, EventArgs e)
        {
            

            if (islight == false)
            {

                this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
                    label1.ForeColor = Color.Black;
                    button4.BackColor = System.Drawing.SystemColors.ScrollBar;
                button4.ForeColor = Color.Black;
                button5.ForeColor = Color.Black;
                    button5.BackColor = System.Drawing.SystemColors.ScrollBar;
                    panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
                button1.BackColor = System.Drawing.SystemColors.ScrollBar;
                    button2.BackColor = System.Drawing.SystemColors.ScrollBar;
                    button3.BackColor = System.Drawing.SystemColors.ScrollBar;
                    label2.ForeColor = Color.Black;
                button6.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
                button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
                    label3.ForeColor = Color.Black;
                    this.button6.Image = global::Paint.Resource1.darkk;
                islight = true;
                
            }
            else if (islight == true)
            {
                panel2.BackColor = Color.FromArgb(40, 40, 40);
                label1.ForeColor = Color.White;
                button4.BackColor = Color.Black;
                button4.ForeColor = Color.White;
                button5.BackColor = Color.Black;
                button5.ForeColor = Color.White;
                panel1.BackColor = Color.FromArgb(40, 40, 40);
                button1.BackColor = Color.FromArgb(40, 40, 40);
                button2.BackColor = Color.FromArgb(40, 40, 40);
                button3.BackColor = Color.FromArgb(40, 40, 40);
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                this.button6.Image = global::Paint.Resource1.light1;
                button6.FlatAppearance.MouseDownBackColor = Color.FromArgb(40,40, 40);
                button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 40, 40);
                islight = false;
            }
            


        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                DialogResult dr = MessageBox.Show("Are you sure to open new file without saving recent one?","Confirmation", MessageBoxButtons.YesNo);
                if(dr== DialogResult.Yes)
                {
                    pictureBox1.Refresh();
                }
                else if (dr == DialogResult.No)
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "Save as PNG (*.png)|*.png";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        int width = Convert.ToInt32(pictureBox1.Width);
                        int height = Convert.ToInt32(pictureBox1.Height);
                        Bitmap bmp = new Bitmap(width, height);
                        pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                        bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    pictureBox1.Refresh();
                }
            }
            else
            {
                pictureBox1.Refresh();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Save as PNG (*.png)|*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureBox1.Width);
                int height = Convert.ToInt32(pictureBox1.Height);
                Bitmap bmp = new Bitmap(width, height);
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }

        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Discord.gg/FQ22fb2\n Account: advellerd#5711", "Contact");
        }

        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
