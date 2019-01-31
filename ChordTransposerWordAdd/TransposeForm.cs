
namespace ChordTransposerWordAdd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Word;

    public partial class TransposeForm : Form
    {
        public bool _preferSharps { get; set; }
        public int _halfSteps { get; set; }
        private readonly static string[] _keysSharps = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

        public TransposeForm()
        {
            InitializeComponent();
        }

        private void btnTranspose_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabcontrolTransposerType.SelectedTab == tabByNumber)
                {
                    _halfSteps = (int)spinSteps.Value;
                    _preferSharps = rbPreferSharps.Checked;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCurrentKey.Text) && GetFirstIndex(txtCurrentKey.Text) != -1)
                    {
                        if (!string.IsNullOrEmpty(txtNewKey.Text) && GetFirstIndex(txtNewKey.Text) != -1)
                        {
                            _halfSteps = CalculateHalfSteps();
                            _preferSharps = rbPreferSharps.Checked;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Must enter a valid new key");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Must enter a valid current key");
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message);
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
        private int CalculateHalfSteps()
        {
            var curIndex = 0;
            var newIndex = 0;
            //if ((string)radioDirection.EditValue == "up")
            {
                curIndex = GetFirstIndex(txtCurrentKey.Text);
                newIndex = GetLastIndex(txtNewKey.Text);
            }
            //else
            //{
            //    curIndex = GetLastIndex(txtCurrentKey.Text);
            //    newIndex = GetFirstIndex(txtNewKey.Text);
            //}

            var halfSteps = newIndex - curIndex;
            if (halfSteps > 12)
                halfSteps -= 12;
            else if (halfSteps < -12)
                halfSteps += 12;

            return halfSteps;
        }
        private static int GetFirstIndex(string text)
        {
            for (int i = 0; i < _keysSharps.Length; i++)
            {
                if (GetEnharmonicName(text) == _keysSharps[i])
                {
                    return i;
                }
            }
            return -1;
        }
        private static int GetLastIndex(string text)
        {
            for (int i = _keysSharps.Length - 1; i >= 0; i--)
            {
                if (GetEnharmonicName(text) == _keysSharps[i])
                {
                    return i;
                }
            }
            return -1;
        }

        //private void txtNewKey_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtNewKey.Text) && GetFirstIndex(txtNewKey.Text) != -1)
        //    {
        //        switch (txtNewKey.Text)
        //        {
        //            case "C#":
        //            case "D":
        //            case "D#":
        //            case "E":
        //            case "F#":
        //            case "G":
        //            case "G#":
        //            case "A":
        //            case "A#":
        //            case "B":
        //                radioGroup1.EditValue = "sharps";
        //                break;
        //            case "Db":
        //            case "Eb":
        //            case "F":
        //            case "Gb":
        //            case "Ab":
        //            case "Bb":
        //                radioGroup1.EditValue = "flats";
        //                break;
        //            default:
        //                radioGroup1.EditValue = "sharps";
        //                break;
        //        }
        //    }
        //}

        private static string GetEnharmonicName(string key)
        {
            var enharmonic = key;
            if (key == "Db")
                enharmonic = "C#";
            else if (key == "Eb")
                enharmonic = "D#";
            else if (key == "Gb")
                enharmonic = "F#";
            else if (key == "Ab")
                enharmonic = "G#";
            else if (key == "Bb")
                enharmonic = "A#";
            return enharmonic;
        }

        private void TransposeForm_Load(object sender, EventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            //StoryRanges storyRanges = doc.StoryRanges;
            //foreach (Range storyRange in storyRanges)
            //{
            //    string storyRangeText = storyRange.Text;
            //    Console.WriteLine(storyRangeText);
            //}
            var shapes = doc.Shapes;
            foreach (Shape shape in shapes)
            {
                var textFrame = shape.TextFrame;
                var textRange = textFrame.TextRange;
                var text = textRange.Text;
                var keyOfIndex = text.IndexOf("Key of ");
                if (keyOfIndex != -1)
                {
                    txtCurrentKey.Text = text.Substring(keyOfIndex + 7, 2).Trim();
                    txtNewKey.Focus();
                    break;
                }
                keyOfIndex = text.IndexOf(" Form ");
                if (keyOfIndex != -1)
                {
                    txtCurrentKey.Text = text.Substring(keyOfIndex - 2, 2).Trim();
                    txtNewKey.Focus();
                    break;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
