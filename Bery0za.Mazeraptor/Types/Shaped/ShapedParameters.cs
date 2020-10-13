﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bery0za.Mazerator.Types.Shaped
{
    public class ShapedParameters : Parameters
    {
        public readonly IShape shape;

        public ShapedParameters(IShape shape)
        {
            this.shape = shape;
        }

        protected override void CheckParameters()
        {
            if (shape.Width < 1 || shape.Height < 1)
            {
                throw new ArgumentException("Incorrect parameters for maze");
            }
        }
    }
}
