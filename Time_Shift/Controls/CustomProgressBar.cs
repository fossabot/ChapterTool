﻿using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace ChapterTool.Controls
{
    class CustomProgressBar : ProgressBar
    {
        Color BarColor = Color.Blue;        // Color of progress meter



        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            SolidBrush brush = new SolidBrush(BarColor);

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);

            // Clean up.
            brush.Dispose();

        }
        public Color ProgressBarColor
        {
            get
            {
                return BarColor;
            }

            set
            {
                BarColor = value;

                // Invalidate the control to get a repaint.
                Invalidate();
            }
        }


    }
}