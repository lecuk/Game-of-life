using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace Game_of_life.Classes
{
    struct SimulationOptions
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
    }

    class Simulation
    {
        public const int NeighbourCountCombinations = 9;

        public readonly int width, height;
        public readonly int maxX, maxY;

        readonly bool[,] cells;
        readonly bool[,] nextUpdateCells;
        readonly bool[,] needManualChange;
        readonly bool[,] manualChangeValues;

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

        public delegate void OnUpdate();
        public event OnUpdate Updated;

        public delegate void OnCellStateChange(int x, int y);
        public event OnCellStateChange CellStateChanged;

        public bool GetCellState(int x, int y)
        {
            if (ConnectedEdgesPosition(ref x, ref y))
            {
                return cells[x, y];
            }
            return false;
        }

        public void SetCellState(int x, int y, bool state)
        {
            if (ConnectedEdgesPosition(ref x, ref y))
            {
                nextUpdateCells[x, y] = state;
            }
        }

        bool ConnectedEdgesPosition(ref int x, ref int y)
        {
            if (CurrentOptions.connectEdges)
            {
                if (x < 0)
                    x = maxX;

                if (x > maxX)
                    x = 0;

                if (y < 0)
                    y = maxY;

                if (y > maxY)
                    y = 0;

                return true;
            }
            else
            {
                if (IsInBounds(x, y))
                    return true;
            }
            return false;
        }

        public bool IsInBounds(int x, int y)
        {
            return (x >= 0 && x <= maxX && y >= 0 && y <= maxY);
        }

        public int GetNeighbourCount(int x, int y)
        {
            int count = 0;

            if (GetCellState(x - 1, y - 1)) count++;
            if (GetCellState(x - 1, y    )) count++;
            if (GetCellState(x - 1, y + 1)) count++;
            if (GetCellState(x    , y - 1)) count++;
            if (GetCellState(x    , y + 1)) count++;
            if (GetCellState(x + 1, y - 1)) count++;
            if (GetCellState(x + 1, y    )) count++;
            if (GetCellState(x + 1, y + 1)) count++;

            return count;
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
                    UpdateCellState(x, y);
                }
            }
        }

        void SetCellStateNow(int x, int y, bool state)
        {
            if (ConnectedEdgesPosition(ref x, ref y))
            {
                if (state != GetCellState(x, y))
                {
                    cells[x, y] = state;
                    CellStateChanged?.Invoke(x, y);
                }
            }
        }

        void UpdateAllCells()
        {
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    if (needManualChange[x, y])
                    {
                        SetCellStateNow(x, y, manualChangeValues[x, y]);
                        needManualChange[x, y] = false;
                    }
                    else
                    {
                        SetCellStateNow(x, y, nextUpdateCells[x, y]);
                    }
                }
            }
        }

        void UpdateManuallyChangedCells()
        {
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    if (needManualChange[x, y])
                    {
                        SetCellStateNow(x, y, manualChangeValues[x, y]);
                        needManualChange[x, y] = false;
                    }
                }
            }
        }

        void UpdateNaturallyChangedCells()
        {
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    if (!needManualChange[x, y])
                    {
                        SetCellStateNow(x, y, nextUpdateCells[x, y]);
                    }
                }
            }
        }

        public void ChangeCellStateManually(int x, int y, bool state)
        {
            if (ConnectedEdgesPosition(ref x, ref y))
            {
                needManualChange[x, y] = true;
                manualChangeValues[x, y] = state;
            }
        }

        void UpdateCellState(int x, int y)
        {
            bool alive = GetCellState(x, y);
            if (alive)
            {
                SetCellState(x, y, !CurrentOptions.killConditions[GetNeighbourCount(x, y)]);
            }
            else
            {
                SetCellState(x, y, CurrentOptions.birthConditions[GetNeighbourCount(x, y)]);
            }
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
            workThread.Abort();
        }

        public Simulation(int width, int height, SimulationOptions options)
        {
            this.width = width;
            this.height = height;

            maxX = width - 1;
            maxY = height - 1;

            cells = new bool[width, height];
            nextUpdateCells = new bool[width, height];
            needManualChange = new bool[width, height];
            manualChangeValues = new bool[width, height];

            UpdateOptionsNextFrame(options);
        }
    }
}
