using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

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
                int chromeWidth = (this.Width - this.ClientRectangle.Width) / 2;
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

        public Bitmap ScreenShot(int width, int height, int x, int y, Size size, float scaleX, float scaleY)
        {
            Bitmap screenShotBMP;

            screenShotBMP = new Bitmap(width,
                height, PixelFormat.Format24bppRgb);

            using (Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP))
            {
                screenShotGraphics.CopyFromScreen(x,
                    y, 0, 0, size,
                    CopyPixelOperation.SourceCopy);
            }

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
            }

            return result;
        }

        private void Magnifier_Move(object sender, EventArgs e)
        {
            Snap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Snap();
        }
    }
}
