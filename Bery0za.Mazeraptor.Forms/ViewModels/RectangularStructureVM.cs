using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Types.Rectangular;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public class RectangularStructureVM : ViewModel, IStructureVM
    {
        public PropertyWrapper<int> Width = new PropertyWrapper<int>(1);
        public PropertyWrapper<int> Height = new PropertyWrapper<int>(1);

        public IStructure CreateStructure()
        {
            return new RectangularStructure(new RectangularParameters(Width.Value, Height.Value));
        }
    }
}