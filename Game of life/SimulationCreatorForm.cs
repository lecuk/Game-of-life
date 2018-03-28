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
    public partial class SimulationCreatorForm : Form
    {
        string filePath = "No path selected.";

        MainForm parentForm;
        
        private SimulationCreatorForm()
        {
            InitializeComponent();
        }

        public static SimulationCreatorForm OpenDialog(MainForm parent)
        {
            SimulationCreatorForm dialogForm = new SimulationCreatorForm();
            dialogForm.parentForm = parent;
            dialogForm.BeginDialog();
            dialogForm.Show();
            return dialogForm;
        }

        void BeginDialog()
        {
            parentForm.Enabled = false;
        }

        void EndDialog()
        {
            parentForm.Enabled = true;
        }

        public string SelectedFilePath()
        {
            DialogResult result = OpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = OpenFileDialog.FileName;
                if (path.Substring(path.Length - 5) == ".gols")
                {
                    return path;
                }
                MessageBox.Show("Wrong file format! File name should end with '.gols'");
            }
            return "No path selected";
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
            filePath = SelectedFilePath();
            TextBox_FilePath.Text = filePath;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Load_Click(object sender, EventArgs e)
        {
            Simulation simulation = SimulationSaver.Load(filePath);

            if (simulation != null)
            {
                parentForm.StartNewSimulation(simulation);
            }
            else
            {
                MessageBox.Show("Error was occured during load");
            }
            Close();
        }

        private void SimulationCreatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            EndDialog();
        }

        private void TextBox_FilePath_TextChanged(object sender, EventArgs e)
        {
            filePath = TextBox_FilePath.Text;
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            Simulation simulation = new Simulation((int)NumericUpDown_Width.Value, (int)NumericUpDown_Height.Value, SimulationOptions.Default);
            parentForm.StartNewSimulation(simulation);
            Close();
        }
    }
}
