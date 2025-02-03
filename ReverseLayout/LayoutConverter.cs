using System.Collections.Generic;
using System.Text;

namespace ReverseLayout
{
    public static class LayoutConverter
    {
        private static readonly Dictionary<char, char> EnToRu = new Dictionary<char, char>
        {
            // ... (ваш исходный словарь здесь)
        };

        private static readonly Dictionary<char, char> RuToEn = new Dictionary<char, char>();

        static LayoutConverter()
        {
            InitializeRuToEnDictionary();
        }

        private static void InitializeRuToEnDictionary()
        {
            foreach (var pair in EnToRu)
            {
                if (!RuToEn.ContainsKey(pair.Value))
                    RuToEn.Add(pair.Value, pair.Key);
            }
        }

        public static string Convert(string input)
        {
            StringBuilder output = new StringBuilder();
            foreach (char c in input)
            {
                if (EnToRu.TryGetValue(c, out char ruChar))
                    output.Append(ruChar);
                else if (RuToEn.TryGetValue(c, out char enChar))
                    output.Append(enChar);
                else
                    output.Append(c);
            }
            return output.ToString();
        }
    }
}