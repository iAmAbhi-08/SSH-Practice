using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OptionsPractice.Models.Configuration;
using OptionsPractice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticeController : Controller
    {
        readonly IConfigurationReader _configurationReader;
        public PracticeController(IConfigurationReader configurationReader)
        {
            _configurationReader = configurationReader;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Content(_configurationReader.ReadDashboardHeaderSettings());
        }
    }
}
