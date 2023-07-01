using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System;
using System.Diagnostics;
using AForge.Imaging.Filters;

namespace FractalFeedback
{
    public partial class Fractal : Form
    {
        public Model model { get; private set; }
        public Fractal()
        {
            InitializeComponent();
            if (this.model == null)
            {
                this.model = new Model();
            }
        }

        public Fractal(Model model)
            : this()
        {
            this.model = model;
        }

        Random random = new Random();
        private void Snap()
        {
            try
            {
                int chromeHeight = this.Height - pictureBox1.Height;
                int chromeWidth = this.Width - pictureBox1.Width;
                float scaleX = model.scaleXSeed + (float)random.Next(model.scaleXRandomMin, model.scaleXRandomMax) / model.scaleXRandomDivisor;
                float scaleY = model.scaleYSeed + (float)random.Next(model.scaleYRandomMin, model.scaleYRandomMax) / model.scaleYRandomDivisor;
                pictureBox1.Image = F(ScreenShot(pictureBox1.Width, pictureBox1.Height, this.Location.X + chromeWidth, this.Location.Y + chromeHeight, this.ClientRectangle.Size, scaleX, scaleY));
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

        bool firstTime = true;
        public Bitmap ScreenShot(int width, int height, int x, int y, Size size, float scaleX, float scaleY)
        {
            Bitmap screenShotBMP;
            if (firstTime)
            {
                screenShotBMP = new Bitmap(width,
                    height, PixelFormat.Format24bppRgb);

                using (Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP))
                {
                    screenShotGraphics.CopyFromScreen(x,
                        y, 0, 0, size,
                        CopyPixelOperation.SourceCopy);
                }
                firstTime = false;
            }
            else
            {
                screenShotBMP = new Bitmap(pictureBox1.Image);
            }
            return ResizeBitmap(screenShotBMP, (int)(width * scaleX), (int)(height * scaleY), width, height);
        }

        public Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight, int width, int height)
        {
            Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.TranslateTransform((float)width / 2, (float)height / 2);
                g.RotateTransform(model.rotateAngle);
                g.TranslateTransform(-(float)width / 2, -(float)height / 2);
                g.DrawImage(b, (width - nWidth) / 2, (height - nHeight) / 2, nWidth, nHeight);
                var radius = random.Next(model.dotRadiusMin, model.dotRadiusMax);
                //Dot(random.Next(0, nWidth) - radius, random.Next(0, nHeight) - radius, radius * 2, g);
                if (this.downY != null)
                    Dot(this.downX.Value - radius, this.downY.Value - radius, radius * 2, g);


                // if (this.moveY != null)
                //     Dot(this.moveX.Value - radius, this.moveY.Value - radius, radius * 2, g);
            }

            return result;
        }

        private void Dot(int x, int y, int diameter, Graphics g)
        {
            g.DrawEllipse(new Pen(Color.FromArgb(random.Next(model.redMin, model.redMax), random.Next(model.greenMin, model.greenMax), random.Next(model.blueMin, model.blueMax)), model.brushWidth),
                  new Rectangle(x, y, diameter, diameter));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Snap();
        }

        int? downX = null;
        int? downY = null;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            downX = e.X;
            downY = e.Y;
        }

        int? moveX = null;
        int? moveY = null;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            moveX = e.X;
            moveY = e.Y;
        }

        FiltersSequence filters = null;

        public Bitmap F(Bitmap screenshot)
        {
            if (filters == null)
            {
                filters = new FiltersSequence();

                foreach (var f in model.Filters)
                {
                    filters.Add(CreateFilter(f.Id));
                }

                // create filters sequence
                Debug.WriteLine(filters.Count);

            }
            //return screenshot;
            return filters.Apply(screenshot);
        }

        private IFilter CreateFilter(string id)
        {
            switch(id)
            {
                case "Edges": return new Edges();
                case "Erosion": return new Erosion();
                case "ExtractChannel": return new ExtractChannel();
                case "GaussianBlur": return new GaussianBlur();
                case "GaussianSharpen": return new GaussianSharpen();
                case "AdaptiveSmoothing": return new AdaptiveSmoothing();
                case "AdditiveNoise": return new AdditiveNoise();
                case "BlobsFiltering": return new BlobsFiltering();
                case "Blur": return new Blur();
                case "BrightnessCorrection": return new BrightnessCorrection();
                case "OilPainting": return new OilPainting();
                case "ChannelFiltering": return new ChannelFiltering();
                case "Closing": return new Closing();
                case "ColorFiltering": return new ColorFiltering();
                case "Sepia": return new Sepia();
                case "Dilatation": return new Dilatation();
                case "RotateChannels": return new RotateChannels();
                case "Sharpen": return new Sharpen();
                case "HueModifier": return new HueModifier();
                case "ContrastStretch": return new ContrastStretch();
                case "YCbCrFiltering": return new YCbCrFiltering();
                case "TopHat": return new TopHat();
                case "PointedColorFloodFill": return new PointedColorFloodFill();
                case "Opening": return new Opening();
                case "PointedMeanFloodFill": return new PointedMeanFloodFill();
                case "SaturationCorrection": return new SaturationCorrection();
                case "SaltAndPepperNoise": return new SaltAndPepperNoise();
                case "SimplePosterization": return new SimplePosterization();
                case "YCbCrExtractChannel": return new YCbCrExtractChannel();
                case "YCbCrLinear": return new YCbCrLinear();
                case "ConservativeSmoothing": return new ConservativeSmoothing();
                case "HSLFiltering": return new HSLFiltering();
                case "HSLLinear": return new HSLLinear();
                case "LevelsLinear": return new LevelsLinear();
                case "Mean": return new Mean();
                case "Median": return new Median();
                case "ConnectedComponentsLabeling": return new ConnectedComponentsLabeling();
                case "HistogramEqualization": return new HistogramEqualization();
                case "Jitter": return new Jitter();
                case "Shrink": return new Shrink();
                case "WaterWave": return new WaterWave();
                case "Invert": return new Invert();
            }
            return null;
        }
    }
}