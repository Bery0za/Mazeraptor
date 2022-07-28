using System.Collections.Generic;

using Bery0za.Mazerator.Types;

namespace Bery0za.Mazerator
{
    public interface IStructure : IEnumerable<Cell>
    {
        Parameters Parameters { get; }
        int Count { get; }

        void Init();

        bool ContainsCells(params Cell[] cells);
        bool ContainsCellAtPosition(IPosition position);
        Cell GetCellAtPosition(IPosition position);
        IEnumerable<Cell> CalcNeighborsForCell(Cell cell);

        bool IsAdjacent(Cell cellA, Cell cellB);
        bool IsNeighbour(Cell cellA, Cell cellB);
        void SetAdjacent(Cell cell, IEnumerable<Cell> adjacent);
        void SetAdjacent(Cell cellA, Cell cellB);
        void SetNeighbour(Cell cell, IEnumerable<Cell> neighbors);
        void SetNeighbour(Cell cellA, Cell cellB);
    }
}