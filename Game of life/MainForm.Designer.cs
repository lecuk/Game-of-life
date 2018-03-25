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
            this.CheckedListBox_KillConditions = new System.Windows.Forms.CheckedListBox();
            this.Label_KillConditions = new System.Windows.Forms.Label();
            this.Label_Conditions = new System.Windows.Forms.Label();
            this.PictureBox_Main = new System.Windows.Forms.PictureBox();
            this.Button_StartSimulation = new System.Windows.Forms.Button();
            this.Button_Pause = new System.Windows.Forms.Button();
            this.Button_Stop = new System.Windows.Forms.Button();
            this.NumericUpDown_Width = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.NumericUpDown_Height = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckBox_ConnectEdges = new System.Windows.Forms.CheckBox();
            this.NumericUpDown_FPS = new System.Windows.Forms.NumericUpDown();
            this.Label_FPS = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_FPS)).BeginInit();
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
            this.panel1.Controls.Add(this.CheckedListBox_KillConditions);
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
            // CheckedListBox_KillConditions
            // 
            this.CheckedListBox_KillConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckedListBox_KillConditions.BackColor = System.Drawing.SystemColors.Control;
            this.CheckedListBox_KillConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckedListBox_KillConditions.CheckOnClick = true;
            this.CheckedListBox_KillConditions.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.CheckedListBox_KillConditions.Location = new System.Drawing.Point(90, 36);
            this.CheckedListBox_KillConditions.Name = "CheckedListBox_KillConditions";
            this.CheckedListBox_KillConditions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckedListBox_KillConditions.Size = new System.Drawing.Size(31, 135);
            this.CheckedListBox_KillConditions.TabIndex = 6;
            this.CheckedListBox_KillConditions.ThreeDCheckBoxes = true;
            this.CheckedListBox_KillConditions.SelectedValueChanged += new System.EventHandler(this.CheckedListBox_KillConditions_SelectedValueChanged);
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
            this.Label_Conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Conditions.Location = new System.Drawing.Point(18, 0);
            this.Label_Conditions.Name = "Label_Conditions";
            this.Label_Conditions.Size = new System.Drawing.Size(92, 15);
            this.Label_Conditions.TabIndex = 4;
            this.Label_Conditions.Text = "State Contitions";
            // 
            // PictureBox_Main
            // 
            this.PictureBox_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox_Main.BackColor = System.Drawing.Color.Black;
            this.PictureBox_Main.Location = new System.Drawing.Point(145, 0);
            this.PictureBox_Main.Name = "PictureBox_Main";
            this.PictureBox_Main.Size = new System.Drawing.Size(446, 383);
            this.PictureBox_Main.TabIndex = 5;
            this.PictureBox_Main.TabStop = false;
            this.PictureBox_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Main_MouseDown);
            this.PictureBox_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Main_MouseMove);
            // 
            // Button_StartSimulation
            // 
            this.Button_StartSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_StartSimulation.Location = new System.Drawing.Point(12, 291);
            this.Button_StartSimulation.Name = "Button_StartSimulation";
            this.Button_StartSimulation.Size = new System.Drawing.Size(127, 33);
            this.Button_StartSimulation.TabIndex = 6;
            this.Button_StartSimulation.Text = "Start";
            this.Button_StartSimulation.UseVisualStyleBackColor = true;
            this.Button_StartSimulation.Click += new System.EventHandler(this.Button_StartSimulation_Click);
            // 
            // Button_Pause
            // 
            this.Button_Pause.Location = new System.Drawing.Point(12, 330);
            this.Button_Pause.Name = "Button_Pause";
            this.Button_Pause.Size = new System.Drawing.Size(60, 23);
            this.Button_Pause.TabIndex = 7;
            this.Button_Pause.Text = "Pause";
            this.Button_Pause.UseVisualStyleBackColor = true;
            this.Button_Pause.Click += new System.EventHandler(this.Button_Pause_Click);
            // 
            // Button_Stop
            // 
            this.Button_Stop.Location = new System.Drawing.Point(78, 330);
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Size = new System.Drawing.Size(61, 23);
            this.Button_Stop.TabIndex = 8;
            this.Button_Stop.Text = "Stop";
            this.Button_Stop.UseVisualStyleBackColor = true;
            this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // NumericUpDown_Width
            // 
            this.NumericUpDown_Width.Location = new System.Drawing.Point(12, 206);
            this.NumericUpDown_Width.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDown_Width.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericUpDown_Width.Name = "NumericUpDown_Width";
            this.NumericUpDown_Width.Size = new System.Drawing.Size(60, 20);
            this.NumericUpDown_Width.TabIndex = 9;
            this.NumericUpDown_Width.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Width";
            // 
            // NumericUpDown_Height
            // 
            this.NumericUpDown_Height.Location = new System.Drawing.Point(78, 206);
            this.NumericUpDown_Height.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDown_Height.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericUpDown_Height.Name = "NumericUpDown_Height";
            this.NumericUpDown_Height.Size = new System.Drawing.Size(61, 20);
            this.NumericUpDown_Height.TabIndex = 11;
            this.NumericUpDown_Height.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Height";
            // 
            // CheckBox_ConnectEdges
            // 
            this.CheckBox_ConnectEdges.AutoSize = true;
            this.CheckBox_ConnectEdges.Location = new System.Drawing.Point(12, 233);
            this.CheckBox_ConnectEdges.Name = "CheckBox_ConnectEdges";
            this.CheckBox_ConnectEdges.Size = new System.Drawing.Size(98, 17);
            this.CheckBox_ConnectEdges.TabIndex = 13;
            this.CheckBox_ConnectEdges.Text = "Connect edges";
            this.CheckBox_ConnectEdges.UseVisualStyleBackColor = true;
            this.CheckBox_ConnectEdges.CheckedChanged += new System.EventHandler(this.CheckBox_ConnectEdges_CheckedChanged);
            // 
            // NumericUpDown_FPS
            // 
            this.NumericUpDown_FPS.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumericUpDown_FPS.Location = new System.Drawing.Point(12, 257);
            this.NumericUpDown_FPS.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NumericUpDown_FPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_FPS.Name = "NumericUpDown_FPS";
            this.NumericUpDown_FPS.Size = new System.Drawing.Size(60, 20);
            this.NumericUpDown_FPS.TabIndex = 14;
            this.NumericUpDown_FPS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_FPS.ValueChanged += new System.EventHandler(this.NumericUpDown_FPS_ValueChanged);
            // 
            // Label_FPS
            // 
            this.Label_FPS.AutoSize = true;
            this.Label_FPS.Location = new System.Drawing.Point(78, 260);
            this.Label_FPS.Name = "Label_FPS";
            this.Label_FPS.Size = new System.Drawing.Size(27, 13);
            this.Label_FPS.TabIndex = 15;
            this.Label_FPS.Text = "FPS";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 383);
            this.Controls.Add(this.Label_FPS);
            this.Controls.Add(this.NumericUpDown_FPS);
            this.Controls.Add(this.CheckBox_ConnectEdges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumericUpDown_Height);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumericUpDown_Width);
            this.Controls.Add(this.Button_Stop);
            this.Controls.Add(this.Button_Pause);
            this.Controls.Add(this.Button_StartSimulation);
            this.Controls.Add(this.PictureBox_Main);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Game of life";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_FPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label_BirthConditions;
        private System.Windows.Forms.CheckedListBox CheckedListBox_BirthConditions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox CheckedListBox_KillConditions;
        private System.Windows.Forms.Label Label_KillConditions;
        private System.Windows.Forms.Label Label_Conditions;
        private System.Windows.Forms.PictureBox PictureBox_Main;
        private System.Windows.Forms.Button Button_StartSimulation;
        private System.Windows.Forms.Button Button_Pause;
        private System.Windows.Forms.Button Button_Stop;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Height;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckBox_ConnectEdges;
        private System.Windows.Forms.NumericUpDown NumericUpDown_FPS;
        private System.Windows.Forms.Label Label_FPS;
    }
}

