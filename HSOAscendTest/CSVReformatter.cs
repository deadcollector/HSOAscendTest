using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSOAscendTest
{
    public class CSVReformatter
    {
        private const string PIPE = "|";
        private const string QUOTE = "\"";
        private const string COMMA = ",";
        private const string NEW_LINE = "\n";
        private const string RETURN = "\r";
        private const string RN = "\r\n";
        private const string COMMA_REPLACE = "[c]";
        private const string NEW_LINE_REPLACE = "[n]";
        private const string RETURN_REPLACE = "[r]";

        public static string PIPE1 => PIPE;

        public static string QUOTE1 => QUOTE;

        public static string COMMA1 => COMMA;

        public static string NEW_LINE1 => NEW_LINE;

        public static string RETURN1 => RETURN;

        public static string RN1 => RN;

        public static string COMMA_REPLACE1 => COMMA_REPLACE;

        public static string NEW_LINE_REPLACE1 => NEW_LINE_REPLACE;

        public static string RETURN_REPLACE1 => RETURN_REPLACE;

        public string ReformattedCSV{ get; set; }
        public CSVReformatter(string csv)
        {
            ParseCSV(csv);
        }

        private void ParseCSV(string csv)
        {
            var lines = MakeRecordsParsifiable(csv);
            if (lines != null)
            {
                ReformatData(lines);
            }
        }

        private string[] MakeRecordsParsifiable(string text)
        {
            string[] records;
            if (!string.IsNullOrEmpty(text))
            {
                string modifiedFileText = text.Replace(QUOTE1, PIPE1);

                bool isInsideQuotes = false;
                string currentChar = "";
                for (int i = 0; i < modifiedFileText.Length; i++)
                {
                    currentChar = modifiedFileText.Substring(i, 1);

                    if (currentChar == PIPE1 && !isInsideQuotes)
                    {
                        isInsideQuotes = true;
                    }
                    else if (currentChar == PIPE1 && isInsideQuotes)
                    {
                        isInsideQuotes = false;
                    }
                    else if (currentChar == COMMA1 && isInsideQuotes)
                    {
                        modifiedFileText = ReplaceTokens(modifiedFileText, i, COMMA_REPLACE1);
                    }
                    else if (currentChar == NEW_LINE1 && isInsideQuotes)
                    {
                        modifiedFileText = ReplaceTokens(modifiedFileText, i, NEW_LINE_REPLACE1);
                    }
                    else if (currentChar == RETURN1 && isInsideQuotes)
                    {
                        modifiedFileText = ReplaceTokens(modifiedFileText, i, RETURN_REPLACE1);
                    }

                }

                if (modifiedFileText.Contains(RN))
                {
                    records = modifiedFileText.Split(RN1);
                }
                else
                {
                    records = modifiedFileText.Split(NEW_LINE);
                }

                return records;
            }

            return null;
        }
        private string ReplaceTokens(string text, int i, string charType)
        {
            return text.Remove(i, 1).Insert(i, charType);
        }

        private void ReformatData(string[] lines)
        {
            var newLines = new List<string>();
            var fields = new List<string>();
            foreach (var line in lines)
            {
                fields = line.Split(COMMA1).ToList();

                var reformattedLine = new StringBuilder();
                foreach (var field in fields)
                {
                    reformattedLine.Append("[" + field.Replace(PIPE, "").Replace(COMMA_REPLACE, COMMA) + "] ");
                }

                ReformattedCSV += reformattedLine.ToString().Trim() + RN;
            }
        }
    }
}
