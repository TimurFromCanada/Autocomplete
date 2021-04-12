using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;

            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return phrases[index];
            }
            else
            {
                return null;
            }
        }

        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var start = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            var numbers = GetCountByPrefix(phrases, prefix);

            if (numbers <= 0)
            {
                return new string[0];
            }
                
            if (count > numbers)
            {
                count = numbers;
            }
                
            var words = new string[count];

            for (var i = 0; i < count; i++)
            {
                words[i] = phrases[start + i];
            }
                
            return words;
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            var right = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);
            return right - left - 1;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(6, 3 * 2, "Пример");
        }
    }
}


