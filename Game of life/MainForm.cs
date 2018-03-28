using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Game_of_life.Classes;

namespace Game_of_life
{
    public partial class MainForm : Form
    {
        Simulation simulation;
        Drawer drawer;

        System.Drawing.Graphics graph;

        Timer updateTimer;

        public MainForm()
        {
            InitializeComponent();

            graph = PictureBox_Main.CreateGraphics();

            ResetUICounters();

            updateTimer = new Timer();
            updateTimer.Interval = 100;
            updateTimer.Tick += TimerUpdate;
            updateTimer.Start();
        }

        private void CheckedListBox_BirthConditions_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckedListBox_BirthConditions.SelectedIndex = -1;
            UpdateSimulationOptions();
        }

        private void CheckedListBox_KillConditions_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckedListBox_KillConditions.SelectedIndex = -1;
            UpdateSimulationOptions();
        }

        private void Button_StartSimulation_Click(object sender, EventArgs e)
        {
            SimulationCreatorForm form = SimulationCreatorForm.OpenDialog(this);
        }

        public bool[] BirthConditions
        {
            get
            {
                bool[] conditions = new bool[Simulation.NeighbourCountCombinations];
                for (int i = 0; i < Simulation.NeighbourCountCombinations; i++)
                {
                    conditions[i] = CheckedListBox_BirthConditions.GetItemChecked(i);
                }
                return conditions;
            }
        }

        public bool[] KillConditions
        {
            get
            {
                bool[] conditions = new bool[Simulation.NeighbourCountCombinations];
                for (int i = 0; i < Simulation.NeighbourCountCombinations; i++)
                {
                    conditions[i] = CheckedListBox_KillConditions.GetItemChecked(i);
                }
                return conditions;
            }
        }

        SimulationOptions CurrentOptions
        {
            get
            {
                return new SimulationOptions((int)NumericUpDown_FPS.Value, BirthConditions, KillConditions, CheckBox_ConnectEdges.Checked);
            }
        }

        void ClearScreen()
        {
            PictureBox_Main.CreateGraphics().Clear(System.Drawing.Color.Black);
        }

        void UpdateSimulationOptions()
        {
            simulation?.UpdateOptionsNextFrame(CurrentOptions);
        }
        
        private void Button_Pause_Click(object sender, EventArgs e)
        {
            PauseOrContinue();
        }

        void Pause()
        {
            if (simulation != null)
            {
                simulation.Pause();
                Button_Pause.Text = "Continue";
            }
        }

        void PauseOrContinue()
        {
            if (simulation != null)
            {
                if (simulation.IsPaused)
                {
                    Continue();
                }
                else
                {
                    Pause();
                }
            }
        }

        void Continue()
        {
            if (simulation != null)
            {
                simulation.Continue();
                Button_Pause.Text = "Pause";
            }
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            if (simulation != null)
                simulation.Clear();
        }

        private void PictureBox_Main_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            simulation?.UnsafeStop();
        }

        private void NumericUpDown_FPS_ValueChanged(object sender, EventArgs e)
        {
            UpdateSimulationOptions();
        }

        private void CheckBox_ConnectEdges_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSimulationOptions();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
        }

        private void PictureBox_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (simulation != null && drawer != null)
            {
                float w = drawer.UnitSize.Width;
                float h = drawer.UnitSize.Height;
                int x = (int)((e.X) / w);
                int y = (int)((e.Y) / h);
                Point p = new Point(x, y);

                if (simulation.IsInBounds(p))
                {
                    if (e.Button == MouseButtons.Left)
                        simulation.ChangeCellStateManually(p, true);
                    if (e.Button == MouseButtons.Right)
                        simulation.ChangeCellStateManually(p, false);
                }
            }
        }

        private void PictureBox_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (simulation != null && drawer != null)
                {
                    float w = drawer.UnitSize.Width;
                    float h = drawer.UnitSize.Height;
                    int x = (int)((e.X) / w);
                    int y = (int)((e.Y) / h);
                    Point p = new Point(x, y);

                    if (simulation.IsInBounds(p))
                    {
                        simulation.ChangeCellStateManually(p, true);
                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (simulation != null && drawer != null)
                {
                    float w = drawer.UnitSize.Width;
                    float h = drawer.UnitSize.Height;
                    int x = (int)((e.X) / w);
                    int y = (int)((e.Y) / h);
                    Point p = new Point(x, y);

                    if (simulation.IsInBounds(p))
                    {
                        simulation.ChangeCellStateManually(p, false);
                    }
                }
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            graph = PictureBox_Main.CreateGraphics();
            drawer?.UpdateGraphicsNextFrame(graph, graph.VisibleClipBounds);
            drawer?.RedrawAllPositions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCurrentSimulation();
        }

        public void StartNewSimulation(Simulation simulation)
        {
            this.simulation?.SafeStop();
            this.simulation = simulation;
            graph = PictureBox_Main.CreateGraphics();
            drawer = new Drawer(graph, graph.VisibleClipBounds, simulation);
            simulation.Updated += drawer.Draw;
            simulation.CellStateChanged += drawer.RedrawPosition;
            UpdateChildControlsWithNewOptions(simulation.GetCurrentOptions());
            drawer.RedrawAllPositions();
            ResetUICounters();
            simulation.Simulate();
            Pause();
        }

        public void UpdateChildControlsWithNewOptions(SimulationOptions newOptions)
        {
            for (int i = 0; i <= 8; i++)
            {
                CheckedListBox_BirthConditions.SetItemChecked(i, newOptions.birthConditions[i]);
                CheckedListBox_KillConditions.SetItemChecked(i, newOptions.killConditions[i]);
            }
            CheckBox_ConnectEdges.Checked = newOptions.connectEdges;
            NumericUpDown_FPS.Value = (decimal)(1000.0 / newOptions.frameDuration);
        }

        void TimerUpdate(object sender, EventArgs e)
        {
            UpdateUI();
        }

        void UpdateUI()
        {
            if (simulation != null && simulation.IsWorking)
            {
                Label_CellsAlive.Text = $"Cells alive: {simulation?.CellsAlive.ToString()}";
                Label_Updates.Text = $"Updates: {simulation?.Updates.ToString()}";
                Label_Frames.Text = $"Frames: {simulation?.Frames.ToString()}";
            }
        }

        void ResetUICounters()
        {
            Label_CellsAlive.Text = "";
            Label_Updates.Text = "";
            Label_Frames.Text = "";
        }

        private void MainForm_EnabledChanged(object sender, EventArgs e)
        {
            drawer?.RedrawAllPositions();
        }

        public void SaveCurrentSimulation()
        {
            DialogResult result = SelectPathDialog.ShowDialog();
            SelectPathDialog.OverwritePrompt = true;
            if (result == DialogResult.OK)
            {
                string path = SelectPathDialog.FileName;
                if (path.Substring(path.Length - 5) == ".gols")
                {
                    SimulationSaver.Save(simulation, path);
                }
                else
                    MessageBox.Show("Wrong file format! File name should end with '.gols'");
            }
        }
    }
}
