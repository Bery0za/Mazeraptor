using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Types.Shaped;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public enum InteriorSelector
    {
        Alpha,
        Lightness
    }

    public class ShapedStructureVM : ViewModel, IStructureVM
    {
        public PropertyWrapper<InteriorSelector> Type = new PropertyWrapper<InteriorSelector>(ViewModels.InteriorSelector.Alpha);
        public PropertyWrapper<IEnumerable<InteriorSelector>> AvailableTypes = new PropertyWrapper<IEnumerable<InteriorSelector>>();

        private BitmapShape _shape = BitmapShape.Empty;

        public ShapedStructureVM()
        {
            AvailableTypes.Value = new [] { InteriorSelector.Alpha, InteriorSelector.Lightness };

            Type.ValueChanged += TypeOnValueChanged;
        }

        public IStructure CreateStructure()
        {
            return new ShapedStructure(new ShapedParameters(_shape));
        }
        
        public void Load(Stream stream)
        {
            if (stream.CanRead)
            {
                Bitmap bitmap = new Bitmap(stream);
                BitmapShape shape = new BitmapShape(bitmap, DefineSelector(Type.Value));

                if (_shape != BitmapShape.Empty) _shape.Dispose();
                _shape = shape;
            }
            else
            {
                _shape = BitmapShape.Empty;
            }

            stream.Close();
        }

        private BitmapShape.InteriorSelector DefineSelector(InteriorSelector selectorType)
        {
            switch (selectorType)
            {
                case ViewModels.InteriorSelector.Alpha:
                    return BitmapShape.AlphaSelector;

                case ViewModels.InteriorSelector.Lightness:
                    return BitmapShape.LightnessSelector;

                default:
                    throw new ArgumentException();
            }
        }

        private void TypeOnValueChanged(InteriorSelector value, InteriorSelector previousValue)
        {
            _shape.ShapeSelector = DefineSelector(value);
        }

        public override void Destroy()
        {
            Type.ValueChanged -= TypeOnValueChanged;
        }
    }
}
