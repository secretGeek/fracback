using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
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

        }

    }
}
