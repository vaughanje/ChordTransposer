using ChordTransposerWordAdd.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordTransposerWordAdd
{
    class WordList
    {
        private static List<string> wordList = null;

        public static bool IsEnglishWord(string word)
        {
            if (wordList == null)
            {
                wordList = new List<string>();
                wordList.AddRange(Resources.words.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).AsEnumerable());
            }

            return (wordList.IndexOf(word) != -1);
        }

    }
}
