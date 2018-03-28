namespace Game_of_life
{
    partial class SimulationCreatorForm
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
            this.NumericUpDown_Height = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Width = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TextBox_FilePath = new System.Windows.Forms.TextBox();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.Button_Create = new System.Windows.Forms.Button();
            this.Button_Load = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Width)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDown_Height
            // 
            this.NumericUpDown_Height.Location = new System.Drawing.Point(12, 55);
            this.NumericUpDown_Height.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericUpDown_Height.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericUpDown_Height.Name = "NumericUpDown_Height";
            this.NumericUpDown_Height.Size = new System.Drawing.Size(68, 20);
            this.NumericUpDown_Height.TabIndex = 0;
            this.NumericUpDown_Height.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // NumericUpDown_Width
            // 
            this.NumericUpDown_Width.Location = new System.Drawing.Point(12, 29);
            this.NumericUpDown_Width.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericUpDown_Width.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericUpDown_Width.Name = "NumericUpDown_Width";
            this.NumericUpDown_Width.Size = new System.Drawing.Size(68, 20);
            this.NumericUpDown_Width.TabIndex = 1;
            this.NumericUpDown_Width.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Create a new simulation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Or load from file";
            // 
            // TextBox_FilePath
            // 
            this.TextBox_FilePath.Location = new System.Drawing.Point(12, 127);
            this.TextBox_FilePath.Name = "TextBox_FilePath";
            this.TextBox_FilePath.Size = new System.Drawing.Size(271, 20);
            this.TextBox_FilePath.TabIndex = 6;
            this.TextBox_FilePath.TextChanged += new System.EventHandler(this.TextBox_FilePath_TextChanged);
            // 
            // Button_Browse
            // 
            this.Button_Browse.Location = new System.Drawing.Point(289, 126);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(68, 22);
            this.Button_Browse.TabIndex = 7;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.UseVisualStyleBackColor = true;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // Button_Create
            // 
            this.Button_Create.Location = new System.Drawing.Point(12, 81);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(75, 23);
            this.Button_Create.TabIndex = 8;
            this.Button_Create.Text = "Create";
            this.Button_Create.UseVisualStyleBackColor = true;
            this.Button_Create.Click += new System.EventHandler(this.Button_Create_Click);
            // 
            // Button_Load
            // 
            this.Button_Load.Location = new System.Drawing.Point(12, 153);
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(75, 23);
            this.Button_Load.TabIndex = 9;
            this.Button_Load.Text = "Load";
            this.Button_Load.UseVisualStyleBackColor = true;
            this.Button_Load.Click += new System.EventHandler(this.Button_Load_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.Location = new System.Drawing.Point(282, 167);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 10;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // SimulationCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 202);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Load);
            this.Controls.Add(this.Button_Create);
            this.Controls.Add(this.Button_Browse);
            this.Controls.Add(this.TextBox_FilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumericUpDown_Width);
            this.Controls.Add(this.NumericUpDown_Height);
            this.MaximumSize = new System.Drawing.Size(385, 241);
            this.MinimumSize = new System.Drawing.Size(385, 241);
            this.Name = "SimulationCreatorForm";
            this.Text = "Create new simulation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SimulationCreatorForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumericUpDown_Height;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.TextBox TextBox_FilePath;
        private System.Windows.Forms.Button Button_Browse;
        private System.Windows.Forms.Button Button_Create;
        private System.Windows.Forms.Button Button_Load;
        private System.Windows.Forms.Button Button_Cancel;
    }
}