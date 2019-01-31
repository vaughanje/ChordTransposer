namespace ChordTransposerWordAdd
{
    partial class TransposeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransposeForm));
            this.tabcontrolTransposerType = new System.Windows.Forms.TabControl();
            this.tabByNumber = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.spinSteps = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNewKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbPreferSharps = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnTranspose = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabcontrolTransposerType.SuspendLayout();
            this.tabByNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSteps)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabcontrolTransposerType
            // 
            this.tabcontrolTransposerType.Controls.Add(this.tabByNumber);
            this.tabcontrolTransposerType.Controls.Add(this.tabPage2);
            this.tabcontrolTransposerType.Location = new System.Drawing.Point(12, 12);
            this.tabcontrolTransposerType.Name = "tabcontrolTransposerType";
            this.tabcontrolTransposerType.SelectedIndex = 0;
            this.tabcontrolTransposerType.Size = new System.Drawing.Size(290, 137);
            this.tabcontrolTransposerType.TabIndex = 0;
            // 
            // tabByNumber
            // 
            this.tabByNumber.Controls.Add(this.label2);
            this.tabByNumber.Controls.Add(this.spinSteps);
            this.tabByNumber.Controls.Add(this.label1);
            this.tabByNumber.Location = new System.Drawing.Point(4, 22);
            this.tabByNumber.Name = "tabByNumber";
            this.tabByNumber.Padding = new System.Windows.Forms.Padding(3);
            this.tabByNumber.Size = new System.Drawing.Size(282, 111);
            this.tabByNumber.TabIndex = 0;
            this.tabByNumber.Text = "By Half Steps";
            this.tabByNumber.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "half steps";
            // 
            // spinSteps
            // 
            this.spinSteps.Location = new System.Drawing.Point(85, 35);
            this.spinSteps.Name = "spinSteps";
            this.spinSteps.Size = new System.Drawing.Size(42, 20);
            this.spinSteps.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adjust by:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNewKey);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtCurrentKey);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(282, 111);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "By Key";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNewKey
            // 
            this.txtNewKey.Location = new System.Drawing.Point(177, 34);
            this.txtNewKey.Name = "txtNewKey";
            this.txtNewKey.Size = new System.Drawing.Size(33, 20);
            this.txtNewKey.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "New Key:";
            // 
            // txtCurrentKey
            // 
            this.txtCurrentKey.Location = new System.Drawing.Point(85, 34);
            this.txtCurrentKey.Name = "txtCurrentKey";
            this.txtCurrentKey.Size = new System.Drawing.Size(29, 20);
            this.txtCurrentKey.TabIndex = 1;
            this.txtCurrentKey.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current Key:";
            // 
            // rbPreferSharps
            // 
            this.rbPreferSharps.AutoSize = true;
            this.rbPreferSharps.Checked = true;
            this.rbPreferSharps.Location = new System.Drawing.Point(64, 156);
            this.rbPreferSharps.Name = "rbPreferSharps";
            this.rbPreferSharps.Size = new System.Drawing.Size(87, 17);
            this.rbPreferSharps.TabIndex = 1;
            this.rbPreferSharps.TabStop = true;
            this.rbPreferSharps.Text = "Prefer sharps";
            this.rbPreferSharps.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(157, 156);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Prefer flats";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnTranspose
            // 
            this.btnTranspose.Location = new System.Drawing.Point(64, 185);
            this.btnTranspose.Name = "btnTranspose";
            this.btnTranspose.Size = new System.Drawing.Size(75, 23);
            this.btnTranspose.TabIndex = 3;
            this.btnTranspose.Text = "Transpose";
            this.btnTranspose.UseVisualStyleBackColor = true;
            this.btnTranspose.Click += new System.EventHandler(this.btnTranspose_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TransposeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 221);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTranspose);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.rbPreferSharps);
            this.Controls.Add(this.tabcontrolTransposerType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransposeForm";
            this.Text = "TransposeForm";
            this.Load += new System.EventHandler(this.TransposeForm_Load);
            this.tabcontrolTransposerType.ResumeLayout(false);
            this.tabByNumber.ResumeLayout(false);
            this.tabByNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSteps)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabcontrolTransposerType;
        private System.Windows.Forms.TabPage tabByNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown spinSteps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtNewKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbPreferSharps;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnTranspose;
        private System.Windows.Forms.Button button2;
    }
}