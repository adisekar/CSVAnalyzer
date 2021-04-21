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
        private readonly IFileService _fileService;
        private readonly IVehicleSaleService _vehicleSalesService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IFileService csvService, IVehicleSaleService vehicleSaleService, IHostingEnvironment hostingEnvironment)
        {
            _fileService = csvService;
            _vehicleSalesService = vehicleSaleService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            ICollection<IFile> csvFiles = _fileService.GetAllFiles();
            return View(csvFiles);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(FileUploadVM model)
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
                _fileService.Add(csvFile);
                return RedirectToAction("details", new { Id = csvFile.Id });
            }
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            IFile file = _fileService.GetFile(id);
            ICollection<IVehicleSale> list = await _vehicleSalesService.GetAllSales(file);
            string mostSoldVehicle = _vehicleSalesService.GetMostSoldVehicle(list);
            try
            {
                FileDetailsVM fileDetailsVM = new FileDetailsVM()
                {
                    VehicleSales = list,
                    MostSoldVehicle = mostSoldVehicle
                };
                return View(fileDetailsVM);
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
