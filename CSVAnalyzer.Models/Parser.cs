using System;
using System.Collections.Generic;
using System.Text;

namespace CSVAnalyzer.Models
{
    public class Parser
    {
        // O(n) complexity
        public static string[] CustomParseColumnsFromLine(string line)
        {
            List<string> columns = new List<string>();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '"')
                {
                    for (int j = i + 1; j < line.Length; j++)
                    {
                        if (line[j] == '"' || j == line.Length - 1)
                        {
                            columns.Add(line.Substring(i, j - i + 1));
                            // Skip comma after ending "
                            i = j + 1;
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = i; j < line.Length; j++)
                    {
                        if (line[j] == ',' || j == line.Length - 1)
                        {
                            int strLen = j == line.Length - 1 ? j - i + 1 : j - i;
                            columns.Add(line.Substring(i, strLen));
                            i = j;
                            break;
                        }
                    }
                }
            }
            return columns.ToArray();
        }
    }
}
