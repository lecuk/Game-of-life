using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Game_of_life.Classes
{
    class Drawer
    {
        Graphics Graph;
        RectangleF DrawingRect;
        Simulation SimulationToDraw;

        bool NeedGraphUpdate = false;
        Graphics newGraph;
        RectangleF newRectangle;

        bool[,] changedPositions;

        public SizeF UnitSize
        {
            get
            {
                return new SizeF(DrawingRect.Width / SimulationToDraw.width, DrawingRect.Height / SimulationToDraw.height);
            }
        }

        public RectangleF CellRectangle(int x, int y)
        {
            if (SimulationToDraw.IsInBounds(x, y))
            {
                PointF point = new PointF(UnitSize.Width * x, UnitSize.Height * y);
                return new RectangleF(point, UnitSize);
            }
            return RectangleF.Empty;
        }

        public void Draw()
        {
            if (NeedGraphUpdate)
                UpdateGraphics();

            for (int x = 0; x <= SimulationToDraw.maxX; x++)
            {
                for (int y = 0; y <= SimulationToDraw.maxY; y++)
                {
                    if (changedPositions[x, y])
                    {
                        RectangleF rect = CellRectangle(x, y);
                        if (SimulationToDraw.GetCellState(x, y))
                        {
                            Graph.FillRectangle(Brushes.White, rect);
                        }
                        else
                        {
                            Graph.FillRectangle(Brushes.Black, rect);
                        }
                        changedPositions[x, y] = false;
                    }
                }
            }
        }

        public void RedrawPosition(int x, int y)
        {
            changedPositions[x, y] = true;
        }

        public void RedrawAllPositions()
        {
            for (int x = 0; x <= SimulationToDraw.maxX; x++)
            {
                for (int y = 0; y <= SimulationToDraw.maxY; y++)
                {
                    RedrawPosition(x, y);
                }
            }
        }

        public void UpdateGraphicsNextFrame(Graphics newGraph, RectangleF newRectangle)
        {
            this.newGraph = newGraph;
            this.newRectangle = newRectangle;
            NeedGraphUpdate = true;
        }

        void UpdateGraphics()
        {
            Graph = newGraph;
            DrawingRect = newRectangle;
        }

        public Drawer(Graphics graph, RectangleF rectangle, Simulation simulation)
        {
            SimulationToDraw = simulation;
            UpdateGraphicsNextFrame(graph, rectangle);
            changedPositions = new bool[simulation.width, simulation.height];
        }
    }
}
