using System;
using System.Collections.Generic;
using System.Linq;
using Abp.UI;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mofadeng.TechnicalTest.Utilities;

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
        public IEnumerable<BrandBoardGroup> Get()
        {
            string path = "./Brands.csv";
            if (!System.IO.File.Exists(path))
            {
                throw new UserFriendlyException("CouldNotFindTheMappingFile");
            }
            var items = CSVHelper.ReadFromCSV<BrandBoardItem>(path);
            return GroupBrandData(items);
        }

        public IEnumerable<BrandBoardGroup> GroupBrandData(IEnumerable<BrandBoardItem> items)
        {
            // group items by rule from customised group utility
            // groupItemNumber is optional parameter. It is futureproof consideration for different groupping rule
            // "others" tag is replaced with "z" to make it alway display at last.
            var groups = items
                .GroupBy(l => GroupUtility.GetGroupName(l.BrandName, groupItemNumber: 2))
                .OrderBy(l=>l.Key.Replace("Others", "z"));
            

            var result = new List<BrandBoardGroup>();
            foreach (var group in groups)
            {
                // loop group and sort items in each group with custimised rule
                // the order in given example does not meet any unified rule from my humble option
                // here is a temp rule to match the example
                // rule1: case is not sensitive
                // rule2: if words start with b/e/l [space] is sorted like "s"
                // rule3: "ABC" is after "ABCD"
                var resultItem = new BrandBoardGroup()
                {
                    GroupName = group.Key,
                    Items = group.ToList()
                        .OrderBy(l => ("BEL".Contains(l.BrandName[0]) ? l.BrandName.Replace(" ", "s") : (l.BrandName + "{")), StringComparer.OrdinalIgnoreCase)
                };
                result.Add(resultItem);
            }
            return result;            
        }
    }

    public class BrandBoardItem
    {
        [Index(0)]
        public string BrandName { get; set; }
        [Index(1)]
        public string BrandURL { get; set; }
    }

    public class BrandBoardGroup
    {
        public string GroupName { get; set; }
        public IEnumerable<BrandBoardItem> Items { get; set; }
    }
}