using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace ChordTransposerWordAdd
{
	public partial class ChordTransposerRibbon
	{

		private readonly Transposer _transposer = new Transposer();

		private void btnTranspose_Click(object sender, RibbonControlEventArgs e)
		{
			try
			{
				using (var f = new TransposeForm())
				{
					if (f.ShowDialog() == DialogResult.OK)
					{
						_progressForm.Show();
						Application.DoEvents();

						//Globals.ThisAddIn.Application.ScreenUpdating = false;
						Globals.ThisAddIn.Application.UndoRecord.StartCustomRecord("Transposition");

						_transposer.TransposeAllShapesInDocument(Globals.ThisAddIn.Application.ActiveDocument, f._preferSharps, f._halfSteps);

						//Globals.ThisAddIn.Application.ScreenUpdating = true;
						Globals.ThisAddIn.Application.UndoRecord.EndCustomRecord();

						_progressForm.Hide();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		readonly static ProgressForm _progressForm = new ProgressForm();

		static void TranspositionProgressEvent(int pass,
                                               int outOf, 
								      		   int percentComplete)
		{
			try
			{
                var ratio = (decimal)pass / (decimal)outOf;
                var itemsProgress = ratio * 100.0m;
                var adjustedProgress = itemsProgress + (ratio * percentComplete);

                _progressForm.SetProgress((int)(adjustedProgress));
				_progressForm.SetDescription(String.Format("Shape - {0} - {1}%",
														   pass,
														   percentComplete));
				Application.DoEvents();
			}
			catch (Exception)
			{
                ;
			}
		}
	}
}