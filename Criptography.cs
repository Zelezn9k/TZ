using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TZ
{
    public static class Criptography
    {
        public static List<string> analyzeText(string text)
        {
            var Words = text.Split(' ', '-', ':', '.', '"', '\'', '!', '?', ',').Where(q => !string.IsNullOrEmpty(q));
            var UniqWords = new Dictionary<string, int>();
            var result = new List<string>();
            foreach (var word in Words)
            {
                int value = 0;
                UniqWords.TryGetValue(word, out value);
                UniqWords[word] = value + 1;
            }

            UniqWords = UniqWords.OrderByDescending(q => q.Value).ToList().Take(3).ToDictionary(key => key.Key, value => value.Value);
            
            if (UniqWords.Count < 3)
            {
                return result;
            }
            foreach (var pair in UniqWords)
            {
                result.Add(pair.Key);
            }
            return result;
        }
        public static string encrypt(string text, int n)
        {
            if (n <= 0 || String.IsNullOrEmpty(text) )
                return text;
                    
            StringBuilder result = new StringBuilder();
            for (int k = 1; k <= n; k++)
            {
                result = new StringBuilder();
                for (int i = 1; i < text.Length; i += 2)
                {
                    result.Append(text[i]);
                }
                for (int i = 0; i < text.Length; i += 2)
                {
                    result.Append(text[i]);
                }
                text = result.ToString(); 
            }
            return result.ToString();
        }
        public static string decrypt(string encrypted_text, int n)
        {
            if (n <= 0 || String.IsNullOrEmpty(encrypted_text))
                return encrypted_text;

            StringBuilder result = new StringBuilder();
            for (int k = 1; k <= n; k++)
            {
                result = new StringBuilder();
                for(int i = 0; i < encrypted_text.Length; ++i)
                {
                    if (i % 2 == 0)
                    {
                        result.Append(encrypted_text[encrypted_text.Length / 2 + i / 2]);
                    }
                    else
                    {
                        result.Append(encrypted_text[i / 2]);
                    }
                }
                encrypted_text = result.ToString();
            }
            return result.ToString();
        }
    }
}

