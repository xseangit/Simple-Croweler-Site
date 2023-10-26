using crowle.Models;
using Microsoft.AspNetCore.Mvc;
using crowle.servises;
using crowle.sitesdata;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using static crowle.Models.senddata;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace crowle.Controllers
{
    [ApiController]
    [Route("ap")]
    public class GetController : ControllerBase
    {
        private readonly ILogger<GetController> _logger;
        public GetController(ILogger<GetController> logger)
        {
            _logger = logger;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [HttpPost]
        [Route("/get")]
        public async Task Get(recevedata.receved receved)
        {
            Get g = new Get();
            g.GetData(receved);
           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [HttpPost]
        [Route("/getwd")]
        public async Task GetWD(getwd? getwd)
        {
            recevedata.receved receved = new recevedata.receved();
            switch (getwd.site)
            {
                case "isna":
                    {
                        isna isna = new isna();
                        receved = isna.set(getwd.url);
                        break;
                    }
                default:
                    break;
            }
            if (receved != null)
            {
                receved.op.api = getwd.apipa;
                receved.op.domain= getwd.domain;

                Get g = new Get();
                g.GetData(receved);
            }
        }
    }
}