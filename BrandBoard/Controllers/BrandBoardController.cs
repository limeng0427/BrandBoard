using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Abp.UI;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Mofadeng.TechnicalTest.BrandBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandBoardController : ControllerBase
    {

        private readonly ILogger<BrandBoardController> _logger;

        public BrandBoardController(ILogger<BrandBoardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<BrandBoardItem> Get()
        {
            string path = "./Brands.csv";
            if (!System.IO.File.Exists(path))
            {
                throw new UserFriendlyException("CouldNotFindTheMappingFile");
            }
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                if(_logger != null)
                    _logger.LogInformation($"{DateTime.Now} BrandBoardController.Get()");
                csv.Configuration.HasHeaderRecord = false;
                return csv.GetRecords<BrandBoardItem>()
                    .ToArray()
                    .OrderBy(l=>("BEL".Contains(l.BrandName[0])? l.BrandName.Replace(" ", "s"): (l.BrandName + "{")), StringComparer.OrdinalIgnoreCase);
            }
        }
    }

    public class BrandBoardItem
    {
        [Index(0)]
        public string BrandName { get; set; }
        [Index(1)]
        public string BrandURL { get; set; }
    }

}