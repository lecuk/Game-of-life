using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_life
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CheckedListBox_BirthConditions_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckedListBox_BirthConditions.SelectedIndex = -1;
        }

        private void Label_Conditions_Click(object sender, EventArgs e)
        {

        }
    }
}
