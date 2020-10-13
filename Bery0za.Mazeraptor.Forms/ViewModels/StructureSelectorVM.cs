using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public interface IStructureVM
    {
        IStructure CreateStructure();
    }

    public enum StructureType
    {
        Rectangular,
        Circular,
        Shaped
    }

    public class StructureSelectorVM : ViewModel
    {
        public readonly ContextWrapper<IStructureVM> Structure = new ContextWrapper<IStructureVM>(new RectangularStructureVM());
        public readonly PropertyWrapper<StructureType> Type = new PropertyWrapper<StructureType>(StructureType.Rectangular);
        public readonly PropertyWrapper<IEnumerable<StructureType>> AvailableTypes = new PropertyWrapper<IEnumerable<StructureType>>();

        public StructureSelectorVM()
        {
            AvailableTypes.Value = new [] { StructureType.Rectangular, StructureType.Circular, StructureType.Shaped };
            Type.ValueChanged += OnStructureTypeChange;
        }

        public IStructure CreateStructure()
        {
            return Structure.Value.CreateStructure();
        }

        public override IEnumerable<IContext> DefineChildren()
        {
            return new List<IContext>() { Structure };
        }

        private void OnStructureTypeChange(StructureType current, StructureType previous)
        {
            switch (current)
            {
                case StructureType.Rectangular:
                    Structure.Set(new RectangularStructureVM());
                    break;

                case StructureType.Circular:
                    Structure.Set(new CircularStructureVM());
                    break;

                case StructureType.Shaped:
                    Structure.Set(new ShapedStructureVM());
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        public override void Destroy()
        {
            Type.ValueChanged -= OnStructureTypeChange;
        }
    }
}
