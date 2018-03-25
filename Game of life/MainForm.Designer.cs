namespace Game_of_life
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_BirthConditions = new System.Windows.Forms.Label();
            this.CheckedListBox_BirthConditions = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.Label_KillConditions = new System.Windows.Forms.Label();
            this.Label_Conditions = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_BirthConditions
            // 
            this.Label_BirthConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_BirthConditions.BackColor = System.Drawing.SystemColors.Window;
            this.Label_BirthConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label_BirthConditions.Location = new System.Drawing.Point(3, 18);
            this.Label_BirthConditions.Name = "Label_BirthConditions";
            this.Label_BirthConditions.Size = new System.Drawing.Size(57, 15);
            this.Label_BirthConditions.TabIndex = 2;
            this.Label_BirthConditions.Text = "Birth dead";
            this.Label_BirthConditions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckedListBox_BirthConditions
            // 
            this.CheckedListBox_BirthConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckedListBox_BirthConditions.BackColor = System.Drawing.SystemColors.Control;
            this.CheckedListBox_BirthConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckedListBox_BirthConditions.CheckOnClick = true;
            this.CheckedListBox_BirthConditions.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.CheckedListBox_BirthConditions.Location = new System.Drawing.Point(3, 36);
            this.CheckedListBox_BirthConditions.Name = "CheckedListBox_BirthConditions";
            this.CheckedListBox_BirthConditions.Size = new System.Drawing.Size(31, 135);
            this.CheckedListBox_BirthConditions.TabIndex = 3;
            this.CheckedListBox_BirthConditions.ThreeDCheckBoxes = true;
            this.CheckedListBox_BirthConditions.SelectedValueChanged += new System.EventHandler(this.CheckedListBox_BirthConditions_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Controls.Add(this.Label_BirthConditions);
            this.panel1.Controls.Add(this.Label_KillConditions);
            this.panel1.Controls.Add(this.Label_Conditions);
            this.panel1.Controls.Add(this.CheckedListBox_BirthConditions);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.MaximumSize = new System.Drawing.Size(127, 175);
            this.panel1.MinimumSize = new System.Drawing.Size(127, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 175);
            this.panel1.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.checkedListBox1.Location = new System.Drawing.Point(90, 36);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkedListBox1.Size = new System.Drawing.Size(31, 135);
            this.checkedListBox1.TabIndex = 6;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // Label_KillConditions
            // 
            this.Label_KillConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_KillConditions.BackColor = System.Drawing.SystemColors.Window;
            this.Label_KillConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label_KillConditions.Location = new System.Drawing.Point(66, 18);
            this.Label_KillConditions.Name = "Label_KillConditions";
            this.Label_KillConditions.Size = new System.Drawing.Size(58, 15);
            this.Label_KillConditions.TabIndex = 5;
            this.Label_KillConditions.Text = "Kill alive";
            this.Label_KillConditions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Conditions
            // 
            this.Label_Conditions.AutoSize = true;
            this.Label_Conditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Conditions.Location = new System.Drawing.Point(18, 0);
            this.Label_Conditions.Name = "Label_Conditions";
            this.Label_Conditions.Size = new System.Drawing.Size(94, 17);
            this.Label_Conditions.TabIndex = 4;
            this.Label_Conditions.Text = "State Contitions";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Game of life";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Label_BirthConditions;
        private System.Windows.Forms.CheckedListBox CheckedListBox_BirthConditions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label Label_KillConditions;
        private System.Windows.Forms.Label Label_Conditions;
    }
}

