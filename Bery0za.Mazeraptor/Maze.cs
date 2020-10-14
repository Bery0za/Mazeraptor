using System;
using System.Collections.Generic;

using Bery0za.Mazerator.Generators;
using Bery0za.Mazerator.Types;
using Bery0za.Mazerator.Types.Rectangular;

namespace Bery0za.Mazerator
{
    public class Maze
    {
        public static Maze Empty = new Maze("", null, null);

        public string Seed { get; set; }
        public IStructure Structure { get; private set; }
        public MazeGenerator Generator { get; private set; }
        private Random _random;

        public Maze(string seed, IStructure structure, MazeGenerator generator)
        {
            Seed = seed;
            Structure = structure;
            Generator = generator;
            _random = new Random(Seed.GetHashCode());
        }

        public void Generate()
        {
            Structure.Init();
            Generator.GenerateMaze(Structure, _random);
        }
    }
}