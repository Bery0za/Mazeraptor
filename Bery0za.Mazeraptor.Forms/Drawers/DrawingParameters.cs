using System.Drawing;

using Bery0za.Mazerator.Forms.ViewModels;

namespace Bery0za.Mazerator.Forms.Drawers
{
    public readonly struct DrawingParameters
    {
        public readonly float strokeWidth;
        public readonly Color strokeColor;
        public readonly bool strokeEnabled;
        public readonly FillType fillType;
        public readonly Color fillColor;
        public readonly bool fillEnabled;
        public readonly float cellSize;

        public DrawingParameters(float strokeWidth,
                                 Color strokeColor,
                                 bool strokeEnabled,
                                 FillType fillType,
                                 Color fillColor,
                                 bool fillEnabled,
                                 float cellSize)
        {
            this.strokeWidth = strokeWidth;
            this.strokeColor = strokeColor;
            this.strokeEnabled = strokeEnabled;
            this.fillType = fillType;
            this.fillColor = fillColor;
            this.fillEnabled = fillEnabled;
            this.cellSize = cellSize;
        }
    }
}