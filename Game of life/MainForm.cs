using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_of_life.Classes;

namespace Game_of_life
{
    public partial class MainForm : Form
    {
        Simulation simulation;
        Drawer drawer;

        public MainForm()
        {
            InitializeComponent();
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
            if (simulation == null)
            {
                simulation = new Simulation((int)NumericUpDown_Width.Value, (int)NumericUpDown_Height.Value, CurrentOptions);
                drawer = new Drawer(PictureBox_Main.CreateGraphics(), PictureBox_Main.DisplayRectangle, simulation);
                simulation.Updated += drawer.Draw;
                simulation.CellStateChanged += drawer.RedrawPosition;
                simulation.Simulate();
            }
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
            PictureBox_Main.CreateGraphics().Clear(Color.Black);
        }

        void UpdateSimulationOptions()
        {
            simulation?.UpdateOptionsNextFrame(CurrentOptions);
        }
        
        private void Button_Pause_Click(object sender, EventArgs e)
        {
            if (simulation != null )
            {
                if (!simulation.IsPaused)
                {
                    simulation.Pause();
                    Button_Pause.Text = "Continue";
                }
                else
                {
                    simulation.Continue();
                    Button_Pause.Text = "Pause";
                }
            }
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            if (simulation != null)
                simulation.SafeStop();

            simulation = null;
            drawer = null;

            ClearScreen();
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

                if (simulation.IsInBounds(x, y))
                {
                    if (e.Button == MouseButtons.Left)
                        simulation.ChangeCellStateManually(x, y, true);
                    if (e.Button == MouseButtons.Right)
                        simulation.ChangeCellStateManually(x, y, false);
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

                    if (simulation.IsInBounds(x, y))
                    {
                        simulation.ChangeCellStateManually(x, y, true);
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

                    if (simulation.IsInBounds(x, y))
                    {
                        simulation.ChangeCellStateManually(x, y, false);
                    }
                }
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            drawer?.UpdateGraphicsNextFrame(PictureBox_Main.CreateGraphics(), PictureBox_Main.DisplayRectangle);
            drawer?.RedrawAllPositions();
        }
    }
}
