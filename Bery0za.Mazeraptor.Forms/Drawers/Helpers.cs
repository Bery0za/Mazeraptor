using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bery0za.Mazerator.Forms.Drawers
{
    public static class Helpers
    {
        public static Color Lerp(Color colorA, Color colorB, float value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();

            float rDelta = colorB.R - colorA.R;
            float gDelta = colorB.G - colorA.G;
            float bDelta = colorB.B - colorA.B;

            byte r = (byte)(colorA.R + rDelta * value);
            byte g = (byte)(colorA.G + gDelta * value);
            byte b = (byte)(colorA.B + bDelta * value);

            return Color.FromArgb(r, g, b);
        }
    }
}