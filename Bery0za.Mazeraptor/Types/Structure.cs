using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Types
{
    public abstract class Structure<TParameters, TPosition> : IStructure
        where TParameters : Parameters
        where TPosition : IPosition
    {
        public Parameters Parameters => parameters;

        public readonly TParameters parameters;

        protected Structure(TParameters parameters)
        {
            this.parameters = parameters;
        }

        private void AddNeighborsForCells()
        {
            foreach (Cell cell in this)
            {
                SetNeighbour(cell, CalcNeighborsForCell(cell));
            }
        }

        public Type PositionType()
        {
            return typeof(TPosition);
        }

        public bool ContainsCellAtPosition(IPosition position)
        {
            if (position is TPosition typedPosition)
            {
                return ContainsAtPosition(typedPosition);
            }

            throw new InvalidCastException("This structure uses another type of positioning");
        }

        public Cell GetCellAtPosition(IPosition position)
        {
            if (position is TPosition typedPosition)
            {
                return GetCellAtPosition(typedPosition);
            }
            
            throw new InvalidCastException("This structure uses another type of positioning");
        }
        
        protected Cell GetCellAtPosition(TPosition position)
        {
            if (ContainsAtPosition(position))
            {
                return CellAtPosition(position);
            }

            throw new ArgumentOutOfRangeException("Doesn't contain position " + position);
        }

        public virtual void Init()
        {
            AddNeighborsForCells();
        }
        
        public HashSet<Cell> CalcNeighborsForCell(Cell cell)
        {
            if (this.Contains(cell))
            {
                return GetNeighborsAtPosition((TPosition)cell.Position);
            }

            throw new ArgumentOutOfRangeException("Doesn't contain cell " + cell);
        }

        protected abstract HashSet<Cell> GetNeighborsAtPosition(TPosition position);

        protected Cell CreateCellAtPosition(TPosition position)
        {
            return new Cell(position);
        }

        public bool ContainsCells(params Cell[] cells)
        {
            return cells.All(this.Contains);
        }

        protected abstract Cell CellAtPosition(TPosition position);

        protected abstract bool ContainsAtPosition(TPosition position);

        public bool IsNeighbour(Cell cellA, Cell cellB)
        {
            return cellA.NeighbourCells.Contains(cellB);
        }

        public bool IsAdjacent(Cell cellA, Cell cellB)
        {
            return cellA.AdjacentCells.Contains(cellB);
        }

        public void SetNeighbour(Cell cellA, Cell cellB)
        {
            cellA.NeighbourCells.Add(cellB);
            cellB.NeighbourCells.Add(cellA);
        }

        public void SetNeighbour(Cell cell, HashSet<Cell> neighbors)
        {
            cell.NeighbourCells.UnionWith(neighbors);
            
            foreach (Cell neighbour in neighbors)
            {
                neighbour.NeighbourCells.Add(cell);
            }
        }

        public void SetAdjacent(Cell cellA, Cell cellB)
        {
            cellA.AdjacentCells.Add(cellB);
            cellB.AdjacentCells.Add(cellA);
        }

        public void SetAdjacent(Cell cell, HashSet<Cell> adjacents)
        {
            cell.AdjacentCells.UnionWith(adjacents);

            foreach (Cell adjacent in adjacents)
            {
                adjacent.AdjacentCells.Add(cell);
            }
        }

        public abstract IEnumerator<Cell> GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}