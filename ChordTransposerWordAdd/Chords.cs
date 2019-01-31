using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordTransposerWordAdd
{
    class Chords
    {
        public static string[][] GetChordResultData(bool preferSharps)
        {
            return preferSharps ? ChordDataSharps : ChordDataFlats;
        }

        public static string[][] GetChordSearchData(bool bSharpChord)
        {
            return bSharpChord ? ChordDataSharps : ChordDataFlats;
        }

        public static string[][] ChordDataSharps => _chordDataSharps;

        public static string[][] ChordDataFlats => _chordDataFlats;

        static Chords()
        {

            _chordDataSharps = GenerateChords(_keysSharp, _chords);
            _chordDataFlats = GenerateChords(_keysFlat, _chords);
        }

        private static string[][] GenerateChords(string[] keys, string[] chords)
        {
            var keyChords = new string[keys.Length][];
            for (int i = 0; i < keys.Length; i++)
            {
                keyChords[i] = new string[chords.Length + 1];
                for (int j = 0; j < chords.Length; j++)
                {
                    keyChords[i][j] = $"{keys[i]}{chords[j]}";
                }
                keyChords[i][chords.Length] = $"/{keys[i]}";
            }
            return keyChords;
        }

        private readonly static string[] _keysSharp = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        private readonly static string[] _keysFlat  = { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
        private readonly static string[] _chords = { "", "7", "9", "sus", "2", "M7", "m", "m7", "m9",
                                                     "dim", "dim7", "+", "add9", "maj7", "6", "maj9",
                                                     "5", "11", "13", "m6", "m11", "m13", "sus2", "aug",
                                                     "7sus4", "9sus4", "aug9", "7sus", "9sus" };


        private readonly static string[][] _chordDataSharps;
        private readonly static string[][] _chordDataFlats;
    }
}
