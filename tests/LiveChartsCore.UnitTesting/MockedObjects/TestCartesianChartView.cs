﻿using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LiveChartsCore.UnitTesting.MockedObjects
{
    public class TestCartesianChartView : ICartesianChartView<SkiaSharpDrawingContext>
    {
        private readonly MotionCanvas<SkiaSharpDrawingContext> canvas = new();

        public TestCartesianChartView()
        {
            if (!LiveCharts.IsConfigured) LiveCharts.Configure(LiveChartsSkiaSharp.DefaultPlatformBuilder);

            var stylesBuilder = LiveCharts.CurrentSettings.GetStylesBuilder<SkiaSharpDrawingContext>();
            var initializer = stylesBuilder.GetInitializer();
            if (stylesBuilder.CurrentColors == null || stylesBuilder.CurrentColors.Length == 0)
                throw new Exception("Default colors are not valid");
            initializer.ConstructChart(this);

            Core = new CartesianChart<SkiaSharpDrawingContext>(
                this, LiveChartsSkiaSharp.DefaultPlatformBuilder, canvas);
        }

        public CartesianChart<SkiaSharpDrawingContext> Core { get; }

        public IEnumerable<IAxis> XAxes { get; set; }

        public IEnumerable<IAxis> YAxes { get; set; }

        public IEnumerable<ISeries> Series { get; set; }

        public ZoomAndPanMode ZoomMode { get; set; }

        public double ZoomingSpeed { get; set; }

        public MotionCanvas<SkiaSharpDrawingContext> CoreCanvas => canvas;

        public IChartLegend<SkiaSharpDrawingContext> Legend => null;

        public IChartTooltip<SkiaSharpDrawingContext> Tooltip => null;

        public PointStatesDictionary<SkiaSharpDrawingContext> PointStates { get; set; }

        public SizeF ControlSize => new(100, 100);

        public Margin DrawMargin { get; set; }

        public TimeSpan AnimationsSpeed { get; set; } = TimeSpan.FromMilliseconds(1);

        public Func<float, float> EasingFunction { get; set; } = EasingFunctions.Lineal;

        public LegendPosition LegendPosition { get; set; }

        public LegendOrientation LegendOrientation { get; set; }

        public TooltipPosition TooltipPosition { get; set; }

        public TooltipFindingStrategy TooltipFindingStrategy { get; set; }

        public PointF ScaleUIPoint(PointF point, int xAxisIndex = 0, int yAxisIndex = 0)
        {
            return new PointF();
        }
    }
}
