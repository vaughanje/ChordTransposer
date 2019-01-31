namespace ChordTransposerWordAdd
{
    partial class ChordTransposerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ChordTransposerRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            _transposer.TranspositionProgressEvent += TranspositionProgressEvent;
        }

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
            if (_progressForm != null)
                _progressForm.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabChordTransposer = this.Factory.CreateRibbonTab();
            this.grpTransposer = this.Factory.CreateRibbonGroup();
            this.btnTranspose = this.Factory.CreateRibbonButton();
            this.tabChordTransposer.SuspendLayout();
            this.grpTransposer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabChordTransposer
            // 
            this.tabChordTransposer.Groups.Add(this.grpTransposer);
            this.tabChordTransposer.Label = "Chord Transposer";
            this.tabChordTransposer.Name = "tabChordTransposer";
            // 
            // grpTransposer
            // 
            this.grpTransposer.Items.Add(this.btnTranspose);
            this.grpTransposer.Label = "Transposer";
            this.grpTransposer.Name = "grpTransposer";
            // 
            // btnTranspose
            // 
            this.btnTranspose.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnTranspose.Image = global::ChordTransposerWordAdd.Properties.Resources.treble;
            this.btnTranspose.Label = "Transpose";
            this.btnTranspose.Name = "btnTranspose";
            this.btnTranspose.ShowImage = true;
            this.btnTranspose.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnTranspose_Click);
            // 
            // ChordTransposerRibbon
            // 
            this.Name = "ChordTransposerRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabChordTransposer);
            this.tabChordTransposer.ResumeLayout(false);
            this.tabChordTransposer.PerformLayout();
            this.grpTransposer.ResumeLayout(false);
            this.grpTransposer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabChordTransposer;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTransposer;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTranspose;
    }

    partial class ThisRibbonCollection
    {
        internal ChordTransposerRibbon ChordTransposerRibbon
        {
            get { return this.GetRibbon<ChordTransposerRibbon>(); }
        }
    }
}
