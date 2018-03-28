using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace Game_of_life.Classes
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator == (Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }

        public static bool operator != (Point p1, Point p2)
        {
            return (p1.x != p2.x | p1.y != p2.y);
        }

        public static Point OutOfBounds = new Point(-666, -666);
    }

    public struct SimulationOptions
    {
        public double frameDuration;

        public readonly bool[]
            birthConditions,
            killConditions;

        public readonly bool connectEdges;

        public SimulationOptions(int FPS, bool[] b, bool[] k, bool connectEdges)
        {
            frameDuration = 1000.0 / FPS;
            birthConditions = b;
            killConditions = k;
            this.connectEdges = connectEdges;
        }

        public static SimulationOptions Default 
        {
            get
            {
                int FPS = 30;
                bool[] birthConditions = new bool[9];
                bool[] killConditions = new bool[9];
                birthConditions[3] = true;
                killConditions[0] = true;
                killConditions[1] = true;
                killConditions[4] = true;
                killConditions[5] = true;
                killConditions[6] = true;
                killConditions[7] = true;
                killConditions[8] = true;
                bool connectEdges = true;
                return new SimulationOptions(FPS, birthConditions, killConditions, connectEdges);
            }
        }
    }

    public class Simulation
    {
        public const int NeighbourCountCombinations = 9;

        public readonly int width, height;
        public readonly int maxX, maxY;

        readonly bool[,] cells;
        readonly bool[,] nextUpdateCells;
        readonly Dictionary<Point, bool> manualChanges;
        private bool clear = false;

        private SimulationOptions CurrentOptions;
        private SimulationOptions nextFrameOptions;
        private bool NeedUpdateOptions = false;
        
        private Thread workThread;
        private bool isWorking = false;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        private bool isPaused = false;
        public bool IsPaused
        {
            get
            {
                return isPaused;
            }
        }

        private int updates;
        public int Updates
        {
            get
            {
                return updates;
            }
        }

        private int frames;
        public int Frames
        {
            get
            {
                return frames;
            }
        }

        private int cellsAlive;
        public int CellsAlive
        {
            get
            {
                return cellsAlive;
            }
        }

        public delegate void OnUpdate();
        public event OnUpdate Updated;

        public delegate void OnCellStateChange(Point p);
        public event OnCellStateChange CellStateChanged;

        public bool GetCellState(Point p)
        {
            Point tp = ConnectedEdgesPosition(p);
            if (tp != Point.OutOfBounds)
                return cells[tp.x, tp.y];
            return false;
        }

        public void SetCellState(Point p, bool state)
        {
            Point tp = ConnectedEdgesPosition(p);
            if (tp != Point.OutOfBounds)
                nextUpdateCells[tp.x, tp.y] = state;
        }

        Point ConnectedEdgesPosition(Point p)
        {
            if (CurrentOptions.connectEdges)
            {
                if (p.x < 0)
                    p.x = maxX;

                if (p.x > maxX)
                    p.x = 0;

                if (p.y < 0)
                    p.y = maxY;

                if (p.y > maxY)
                    p.y = 0;

                return p;
            }
            else
            {
                if (IsInBounds(p))
                    return p;
            }
            return Point.OutOfBounds;
        }

        public bool IsInBounds(Point p)
        {
            return (p.x >= 0 && p.x <= maxX && p.y >= 0 && p.y <= maxY);
        }

        public int GetNeighbourCount(Point p)
        {
            int count = 0;

            if (GetCellState(new Point(p.x - 1, p.y - 1))) count++;
            if (GetCellState(new Point(p.x - 1, p.y    ))) count++;
            if (GetCellState(new Point(p.x - 1, p.y + 1))) count++;
            if (GetCellState(new Point(p.x    , p.y - 1))) count++;
            if (GetCellState(new Point(p.x    , p.y + 1))) count++;
            if (GetCellState(new Point(p.x + 1, p.y - 1))) count++;
            if (GetCellState(new Point(p.x + 1, p.y    ))) count++;
            if (GetCellState(new Point(p.x + 1, p.y + 1))) count++;

            return count;
        }

        public SimulationOptions GetCurrentOptions()
        {
            return CurrentOptions;
        }

        public void UpdateOptionsNextFrame(SimulationOptions newOptions)
        {
            nextFrameOptions = newOptions;
            NeedUpdateOptions = true;
        }

        void UpdateOptions()
        {
            CurrentOptions = nextFrameOptions;
            NeedUpdateOptions = false;
        }

        public void Simulate()
        {
            workThread = new Thread(Work);
            isWorking = true;
            workThread.Start();
        }

        void Work()
        {
            Stopwatch stopwatch = new Stopwatch();
            while (isWorking)
            {
                stopwatch.Restart();
                if (NeedUpdateOptions)
                    UpdateOptions();

                if (!isPaused)
                {
                    UpdateCellStates();
                    UpdateNaturallyChangedCells();
                    frames++;
                }
                while(stopwatch.Elapsed.Ticks < CurrentOptions.frameDuration * TimeSpan.TicksPerMillisecond)
                {
                    //SpinWait
                }
                UpdateManuallyChangedCells();
                Updated?.Invoke();
                updates++;
                stopwatch.Reset();
            }
        }

        void UpdateCellStates()
        {
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    UpdateCellState(new Point(x, y));
                }
            }
        }

        void SetCellStateNow(Point p, bool state)
        {
            Point tp = ConnectedEdgesPosition(p);
            if (tp != Point.OutOfBounds) {
                if (state != GetCellState(tp))
                {
                    if (state)
                    {
                        cellsAlive++;
                    }
                    else
                    {
                        cellsAlive--;
                    }
                    cells[tp.x, tp.y] = state;
                    CellStateChanged?.Invoke(tp);
                }
            }
        }

        void UpdateAllCells()
        {
            UpdateNaturallyChangedCells();
            UpdateManuallyChangedCells();
        }

        object listLocker = new object();
        void UpdateManuallyChangedCells()
        {
            if (!clear && manualChanges.Count > 0)
            {
                lock (listLocker)
                {
                    foreach (Point p in manualChanges.Keys)
                    {
                        SetCellStateNow(p, manualChanges[p]);
                    }
                    manualChanges.Clear();
                }
            }
            if (clear)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        SetCellStateNow(new Point(x, y), false);
                    }
                }
                clear = false;
            }
        }

        void UpdateNaturallyChangedCells()
        {
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    SetCellStateNow(new Point(x, y), nextUpdateCells[x, y]);
                }
            }
        }

        public void ChangeCellStateManually(Point p, bool state)
        {
            Point tp = ConnectedEdgesPosition(p);
            if (tp != Point.OutOfBounds)
            {
                if (!manualChanges.ContainsKey(tp))
                    manualChanges.Add(tp, state);
            }
        }

        void UpdateCellState(Point p)
        {
            bool alive = GetCellState(p);
            if (alive)
            {
                SetCellState(p, !CurrentOptions.killConditions[GetNeighbourCount(p)]);
            }
            else
            {
                SetCellState(p, CurrentOptions.birthConditions[GetNeighbourCount(p)]);
            }
        }

        public void Clear()
        {
            clear = true;
        }

        public void Pause()
        {
            if (IsWorking)
                isPaused = true;
        }

        public void Continue()
        {
            if (IsWorking)
                isPaused = false;
        }

        public void SafeStop()
        {
            isWorking = false;
        }

        public void UnsafeStop()
        {
            if (isWorking)
                workThread.Abort();
        }

        public Simulation(int width, int height, SimulationOptions options) : this(width, height, options, null)
        {
        }

        public Simulation(int width, int height, SimulationOptions options, List<Point> cellsToAdd)
        {
            this.width = width;
            this.height = height;

            maxX = width - 1;
            maxY = height - 1;

            cells = new bool[width, height];
            nextUpdateCells = new bool[width, height];
            manualChanges = new Dictionary<Point, bool>();

            CurrentOptions = options;

            if (cellsToAdd != null)
            {
                foreach(Point p in cellsToAdd)
                {
                    SetCellStateNow(p, true);
                }
            }
        }
    }
}
