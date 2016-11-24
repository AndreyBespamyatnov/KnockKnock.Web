using System.Collections.Generic;
using System.Linq;
using KnockKnock.Web.Interfaces;

namespace KnockKnock.Web.Services.Reverse
{
    /// <summary>
    /// The <see cref="IReverseWordsService"/> implimentation
    /// You can reverce eache words in one sentence
    /// <exception cref="MaxLengthException">
    /// Will be throw if input sentence string great that <see cref="MaxStringLength"/> propery
    /// </exception> 
    /// </summary>
    public class ReverseWordsService : ServiceBase, IReverseWordsService
    {
        /// <summary>
        /// 102 million chars ought to be enough for anybody
        /// </summary>
        protected virtual int MaxStringLength => int.MaxValue / 21;

        /// <summary>
        /// Reverse eache word in sentence
        /// Prevalidated by <see cref="MaxStringLength"/>
        /// </summary>
        /// <param name="sentence">The sentence to reverse</param>
        /// <returns>Reversed sentence</returns>
        public string ReverseWords(string sentence)
        {
            Validate(sentence);

            string result = string.Empty;
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return result;
            }

            result = GetFromCache(sentence);
            if (result != null)
            {
                return result;
            }

            LinkedList<char> wordList = new LinkedList<char>();
            LinkedListNode<char> lastLeft = null;
            for (int index = 0; index < sentence.Length; index++)
            {
                var c = sentence[index];

                if (!char.IsLetterOrDigit(c))
                {
                    wordList.AddLast(c);
                }
                else
                {
                    lastLeft = lastLeft == null ? wordList.AddLast(c) : wordList.AddBefore(lastLeft, c);
                    if (index + 1 < sentence.Length && !char.IsLetterOrDigit(sentence[index + 1]))
                    {
                        lastLeft = null;
                    }
                }
            }

            AddToCache(wordList, sentence);
            return new string(wordList.ToArray());
        }

        /// <summary>
        /// Has one validation for max length
        /// </summary>
        /// <param name="str">The string to validate</param>
        protected virtual void Validate(string str)
        {
            if (str.Length >= MaxStringLength)
            {
                throw new MaxLengthException();
            }
        }
    }
}