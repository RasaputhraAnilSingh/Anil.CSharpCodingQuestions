using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Anil.CSharpCodingQuestions
{

    /// <summary>
    /// C# String Manipulation Interview Problems:
    ///
    /// 1. Reverse a string without using built-in Reverse().
    /// 2. Check whether a string is a palindrome.
    /// 3. Reverse each word in a sentence.
    /// 4. Find duplicate characters in a string.
    /// 5. Find the first non-repeating character.
    /// 6. Count the occurrence of each character.
    /// 7. Count vowels and consonants.
    /// 8. Check whether two strings are anagrams.
    /// 9. Remove duplicate characters from a string.
    /// 10. Find the first repeating character.
    /// 11. Find the maximum occurring character.
    /// 12. Count the number of words in a sentence.
    /// 13. Reverse the order of words in a sentence.
    /// 14. Check whether a string contains only digits.
    /// 15. Find the longest word in a sentence.
    /// 16. Find the longest substring without repeating characters.
    /// 17. Find all permutations of a string.
    /// 18. Check whether one string is a rotation of another.
    /// 19. Remove special characters from a string.
    /// 20. Compress a string (e.g., "aaabbc" → "a3b2c1").
    ///
    /// Concepts Covered:
    /// Loops, Strings, Arrays, LINQ, Dictionary, HashSet,
    /// StringBuilder, Recursion, Backtracking, Sliding Window,
    /// Time Complexity and Space Complexity.
    /// </summary>

    public class StringBasedQuestions
    {
        //string is immutable, once string is created that can't be changable.
        //It looks like we're modifying the same string, but internally C# creates a new string object every time.
        //o(n2) Each iteration creates a new string and copies all existing characters plus the new character, so total copying is 1 + 2 + 3 + 4 + 5 = 15 for 5 characters; generally, \(1+2+\cdots+n = \frac{n(n+1)}{2}\), which gives O(n²) time complexity.
        public void reverse_string(string @string)
        {
            string reverse = string.Empty;
            for(int i = @string.Length - 1; i >= 0; i--)
            {
                reverse += @string[i];
            }
            Console.WriteLine(reverse);
        }

        //StringBuilder maintains a mutable character buffer.
        //Append() generally adds characters without creating a new string every time.
        //It expands its internal buffer when necessary.
        public void optimize_reverse_string(string @string) 
        { 
            StringBuilder reverse = new StringBuilder();
            for (int i = @string.Length - 1; i >= 0; i--) 
            {
                reverse.Append(@string[i]);
            }
            Console.WriteLine(reverse.ToString());
        }
        // END - REVERSE STRING

        public void IsPolindrome(string @string) 
        {
            bool IsPolindrome = true;

            for (int i = 0; i < @string.Length / 2; i++) 
            { 
                if( @string[i] != @string.Length - 1 - i)
                {
                    IsPolindrome = false;
                    break;
                }
            }

            Console.WriteLine(IsPolindrome ? "Polindrome" : "Not a Polindrome");
        }

        public void optimize_IsPolidrome(string @string)
        {
            bool isPolidrome = true;
            int left = 0;
            int right = @string.Length - 1;
            while (left < right) 
            { 
                if(@string[left] != @string[right])
                {
                    isPolidrome = false;
                    break;
                }
                left++;
                right--;
            }
           
            Console.WriteLine(isPolidrome ? "Polidrome" : "Not a Polidrome");

        }
        // END - Polindrome STRING


        public void findDuplicatesCharInStringUsingLinQ(string @string)
        {
           var duplicates =  @string.GroupBy(ch => ch).Where(group => group.Count() > 1);

            foreach (var group in duplicates)
            {
                Console.WriteLine($"{group.Key} = {group.Count()}");

            }
        }
        public void findDuplicatesCharInStringUsingDic(string @string)
        {
           Dictionary<char, int> duplicates = new Dictionary<char, int>();
           foreach (char c in @string)
            {
                if (duplicates.ContainsKey(c))
                {
                    duplicates[c]++;
                }
                else
                {
                    duplicates.Add(c, 1);
                }
            }
            foreach (var item in duplicates)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine($"{item.Key} = {item.Value}");
                   
                }
            }
        }
        // END Find Duplicates char in string.


        public void ReverseEachWordInaSentnece(string @string)
        {
            string[] array = @string.Split(" ");

            for (int i = 0; i < array.Length; i++)
            {
                char[] chars = array[i].ToCharArray();

                int left = 0;
                int right = chars.Length - 1;

                while(left < right)
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;

                    left++;
                    right--;
                }
             

                array[i] = new string(chars);
            }

            string result = string.Join(" ", array);

            Console.WriteLine(result);
        }

        public void Optimize_ReverseEachWordInaSentnece(string @string)
        {
            string result = string.Join(" ",@string.Split(' ').Select(word => new string(word.Reverse().ToArray())));
            Console.WriteLine(result);
        }

        //END Reverse each word in a sentences

        public void First_Non_Repeatingcharcter(string @string)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            foreach(char a  in @string)
            {
                
                    if (keyValuePairs.ContainsKey(a))
                    {
                        keyValuePairs[a]++;
                    }
                    else
                    {
                        keyValuePairs[a] = 1;
                    }   
                
            }
            
            foreach(char a in @string)
            {
                if (keyValuePairs[a] == 1)
                {
                    Console.WriteLine($"{a}");
                    break;
                }
            }
          
        }
        public void Optimize_First_Non_Repeatingcharcter(string @string)
        {
            var result = @string.GroupBy(ch => ch).FirstOrDefault(g => g.Count() == 1);
            if(result != null)
            {
                Console.WriteLine(result.Key);
            }
        }

        //END Find non-repeating characters
    }
}
