using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LawProject.Application.Utilities
{
    /// <summary>
    /// Dissection Legal document content to Part, Chapter, Item, Article
    /// </summary>
    public class DissectionLegalDocument
    {
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
        };
        // Chữ la mã tới số.
        public static int RomanToInteger(string roman)
        {
            roman = roman.Replace("C", "").Replace("D", "");
            int number = 0;
            char previousChar = roman[0];
            foreach (char currentChar in roman)
            {
                number += RomanMap[currentChar];
                if (RomanMap[previousChar] < RomanMap[currentChar])
                {
                    number -= RomanMap[previousChar] * 2;
                }
                previousChar = currentChar;
            }
            return number;
        }
        // Số tới chữ la mã.
        public static string roman(int number)
        {
            StringBuilder result = new StringBuilder();
            int[] digitsValues = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] romanDigits = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            while (number > 0)
            {
                for (int i = digitsValues.Count() - 1; i >= 0; i--)
                    if (number / digitsValues[i] >= 1)
                    {
                        number -= digitsValues[i];
                        result.Append(romanDigits[i]);
                        break;
                    }
            }
            return result.ToString();
        }
        // Số tới thứ.
        public static string ToChar(int number)
        {
            StringBuilder result = new StringBuilder();
            int[] digitsValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] romanDigits = { "thứ nhất", "thứ hai", "thứ ba", "thứ tư", "thứ năm", "thứ sáu", "thứ bảy", "thứ tám", "thứ chín", "thứ mười" };

            for (int i = 0; i < digitsValues.Count(); i++)
                if (number == digitsValues[i])
                {
                    result.Append(romanDigits[i]);
                    break;
                }
            return result.ToString();
        }
        public static string GetTextAtLine(string text, int lineNumber)
        {
            string result = "";
            text = text.Replace("<br />", "\n");
            text = Regex.Replace(text, @"<(.)*?>", "\n");
            string[] lines = text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            result = lines[lineNumber];
            return result;
        }

        public static string ReplaceTitle(string text, string[] keyWord)
        {
            string result = "";
            foreach (var item in keyWord)
            {
                if (!String.IsNullOrEmpty(text))
                    //if (text.ToLower().Contains(item.ToLower()))
                    if (text.Contains(item))
                        return result;
            }
            return text;
        }
        /// <summary>
        /// Convert File PDF to Object Data LegalDoc.
        /// new Regex("\\n(|[a-zA-Z0-9_ ]*)Phần " + numberPart + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Phần " + numberLastPart + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        /// (|[a-zA-Z0-9_ ]*) hoặc cho phép khoảng trắng trước Phần,Chương, Mục, Điều.
        /// _partContent.Groups[2].Value lấy group 2 nội dung, group 1 là whitespace
        /// </summary>
        /// <param name="filePDF">params link src pdf.</param>
        /// <returns>return List<Part></returns>
        public static List<Part> ConvertPDFToObject(string filePDF, string contentText)
        {
            var _partAll = new List<Part>();

            if (String.IsNullOrEmpty(contentText))
            {
                return _partAll;
            }
            try
            {
                bool isNumberChaptRoman = false;
                StringBuilder content = new StringBuilder();
                string contentTextAll = "";
                //if (!String.IsNullOrEmpty(filePDF))
                //{
                //    PdfReader reader = new PdfReader(filePDF);

                //    // Đọc từng trang trong Pdf.
                //    for (int i = 1; i <= reader.NumberOfPages; i++)
                //    {
                //        // Lấy toàn bộ ký tự của trang
                //        string textAll = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                //        string textReplace = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                //        content.Append(textReplace);
                //    }
                //    contentTextAll = content.ToString();
                //}
                //else
                //{
                //    contentTextAll = "x\n" + contentText;
                //}

                contentTextAll = "x\n" + contentText;
                contentTextAll = Regex.Replace(contentTextAll, @"PHẦN", "Phần");
                contentTextAll = Regex.Replace(contentTextAll, @"CHƯƠNG", "Chương");
                contentTextAll = Regex.Replace(contentTextAll, @"MỤC", "Mục");

                LegalDocument lgDoc = new LegalDocument();

                List<Part> lstObjPart = new List<Part>();
                List<Chapter> lstObjChapter = new List<Chapter>();
                List<Item> lstObjItem = new List<Item>();
                List<Article> lstObjArticle = new List<Article>();

                int lenghtParts = 1;
                int lengthChapters = 1;
                int lengthItems = 1;
                int lengthAriticles = 1;

                List<string> lstrgPartInContentAll = new List<string>();
                List<string> lstrgChapterInContentAll = new List<string>();
                List<string> lstrgItemInContentAll = new List<string>();
                List<string> lstrgArticleInContentAll = new List<string>();

                // Xét lấy danh sách mảng nội dung từ Phần tới Phần.
                for (int p = 1; p <= lenghtParts; p++)
                {
                    int pLast = p + 1;
                    // số tới số la mã
                    string pToRoman = roman(p);
                    string dLastToRoman = roman(pLast);
                    // số tới chữ
                    string pToChar = ToChar(p);
                    string pLastToChar = ToChar(pLast); ;

                    // to number
                    string numberPart = "0";
                    string numberLastPart = "0";

                    // xác định chữ cái số của Phần.
                    if (contentTextAll.Contains("Phần " + p.ToString()))
                    {
                        numberPart = p.ToString();
                        numberLastPart = (numberPart + 1).ToString();
                    }
                    if (contentTextAll.Contains("Phần " + pToRoman))
                    {
                        numberPart = pToRoman;
                        numberLastPart = dLastToRoman;
                    }
                    Regex rCPart = new Regex("Phần " + pToChar, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    Match _partChekContent = rCPart.Match(contentTextAll);
                    if (_partChekContent.Success)
                    {
                        numberPart = pToChar;
                        numberLastPart = pLastToChar;
                    }
                    if (numberPart != "0" && numberLastPart != "0")
                    {
                        Regex rPart = new Regex("\\n(|[a-zA-Z0-9_ ]*)Phần " + numberPart + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Phần " + numberLastPart + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        Match _partContent = rPart.Match(contentTextAll);
                        if (_partContent.Success)
                        {
                            lenghtParts++;
                            lstrgPartInContentAll.Add(_partContent.Groups[2].Value);
                        }
                        else
                        {
                            Regex rPartEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Phần " + numberPart + "(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                            Match _partEndContent = rPartEnd.Match(contentTextAll);
                            if (_partEndContent.Success)
                            {
                                lstrgPartInContentAll.Add(_partEndContent.Groups[2].Value);
                            }
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                }

                for (int c = 1; c <= lengthChapters; c++)
                {
                    int cLast = c + 1;
                    string cToRoman = roman(c);
                    string cLastToRoman = roman(cLast);

                    // to number
                    string numberChapt = "0"; ;
                    string numberLastChapt = "0"; ;

                    // xác định chữ cái số của Chương.
                    if (contentTextAll.Contains("Chương " + c.ToString()))
                    {
                        numberChapt = c.ToString();
                        numberLastChapt = cLast.ToString();
                        isNumberChaptRoman = false;
                    }
                    else if (contentTextAll.Contains("Chương " + cToRoman))
                    {
                        numberChapt = cToRoman;
                        numberLastChapt = cLastToRoman;

                        isNumberChaptRoman = true;
                    }

                    Regex rChapt = new Regex("\\n(|[a-zA-Z0-9_ ]*)Chương " + numberChapt + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Chương " + numberLastChapt + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    Match _chaptContent = rChapt.Match(contentTextAll);
                    if (_chaptContent.Success)
                    {
                        lengthChapters++;
                        lstrgChapterInContentAll.Add(_chaptContent.Groups[2].Value);
                    }
                    else
                    {
                        Regex rChaptEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Chương " + numberChapt + "(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        Match _chaptEndContent = rChaptEnd.Match(contentTextAll);
                        if (_chaptEndContent.Success)
                        {
                            lstrgChapterInContentAll.Add(_chaptEndContent.Groups[2].Value);
                        }
                        break;
                    }
                }

                for (int m = 1; m <= lengthItems; m++)
                {
                    int mLast = m + 1;

                    string mToRoman = roman(m);
                    string mLastToRoman = roman(mLast);

                    // to number
                    string numberItem = "0";
                    string numberLastItem = "0";

                    // xác định chữ cái số của Chương.
                    if (contentTextAll.Contains("Mục " + m.ToString()))
                    {
                        numberItem = m.ToString();
                        numberLastItem = mLast.ToString();
                    }
                    else if (contentTextAll.Contains("Mục " + mToRoman))
                    {
                        numberItem = mToRoman;
                        numberLastItem = mLastToRoman;
                    }


                    Regex rItem = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + numberItem + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Mục " + numberLastItem + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    Match _itemContent = rItem.Match(contentTextAll);
                    if (_itemContent.Success)
                    {
                        lengthItems++;
                        lstrgItemInContentAll.Add(_itemContent.Groups[2].Value);
                    }
                    else
                    {
                        Regex rItemEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + numberItem + "(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        Match _itemEndContent = rItemEnd.Match(contentTextAll);
                        if (_itemEndContent.Success)
                        {
                            lstrgItemInContentAll.Add(_itemEndContent.Groups[2].Value);
                        }
                        break;
                    }
                }

                for (int d = 1; d <= lengthAriticles; d++)
                {
                    int dLast = d + 1;
                    Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + d + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + "\\.", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    Match _articleContent = rArticle.Match(contentTextAll);
                    if (_articleContent.Success)
                    {
                        lengthAriticles++;
                        //lstrgArticleInContentAll.Add(_articleContent.ToString());
                        lstrgArticleInContentAll.Add(_articleContent.Groups[2].Value);
                    }
                    else
                    {
                        Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + d + "\\.(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        Match _articleEndContent = rArticleEnd.Match(contentTextAll);
                        if (_articleEndContent.Success)
                        {
                            //lstrgArticleInContentAll.Add(_articleEndContent.ToString());
                            lstrgArticleInContentAll.Add(_articleEndContent.Groups[2].Value);
                        }
                        break;
                    }
                }

                // Danh sách phần,chương,mục, điều theo theo toàn bộ nội dung
                var P = lstrgPartInContentAll;
                var C = lstrgChapterInContentAll;
                var M = lstrgItemInContentAll;
                var D = lstrgArticleInContentAll;

                int lengthChart1 = 0;
                int lengthItem1 = 0;
                int lengthAritcle1 = 0;

                List<string> lstrgChapter = new List<string>();
                List<string> lstrgItem = new List<string>();
                List<string> lstrgArticle = new List<string>();

                List<string> _lstContentToChapter = new List<string>(); // list chương lấy theo group 1 regex
                List<string> _lstContentToItem = new List<string>(); // list mục lấy theo group 1 regex
                List<string> _lstContentToArticle = new List<string>(); // list điều lấy theo group 1 regex


                // nếu Phần có trong (toàn bộ nội dung)
                if (lstrgPartInContentAll.Count != 0)
                {
                    lstObjPart = new List<Part>();
                    for (int p = 0; p <= lstrgPartInContentAll.Count; p++)
                    {
                        if (p + 1 > lstrgPartInContentAll.Count)
                        {
                            break;
                        }
                        Part part = new Part();
                        part.PartID = p + 1;
                        part.Title = GetTextAtLine(lstrgPartInContentAll[p], 0);// + GetTextAtLine(lstrgPartInContentAll[p], 1)
                        part.Idx = p + 1;

                        // Kiểm tra Chương trước nếu có
                        lengthChart1 = 0;
                        lstrgChapter.Clear();
                        // get chỉ số chuong có trước.
                        int getIndexChapt = 0;
                        if (_lstContentToChapter.Count != 0 && _lstContentToChapter.Last() != "")
                        {
                            string indexFirst = GetTextAtLine(_lstContentToChapter.Last().Substring(0, 13).Replace("Chương ", ""), 0);
                            if (!isNumberChaptRoman)
                            {
                                Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                getIndexChapt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                            }
                            else
                            {
                                Regex rIndexFirst = new Regex("M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})", RegexOptions.Singleline);
                                Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                if (_rIndexFirst.Success)
                                    getIndexChapt = RomanToInteger(_rIndexFirst.ToString());
                            }

                        }
                        else
                        {
                            getIndexChapt = 0;
                        }
                        int cFirst = getIndexChapt + 1;
                        int cLast = getIndexChapt + 2;

                        // Kiểm tra Chương theo Phần
                        for (int c = 0; c <= lengthChart1; c++)
                        {
                            // số tới số la mã
                            string cToRoman = roman(cFirst);
                            string cLastToRoman = roman(cLast);
                            if (!isNumberChaptRoman)
                            {
                                cToRoman = cFirst.ToString();
                                cLastToRoman = cLast.ToString();
                            }
                            Regex rChapt = new Regex("\\n(|[a-zA-Z0-9_ ]*)Chương " + cToRoman + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Chương " + cLastToRoman + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                            Match _chaptContent = rChapt.Match(lstrgPartInContentAll[p]);
                            if (_chaptContent.Success)
                            {
                                lengthChart1++;
                                cFirst++;
                                cLast++;
                                lstrgChapter.Add(_chaptContent.Groups[2].Value);
                                _lstContentToChapter.Add(_chaptContent.ToString());
                            }
                            else
                            {
                                Regex rChaptEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Chương " + cToRoman + "(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                Match _chaptEndContent = rChaptEnd.Match(lstrgPartInContentAll[p]);
                                if (_chaptEndContent.Success)
                                {
                                    lstrgChapter.Add(_chaptEndContent.Groups[2].Value);
                                    _lstContentToChapter.Add(_chaptEndContent.ToString());
                                    break;
                                }
                            }
                        }
                        ////////// nếu chương có trong phần voi toan bo noi dung /////
                        if (lstrgChapter.Count != 0)
                        {
                            lstObjChapter = new List<Chapter>();
                            for (int c = 0; c <= lstrgChapter.Count; c++)
                            {
                                if (c + 1 > lstrgChapter.Count)
                                {
                                    break;
                                }
                                Chapter chapt = new Chapter();
                                chapt.PartID = p + 1;
                                chapt.ChapID = c + 1;
                                chapt.Title = GetTextAtLine(lstrgChapter[c], 0) +
                                    (ReplaceTitle(GetTextAtLine(lstrgChapter[c], 1), new string[] { "Mục", "Điều" }) == "" ? "" : ("<br />" + GetTextAtLine(lstrgChapter[c], 1) +
                                    "<br />" + ReplaceTitle(GetTextAtLine(lstrgChapter[c], 2), new string[] { "Mục", "Điều" })));
                                chapt.Idx = c + 1;

                                // kiểm tra mục trong chương
                                lengthItem1 = 0;
                                lstrgItem.Clear();
                                // get chỉ số mục có trước.
                                int getIndexItem = 0;
                                //if (lstObjItem.Count != 0 && lstObjItem.Last().Title != "")
                                //{                                    
                                //string indexFirst = lstObjItem.Last().Title.Substring(0, 14);
                                //Regex rIndexFirst = new Regex("(\\d+)", RegexOptions.Singleline);
                                //Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                //getIndexItem = Int32.Parse(_rIndexFirst.ToString().Replace(".", string.Empty));                                   
                                //}
                                //else
                                //{
                                //getIndexItem = 0;
                                //}
                                int mFirst = getIndexItem + 1;
                                int mLast = getIndexItem + 2;

                                // kiểm tra mục trong chương
                                for (int m = 0; m <= lengthItem1; m++)
                                {
                                    Regex rItem = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + mFirst + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Mục " + mLast + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                    Match _itemContent = rItem.Match(lstrgChapter[c]);
                                    if (_itemContent.Success)
                                    {
                                        lengthItem1++;
                                        mFirst++;
                                        mLast++;
                                        lstrgItem.Add(_itemContent.Groups[2].Value);
                                    }
                                    else
                                    {
                                        Regex rItemEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + mFirst + "(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                        Match _itemEndContent = rItemEnd.Match(lstrgChapter[c]);
                                        if (_itemEndContent.Success)
                                        {
                                            lstrgItem.Add(_itemEndContent.Groups[2].Value);
                                            break;
                                        }
                                    }
                                }
                                // nếu mục có trong chương
                                if (lstrgItem.Count != 0)
                                {
                                    lstObjItem = new List<Item>();
                                    for (int m = 0; m <= lstrgItem.Count; m++)
                                    {
                                        if (m + 1 > lstrgItem.Count)
                                        {
                                            break;
                                        }
                                        Item item = new Item();
                                        item.ItemID = m + 1;
                                        item.ChapID = c + 1;
                                        item.Idx = m + 1;
                                        item.Title = GetTextAtLine(lstrgItem[m], 0) +
                                                    (ReplaceTitle(GetTextAtLine(lstrgItem[m], 1), new string[] { "Điều" }) == "" ? "" : ("<br />" + GetTextAtLine(lstrgItem[m], 1) +
                                                    "<br />" + ReplaceTitle(GetTextAtLine(lstrgItem[m], 2), new string[] { "Điều" })));

                                        // new lai list chua dieu` moi khi xet muc co --- remove lai dlist dieu cu theo muc truoc.
                                        lstrgArticle.Clear();
                                        // set lai length khi muc truoc da co'.
                                        lengthAritcle1 = 0;
                                        // get chỉ số điều có trước.
                                        int getIndexArt = 0;
                                        if (_lstContentToArticle.Count != 0 && _lstContentToArticle.Last() != "")
                                        {
                                            string indexFirst = _lstContentToArticle.Last().Substring(0, 16);
                                            Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                            Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                            Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                            Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                            getIndexArt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                                        }
                                        else
                                        {
                                            getIndexArt = 0;
                                        }
                                        int dFirst = getIndexArt + 1;
                                        int dLast = getIndexArt + 2;

                                        // kiểm tra lấy điều trong mục
                                        for (int d = 0; d <= lengthAritcle1; d++)
                                        {
                                            //lstrgItem[m] = lstrgItem[m].Replace("Điều " + dFirst + "", "Điều " + dFirst + ".");
                                            //lstrgItem[m] = lstrgItem[m].Replace("Điều " + dLast + "", "Điều " + dLast + ".");
                                            Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + "\\.", RegexOptions.Singleline);
                                            Match _articleContent = rArticle.Match(lstrgItem[m]);
                                            if (_articleContent.Success)
                                            {
                                                lengthAritcle1++;
                                                dFirst++;
                                                dLast++;
                                                lstrgArticle.Add(_articleContent.Groups[2].Value);
                                                _lstContentToArticle.Add(_articleContent.ToString());
                                            }
                                            else
                                            {
                                                Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.*)", RegexOptions.Singleline);
                                                Match _articleEndContent = rArticleEnd.Match(lstrgItem[m]);
                                                if (_articleEndContent.Success)
                                                {
                                                    lstrgArticle.Add(_articleEndContent.Groups[2].Value);
                                                    _lstContentToArticle.Add(_articleEndContent.ToString());
                                                    break;
                                                }
                                            }
                                        }
                                        // niếu điều có trong mục 
                                        if (lstrgArticle.Count != 0)
                                        {
                                            lstObjArticle = new List<Article>();
                                            for (int d = 0; d < lstrgArticle.Count; d++)
                                            {
                                                Article article = new Article();
                                                article.ArticleID = d + 1;
                                                //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                                //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticle[d], 0).Substring(0, 16));
                                                article.Title = GetTextAtLine(lstrgArticle[d], 0);
                                                article.ItemID = m + 1;
                                                article.Idx = d + 1;
                                                article.Contents = lstrgArticle[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                                article.Contents = article.Contents.Remove(0, 6) + "<br />";
                                                lstObjArticle.Add(article);
                                            }
                                        }
                                        item.Articles = lstObjArticle;
                                        lstObjItem.Add(item);
                                    }
                                }
                                else // mục không có trong chương
                                {
                                    lstObjItem = new List<Item>();
                                    Item item = new Item();
                                    item.ItemID = 1;
                                    item.ChapID = c + 1;
                                    item.Idx = 1;
                                    item.Title = "";
                                    // new lai list chua dieu` moi khi xet muc co --- remove lai dlist dieu cu theo muc truoc.
                                    lstrgArticle.Clear();
                                    // set lai length khi muc truoc da co'.
                                    lengthAritcle1 = 0;
                                    // get chỉ số điều có trước.
                                    int getIndexArt = 0;
                                    if (_lstContentToArticle.Count != 0 && _lstContentToArticle.Last() != "")
                                    {
                                        string indexFirst = _lstContentToArticle.Last().Substring(0, 16);
                                        Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                        Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                        Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                        Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                        getIndexArt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                                    }
                                    else
                                    {
                                        getIndexArt = 0;
                                    }
                                    int dFirst = getIndexArt + 1;
                                    int dLast = getIndexArt + 2;
                                    // kiem tra dieu trong chuong
                                    for (int d = 0; d <= lengthAritcle1; d++)
                                    {
                                        //lstrgChapter[c] = lstrgChapter[c].Replace("Điều " + dFirst + "", "Điều " + dFirst + ".");
                                        //lstrgChapter[c] = lstrgChapter[c].Replace("Điều " + dLast + "", "Điều " + dLast + ".");
                                        Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + "\\.", RegexOptions.Singleline);
                                        Match _articleContent = rArticle.Match(lstrgChapter[c]);
                                        if (_articleContent.Success)
                                        {
                                            lengthAritcle1++;
                                            dFirst++;
                                            dLast++;
                                            lstrgArticle.Add(_articleContent.Groups[2].Value);
                                            _lstContentToArticle.Add(_articleContent.ToString());
                                        }
                                        else
                                        {
                                            Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.*)", RegexOptions.Singleline);
                                            Match _articleEndContent = rArticleEnd.Match(lstrgChapter[c]);
                                            if (_articleEndContent.Success)
                                            {
                                                lstrgArticle.Add(_articleEndContent.Groups[2].Value);
                                                _lstContentToArticle.Add(_articleEndContent.ToString());
                                                break;
                                            }
                                        }
                                    }
                                    // niếu điều có trong chuong 
                                    if (lstrgArticle.Count != 0)
                                    {
                                        lstObjArticle = new List<Article>();
                                        for (int d = 0; d < lstrgArticle.Count; d++)
                                        {
                                            Article article = new Article();
                                            article.ArticleID = d + 1;
                                            //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                            //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticle[d], 0).Substring(0, 16));
                                            article.Title = GetTextAtLine(lstrgArticle[d], 0);
                                            article.ItemID = 1;
                                            article.Idx = d + 1;
                                            article.Contents = lstrgArticle[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                            if (!String.IsNullOrEmpty(article.Contents))
                                                article.Contents = article.Contents.Remove(0, 6) + "<br />";
                                            lstObjArticle.Add(article);
                                        }
                                    }
                                    item.Articles = lstObjArticle;
                                    lstObjItem.Add(item);
                                }
                                chapt.Items = lstObjItem;
                                lstObjChapter.Add(chapt);
                            }
                        }
                        // Chuong khong co trong phan , xet muc trong phan`
                        else
                        {
                            lstObjChapter = new List<Chapter>();
                            Chapter chapt = new Chapter();
                            chapt.PartID = p + 1;
                            chapt.ChapID = 1;
                            chapt.Title = "";
                            chapt.Idx = 1;

                            // kiểm tra mục trong phần

                            lengthItem1 = 0;
                            lstrgItem.Clear();
                            // get chỉ số mục có trước.
                            int getIndexItem = 0;
                            //if (lstObjItem.Count != 0 && lstObjItem.Last().Title != "")
                            //{
                            //    string indexFirst = lstObjItem.Last().Title.Substring(0, 14);
                            //    Regex rIndexFirst = new Regex("(\\d+)", RegexOptions.Singleline);
                            //    Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                            //    getIndexItem = Int32.Parse(_rIndexFirst.ToString().Replace(".", string.Empty));

                            //}
                            //else
                            //{
                            //    getIndexItem = 0;
                            //}
                            int mFirst = getIndexItem + 1;
                            int mLast = getIndexItem + 2;

                            // kiem tra muc trong pha`n
                            for (int m = 0; m <= lengthItem1; m++)
                            {
                                Regex rItem = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + mFirst + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Mục " + mLast + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                Match _itemContent = rItem.Match(lstrgPartInContentAll[p]);
                                if (_itemContent.Success)
                                {
                                    lengthItem1++;
                                    mFirst++;
                                    mLast++;
                                    lstrgItem.Add(_itemContent.Groups[2].Value);
                                }
                                else
                                {
                                    Regex rItemEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + mFirst + "(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                    Match _itemEndContent = rItemEnd.Match(lstrgPartInContentAll[p]);
                                    if (_itemEndContent.Success)
                                    {
                                        lstrgItem.Add(_itemEndContent.Groups[2].Value);
                                        break;
                                    }
                                }
                            }
                            if (lstrgItem.Count != 0) // neu muc co trong phan voi toan bo noi dung
                            {
                                lstObjItem = new List<Item>();
                                for (int m = 0; m <= lstrgItem.Count; m++)
                                {
                                    if (m + 1 > lstrgItem.Count)
                                    {
                                        break;
                                    }
                                    Item item = new Item();
                                    item.ItemID = m + 1;
                                    item.ChapID = 1;
                                    item.Idx = m + 1;
                                    item.Title = GetTextAtLine(lstrgItem[m], 0) +
                                                    (ReplaceTitle(GetTextAtLine(lstrgItem[m], 1), new string[] { "Điều" }) == "" ? "" : ("<br />" + GetTextAtLine(lstrgItem[m], 1) +
                                                    "<br />" + ReplaceTitle(GetTextAtLine(lstrgItem[m], 2), new string[] { "Điều" })));
                                    // new lai list chua dieu` moi khi xet muc co --- remove lai dlist dieu cu theo muc truoc.
                                    lstrgArticle.Clear();
                                    // set lai length khi muc truoc da co'.
                                    lengthAritcle1 = 0;
                                    // get chỉ số điều có trước.
                                    int getIndexArt = 0;
                                    if (_lstContentToArticle.Count != 0 && _lstContentToArticle.Last() != "")
                                    {
                                        string indexFirst = _lstContentToArticle.Last().Substring(0, 16);
                                        Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                        Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                        Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                        Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                        getIndexArt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                                    }
                                    else
                                    {
                                        getIndexArt = 0;
                                    }
                                    int dFirst = getIndexArt + 1;
                                    int dLast = getIndexArt + 2;
                                    // kiểm tra lấy điều trong mục
                                    for (int d = 0; d <= lengthAritcle1; d++)
                                    {
                                        //lstrgItem[m] = lstrgItem[m].Replace("Điều " + dFirst + "", "Điều " + dFirst + ".");
                                        //lstrgItem[m] = lstrgItem[m].Replace("Điều " + dLast + "", "Điều " + dLast + ".");
                                        Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + "\\.", RegexOptions.Singleline);
                                        Match _articleContent = rArticle.Match(lstrgItem[m]);
                                        if (_articleContent.Success)
                                        {
                                            lengthAritcle1++;
                                            dFirst++;
                                            dLast++;
                                            lstrgArticle.Add(_articleContent.Groups[2].Value);
                                            _lstContentToArticle.Add(_articleContent.ToString());

                                        }
                                        else
                                        {
                                            Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.*)", RegexOptions.Singleline);
                                            Match _articleEndContent = rArticleEnd.Match(lstrgItem[m]);
                                            if (_articleEndContent.Success)
                                            {
                                                lstrgArticle.Add(_articleEndContent.Groups[2].Value);
                                                _lstContentToArticle.Add(_articleEndContent.ToString());
                                                break;
                                            }
                                        }
                                    }
                                    // niếu điều có trong mục 
                                    if (lstrgArticle.Count != 0)
                                    {
                                        lstObjArticle = new List<Article>();
                                        for (int d = 0; d < lstrgArticle.Count; d++)
                                        {
                                            Article article = new Article();
                                            article.ArticleID = d + 1;
                                            //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                            //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticle[d], 0).Substring(0, 16));
                                            article.Title = GetTextAtLine(lstrgArticle[d], 0);
                                            article.ItemID = m + 1;
                                            article.Idx = d + 1;
                                            article.Contents = lstrgArticle[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                            if (!String.IsNullOrEmpty(article.Contents))
                                                article.Contents = article.Contents.Remove(0, 6) + "<br />";

                                            lstObjArticle.Add(article);
                                        }
                                    }
                                    item.Articles = lstObjArticle;
                                    lstObjItem.Add(item);
                                }
                            }
                            else // muc khong co trong phan` voi toan bo noi dung
                            {
                                lstObjItem = new List<Item>();
                                Item item = new Item();
                                item.ItemID = 1;
                                item.ChapID = 1;
                                item.Idx = 1;
                                item.Title = "";
                                // new lai list chua dieu` moi khi xet muc co --- remove lai dlist dieu cu theo muc truoc.
                                lstrgArticle.Clear();
                                // set lai length khi muc truoc da co'.
                                lengthAritcle1 = 0;
                                // get chỉ số điều có trước.
                                int getIndexArt = 0;
                                if (_lstContentToArticle.Count != 0 && _lstContentToArticle.Last() != "")
                                {
                                    string indexFirst = _lstContentToArticle.Last().Substring(0, 16);
                                    Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                    Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                    Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                    Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                    getIndexArt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                                }
                                else
                                {
                                    getIndexArt = 0;
                                }
                                int dFirst = getIndexArt + 1;
                                int dLast = getIndexArt + 2;
                                // kiem tra dieu trong phan`
                                for (int d = 0; d <= lengthAritcle1; d++)
                                {
                                    //lstrgPartInContentAll[p] = lstrgPartInContentAll[p].Replace("Điều " + dFirst + "", "Điều " + dFirst + ".");
                                    //lstrgPartInContentAll[p] = lstrgPartInContentAll[p].Replace("Điều " + dLast + "", "Điều " + dLast + ".");
                                    Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + ".", RegexOptions.Singleline);
                                    Match _articleContent = rArticle.Match(lstrgPartInContentAll[p]);
                                    if (_articleContent.Success)
                                    {
                                        lengthAritcle1++;
                                        dFirst++;
                                        dLast++;
                                        lstrgArticle.Add(_articleContent.Groups[2].Value);
                                        _lstContentToArticle.Add(_articleContent.ToString());
                                    }
                                    else
                                    {
                                        Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.*)", RegexOptions.Singleline);
                                        Match _articleEndContent = rArticleEnd.Match(lstrgPartInContentAll[p]);
                                        if (_articleEndContent.Success)
                                        {
                                            lstrgArticle.Add(_articleEndContent.Groups[2].Value);
                                            _lstContentToArticle.Add(_articleEndContent.ToString());
                                            break;
                                        }
                                    }
                                }
                                // niếu điều có trong phan` 
                                if (lstrgArticle.Count != 0)
                                {
                                    lstObjArticle = new List<Article>();
                                    for (int d = 0; d < lstrgArticle.Count; d++)
                                    {
                                        Article article = new Article();
                                        article.ArticleID = d + 1;
                                        //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                        //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticle[d], 0).Substring(0, 16));
                                        article.Title = GetTextAtLine(lstrgArticle[d], 0);
                                        article.ItemID = 1;
                                        article.Idx = d + 1;
                                        article.Contents = lstrgArticle[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                        if (!String.IsNullOrEmpty(article.Contents))
                                            article.Contents = article.Contents.Remove(0, 6) + "<br />";

                                        lstObjArticle.Add(article);
                                    }
                                }
                                item.Articles = lstObjArticle;
                                lstObjItem.Add(item);
                            }
                            chapt.Items = lstObjItem;
                            lstObjChapter.Add(chapt);
                        }
                        part.Chapters = lstObjChapter;
                        lstObjPart.Add(part);
                    }
                } // end xu ly phan`khi co theo toan bo noi dung
                else
                {
                    // khong co phan
                    // xet lay chuong theo toan bo noi dung
                    Part part = new Part();
                    part.PartID = 1;
                    part.Title = "";
                    part.Idx = 1;
                    // neu chuong co trong toan bo noi dung
                    if (lstrgChapterInContentAll.Count != 0)
                    {
                        lstObjChapter = new List<Chapter>();
                        for (int c = 0; c <= lstrgChapterInContentAll.Count; c++)
                        {
                            if (c + 1 > lstrgChapterInContentAll.Count)
                            {
                                break;
                            }
                            Chapter chapt = new Chapter();
                            chapt.PartID = 1;
                            chapt.ChapID = c + 1;
                            chapt.Title = GetTextAtLine(lstrgChapterInContentAll[c], 0) +
                                    (ReplaceTitle(GetTextAtLine(lstrgChapterInContentAll[c], 1), new string[] { "Mục", "Điều" }) == "" ? "" : ("<br />" + GetTextAtLine(lstrgChapterInContentAll[c], 1) +
                                    "<br />" + ReplaceTitle(GetTextAtLine(lstrgChapterInContentAll[c], 2), new string[] { "Mục", "Điều" })));
                            chapt.Idx = c + 1;
                            // kiểm tra mục trong chương
                            lengthItem1 = 0;
                            lstrgItem.Clear();
                            // get chỉ số mục có trước.
                            int getIndexItem = 0;
                            //if (lstObjItem.Count != 0 && lstObjItem.Last().Title != "")
                            //{
                            //    string indexFirst = lstObjItem.Last().Title.Substring(0, 14);
                            //    Regex rIndexFirst = new Regex("(\\d+)", RegexOptions.Singleline);
                            //    Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                            //    getIndexItem = Int32.Parse(_rIndexFirst.ToString().Replace(".", string.Empty));
                            //}
                            //else
                            //{
                            //    getIndexItem = 0;
                            //}
                            int mFirst = getIndexItem + 1;
                            int mLast = getIndexItem + 2;
                            for (int m = 0; m <= lengthItem1; m++)
                            {
                                Regex rItem = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + mFirst + "(.+?)\\n(|[a-zA-Z0-9_ ]*)Mục " + mLast + "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                Match _itemContent = rItem.Match(lstrgChapterInContentAll[c]);
                                if (_itemContent.Success)
                                {
                                    lengthItem1++;
                                    mFirst++;
                                    mLast++;
                                    lstrgItem.Add(_itemContent.Groups[2].Value);
                                }
                                else
                                {
                                    Regex rItemEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Mục " + mFirst + "(.*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                    Match _itemEndContent = rItemEnd.Match(lstrgChapterInContentAll[c]);
                                    if (_itemEndContent.Success)
                                    {
                                        lstrgItem.Add(_itemEndContent.Groups[2].Value);
                                        break;
                                    }
                                }
                            }
                            // neu muc co trong chuong
                            if (lstrgItem.Count != 0)
                            {
                                ////////////////////////////////////////////////// xet truong hop <= boi vi no = nen tang len 1 index -> error 
                                lstObjItem = new List<Item>();
                                for (int m = 0; m <= lstrgItem.Count; m++)
                                {
                                    if (m + 1 > lstrgItem.Count)
                                    {
                                        break;
                                    }
                                    Item item = new Item();
                                    item.ItemID = m + 1;
                                    item.ChapID = c + 1;
                                    item.Idx = m + 1;
                                    item.Title = GetTextAtLine(lstrgItem[m], 0) +
                                    (ReplaceTitle(GetTextAtLine(lstrgItem[m], 1), new string[] { "Điều" }) == "" ? "" : ("<br />" + GetTextAtLine(lstrgItem[m], 1) +
                                    "<br />" + ReplaceTitle(GetTextAtLine(lstrgItem[m], 2), new string[] { "Điều" })));
                                    // new lai list chua dieu` moi khi xet muc co --- remove lai dlist dieu cu theo muc truoc.
                                    lstrgArticle.Clear();
                                    // set lai length khi muc truoc da co'.
                                    lengthAritcle1 = 0;
                                    // get chỉ số điều có trước.
                                    int getIndexArt = 0;
                                    if (_lstContentToArticle.Count != 0 && _lstContentToArticle.Last() != "")
                                    {
                                        string indexFirst = _lstContentToArticle.Last().Substring(0, 16);
                                        Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                        Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                        Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                        Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                        getIndexArt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                                    }
                                    else
                                    {
                                        getIndexArt = 0;
                                    }
                                    int dFirst = getIndexArt + 1;
                                    int dLast = getIndexArt + 2;
                                    // kiểm tra lấy điều trong mục
                                    for (int d = 0; d <= lengthAritcle1; d++)
                                    {
                                        //lstrgItem[m] = lstrgItem[m].Replace("Điều " + dFirst + "", "Điều " + dFirst + ".");
                                        //lstrgItem[m] = lstrgItem[m].Replace("Điều " + dLast + "", "Điều " + dLast + ".");
                                        Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + "\\.", RegexOptions.Singleline);
                                        Match _articleContent = rArticle.Match(lstrgItem[m]);
                                        if (_articleContent.Success)
                                        {
                                            lengthAritcle1++;
                                            dFirst++;
                                            dLast++;
                                            lstrgArticle.Add(_articleContent.Groups[2].Value);
                                            _lstContentToArticle.Add(_articleContent.ToString());
                                        }
                                        else
                                        {
                                            Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.*)", RegexOptions.Singleline);
                                            Match _articleEndContent = rArticleEnd.Match(lstrgItem[m]);
                                            if (_articleEndContent.Success)
                                            {
                                                lstrgArticle.Add(_articleEndContent.Groups[2].Value);
                                                _lstContentToArticle.Add(_articleEndContent.ToString());
                                                break;
                                            }
                                        }
                                    }
                                    // niếu điều có trong mục theo index
                                    if (lstrgArticle.Count != 0)
                                    {
                                        lstObjArticle = new List<Article>();
                                        for (int d = 0; d < lstrgArticle.Count; d++)
                                        {
                                            Article article = new Article();
                                            article.ArticleID = d + 1;
                                            //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                            //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticle[d], 0).Substring(0, 16));
                                            article.Title = GetTextAtLine(lstrgArticle[d], 0);
                                            article.ItemID = m + 1;
                                            article.Idx = d + 1;
                                            article.Contents = lstrgArticle[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                            if (!String.IsNullOrEmpty(article.Contents))
                                                article.Contents = article.Contents.Remove(0, 6) + "<br />";
                                            lstObjArticle.Add(article);
                                        }
                                    }
                                    item.Articles = lstObjArticle;
                                    lstObjItem.Add(item);
                                }
                            }
                            else // neu muc khong co trong chuong
                            {
                                lstObjItem = new List<Item>();
                                // xet ID, phai xet th muc o chuong dau k , chuong sau co, chuong sau co nua
                                Item item = new Item();
                                item.ItemID = 1;
                                item.ChapID = c + 1;
                                item.Idx = 1;
                                item.Title = "";
                                // new lai list chua dieu` moi khi xet muc co --- remove lai dlist dieu cu theo muc truoc.
                                lstrgArticle.Clear();
                                // set lai length khi muc truoc da co'.
                                lengthAritcle1 = 0;
                                // get chỉ số điều có trước.
                                int getIndexArt = 0;
                                if (_lstContentToArticle.Count != 0 && _lstContentToArticle.Last() != "")
                                {
                                    string indexFirst = _lstContentToArticle.Last().Substring(0, 16);
                                    Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                    Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                    Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                    Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                    getIndexArt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                                }
                                else
                                {
                                    getIndexArt = 0;
                                }
                                int dFirst = getIndexArt + 1;
                                int dLast = getIndexArt + 2;
                                // kiem tra lay dieu trong chuong
                                for (int d = 0; d <= lengthAritcle1; d++)
                                {
                                    //lstrgChapterInContentAll[c] = lstrgChapterInContentAll[c].Replace("Điều " + dFirst + "", "Điều " + dFirst + ".");
                                    //lstrgChapterInContentAll[c] = lstrgChapterInContentAll[c].Replace("Điều " + dLast + "", "Điều " + dLast + ".");
                                    Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + "\\.", RegexOptions.Singleline);
                                    Match _articleContent = rArticle.Match(lstrgChapterInContentAll[c]);
                                    if (_articleContent.Success)
                                    {
                                        lengthAritcle1++;
                                        dFirst++;
                                        dLast++;
                                        lstrgArticle.Add(_articleContent.Groups[2].Value);
                                        _lstContentToArticle.Add(_articleContent.ToString());
                                    }
                                    else
                                    {
                                        Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.*)", RegexOptions.Singleline);
                                        Match _articleEndContent = rArticleEnd.Match(lstrgChapterInContentAll[c]);
                                        if (_articleEndContent.Success)
                                        {
                                            lstrgArticle.Add(_articleEndContent.Groups[2].Value);
                                            _lstContentToArticle.Add(_articleEndContent.ToString());
                                            break;
                                        }
                                    }
                                }
                                // niếu điều có trong chuong 
                                if (lstrgArticle.Count != 0)
                                {
                                    lstObjArticle = new List<Article>();
                                    for (int d = 0; d < lstrgArticle.Count; d++)
                                    {
                                        Article article = new Article();
                                        article.ArticleID = d + 1;
                                        //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                        //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticle[d], 0).Substring(0, 16));
                                        article.Title = GetTextAtLine(lstrgArticle[d], 0);
                                        article.ItemID = 1;
                                        article.Idx = d + 1;
                                        article.Contents = lstrgArticle[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                        if (!String.IsNullOrEmpty(article.Contents))
                                            article.Contents = article.Contents.Remove(0, 6) + "<br />";
                                        lstObjArticle.Add(article);
                                    }
                                }
                                item.Articles = lstObjArticle;
                                lstObjItem.Add(item);
                            }
                            chapt.Items = lstObjItem;
                            lstObjChapter.Add(chapt);
                        }
                    }
                    else // chuong khong co trong toan bo noi dung
                    {
                        lstObjChapter = new List<Chapter>();
                        Chapter chapt = new Chapter();
                        chapt.PartID = 1;
                        chapt.ChapID = 1;
                        chapt.Title = "";
                        chapt.Idx = 1;
                        // xet muc trong toan bo noi dung, neu muc co trong toan bo noi dung.
                        if (lstrgItemInContentAll.Count != 0)
                        {
                            lstObjItem = new List<Item>();
                            for (int m = 0; m <= lstrgItemInContentAll.Count; m++)
                            {
                                if (m + 1 > lstrgItemInContentAll.Count)
                                {
                                    break;
                                }
                                Item item = new Item();
                                item.ItemID = m + 1;
                                item.ChapID = 1;
                                item.Idx = m + 1;
                                item.Title = GetTextAtLine(lstrgItemInContentAll[m], 0) +
                                    (ReplaceTitle(GetTextAtLine(lstrgItemInContentAll[m], 1), new string[] { "Điều" }) == "" ? "" : ("<br />" + GetTextAtLine(lstrgItemInContentAll[m], 1) +
                                    "<br />" + ReplaceTitle(GetTextAtLine(lstrgItemInContentAll[m], 2), new string[] { "Điều" })));

                                // new lai list chua dieu` moi khi xet muc co --- remove lai dlist dieu cu theo muc truoc.
                                lstrgArticle.Clear();
                                // set lai length khi muc truoc da co'.
                                lengthAritcle1 = 0;
                                // get chỉ số điều có trước.
                                int getIndexArt = 0;
                                if (_lstContentToArticle.Count != 0 && _lstContentToArticle.Last() != "")
                                {
                                    string indexFirst = _lstContentToArticle.Last().Substring(0, 16);
                                    Regex rIndexFirst = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                    Match _rIndexFirst = rIndexFirst.Match(indexFirst);
                                    Regex rIndexFirst1 = new Regex("(^\\d+)\\.", RegexOptions.Singleline);
                                    Match _rIndexFirst1 = rIndexFirst1.Match(_rIndexFirst.ToString());
                                    getIndexArt = Int32.Parse(_rIndexFirst1.ToString().Replace(".", string.Empty));
                                }
                                else
                                {
                                    getIndexArt = 0;
                                }
                                int dFirst = getIndexArt + 1;
                                int dLast = getIndexArt + 2;
                                // kiểm tra lấy điều trong mục
                                for (int d = 0; d <= lengthAritcle1; d++)
                                {
                                    //lstrgItemInContentAll[m] = lstrgItemInContentAll[m].Replace("Điều " + dFirst + "", "Điều " + dFirst + ".");
                                    //lstrgItemInContentAll[m] = lstrgItemInContentAll[m].Replace("Điều " + dLast + "", "Điều " + dLast + ".");
                                    Regex rArticle = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.+?)\\n(|[a-zA-Z0-9_ ]*)Điều " + dLast + "\\.", RegexOptions.Singleline);
                                    Match _articleContent = rArticle.Match(lstrgItemInContentAll[m]);
                                    if (_articleContent.Success)
                                    {
                                        lengthAritcle1++;
                                        dFirst++;
                                        dLast++;
                                        lstrgArticle.Add(_articleContent.Groups[2].Value);
                                        _lstContentToArticle.Add(_articleContent.ToString());
                                    }
                                    else
                                    {
                                        Regex rArticleEnd = new Regex("\\n(|[a-zA-Z0-9_ ]*)Điều " + dFirst + "\\.(.*)", RegexOptions.Singleline);
                                        Match _articleEndContent = rArticleEnd.Match(lstrgItemInContentAll[m]);
                                        if (_articleEndContent.Success)
                                        {
                                            lstrgArticle.Add(_articleEndContent.Groups[2].Value);
                                            _lstContentToArticle.Add(_articleEndContent.ToString());
                                            break;
                                        }
                                    }
                                }
                                // niếu điều có trong mục 
                                if (lstrgArticle.Count != 0)
                                {
                                    lstObjArticle = new List<Article>();
                                    for (int d = 0; d < lstrgArticle.Count; d++)
                                    {
                                        Article article = new Article();
                                        article.ArticleID = d + 1;
                                        //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                        //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticle[d], 0).Substring(0, 16));
                                        article.Title = GetTextAtLine(lstrgArticle[d], 0);
                                        article.ItemID = m + 1;
                                        article.Idx = d + 1;
                                        article.Contents = lstrgArticle[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                        if (!String.IsNullOrEmpty(article.Contents))
                                            article.Contents = article.Contents.Remove(0, 6) + "<br />";
                                        lstObjArticle.Add(article);
                                    }
                                }
                                item.Articles = lstObjArticle;
                                lstObjItem.Add(item);
                            }
                        }
                        else // muc khong co trong toan bo noi dung
                        {
                            lstObjItem = new List<Item>();
                            Item item = new Item();
                            item.ItemID = 1;
                            item.ChapID = 1;
                            item.Idx = 1;
                            item.Title = "";
                            // xet lay dieu trong toan bo noi dung
                            if (lstrgArticleInContentAll.Count != 0)
                            {
                                lstObjArticle = new List<Article>();
                                for (int d = 0; d <= lstrgArticleInContentAll.Count; d++)
                                {
                                    if (d + 1 > lstrgArticleInContentAll.Count)
                                    {
                                        break;
                                    }
                                    Article article = new Article();
                                    article.ArticleID = d + 1;
                                    //Regex dNumber = new Regex("(\\d+)\\.", RegexOptions.Singleline);
                                    //Match _dNumber = dNumber.Match(GetTextAtLine(lstrgArticleInContentAll[d], 0).Substring(0, 16));
                                    article.Title = GetTextAtLine(lstrgArticleInContentAll[d], 0);
                                    article.ItemID = 1;
                                    article.Idx = d + 1;
                                    article.Contents = lstrgArticleInContentAll[d].Remove(0, article.Title.Length).Replace("\n", "<br />");//.Replace(GetTextAtLine(lstrgArticle[d], 0), "")
                                    if (!String.IsNullOrEmpty(article.Contents))
                                        article.Contents = article.Contents.Remove(0, 6) + "<br />";
                                    lstObjArticle.Add(article);
                                }
                            }
                            item.Articles = lstObjArticle;
                            lstObjItem.Add(item);
                        }
                        chapt.Items = lstObjItem;
                        lstObjChapter.Add(chapt);
                    }
                    part.Chapters = lstObjChapter;
                    lstObjPart.Add(part);
                }
                _partAll = lstObjPart;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
            }
            return _partAll;
        }
    }
}
