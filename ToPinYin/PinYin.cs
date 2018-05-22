using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToPinYin
{
    public class PinYin
    {
        /// <summary>
        /// 汉字
        /// </summary>
        public string Letter { get; set; }

        /// <summary>
        /// 带音调的拼音
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// 不带音调的拼音
        /// </summary>
        public string Pinyin2 { get; set; }
    }
}
