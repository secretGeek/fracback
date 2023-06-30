using Microsoft.Scripting.Hosting;

namespace PythonFeedback
{
    public class Model
    {
        public float scaleXSeed { get; set; }
        public float scaleYSeed { get; set; }
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
        public ScriptSource source { get; set; }
        public ScriptScope scope { get; set; }
        public Model()
        {
            this.scaleXSeed = 1.0f;
            this.scaleYSeed = 1.0f;

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