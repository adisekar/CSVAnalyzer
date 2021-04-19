using CSVAnalyzer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVAnalyzer.ViewModels
{
    public class CsvFileDetailsVM
    {
        public IEnumerable<DealerTrack> DealerTrackList { get; set; }

        public string MostSoldVehicle { get; set; }
    }
}
