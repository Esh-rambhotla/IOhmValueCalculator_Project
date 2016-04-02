using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace IOhmValueCalculator1
{
    public class ValueCalculator
    {
        public DropDownList dDL1 = null;
        public DropDownList dDL2 = null;
        public DropDownList dDL3 = null;
        public DropDownList dDL4 = null;
        List<colorCodes> colorList = new List<colorCodes>();

        public ValueCalculator()
        {
            
        }

        public void createLists(DropDownList dDL1, DropDownList dDL2, DropDownList dDL3, DropDownList dDL4)
        {
            

            this.dDL1 = dDL1;
            this.dDL2 = dDL2;
            this.dDL3 = dDL3;
            this.dDL4 = dDL4;


            colorList.Add(new colorCodes("Black", 0, 1, 0));
            colorList.Add(new colorCodes("Brown", 1, 10, 1));
            colorList.Add(new colorCodes("Red", 2, 100, 2));
            colorList.Add(new colorCodes("Orange", 3, 1000, 0));
            colorList.Add(new colorCodes("Yellow", 4, 10000, 5));
            colorList.Add(new colorCodes("Green", 5, 100000, 0.5));
            colorList.Add(new colorCodes("Blue", 6, 1000000, 0.25));
            colorList.Add(new colorCodes("Violet", 7, 10000000, 0.1));
            colorList.Add(new colorCodes("Gray", 8, 100000000, 10));
            colorList.Add(new colorCodes("White", 9, 1000000000, 0));
            colorList.Add(new colorCodes("Gold", 0, 0.1, 5));
            colorList.Add(new colorCodes("Silver", 0, 0.01, 10));
            colorList.Add(new colorCodes("None", 0, 0, 20));


            var c = from x in colorList.OfType<colorCodes>() select x;
            foreach (var d in c)
            {
                dDL1.Items.Insert(0, d.Color.ToString());
                dDL2.Items.Insert(0, d.Color.ToString());
                dDL4.Items.Insert(0, d.Color.ToString());
            }
            var e = from x in colorList.OfType<colorCodes>() where x.Color != "None" select x;
            foreach (var d in e)
            {
                dDL3.Items.Insert(0, d.Color.ToString());
            }
        }

        internal void clearList()
        {
            if (dDL1.Items.Count > 13)
            {
                for(int i = dDL1.Items.Count; i > 13; i--)
                {
                    dDL1.Items.RemoveAt(i-1);
                    dDL2.Items.RemoveAt(i-1);
                    dDL4.Items.RemoveAt(i-1);
                }
            }

            if (dDL3.Items.Count > 12)
            {
                for (int i = dDL3.Items.Count; i > 12; i--)
                {
                    dDL3.Items.RemoveAt(i - 1);
                }
            }
            
        }

        public string CalculateOhmValue(DropDownList dDL1, DropDownList dDL2, DropDownList dDL3, DropDownList dDL4)
        {
            int SignificantFigure1 = 0, SignificantFigure2 = 0;
            double Multiplier = 0, Tolerance = 0;
            
            string bandAColor = dDL1.SelectedValue;
            string bandBColor = dDL2.SelectedValue;
            string bandCColor = dDL3.SelectedValue;
            string bandDColor = dDL4.SelectedValue;

            var colorA = (from x in colorList.OfType<colorCodes>() where x.Color == bandAColor select x).FirstOrDefault();
            var colorB = (from x in colorList.OfType<colorCodes>() where x.Color == bandBColor select x).FirstOrDefault();
            var colorC = (from x in colorList.OfType<colorCodes>() where x.Color == bandCColor select x).FirstOrDefault();
            var colorD = (from x in colorList.OfType<colorCodes>() where x.Color == bandDColor select x).FirstOrDefault();

            SignificantFigure1 = Convert.ToInt32(colorA.SignificantFigures);
            SignificantFigure2 = Convert.ToInt32(colorB.SignificantFigures);
            Multiplier = Convert.ToDouble(colorC.Multiplier);
            Tolerance = Convert.ToDouble(colorD.Tolerance);


            double temp = (SignificantFigure1 * 10 + SignificantFigure2) * Multiplier;
            double percentageValue = (temp * Tolerance) / 100;
            return ("Maximum Resistance is: " + (temp + percentageValue) +" Ohms and" + " Minimum Resistance is: " + (temp - percentageValue)+" Ohms.");

        }
    }
}

