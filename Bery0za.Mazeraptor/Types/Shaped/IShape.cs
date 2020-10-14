using Bery0za.Mazerator.Types.Rectangular;

namespace Bery0za.Mazerator.Types.Shaped
{
    public interface IShape
    {
        int Width { get; }
        int Height { get; }
        bool ContainsAtPosition(RectangularPosition position);
    }
}