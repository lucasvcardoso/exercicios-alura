using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromo
{
    public class Palindromo
    {
        public bool EhPalindromo(string frase)
        {
            string sentence = frase.ToUpper().Replace(" ", "").Replace("-", "");
            var counter = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] != sentence[sentence.Length - i - 1])
                {
                    counter++;
                }
                if (counter > 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsAlmostPalindrome(string word)
        {
            int counter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    counter++;
                }
                if (counter > 1)
                {
                    return false;
                }
            }
            return true;
        }

        
    }
}
