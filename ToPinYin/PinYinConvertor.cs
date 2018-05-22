using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ToPinYin
{
    [ValueConversion(typeof(string), typeof(string))]
    public class PinYinConvertor : IValueConverter
    {
        private readonly Dictionary<string, PinYin> dictionary = null;

        public PinYinConvertor()
        {
            dictionary = new Dictionary<string, PinYin>();

            var lines = File.ReadAllLines("pinyin.txt");
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var words = line.Split('\t');
                if (words.Length != 3)
                {
                    continue;
                }

                if (dictionary.ContainsKey(words[0]))
                {
                    continue;
                }

                PinYin yinpin = new PinYin { Letter = words[0], Pinyin = words[1], Pinyin2 = words[2] };

                dictionary.Add(words[0], yinpin);
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as string;
            if (string.IsNullOrEmpty(source))
            {
                return "请在左侧输入汉字";
            }

            StringBuilder builder = new StringBuilder();
            foreach (var item in source)
            {
                var stringKey = item.ToString();

                if (stringKey == "\r" || stringKey == "\n")
                {
                    builder.AppendLine();
                    continue;
                }

                if (dictionary.ContainsKey(stringKey))
                {
                    builder.Append(dictionary[stringKey].Pinyin2);

                    builder.Append(" ");
                }
            }

            return builder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
