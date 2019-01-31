using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChordTransposerWordAdd
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }
        public void SetCaption(string caption)
        {
            this.lblDescription.Text = caption;
        }
        public void SetDescription(string description)
        {
            this.lblDescription.Text = description;
        }

        internal void SetProgress(int percentComplete)
        {
            this.progressBar1.Value = percentComplete; ;
        }
        //public void ProcessCommand(Enum cmd, object arg)
        //{
        //    base.ProcessCommand(cmd, arg);
        //}
    }
}
