using System;

namespace Kinvo.Utilities.Util
{
    public static class EditDistanceMetrics
    {
        /// <summary>
        /// The Levenshtein distance between two words is the minimum number of single-character edits 
        /// (insertions, deletions or substitutions) required to change one word into the other
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public static int GetLevenshteinEditDistance(
        string word1,
        string word2)
        {
            /// Sources:
            /// Implementation: https://www.eximiaco.tech/en/2019/11/17/computing-the-levenshtein-edit-distance-of-two-strings-using-c/
            /// Theory: https://en.wikipedia.org/wiki/Levenshtein_distance#Relationship_with_other_edit_distance_metrics
            if (string.IsNullOrEmpty(word1))
            {
                return word2.Length;
            }

            if (string.IsNullOrEmpty(word2))
            {
                return word1.Length;
            }

            word1 = word1.ToUpper();
            word2 = word2.ToUpper();

            var current = 1;
            var previous = 0;
            var r = new int[2, word2.Length + 1];
            for (var i = 0; i <= word2.Length; i++)
            {
                r[previous, i] = i;
            }

            for (var i = 0; i < word1.Length; i++)
            {
                r[current, 0] = i + 1;

                for (var j = 1; j <= word2.Length; j++)
                {
                    var cost = (word2[j - 1] == word1[i]) ? 0 : 1;
                    r[current, j] = Min(
                        r[previous, j] + 1,
                        r[current, j - 1] + 1,
                        r[previous, j - 1] + cost);
                }
                previous = (previous + 1) % 2;
                current = (current + 1) % 2;
            }
            return r[previous, word2.Length];
        }

        private static int Min(int e1, int e2, int e3) =>
            Math.Min(Math.Min(e1, e2), e3);
    }
}
