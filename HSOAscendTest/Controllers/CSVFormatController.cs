using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSOAscendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVFormatController : ControllerBase
    {
        // GET: api/CSVFormat
        [HttpGet]
        public string Get(string csv)
        {
            var reformatter = new CSVReformatter(csv);
            return reformatter.ReformattedCSV == null ? "I Love You!" : reformatter.ReformattedCSV;
        }
    }
}
