using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace FractalFeedback
{
    public partial class Controller : Form
    {
        public Model model { get; private set; }



        public Controller(Model model) : this()
        {
            this.model = model;
        }

        public Controller()
        {
            InitializeComponent();

            if (this.model == null)
            {
                this.model = new Model();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filtersy = new List<ImageFilter>();
            foreach (var item in listFilters.Items)
            {
                if (item is ImageFilter filty)
                {
                    filtersy.Add(filty);
                }
            }
            model.Filters = filtersy;
            var f = new Fractal(model);
            f.Show();
        }

        private void txtscaleXSeed_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(txtscaleXSeed.Text, out value) && value >= 0 && value <= 5)
            {
                this.model.scaleXSeed = value;
            }
        }

        private void txtscaleXRandomMin_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtscaleXRandomMin.Text, out value) && value >= 0 && value <= 1000)
            {
                this.model.scaleXRandomMin = value;
            }
        }

        private void txtscaleXRandomMax_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtscaleXRandomMax.Text, out value) && value >= 0 && value <= 5000)
            {
                this.model.scaleXRandomMax = value;
            }
        }

        private void txtscaleXRandomDivisor_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtscaleXRandomDivisor.Text, out value) && value >= 1 && value <= 10000)
            {
                this.model.scaleXRandomDivisor = value;
            }
        }

        private void txtscaleYSeed_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(txtscaleYSeed.Text, out value) && value >= 0.5 && value <= 2.5)
            {
                this.model.scaleYSeed = value;
            }
        }

        private void txtscaleYRandomMin_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtscaleYRandomMin.Text, out value) && value >= 0 && value <= 1000)
            {
                this.model.scaleYRandomMin = value;
            }
        }

        private void txtscaleYRandomMax_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtscaleYRandomMax.Text, out value) && value >= 0 && value <= 5000)
            {
                this.model.scaleYRandomMax = value;
            }
        }

        private void txtscaleYRandomDivisor_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtscaleYRandomDivisor.Text, out value) && value >= 1 && value <= 10000)
            {
                this.model.scaleYRandomDivisor = value;
            }
        }

        private void txtdotRadiusMin_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtdotRadiusMin.Text, out value) && value >= 0 && value <= 100)
            {
                this.model.dotRadiusMin = value;
            }
        }

        private void txtdotRadiusMax_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtdotRadiusMax.Text, out value) && value >= 1 && value <= 100)
            {
                this.model.dotRadiusMax = value;
            }
        }

        private void txtredMin_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtredMin.Text, out value) && value >= 0 && value <= 255)
            {
                this.model.redMin = value;
            }
        }

        private void txtredMax_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtredMax.Text, out value) && value >= 0 && value <= 255)
            {
                this.model.redMax = value;
            }
        }

        private void txtgreenMin_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtgreenMin.Text, out value) && value >= 0 && value <= 255)
            {
                this.model.greenMin = value;
            }
        }

        private void txtgreenMax_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtgreenMax.Text, out value) && value >= 0 && value <= 255)
            {
                this.model.greenMax = value;
            }
        }

        private void txtblueMin_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtblueMin.Text, out value) && value >= 0 && value <= 255)
            {
                this.model.blueMin = value;
            }
        }

        private void txtblueMax_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtblueMax.Text, out value) && value >= 0 && value <= 255)
            {
                this.model.blueMax = value;
            }
        }

        private void txtbrushWidth_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtbrushWidth.Text, out value) && value >= 1 && value <= 100)
            {
                this.model.brushWidth = value;
            }
        }

        private void txtrotateAngle_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtrotateAngle.Text, out value) && value >= -360 && value <= 360)
            {
                this.model.rotateAngle = value;
            }
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            listFilters.DisplayMember = nameof(ImageFilter.Name);
            listFilters.ValueMember = nameof(ImageFilter.Id);
            //listFilters.DataSource = SelectedFilters;
            txtscaleXSeed.Text = model.scaleXSeed.ToString();
            txtscaleXRandomMin.Text = model.scaleXRandomMin.ToString();
            txtscaleXRandomMax.Text = model.scaleXRandomMax.ToString();
            txtscaleXRandomDivisor.Text = model.scaleXRandomDivisor.ToString();
            txtscaleYSeed.Text = model.scaleYSeed.ToString();
            txtscaleYRandomMin.Text = model.scaleYRandomMin.ToString();
            txtscaleYRandomMax.Text = model.scaleYRandomMax.ToString();
            txtscaleYRandomDivisor.Text = model.scaleYRandomDivisor.ToString();
            txtdotRadiusMin.Text = model.dotRadiusMin.ToString();
            txtdotRadiusMax.Text = model.dotRadiusMax.ToString();
            txtredMin.Text = model.redMin.ToString();
            txtredMax.Text = model.redMax.ToString();
            txtgreenMin.Text = model.greenMin.ToString();
            txtgreenMax.Text = model.greenMax.ToString();
            txtblueMin.Text = model.blueMin.ToString();
            txtblueMax.Text = model.blueMax.ToString();
            txtbrushWidth.Text = model.brushWidth.ToString();
            txtrotateAngle.Text = model.rotateAngle.ToString();

            SetFilters();
            var filters = AllFilters.ToArray();
            cboFilters.DisplayMember = "Name";
            cboFilters.ValueMember = "Id";
            cboFilters.Items.AddRange(filters);
        }

        List<ImageFilter> AllFilters = new List<ImageFilter>();
        public void SetFilters()
        {
            var filters = new List<ImageFilter>
            {
                new ImageFilter("Opening","Opening"),
                new ImageFilter("RotateChannels","RotateChannels"),
                new ImageFilter("WaterWave","WaterWave"),
                new ImageFilter("Edges","Edges"),
                new ImageFilter("Erosion","Erosion"),
                new ImageFilter("ExtractChannel","ExtractChannel"),
                new ImageFilter("GaussianBlur","GaussianBlur"),
                new ImageFilter("GaussianSharpen","GaussianSharpen"),
                new ImageFilter("AdaptiveSmoothing","AdaptiveSmoothing"),
                new ImageFilter("AdditiveNoise","AdditiveNoise"),
                new ImageFilter("BlobsFiltering","BlobsFiltering"),
                new ImageFilter("Blur","Blur"),
                new ImageFilter("BrightnessCorrection","BrightnessCorrection"),
                new ImageFilter("OilPainting","OilPainting"),
                new ImageFilter("ChannelFiltering","ChannelFiltering"),
                new ImageFilter("Closing","Closing"),
                new ImageFilter("ColorFiltering","ColorFiltering"),
                new ImageFilter("Sepia","Sepia"),
                new ImageFilter("Dilatation","Dilatation"),
                new ImageFilter("RotateChannels","RotateChannels"),
                new ImageFilter("Sharpen","Sharpen"),
                new ImageFilter("HueModifier","HueModifier"),
                new ImageFilter("ContrastStretch","ContrastStretch"),
                new ImageFilter("YCbCrFiltering","YCbCrFiltering"),
                new ImageFilter("TopHat","TopHat"),
                new ImageFilter("PointedColorFloodFill","PointedColorFloodFill"),
                new ImageFilter("Opening","Opening"),
                new ImageFilter("PointedMeanFloodFill","PointedMeanFloodFill"),
                new ImageFilter("SaturationCorrection","SaturationCorrection"),
                new ImageFilter("SaltAndPepperNoise","SaltAndPepperNoise"),
                new ImageFilter("SimplePosterization","SimplePosterization"),
                new ImageFilter("YCbCrExtractChannel","YCbCrExtractChannel"),
                new ImageFilter("YCbCrLinear","YCbCrLinear"),
                new ImageFilter("ConservativeSmoothing","ConservativeSmoothing"),
                new ImageFilter("HSLFiltering","HSLFiltering"),
                new ImageFilter("HSLLinear","HSLLinear"),
                new ImageFilter("LevelsLinear","LevelsLinear"),
                new ImageFilter("Mean","Mean"),
                new ImageFilter("Median","Median"),
                new ImageFilter("ConnectedComponentsLabeling","ConnectedComponentsLabeling"),
                new ImageFilter("HistogramEqualization","HistogramEqualization"),
                new ImageFilter("Jitter","Jitter"),
                new ImageFilter("Shrink","Shrink"),
                new ImageFilter("WaterWave","WaterWave"),
                new ImageFilter("Invert","Invert"),
            };
            AllFilters = filters;
        }

        //List<ImageFilter> SelectedFilters = new List<ImageFilter>();
        private void cboFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilters.SelectedIndex >= 0)
            {
                //SelectedFilters.Add(AllFilters[cboFilters.SelectedIndex]);
                //listFilters.DataSource = SelectedFilters;
                listFilters.DataSource = null;
                listFilters.DisplayMember = nameof(ImageFilter.Name);
                listFilters.ValueMember = nameof(ImageFilter.Id);
                //listFilters.Items.AddRange(SelectedFilters.ToArray());
                listFilters.Items.Add(AllFilters[cboFilters.SelectedIndex]);
                lblFilter.Text = AllFilters[cboFilters.SelectedIndex].Name;
                //model.Filters.Add();
            }
        }

        private void listFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.P
        }

        private void listFilters_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Delete):
                    {
                        if (listFilters.SelectedItem != null)
                        {
                            listFilters.Items.Remove(listFilters.SelectedItem);
                        };
                        break;
                    }
                case (Keys.Up):
                    {
                        if (listFilters.SelectedIndex > 0)
                        {
                            var oldIndex = listFilters.SelectedIndex;
                            var item = listFilters.SelectedItem;
                            listFilters.Items.RemoveAt(oldIndex);
                            listFilters.Items.Insert(oldIndex - 1, item);
                        };

                        break;
                    }
            }
        }
    }

    public class ImageFilter
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ImageFilter(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
