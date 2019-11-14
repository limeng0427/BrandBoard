using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mofadeng.TechnicalTest.BrandBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandBoardController : ControllerBase
    {

        private readonly ILogger<BrandBoardController> _logger;

        public BrandBoardController(ILogger<BrandBoardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BrandBoardItem> Get()
        {
            using (var reader = new StreamReader("./Brands.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = false;
                return csv.GetRecords<BrandBoardItem>()
                    .ToArray()
                    .OrderBy(l=>l.BrandName);
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