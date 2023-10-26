using ir.news.xsean;
using Microsoft.AspNetCore.Mvc;
using ri.news.xsean.Models;
using System.Diagnostics;

namespace ri.news.xsean.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbcontext _dbcontext;
        public HomeController(ILogger<HomeController> logger, dbcontext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        [Route("Home/Index/{id?}")]
        [Route("[controller]/[action]")]
        public IActionResult Index(int stip = 0)
        {
            try
            {
                IEnumerable<newsfi> ifn = _dbcontext.newsfi.ToList();
                IEnumerable<newss> ssn = _dbcontext.newss.ToList();
                IEnumerable<catgory> catgor = _dbcontext.catgories.ToList();
                IEnumerable<newsfi> fin = new List<newsfi>();

                List<catgory> x = catgor.OrderByDescending(_ => Guid.NewGuid()).Where(p => p.count >= 8).ToList().GetRange(0, 3);
                ViewBag.newsscat = catgor.OrderByDescending(p => p.count).ToList().GetRange(0, 14);
                ViewBag.x = x;

                //fin.AddRange(ifn.OrderByDescending(qu => qu.like.Value).ToList().GetRange(0, 7).ToList());
                //fin.AddRange(ifn.OrderByDescending(qu => qu.seen.Value).ToList().GetRange(0, 7).ToList());
                //fin.AddRange(ifn.OrderByDescending(qu => qu.coment).ToList().GetRange(0, 6));
                //fin.AddRange(ifn.OrderByDescending(qu => Guid.NewGuid()).ToList().GetRange(0, 10));
                //fin.AddRange(ifn.Where(qu => qu.CatgoryName == x[0].Name).ToList().GetRange(0, 4));
                //fin.AddRange(ifn.Where(qu => qu.CatgoryName == x[1].Name).ToList().GetRange(0, 5));
                //fin.AddRange(ifn.Where(qu => qu.CatgoryName == x[2].Name).ToList().GetRange(0, 5));
                //fin.AddRange(ifn.OrderByDescending(qu => qu.datetime).Reverse().ToList().GetRange(0, 8));
                //ssn = fi.find(ifn,_dbcontext, ssn);
                //ViewBag.newsssen = ssn.GetRange(0,7);
                //ViewBag.newssslider = ssn.GetRange(7,7); ;
                //ViewBag.newsscom = ssn.GetRange(14,6); ;
                //ViewBag.newssran = ssn.GetRange(20,10); ;
                //ViewBag.newsssiasatdakhele = ssn.GetRange(30,4); ;
                //ViewBag.newsssiasatkharege = ssn.GetRange(34,5); ;
                //ViewBag.newssasea = ssn.GetRange(39,5); ;
                //ViewBag.newssnew = ssn.GetRange(44,8); ;



                ViewBag.newsssen = fi.find(ifn.OrderByDescending(qu => qu.like.Value).ToList().GetRange(0, 7).ToList(), _dbcontext, ssn);
                ViewBag.newssslider = fi.find(ifn.OrderByDescending(qu => qu.seen.Value).ToList().GetRange(0, 7).ToList(), _dbcontext, ssn);
                ViewBag.newsscom = fi.find(ifn.OrderByDescending(qu => qu.coment).ToList().GetRange(0, 6), _dbcontext, ssn);
                ViewBag.newssran = fi.find(ifn.OrderByDescending(qu => Guid.NewGuid()).ToList().GetRange(0, 10), _dbcontext, ssn);
                ViewBag.newsssiasatdakhele = fi.find(ifn.Where(qu => qu.Catgory == x[0]).ToList().GetRange(0, 4), _dbcontext, ssn);
                ViewBag.newsssiasatkharege = fi.find(ifn.Where(qu => qu.Catgory == x[1]).ToList().GetRange(0, 5), _dbcontext, ssn);
                ViewBag.newssasea = fi.find(ifn.Where(qu => qu.Catgory == x[2]).ToList().GetRange(0, 5), _dbcontext, ssn);
                ViewBag.newssnew = fi.find(ifn.OrderByDescending(qu => qu.datetime).Reverse().ToList().GetRange(0, 8), _dbcontext, ssn);
                return View();
            }
            catch
            {
                return Error();
            }
        }
        public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            return (from s in items select s).Distinct(comparer).ToList();
        }
        public IActionResult post(long id)
        {
            try
            {
                long f = id;
                if (f != 0)
                {
                    var news = _dbcontext.newss.Find(f);
                    news.seen = news.seen + 1;
                    var newsf = _dbcontext.newsfi.Find(f);
                    newsf.seen = newsf.seen + 1;
                    _dbcontext.newss.Update(news);
                    _dbcontext.newsfi.Update(newsf);
                    _dbcontext.SaveChanges();
                    ViewBag.newss = news;
                    ViewBag.cat = _dbcontext.catgories.Find(newsf.Catgoryid).Name;
                }
                return View("post");
            }
            catch
            {
                return View("e404");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult cat(int id, int stip = 0)
        {
            var cat = _dbcontext.catgories.Find(id);
            List<catgory> catgor = _dbcontext.catgories.ToList();
            IEnumerable<newss> ssn = _dbcontext.newss.ToList();
            if (ssn.Where(qu => qu.Catgory.Name == cat.Name).ToList().Count > (stip + 1) * 9)
                ViewBag.news = ssn.Where(qu => qu.Catgory.Name == cat.Name).ToList().GetRange(stip * 9, 9);
            else
                ViewBag.news = ssn.Where(qu => qu.Catgory.Name == cat.Name).ToList().GetRange(stip * 9, _dbcontext.newss.Where(qu => qu.Catgory.Name == cat.Name).ToList().Count - (stip) * 9);
            ViewBag.cat = cat;
            ViewBag.s = stip;
            ViewBag.id = id;
            int n = 0;
            n = ssn.Where(p => p.Catgory.Name == cat.Name).ToList().Count / 9;
            ViewBag.n = n;
            ViewBag.newssran = ssn.OrderByDescending(qu => Guid.NewGuid()).ToList().GetRange(0, 10);
            ViewBag.newsscat = catgor.GetRange(0, 14);
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult title()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
            .Build();
            IEnumerable<int> l = configuration.GetValue<IEnumerable<int>>("title");
            ViewBag.t = _dbcontext.catgories.Where(p => l.Contains((int)p.id)).ToList();
            return View();
        }

    }




}