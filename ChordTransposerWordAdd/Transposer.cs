using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ChordTransposerWordAdd.Properties;


namespace ChordTransposerWordAdd
{
	class Transposer
	{
		public delegate void TranspositionProgressEventHandler(int pass, int outOf, int percentComplete);
		public event TranspositionProgressEventHandler TranspositionProgressEvent;

        protected virtual void OnTranspositionProgressEvent(int pass, int outOf, int percentComplete) => TranspositionProgressEvent?.Invoke(pass, outOf, percentComplete);

        private const string SHARP_INDICATOR = "ShArP";
        private const string SHARP_INDICATOR_MINOR = "ShArPm";

        public void TransposeAllShapesInDocument(Document doc,
		                                         bool preferSharps,
		                                         int halfSteps)
		{
			var shapes = doc.Shapes;
            for (int shapeIndex = 1; shapeIndex <= shapes.Count; shapeIndex++)
			{
				var shape = (Shape) shapes[shapeIndex];
                var textFrame = shape.TextFrame;
                var textRange = textFrame.TextRange;

				PerformTransposition(textRange,
				                     preferSharps,
				                     halfSteps,
				                     shapeIndex,
                                     shapes.Count);
			}
		}

		private void PerformTransposition(Range textRange,
		                                  bool preferSharps,
		                                  int halfSteps,
		                                  int pass,
                                          int outOf)
		{
            //string txt = textRange.Text;

            textRange.Find.Execute("#m",
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   SHARP_INDICATOR_MINOR,
                                   WdReplace.wdReplaceAll,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing);
            textRange.Find.Execute("#",
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   SHARP_INDICATOR,
                                   WdReplace.wdReplaceAll,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing,
                                   Type.Missing);
            //txt = textRange.Text;
            textRange.Find.Execute("Cb",
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing,
			                       "B",
			                       WdReplace.wdReplaceAll,
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing,
			                       Type.Missing);

            var wds = textRange.Words;

			for (int wordIndex = 1; wordIndex <= wds.Count; wordIndex++)
			{
				OnTranspositionProgressEvent(pass,
                                             outOf,
				                             (int) Math.Round( (double) wordIndex / (double) wds.Count * 100.0) );
				if (wordIndex == wds.Count || !WordList.IsEnglishWord(wds[wordIndex+1].Text))
					ProcessCurrentWord(halfSteps,
					                   wds[wordIndex],
					                   preferSharps);
			}
		}

		private static void ProcessCurrentWord(int halfSteps,
		                                       Range wordRange,
		                                       bool preferSharps)
		{
            var bSharpChord = false;
            var wdText = wordRange.Text;

			if (wordRange.Font.Italic == 0)
			{
                var bFound = false;
				if (IsFirstLetterAChordLetter(wdText))
				{
					(bSharpChord, wdText) = CheckAndAdjustForSharpChord(wordRange.Text, wdText);

					for (int keyIndex = 0; keyIndex <= 11 && !bFound; keyIndex++)
					{
						bFound = ProcessKey(halfSteps,
						                    preferSharps,
						                    bSharpChord,
						                    wordRange,
						                    wdText,
						                    keyIndex);
					}
				}
			}
		}

		private static bool ProcessKey(int halfSteps,
		                               bool preferSharps,
		                               bool currentChordIsSharp,
		                               Range wordRange,
		                               string wdText,
		                               int keyIndex)
		{
            var bFound = false;
            var chordSearchData = Chords.GetChordSearchData(currentChordIsSharp);

			for (int chordIndex = 0; chordIndex < chordSearchData[keyIndex].Length && !bFound; chordIndex++)
			{
				bFound = ProcessChord(halfSteps,
				                      preferSharps,
				                      chordSearchData,
				                      wordRange,
				                      wdText,
				                      keyIndex,
				                      chordIndex);
			}
			return bFound;
		}

		private static bool ProcessChord(int halfSteps,
		                                 bool preferSharps,
		                                 string[][] chordSearchData,
		                                 Range wordRange,
		                                 string wdText,
		                                 int keyIndex,
		                                 int chordIndex)
		{
            var result = false;
            var chordResultData = Chords.GetChordResultData(preferSharps);

			if (wdText.Trim().Equals(chordSearchData[keyIndex][chordIndex]))
			{
                var valueToAdd = CalculateAdjustmentValue(halfSteps,
				                                          keyIndex);
                var originalChord = chordSearchData[keyIndex][chordIndex];
                var newChord = chordResultData[(keyIndex + valueToAdd)][chordIndex];

				ReplaceChord(wordRange,
				             wdText,
				             originalChord,
				             newChord);

				result = true;
			}
			return result;
		}

		private static void ReplaceChord(Range wordRange,
		                                 string wdText,
		                                 string originalChord,
		                                 string newChord)
		{
			if (originalChord.Length > newChord.Length)
			{
				wordRange.Text = wdText.Replace(SHARP_INDICATOR,
				                                "#").Replace(originalChord, newChord + " ");
			}
			else
			{
				if ((originalChord.Length < newChord.Length) && (wdText.EndsWith("  ", StringComparison.Ordinal)))
				{
					wordRange.Text = wdText.Replace(SHARP_INDICATOR,
					                                "#").Replace(originalChord + " ",
					                                             newChord);
				}
				else
				{
					wordRange.Text = wdText.Replace(SHARP_INDICATOR,
					                                "#").Replace(originalChord,
					                                             newChord);
				}
			}
		}

		private static bool IsFirstLetterAChordLetter(string wdText)
		{
			return wdText[0] >= 'A' && wdText[0] <= 'G';
		}


        private static (bool, string) CheckAndAdjustForSharpChord(string text, string wdText)
        {
            wdText = text.Replace(SHARP_INDICATOR_MINOR, "#").Replace(SHARP_INDICATOR, "#");
            return (!(wdText == text), wdText);
        }

        private static int CalculateAdjustmentValue(int halfSteps,
		                                            int keyIndex)
		{
            var valueToAdd = halfSteps;
			if (keyIndex + valueToAdd >= 12)
				valueToAdd = valueToAdd - 12;
			else if (keyIndex + valueToAdd < 0)
				valueToAdd = valueToAdd + 12;
			return valueToAdd;
		}

		//private static int GetKeyIndex(string[][] chordData, System.String actualCurrentKey)
		//{
		//    int keyIndex = 0;
		//    for (int i = 0; i < 11; i++)
		//    {
		//        if (chordData[i][0] == actualCurrentKey)
		//        {
		//            keyIndex = i;
		//            break;
		//        }
		//    }
		//    return keyIndex;
		//}

	}
}
