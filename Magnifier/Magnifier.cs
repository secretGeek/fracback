using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
namespace Magnifier
{
    public partial class Magnifier : Form
    {
        public Magnifier()
        {
            InitializeComponent();
        }
        
        private void Snap()
        {
            try
            {
                int chromeWidth = (this.Width - this.ClientRectangle.Width)/2;
                int chromeHeight = (this.Height - this.ClientRectangle.Height - chromeWidth);

                float scaleX = 2;
                    float scaleY = 2;
                    this.BackgroundImage = ScreenShot(this.ClientRectangle.Width, 
                                                    this.ClientRectangle.Height, 
                                                    this.Location.X + chromeWidth, 
                                                    this.Location.Y + chromeHeight, 
                                                    this.ClientRectangle.Size, 
                                                    scaleX, 
                                                    scaleY);
                
            }
            catch (Exception ex1)
            {
                //Snap!! (and bury)
                Debug.WriteLine(ex1.ToString());
            }
            
        }

        public Bitmap ScreenShot()
        {
            return ScreenShot(
                Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height,
                Screen.PrimaryScreen.Bounds.X,
                Screen.PrimaryScreen.Bounds.Y,
                Screen.PrimaryScreen.Bounds.Size,
                1, 1);
        }


        //bool firstTime = true;
        public Bitmap ScreenShot(int width, int height, int x, int y, Size size, float scaleX, float scaleY)
        {
            Bitmap screenShotBMP;
            //if (firstTime)
            //{
                screenShotBMP = new Bitmap(width,
                    height, PixelFormat.Format24bppRgb);

                using (Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP))
                {
                    screenShotGraphics.CopyFromScreen(x,
                        y, 0, 0, size,
                        CopyPixelOperation.SourceCopy);
                }
            //    firstTime = false;
            //}
            //else
            //{
            //    screenShotBMP = new Bitmap(this.BackgroundImage);
            //}
            return ResizeBitmap(screenShotBMP, (int)(width * scaleX), (int)(height * scaleY), width, height);
        }

        public Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight, int width, int height)
        {
            Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.TranslateTransform((float)width / 2, (float)height / 2);
                g.RotateTransform(10);
                g.TranslateTransform(-(float)width / 2, -(float)height / 2);

                g.DrawImage(b, (width - nWidth) / 2, (height - nHeight) / 2, nWidth, nHeight);
                //var radius = random.Next(model.dotRadiusMin, model.dotRadiusMax);

                //Dot(random.Next(0, nWidth) - radius, random.Next(0, nHeight) - radius, radius * 2, g);
                //if (this.downY != null)
                //    Dot(this.downX.Value - radius, this.downY.Value - radius, radius * 2, g);

               // if (this.moveY != null)
               //     Dot(this.moveX.Value - radius, this.moveY.Value - radius, radius * 2, g);
            }

            return result;
        }

        //private void Dot(int x, int y, int diameter, Graphics g)
        //{
        //    g.DrawEllipse(new Pen(Color.FromArgb(random.Next(model.redMin, model.redMax), random.Next(model.greenMin, model.greenMax), random.Next(model.blueMin, model.blueMax)), model.brushWidth),
        //          new Rectangle(x, y, diameter, diameter));
        //}

        

        private void Magnifier_Move(object sender, EventArgs e)
        {
            Snap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Snap();
        }

        
        //int? downX = null;
        //int? downY = null;

        //private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    downX = e.X;
        //    downY = e.Y;
        //}

        //int? moveX = null;
        //int? moveY = null;

        //private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    moveX = e.X;
        //    moveY = e.Y;
        //}
    }
    
}
