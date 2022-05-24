using System;
using System.Collections.Generic;

namespace Word_Break___DP
{
  class Program
  {
    static void Main(string[] args)
    {
      List<string> wordDict = new List<string>() { "cats", "dog", "sand", "and", "cat" };
      string s = "catsandog";
      Solution sol = new Solution();
      var present = sol.WordBreak(s, wordDict);
      Console.WriteLine(present);
    }
  }

  public class Solution
  {
    public bool WordBreak(string s, IList<string> wordDict)
    {
      // create the DP array of s.Length + 1
      // we will have the asnwer at the last index
      bool[] dp = new bool[s.Length + 1];
      // to start the DP will set 0th index as true
      dp[0] = true;
      for (int i = 1; i <= s.Length; i++)
      {
        // calculate all possible substring and check present inside the wordDict
        for (int j = 0; j < i; j++)
        {
          string subStr = s.Substring(j, i - j);
          // check dp[j] already calculated ?
          if(dp[j] && wordDict.Contains(subStr))
          {
            // if the substring is presnt, mark that dp length to true as memorization for later
            dp[i] = true;
            break;
          }
        }
      }

      return dp[s.Length];
    }
  }
}
