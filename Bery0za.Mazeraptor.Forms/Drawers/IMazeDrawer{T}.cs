using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bery0za.Mazerator.Forms.Drawers
{
    public interface IMazeDrawer<T> where T : IStructure
    {
        Bitmap DrawMaze(T structure, DrawingParameters parameters);
        Bitmap DrawMazeOrdered(T structure, DrawingParameters parameters, IEnumerable<Cell> order);
    }
}
