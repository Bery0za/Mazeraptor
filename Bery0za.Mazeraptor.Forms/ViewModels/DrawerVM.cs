using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.Drawers;
using Bery0za.Mazerator.Types.Circular;
using Bery0za.Mazerator.Types.Rectangular;
using Bery0za.Mazerator.Types.Shaped;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public class DrawerVM : ViewModel
    {
        public PropertyWrapper<Maze> Maze = new PropertyWrapper<Maze>(Mazerator.Maze.Empty);
        public PropertyWrapper<bool> DrawingEnabled = new PropertyWrapper<bool>(false);
        public PropertyWrapper<bool> AutoDraw = new PropertyWrapper<bool>(true);
        public PropertyWrapper<float> StrokeWidth = new PropertyWrapper<float>(0.5f);
        public PropertyWrapper<Color> StrokeColor = new PropertyWrapper<Color>(Color.Black);
        public PropertyWrapper<bool> StrokeEnabled = new PropertyWrapper<bool>(true);
        public PropertyWrapper<FillType> FillType = new PropertyWrapper<FillType>(Drawers.FillType.Solid);
        public PropertyWrapper<Color> FillColor = new PropertyWrapper<Color>(Color.White);
        public PropertyWrapper<bool> FillEnabled = new PropertyWrapper<bool>(false);
        public PropertyWrapper<float> CellSize = new PropertyWrapper<float>(10f);
        public PropertyWrapper<IEnumerable<FillType>> AvailableFillTypes = new PropertyWrapper<IEnumerable<FillType>>();
        public PropertyWrapper<List<Cell>> SolvedPath = new PropertyWrapper<List<Cell>>(new List<Cell>());
        public PropertyWrapper<Bitmap> Bitmap = new PropertyWrapper<Bitmap>(new Bitmap(1, 1));

        private FillType[] _fillTypes = new[] { Drawers.FillType.Solid, Drawers.FillType.GenerationGradient, Drawers.FillType.SolvedPath };
        private FillType[] _fillTypesNoSolved = new[] { Drawers.FillType.Solid, Drawers.FillType.GenerationGradient };

        public DrawerVM()
        {
            AvailableFillTypes.Value = new [] { Drawers.FillType.Solid, Drawers.FillType.GenerationGradient };

            Maze.ValueChanged += MazeOnValueChanged;
            SolvedPath.ValueChanged += OnSolvedPathChange;
            Bitmap.ValueChanged += BitmapOnValueChanged;
        }

        public void Draw()
        {
            if (Maze.Value != Mazerator.Maze.Empty && Maze.Value.Structure.Any())
            {
                Bitmap bitmap;
                IEnumerable<Cell> order;
                
                switch (FillType.Value)
                {
                    case Drawers.FillType.Solid:
                        order = Maze.Value.Structure;
                        break;

                    case Drawers.FillType.GenerationGradient:
                        order = Maze.Value.Generator.GenerationPath;
                        break;

                    case Drawers.FillType.SolvedPath:
                        order = SolvedPath.Value;
                        break;

                    default:
                        throw new ArgumentException();
                }

                switch (Maze.Value.Structure)
                {
                    case RectangularStructure rs:
                        var rDrawer = new RectangularMazeDrawer();
                        bitmap = rDrawer.DrawMazeOrdered(rs, CreateParameters(), order);
                        break;

                    case CircularStructure cs:
                        var cDrawer = new CircularMazeDrawer();
                        bitmap = cDrawer.DrawMazeOrdered(cs, CreateParameters(), order);
                        break;

                    case ShapedStructure ss:
                        var sDrawer = new ShapedMazeDrawer();
                        bitmap = sDrawer.DrawMazeOrdered(ss, CreateParameters(), order);
                        break;
                    
                    default:
                        throw new ArgumentException();
                }

                Bitmap.Set(bitmap);
            }
        }

        public void Save(Stream stream)
        {
            if (stream.CanWrite)
            {
                Bitmap.Value.Save(stream, ImageFormat.Png);
                stream.Close();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        private void MazeOnValueChanged(Maze value, Maze previousvalue)
        {
            if (Maze.Value != Mazerator.Maze.Empty && Maze.Value.Structure.Any())
            {
                DrawingEnabled.Set(true);
                if (AutoDraw.Value) Draw();
            }
            else
            {
                DrawingEnabled.Set(false);
            }
        }

        private void OnSolvedPathChange(List<Cell> current, List<Cell> previous)
        {
            if (current.Count > 0)
            {
                AvailableFillTypes.Value = _fillTypes;
                if (FillType.Value == Drawers.FillType.SolvedPath && AutoDraw.Value) Draw();
            }
            else
            {
                AvailableFillTypes.Value = _fillTypesNoSolved;
                if (FillType.Value == Drawers.FillType.SolvedPath) FillType.Set(Drawers.FillType.Solid);
            }
        }

        private void BitmapOnValueChanged(Bitmap value, Bitmap previousValue)
        {
            previousValue?.Dispose();
        }

        private DrawingParameters CreateParameters()
        {
            return new DrawingParameters(StrokeWidth.Value, StrokeColor.Value, StrokeEnabled.Value, FillType.Value,
                FillColor.Value, FillEnabled.Value, CellSize.Value);
        }

        public override void Destroy()
        {
            Bitmap.Value?.Dispose();

            SolvedPath.ValueChanged -= OnSolvedPathChange;
            Bitmap.ValueChanged -= BitmapOnValueChanged;
        }
    }
}
