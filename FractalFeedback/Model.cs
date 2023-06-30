﻿using Microsoft.Scripting.Hosting;

namespace FractalFeedback
{
    public class Model
    {
        public float scaleXSeed { get; set; }
        public float scaleYSeed { get; set; }
        public int scaleXRandomMin { get; set; }
        public int scaleXRandomMax { get; set; }
        public int scaleXRandomDivisor { get; set; }
        public int scaleYRandomMin { get; set; }
        public int scaleYRandomMax { get; set; }
        public int scaleYRandomDivisor { get; set; }
        public int redMin { get; set; }
        public int redMax { get; set; }
        public int greenMin { get; set; }
        public int greenMax { get; set; }
        public int blueMin { get; set; }
        public int blueMax { get; set; }
        public int dotRadiusMin { get; set; }
        public int dotRadiusMax { get; set; }
        public int brushWidth { get; set; }
        public int rotateAngle { get; set; }
        //public int scaleY { get; set; }
        public Model()
        {
            this.scaleXSeed = 1.0f;
            this.scaleXRandomMin = 0;
            this.scaleXRandomMax = 1000;
            this.scaleXRandomDivisor = 5000;

            this.scaleYSeed = 1.0f;
            this.scaleYRandomMin = 0;
            this.scaleYRandomMax = 1000;
            this.scaleYRandomDivisor = 5000;

            this.dotRadiusMin = 0;
            this.dotRadiusMax = 10;

            this.redMin = 0;
            this.redMax = 255;

            this.greenMin = 0;
            this.greenMax = 255;

            this.blueMin = 0;
            this.blueMax = 255;

            this.brushWidth = 6;
            this.rotateAngle = 4;
        }
    }
}
