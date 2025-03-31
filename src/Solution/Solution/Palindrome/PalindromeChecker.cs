using System;
using System.Net.NetworkInformation;

namespace Solution.Palindrome
{
    public static class PalindromeChecker
    {
        public static bool CekPalindrom(string input)
        {
            string normalized = new string(input.ToLower().Where(char.IsLetter).ToArray());

            Stack<char> stack = new Stack<char>();

            foreach(char c in normalized)
            {
                stack.Push(c);
            }

            foreach(char c in normalized)
            {
                if(stack.Pop() != c)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}