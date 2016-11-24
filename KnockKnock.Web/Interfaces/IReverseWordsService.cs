namespace KnockKnock.Web.Interfaces
{
    /// <summary>
    /// You can reverce eache words in one sentence
    /// </summary>
    public interface IReverseWordsService
    {
        /// <summary>
        /// Reverse eache word in sentence
        /// </summary>
        /// <param name="sentence">The sentence to reverse</param>
        /// <returns>Reversed sentence</returns>
        string ReverseWords(string sentence);
    }
}