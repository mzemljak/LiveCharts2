﻿// The MIT License(MIT)
//
// Copyright(c) 2021 Alberto Rodriguez Orozco & LiveCharts Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using LiveChartsCore.Drawing;
using LiveChartsCore.Measure;
using System;

namespace LiveChartsCore.Kernel
{
    /// <summary>
    /// Defines a chart view
    /// </summary>
    public interface IChartView
    {
        /// <summary>
        /// Gets the size of the control.
        /// </summary>
        /// <value>
        /// The size of the control.
        /// </value>
        System.Drawing.SizeF ControlSize { get; }

        /// <summary>
        /// Gets or sets the draw margin, if this property is null, the library will calculate a margin, this margin is the distance 
        /// between the view bounds and the drawable area.
        /// </summary>
        /// <value>
        /// The draw margin.
        /// </value>
        Margin? DrawMargin { get; set; }

        /// <summary>
        /// Gets or sets the animations speed.
        /// </summary>
        /// <value>
        /// The animations speed.
        /// </value>
        TimeSpan AnimationsSpeed { get; set; }

        /// <summary>
        /// Gets or sets the easing function, the library already provides many easing functions in the 
        /// LiveCharts.EasingFunction static class.
        /// </summary>
        /// <value>
        /// The easing function.
        /// </value>
        Func<float, float> EasingFunction { get; set; }

        /// <summary>
        /// Gets or sets the legend position.
        /// </summary>
        /// <value>
        /// The legend position.
        /// </value>
        LegendPosition LegendPosition { get; set; }

        /// <summary>
        /// Gets or sets the legend orientation.
        /// </summary>
        /// <value>
        /// The legend orientation.
        /// </value>
        LegendOrientation LegendOrientation { get; set; }

        /// <summary>
        /// Gets or sets the tooltip position.
        /// </summary>
        /// <value>
        /// The tooltip position.
        /// </value>
        TooltipPosition TooltipPosition { get; set; }

        /// <summary>
        /// Gets or sets the tooltip finding strategy.
        /// </summary>
        /// <value>
        /// The tooltip finding strategy.
        /// </value>
        TooltipFindingStrategy TooltipFindingStrategy { get; set; }
    }

    /// <summary>
    /// Defines a chart view.
    /// </summary>
    /// <typeparam name="TDrawingContext">The type of the drawing context.</typeparam>
    public interface IChartView<TDrawingContext> : IChartView
        where TDrawingContext : DrawingContext
    {
        /// <summary>
        /// Gets the core canvas.
        /// </summary>
        /// <value>
        /// The core canvas.
        /// </value>
        MotionCanvas<TDrawingContext> CoreCanvas { get; }

        /// <summary>
        /// Gets the legend.
        /// </summary>
        /// <value>
        /// The legend.
        /// </value>
        IChartLegend<TDrawingContext>? Legend { get; }

        /// <summary>
        /// Gets the tooltip.
        /// </summary>
        /// <value>
        /// The tooltip.
        /// </value>
        IChartTooltip<TDrawingContext>? Tooltip { get; }

        /// <summary>
        /// Gets or sets the point states.
        /// </summary>
        /// <value>
        /// The point states.
        /// </value>
        PointStatesDictionary<TDrawingContext> PointStates { get; set; }
    }
}
