namespace IOhmValueCalculator1
{
    public class colorCodes
    {
        public string Color { get; set; }
        public int SignificantFigures { get; set; }
        public double Multiplier { get; set; }
        public double Tolerance { get; set; }

        public colorCodes(string color, int significantFigures, double multiplier, double tolerance)
        {
            Color = color;
            SignificantFigures = significantFigures;
            Multiplier = multiplier;
            Tolerance = tolerance;
        }
    }
}