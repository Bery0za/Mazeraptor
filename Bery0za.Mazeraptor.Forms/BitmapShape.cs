using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bery0za.Mazerator.Types.Rectangular;
using Bery0za.Mazerator.Types.Shaped;

namespace Bery0za.Mazerator.Forms
{
    public class BitmapShape : IShape
    {
        public delegate bool InteriorSelector(Color color);

        public static BitmapShape Empty = new BitmapShape(new Bitmap(1, 1), LightnessSelector);

        public int Width => _bitmap.Width;
        public int Height => _bitmap.Height;
        public InteriorSelector ShapeSelector { get; set; }

        private Bitmap _bitmap;

        public BitmapShape(Bitmap bitmap, InteriorSelector interiorSelector)
        {
            _bitmap = bitmap;
            ShapeSelector = interiorSelector;
        }
        public bool ContainsAtPosition(RectangularPosition position)
        {
            Color color = _bitmap.GetPixel(position.x, position.y);

            return ShapeSelector(color);
        }

        public void Dispose()
        {
            _bitmap.Dispose();
        }

        public static bool AlphaSelector(Color color)
        {
            return color.A >= 1 << 7;
        }

        public static bool LightnessSelector(Color color)
        {
            return (color.R + color.G + color.B) / 3f < 1 << 7;
        }
    }
}
