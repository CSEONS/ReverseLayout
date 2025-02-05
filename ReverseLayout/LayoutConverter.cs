using System.Text;

namespace ReverseLayout
{
    public static class LayoutConverter
    {
        private static Dictionary<string, string> layout = new()
        {
            { "q", "й" }, { "w", "ц" }, { "e", "у" }, { "r", "к" }, { "t", "е" }, { "y", "н" },
            { "u", "г" }, { "i", "ш" }, { "o", "щ" }, { "p", "з" }, { "[", "х" }, { "]", "ъ" },
            { "a", "ф" }, { "s", "ы" }, { "d", "в" }, { "f", "а" }, { "g", "п" }, { "h", "р" },
            { "j", "о" }, { "k", "л" }, { "l", "д" }, { ";", "ж" }, { "'", "э" }, { "z", "я" },
            { "x", "ч" }, { "c", "с" }, { "v", "м" }, { "b", "и" }, { "n", "т" }, { "m", "ь" },
            { ",", "б" }, { ".", "ю" }, { "/", "." }, { "Q", "Й" }, { "W", "Ц" }, { "E", "У" },
            { "R", "К" }, { "T", "Е" }, { "Y", "Н" }, { "U", "Г" }, { "I", "Ш" }, { "O", "Щ" },
            { "P", "З" }, { "{", "Х" }, { "}", "Ъ" }, { "A", "Ф" }, { "S", "Ы" }, { "D", "В" },
            { "F", "А" }, { "G", "П" }, { "H", "Р" }, { "J", "О" }, { "K", "Л" }, { "L", "Д" },
            { ":", "Ж" }, { "\"", "Э" }, { "Z", "Я" }, { "X", "Ч" }, { "C", "С" }, { "V", "М" },
            { "B", "И" }, { "N", "Т" }, { "M", "Ь" }, { "<", "Б" }, { ">", "Ю" }, { "?", "," }
        };


        public static string Convert(string input)
        {
            StringBuilder output = new StringBuilder();

            foreach (var symb in input)
            {
                if (layout.ContainsKey(symb.ToString()) is false)
                {
                    continue;
                }

                output.Append(layout[symb.ToString()]);
            }

            return output.ToString();
        }
    }
}