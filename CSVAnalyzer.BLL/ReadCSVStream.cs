using CSVAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSVAnalyzer.BLL
{
    public class ReadCSVStream
    {
        public static async Task ReadCSVAndPopulateListAndFrequency(CSVFile csvFile, List<DealerTrack> list, Dictionary<string, int> frequencyMap)
        {
            using (FileStream fileStream = new FileStream(csvFile.FilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding("iso-8859-1")))
                {
                    string headerLine = await reader.ReadLineAsync();
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] cols = Parser.CustomParseColumnsFromLine(line);

                        DealerTrack dealerTrack = new DealerTrack();
                        dealerTrack.DealNumber = Convert.ToInt32(cols[0]);
                        dealerTrack.CustomerName = cols[1];
                        dealerTrack.DealershipName = cols[2];
                        dealerTrack.Vehicle = cols[3];
                        dealerTrack.Price = cols[4];
                        dealerTrack.Date = cols[5];

                        // Add to frequency map to get the best car
                        if (frequencyMap.ContainsKey(dealerTrack.Vehicle))
                        {
                            frequencyMap[dealerTrack.Vehicle]++;
                        }
                        else
                        {
                            frequencyMap[dealerTrack.Vehicle] = 1;
                        }

                        list.Add(dealerTrack);
                    }
                }
            }
        }
    }
}
