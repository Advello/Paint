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

namespace Paint
{
    static class maxim
    {
        static bool max = false;
        static Point old_location, default_loc;
        static Size old2_size, default_size2;
        public static void setInital(Form form)
        {
            old_location = form.Location;
            old2_size = form.Size;
            default_loc = form.Location;
            default_size2 = form.Size;

        }
        static void Maximize(Form form)
        {
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            form.WindowState = FormWindowState.Normal;
            form.Location = new Point(0, 0);
            form.Size = new Size(x, y);
        }
        public static void Maximizing(Form form)
        {
            
                if (max == false)
                {
                    old_location = new Point(form.Location.X, form.Location.Y);
                    old2_size = new Size(form.Size.Width, form.Size.Height);
                    Maximize(form);
                    max = true;
                }
                else
                {
                    form.Location = old_location;
                    form.Size = old2_size;
                    max = false;

                }
        }
    }
}
