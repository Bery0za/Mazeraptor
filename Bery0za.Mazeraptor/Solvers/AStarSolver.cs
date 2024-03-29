﻿using System;
using System.Collections.Generic;
using System.Linq;

using Bery0za.Core.Extensions;

namespace Bery0za.Mazerator.Solvers
{
    public class AStarSolver : MazeSolver
    {
        HashSet<Cell> closedSet;
        HashSet<Cell> openSet;

        Dictionary<Cell, Cell> cameFrom;
        Dictionary<Cell, float> gScore;
        Dictionary<Cell, float> fScore;

        Func<Cell, Cell, float> heuristic;
        Func<Cell, Cell, float> adjacentDistance;

        public AStarSolver(Func<Cell, Cell, float> heuristic = null, Func<Cell, Cell, float> adjacentDistance = null)
            : base()
        {
            this.heuristic = heuristic ?? DefaultHeuristic;
            this.adjacentDistance = adjacentDistance ?? DefaultAdjacentDistance;
        }

        override protected void ProcessSolving(Cell startCell, Cell endCell)
        {
            if (AStar(startCell, endCell))
            {
                SolutionFound(ReconstructPath(cameFrom, startCell, endCell));
            }
            else
            {
                SolutionNotFound();
            }
        }

        bool AStar(Cell startCell, Cell endCell)
        {
            var procTotalCount = structure.Count() * 0.01f;

            closedSet = new HashSet<Cell>();
            openSet = new HashSet<Cell>();
            cameFrom = new Dictionary<Cell, Cell>();
            gScore = new Dictionary<Cell, float>();
            fScore = new Dictionary<Cell, float>();

            openSet.Add(startCell);
            gScore.Add(startCell, 0);
            fScore.Add(startCell, heuristic(startCell, endCell));

            Cell curCell;

            while (openSet.Any())
            {
                curCell = fScore.OrderBy(kvp => kvp.Value).First(kvp => openSet.Contains(kvp.Key)).Key;

                if (curCell == endCell)
                {
                    return true;
                }

                openSet.Remove(curCell);
                closedSet.Add(curCell);

                foreach (var adjacentCell in curCell.AdjacentCells)
                {
                    if (closedSet.Contains(adjacentCell))
                    {
                        continue;
                    }

                    if (!openSet.Contains(adjacentCell))
                    {
                        openSet.Add(adjacentCell);
                    }

                    var tentativeGScore = gScore[curCell] + adjacentDistance(curCell, adjacentCell);

                    if (tentativeGScore >= (gScore.GetValueOrDefault(adjacentCell, float.PositiveInfinity)))
                    {
                        continue;
                    }

                    cameFrom.Add(adjacentCell, curCell);

                    gScore.Add(adjacentCell, tentativeGScore);
                    fScore.Add(adjacentCell, gScore[adjacentCell] + heuristic(adjacentCell, endCell));
                }

                TrackProgress(cameFrom.Count / procTotalCount);
                if (cancel) return false;
            }

            return false;
        }

        public static float DefaultHeuristic(Cell cellA, Cell cellB)
        {
            return 0f;
        }

        public static float DistanceHeuristic(Cell cellA, Cell cellB)
        {
            return cellA.Position.DistanceTo(cellB.Position);
        }

        public static float DefaultAdjacentDistance(Cell cellA, Cell cellB)
        {
            return 1f;
        }
    }
}