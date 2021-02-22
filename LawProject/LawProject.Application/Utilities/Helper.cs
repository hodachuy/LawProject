using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LawProject.Application.Utilities
{
    public class Helper
    {
        /// <summary>
        /// Lấy danh sách mã văn bản xuất hiện trong 1 chuỗi.
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public static string GetLegalCodeFrString(string contents)
        {
            string lgCode = null;
            List<string> _lstLegalCode = new List<string>();
            Regex rReg = new Regex("(\\d{1,5}\\/)?\\d{1,5}(\\-\\w+)?\\/([a-zA-ZĐ\\-]+)", RegexOptions.Singleline);
            Match _rLegalCode = rReg.Match(contents);
            while (_rLegalCode.Success)
            {
                _lstLegalCode.Add(_rLegalCode.ToString());
                _rLegalCode = _rLegalCode.NextMatch();
            }
            if (_lstLegalCode.Count != 0)
                lgCode = string.Join(",", _lstLegalCode.ToArray());
            return lgCode;
        }


        /// <summary>
        /// Đếm số lần xuất hiện của một từ trong chuỗi.
        /// </summary>
        /// <param name="search">Chuỗi cần tìm trong nội dung</param>
        /// <param name="text">Chuỗi nội dung</param>
        /// <returns></returns>
        public static int CountWordsInString(string search, string text)
        {
            int wordCount = 0;
            string searchTerm = search;

            //Convert the string into an array of words  
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var matchQuery = from word in source
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                             select word;
            wordCount = matchQuery.Count();
            return wordCount;
        }
        /// <summary>
        /// Đếm số tag xuất hiện trong chuỗi.
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountTag(string regexTag, string text)
        {
            int wordCount = 0;
            if (!String.IsNullOrEmpty(text))
            {
                Regex rg = new Regex(regexTag, RegexOptions.Singleline);
                MatchCollection matches = rg.Matches(text);
                wordCount = matches.Count;
            }
            return wordCount;
        }


        /// <summary>
        /// Đếm số lượng ký tự không gồm khoảng trắng.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		public static long CountNonSpaceChars(string value)
        {
            long result = 0;
            foreach (char c in value)
            {
                if (!char.IsWhiteSpace(c))
                {
                    result++;
                }
            }
            return result;
        }
        /// <summary>
        /// Đếm số lượng từ.
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
		public static long WordCount(string strInput)
        {
            long intCount = 0;
            for (int i = 1; i < strInput.Length; i++)
            {
                if (char.IsWhiteSpace(strInput[i - 1]) == true)
                {
                    if (char.IsLetterOrDigit(strInput[i]) == true || char.IsPunctuation(strInput[i]))
                    {
                        intCount++;
                    }
                }
            }
            if (strInput.Length > 2)
            {
                intCount++;
            }
            return intCount;
        }
    }
}
