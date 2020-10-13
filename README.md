# Mazeraptor
![Mazeraptor](https://github.com/Bery0za/Mazeraptor/blob/master/Bery0za.Mazeraptor/Logo.png "Mazeraptor")

Do you need mazes? This library is for you. Mazeraptor is able to generate rectangular, circular, hexagonal or triangular mazes with various generator types and parameters and find paths between cells.

## Currently supported generators
#### RecursiveBacktracker(firstCellSelector, leftCellSelector, neighborCellSelector)
Tends to form long twisty passages.
**leftCellSelector** allows to choose which cell has to be processed next after the passage has been formed.
**neighborCellSelector** defines which neighbor of a cell is processed next.

#### GrowingTree(firstCellSelector, carvingCellSelector, leftCellSelector, neighborCellSelector)
One of the most powerful generator in the world of mazes. It may act as Prim generator or as Recursive backtracker.
**carvingCellSelector** is a magic function which makes growing tree so powerful. After some cell has been processed and its neighbors been added to the carving list you can define which cell process next.
Other functions are the same as in RecursiveBacktracker.

## Currently supported solvers
- AStar (Dijkstra)
- Breadth first
- Depth first

You may also use your favorite photos to define a shape of the maze (depending on pics’ alpha channel or lightness or any other function). You just have to wrap your pic in **IShape** interface and tell which pixels are interior.

## Planned features
- [ ] Voronoi structure
- [ ] Other generators
- [ ] Performance optimizations

Explore Mazeraptor.Forms to find samples of usage and build your own mazes with the app.