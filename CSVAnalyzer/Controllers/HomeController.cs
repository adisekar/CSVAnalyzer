using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSVAnalyzer.Models;
using CSVAnalyzer.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using CSVAnalyzer.BLL;
using CSVAnalyzer.BLL.Managers;

namespace CSVAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICsvService _csvService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ICsvService csvService, IHostingEnvironment hostingEnvironment)
        {
            _csvService = csvService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            ICollection<CSVFile> csvFiles = _csvService.GetAllCsvFiles();
            return View(csvFiles);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(CSVUploadVM model)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                string fileName = null;
                if (model.CsvFile != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "data");
                    fileName = model.CsvFile.FileName;
                    filePath = Path.Combine(uploadsFolder, model.CsvFile.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.CsvFile.CopyToAsync(fileStream);
                    }
                }

                CSVFile csvFile = new CSVFile
                {
                    FilePath = filePath,
                    FileName = fileName
                };
                _csvService.Add(csvFile);
                return RedirectToAction("details", new { Id = csvFile.Id });
            }
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            CSVFile csvFile = _csvService.GetCsvFile(id);
            try
            {
                List<DealerTrack> list = new List<DealerTrack>();
                Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

                await ReadCSVStream.ReadCSVAndPopulateListAndFrequency(csvFile, list, frequencyMap);
                CsvFileDetailsVM csvFileDetailsVM = new CsvFileDetailsVM()
                {
                    DealerTrackList = list,
                    MostSoldVehicle = frequencyMap.OrderByDescending(kv => kv.Value).FirstOrDefault().Key
                };
                return View(csvFileDetailsVM);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
