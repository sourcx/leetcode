
using System.Text;

namespace leetcode;

// Given a string s, find the length of the longest substring without repeating characters.
class Assignment0003
{
    public static void Run()
    {
        // Example 1:
        // Input: s = "abcabcbb"
        // Output: 3
        // Explanation: The answer is "abc", with the length of 3.

        // Example 2:
        // Input: s = "bbbbb"
        // Output: 1
        // Explanation: The answer is "b", with the length of 1.

        // Example 3:
        // Input: s = "pwwkew"
        // Output: 3
        // Explanation: The answer is "wke", with the length of 3.
        // Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

        // Constraints:
        // 0 <= s.length <= 5 * 104
        // s consists of English letters, digits, symbols and spaces.

        var input = "aab";
        var res = (new Assignment0003()).LengthOfLongestSubstring(input);
        Console.WriteLine($"LengthOfLongestSubstring {input} is {res}");

        input = "abcabcbb";
        res = (new Assignment0003()).LengthOfLongestSubstring(input);
        Console.WriteLine($"LengthOfLongestSubstring {input} is {res}");

        input = "bbbbb";
        res = (new Assignment0003()).LengthOfLongestSubstring(input);
        Console.WriteLine($"LengthOfLongestSubstring {input} is {res}");

        input = "pwwkew";
        res = (new Assignment0003()).LengthOfLongestSubstring(input);
        Console.WriteLine($"LengthOfLongestSubstring {input} is {res}");
    }

    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1)
        {
            return s.Length;
        }

        int longest = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var length = LengthOfLongestSubstring(s, i);
            longest = Math.Max(longest, length);
        }

        return longest;
    }

    public int LengthOfLongestSubstring(string s, int startIndex)
    {
        if (s.Length <= 1)
        {
            return s.Length;
        }

        var currentSubstring = new List<char>() { s[startIndex] };

        for (int i = startIndex + 1; i < s.Length; i++)
        {
            char currentChar = s[i];

            if (currentSubstring.Contains(currentChar))
            {
                return currentSubstring.Count;
            }

            currentSubstring.Add(currentChar);
        }

        return currentSubstring.Count;
    }
}
