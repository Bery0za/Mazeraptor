using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Types.Circular;
using Bery0za.Mazerator.Types.Rectangular;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public class CircularStructureVM : ViewModel, IStructureVM
    {
        public PropertyWrapper<int> Rings = new PropertyWrapper<int>(1);
        public PropertyWrapper<float> Ratio = new PropertyWrapper<float>(1);

        public IStructure CreateStructure()
        {
            return new CircularStructure(new CircularParameters(Rings.Value, Ratio.Value));
        }
    }
}