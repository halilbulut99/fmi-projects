﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    class Line : Shape
    {
        public Line(RectangleF rect) : base(rect)
        {

        }


        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);

            grfx.DrawLine(new Pen (BorderColor,BorderWidth), Rectangle.X, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);

        }

    }
}
