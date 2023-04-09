using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Bouncing_DVD_Logo
{
    public partial class Form1 : Form
    {
        List<Point> pixels = new List<Point>();
        List<string> images = new List<string>();
        static int width = 1535;
        static int height = 840;
        Bitmap imageBits;
        int x;
        int y;
        int xSpeed =4;
        int ySpeed =4;
        string current = "";

        public Form1()
        {
            Random rnd = new Random();
            x = rnd.Next(0, width - 233);
            y = rnd.Next(0, height - 104);
            int chance = rnd.Next(0, 2);
            if(chance == 0)
            {
                xSpeed *= -1;
            }
            else
            {
                ySpeed *= -1;
            }
            InitializeComponent();
            for (int i = 2; i <= 13; i++)
            {
                string image = "images/dvd" + i + ".png";
                images.Add(image);
            }
            imageBits = new Bitmap(images[rnd.Next(images.Count)]);
        }
        
        //public void SwapColor()
        //{
        //    for (int i = 0; i < pixels.Count; i++)
        //    {
        //        Point current = pixels[i];
        //        imageBits.SetPixel(current.X, current.Y, Color.Red);

        //    }
        //}

        //public  void WhoToChange()
        //{
        //    for (int i = 0; i < imageBits.Width; i++)
        //    {
        //        for (int j = 0; j < imageBits.Height; j++)
        //        {
        //            Color current = imageBits.GetPixel(i, j);
        //            if (current.A != 0 && current.R == 0 && current.G == 0 && current.B == 0)
        //            {
        //                pixels.Add(new Point(i, j));
        //            }
        //        }

        //    }
        //}

        private void Draw(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(images.Count);
            Graphics g = e.Graphics;
            Rectangle image = new Rectangle(x, y, 233, 104);
            g.DrawImage(imageBits, image);
            //g.DrawRectangle(new Pen(Color.Red), 0, 0, 1535, 840);
            x += xSpeed;
            y += ySpeed;

            if(ySpeed > 0 && image.Y+image.Height > height)
            {
                ySpeed = ySpeed * -1;
                string newFileName = images[index];
                if(newFileName.Equals(current))
                {
                    newFileName = images[index];
                    Console.WriteLine(newFileName);
                }
                imageBits = new Bitmap(newFileName);
                current = newFileName;
            }
            if (xSpeed > 0 && image.X + image.Width > width)
            {
                xSpeed = xSpeed * -1;
                string newFileName = images[index];
                if (newFileName.Equals(current))
                {
                    newFileName = images[index];
                    Console.WriteLine(newFileName);

                }
                imageBits = new Bitmap(newFileName);
                current = newFileName;

            }
            if (ySpeed < 0 && image.Y < 0)
            {
                ySpeed = ySpeed * -1;
                string newFileName = images[index];
                if (newFileName.Equals(current))
                {
                    newFileName = images[index];
                    Console.WriteLine(newFileName);

                }
                imageBits = new Bitmap(newFileName);
                current = newFileName;

            }
            if (xSpeed < 0 && image.X < 0)
            {
                xSpeed = xSpeed * -1;
                string newFileName = images[index];
                if (newFileName.Equals(current))
                {
                    newFileName = images[index];
                    Console.WriteLine(newFileName);

                }
                imageBits = new Bitmap(newFileName);
                current = newFileName;

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
