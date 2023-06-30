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

namespace FilterFeedback
{
    public partial class Fractal : Form
    {
        public Fractal()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint, true);
        }

        private void Snap()
        {
            try
            {
                int chromeWidth = (this.Width - this.ClientRectangle.Width) / 2;
                int chromeHeight = (this.Height - this.ClientRectangle.Height - chromeWidth);

                float scaleX = 0.999F;
                float scaleY = 0.999F;
                this.BackgroundImage = F(ScreenShot(this.ClientRectangle.Width,
                                                this.ClientRectangle.Height,
                                                this.Location.X + chromeWidth,
                                                this.Location.Y + chromeHeight,
                                                this.ClientRectangle.Size,
                                                scaleX,
                                                scaleY));

            }
            catch (Exception ex1)
            {
                //Snap!! (and bury)
                Debug.WriteLine(ex1.ToString());
            }

        }

        AForge.Imaging.Filters.FiltersSequence filter = null;

        public Bitmap F(Bitmap screenshot)
        {
            if (filter == null)
            {
                // create filters sequence
                filter = new AForge.Imaging.Filters.FiltersSequence();
                
                //** Bases classes of filters
                //AForge.Imaging.Filters.BaseFilter());
                //AForge.Imaging.Filters.BaseInPlaceFilter());
                //AForge.Imaging.Filters.BaseInPlaceFilter2());
                //AForge.Imaging.Filters.BaseInPlacePartialFilter());
                //AForge.Imaging.Filters.BaseQuadrilateralTransformationFilter());
                //AForge.Imaging.Filters.BaseResizeFilter());
                //AForge.Imaging.Filters.BaseRotateFilter());
                //AForge.Imaging.Filters.BaseTransformationFilter());
                //AForge.Imaging.Filters.BaseUsingCopyPartialFilter());
                //AForge.Imaging.Filters.ErrorDiffusionDithering());

                //** filters that require constructors arguments
                //filter.Add(new AForge.Imaging.Filters.CanvasCrop(Rectangle));
                //filter.Add(new AForge.Imaging.Filters.CanvasFill(Rectangle));
                //filter.Add(new AForge.Imaging.Filters.CanvasMove(movePoint));
                //filter.Add(new AForge.Imaging.Filters.Convolution(kernel));
                //filter.Add(new AForge.Imaging.Filters.CornersMarker (detector));
                //filter.Add(new AForge.Imaging.Filters.Crop (rectangle));
                //filter.Add(new AForge.Imaging.Filters.ErrorDiffusionToAdjacentNeighbors(coefficients));
                //filter.Add(new AForge.Imaging.Filters.FilterIterator());
                //filter.Add(new AForge.Imaging.Filters.Grayscale(cr, cg, db)); 
                //filter.Add(new AForge.Imaging.Filters.HitAndMiss(se));
                //filter.Add(new AForge.Imaging.Filters.ImageWarp(warpMap));
                //filter.Add(new AForge.Imaging.Filters.Mirror(x,y));
                //filter.Add(new AForge.Imaging.Filters.QuadrilateralTransformationBilinear(sourceCorners));
                //filter.Add(new AForge.Imaging.Filters.QuadrilateralTransformationNearestNeighbor(sourceCorners));
                //filter.Add(new AForge.Imaging.Filters.ReplaceChannel(channel, channelImage)); 
                //filter.Add(new AForge.Imaging.Filters.ResizeBicubic(newWidth, newHeight));
                //filter.Add(new AForge.Imaging.Filters.ResizeBilinear(newWidth, newHeight)); 
                //filter.Add(new AForge.Imaging.Filters.ResizeNearestNeighbor(newWidth, newHeight));
                //filter.Add(new AForge.Imaging.Filters.RotateBicubic(angle));
                //filter.Add(new AForge.Imaging.Filters.RotateBilinear(angle));
                //filter.Add(new AForge.Imaging.Filters.RotateNearestNeighbor(angle));                
                //filter.Add(new AForge.Imaging.Filters.TexturedFilter(texture, filter));
                //filter.Add(new AForge.Imaging.Filters.TexturedMerge(generator));
                //filter.Add(new AForge.Imaging.Filters.Texturer(generator));
                //filter.Add(new AForge.Imaging.Filters.YCbCrReplaceChannel(channel, channelImage));

                //Nice combo
                //filter.Add(new AForge.Imaging.Filters.SaltAndPepperNoise(0.004));
                //filter.Add(new AForge.Imaging.Filters.ConnectedComponentsLabeling());

                //Nice combo
                //filter.Add(new AForge.Imaging.Filters.PointedColorFloodFill ());
                //filter.Add(new AForge.Imaging.Filters.WaterWave());

                //filter.Add(new AForge.Imaging.Filters.SaltAndPepperNoise(50));
                filter.Add(new AForge.Imaging.Filters.Opening());
                filter.Add(new AForge.Imaging.Filters.RotateChannels());
                filter.Add(new AForge.Imaging.Filters.WaterWave());
                

                // add filters to the sequence
                //e.g.
                //Yes filter.Add(new AForge.Imaging.Filters.Edges ());
                //Yes filter.Add(new AForge.Imaging.Filters.Erosion ());
                //Yes filter.Add(new AForge.Imaging.Filters.ExtractChannel ());
                //Yes filter.Add(new AForge.Imaging.Filters.GaussianBlur ());
                //Yes filter.Add(new AForge.Imaging.Filters.GaussianSharpen ());                
                //Yes filter.Add(new AForge.Imaging.Filters.AdaptiveSmoothing());
                //Yes filter.Add(new AForge.Imaging.Filters.AdditiveNoise());
                //Yes filter.Add(new AForge.Imaging.Filters.BlobsFiltering());
                //Yes filter.Add(new AForge.Imaging.Filters.Blur());
                //Yes filter.Add(new AForge.Imaging.Filters.BrightnessCorrection()); //goes bright
                //Yes filter.Add(new AForge.Imaging.Filters.OilPainting ());
                //Yes filter.Add(new AForge.Imaging.Filters.ChannelFiltering());
                //Yes filter.Add(new AForge.Imaging.Filters.Closing());
                //Yes filter.Add(new AForge.Imaging.Filters.ColorFiltering());
                //Yes filter.Add(new AForge.Imaging.Filters.Sepia ());
                //Yes filter.Add(new AForge.Imaging.Filters.Dilatation ());
                //Yes filter.Add(new AForge.Imaging.Filters.RotateChannels());
                
                //Yes filter.Add(new AForge.Imaging.Filters.Sharpen ());
                //Yes filter.Add(new AForge.Imaging.Filters.HueModifier ());
                //Yes filter.Add(new AForge.Imaging.Filters.ContrastStretch());
                //Yes filter.Add(new AForge.Imaging.Filters.YCbCrFiltering ());
                //Yes filter.Add(new AForge.Imaging.Filters.TopHat ());
                //Yes filter.Add(new AForge.Imaging.Filters.PointedColorFloodFill ());
                //Yes filter.Add(new AForge.Imaging.Filters.Opening ());
                //Yes filter.Add(new AForge.Imaging.Filters.PointedMeanFloodFill ());
                //Yes filter.Add(new AForge.Imaging.Filters.SaturationCorrection ());
                //Yes filter.Add(new AForge.Imaging.Filters.SaltAndPepperNoise());
                //Yes filter.Add(new AForge.Imaging.Filters.SimplePosterization ());
                //Yes filter.Add(new AForge.Imaging.Filters.YCbCrExtractChannel ());
                //Yes filter.Add(new AForge.Imaging.Filters.YCbCrLinear ());
                //Yes (nice) filter.Add(new AForge.Imaging.Filters.ConservativeSmoothing());
                
                //Yes filter.Add(new AForge.Imaging.Filters.HSLFiltering ());
                //Yes filter.Add(new AForge.Imaging.Filters.HSLLinear ());
                //Yes filter.Add(new AForge.Imaging.Filters.LevelsLinear ());
                //Yes filter.Add(new AForge.Imaging.Filters.Mean ());
                //Yes filter.Add(new AForge.Imaging.Filters.Median ());
                //Yes filter.Add(new AForge.Imaging.Filters.ConnectedComponentsLabeling());
                //Yes ++ filter.Add(new AForge.Imaging.Filters.HistogramEqualization ());
                //Yes+ filter.Add(new AForge.Imaging.Filters.Jitter ());
                //Yes! filter.Add(new AForge.Imaging.Filters.Shrink ());
                //Yes+++ filter.Add(new AForge.Imaging.Filters.WaterWave  ());
                //Yes++-- filter.Add(new AForge.Imaging.Filters.FlatFieldCorrection ());  //Awesome but very slow
                //THE YES!!! filter.Add(new AForge.Imaging.Filters.Invert ());
                //White filter.Add(new AForge.Imaging.Filters.GammaCorrection ());
                //White filter.Add(new AForge.Imaging.Filters.ContrastCorrection());
                
                //Maybe filter.Add(new AForge.Imaging.Filters.BottomHat());
                //Maybe filter.Add(new AForge.Imaging.Filters.ExtractNormalizedRGBChannel ());                
                                
                //No filter.Add(new AForge.Imaging.Filters.DifferenceEdgeDetector ());
                //No filter.Add(new AForge.Imaging.Filters.Dilatation3x3 ());                
                //No filter.Add(new AForge.Imaging.Filters.HomogenityEdgeDetector ());                
                //No filter.Add(new AForge.Imaging.Filters.Intersect ()); Overlay image
                //No filter.Add(new AForge.Imaging.Filters.IterativeThreshold ());
                //No filter.Add(new AForge.Imaging.Filters.MoveTowards ());
                //No filter.Add(new AForge.Imaging.Filters.OtsuThreshold ());
                //No filter.Add(new AForge.Imaging.Filters.SISThreshold ());
                //No filter.Add(new AForge.Imaging.Filters.SobelEdgeDetector ());
                //No filter.Add(new AForge.Imaging.Filters.Subtract ()); Overlay image not set
                //No filter.Add(new AForge.Imaging.Filters.ThresholdWithCarry ());
                //No filter.Add(new AForge.Imaging.Filters.JarvisJudiceNinkeDithering()); Not supported pixel format
                //No filter.Add(new AForge.Imaging.Filters.StuckiDithering ());
                //No filter.Add(new AForge.Imaging.Filters.SimpleSkeletonization());
                //No filter.Add(new AForge.Imaging.Filters.GrayscaleToRGB ());
                //No filter.Add(new AForge.Imaging.Filters.Merge ()); Overlay image is not set
                //No filter.Add(new AForge.Imaging.Filters.OrderedDithering ());
                //No filter.Add(new AForge.Imaging.Filters.ColorRemapping());
                //No filter.Add(new AForge.Imaging.Filters.Difference());
                //No filter.Add(new AForge.Imaging.Filters.SierraDithering ());
                //No filter.Add(new AForge.Imaging.Filters.Threshold ());
                //No filter.Add(new AForge.Imaging.Filters.BayerDithering());
                //No filter.Add(new AForge.Imaging.Filters.BinaryDilatation3x3());
                //No filter.Add(new AForge.Imaging.Filters.BinaryErosion3x3());
                //No filter.Add(new AForge.Imaging.Filters.BurkesDithering());
                //No filter.Add(new AForge.Imaging.Filters.CannyEdgeDetector());
                //No filter.Add(new AForge.Imaging.Filters.Erosion3x3 ());                
                //No filter.Add(new AForge.Imaging.Filters.EuclideanColorFiltering ());
                //No filter.Add(new AForge.Imaging.Filters.ExtractBiggestBlob ());
                //No filter.Add(new AForge.Imaging.Filters.FloydSteinbergDithering ());                
                //No filter.Add(new AForge.Imaging.Filters.Morph ());
                //No filter.Add(new AForge.Imaging.Filters.Pixellate ());
                //No filter.Add(new AForge.Imaging.Filters.StereoAnaglyph ());
                
                
            }

            // apply the sequence to an image
            return filter.Apply(screenshot);
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
            {
                screenShotBMP = new Bitmap(width,
                    height, PixelFormat.Format24bppRgb);

                using (Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP))
                {
                    screenShotGraphics.CopyFromScreen(x,
                        y, 0, 0, size,
                        CopyPixelOperation.SourceCopy);
                }
                //    firstTime = false;
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Snap();
        }

    }
}
