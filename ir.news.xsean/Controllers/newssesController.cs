using ir.news.xsean;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http.Headers;

namespace ri.news.xsean.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class newssesController : ControllerBase
    {
        private dbcontext _context;
        public newssesController(dbcontext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("add")]
        public async Task newss(data data)
        {
            Random random = new Random();
            id id = new id();
            newss newss1 = new newss();
            if (data.items[0] != null)
                if (_context.urlscros.Where(p => p.url == data.url && p.bad != true).LongCount() != 0)
                {
                    urlscro urlscro = _context.urlscros.Where(p => p.url == data.url && p.bad != true).FirstOrDefault();
                    try
                    {
                        if (urlscro == null) { }
                        else
                        {
                            if (urlscro.crowel == true)
                            {
                            }
                            else if (urlscro.crowel != true)
                            {
                                urlscro.crowel = true;
                                long iddf = id.idgn(20);
                                if (_context.catgories.Where(p => p.Name == string.Join("", data.items[3].datas.Split("  ", StringSplitOptions.RemoveEmptyEntries))).LongCount() != 0)
                                {
                                    var catg = _context.catgories.Where(p => p.Name == string.Join("", data.items[3].datas.Split("  ", StringSplitOptions.RemoveEmptyEntries))).FirstOrDefault();
                                    catg.count = catg.count + 1;
                                    newss1 = new newss
                                    {
                                        Id = iddf,
                                        url = data.url,
                                        site = data.site,
                                        news = data.items[2].datas,
                                        Catgory = catg,
                                        datetime = data.items[5].datas,
                                        like = 0,
                                        newser = data.items[4].datas,
                                        seen = 0,
                                        shorts = data.items[6].datas,
                                        title = data.items[1].datas,
                                        titleimg = data.items[0].datas,
                                        InsertTime = DateTime.Now
                                    };
                                    newsfi newsfi = new newsfi
                                    {
                                        InsertTime = DateTime.Now,
                                        like = 0,
                                        seen = 0,
                                        Id = iddf,
                                        url = data.url,
                                        Catgory = catg,
                                        coment = 0,
                                        datetime = data.items[5].datas,
                                    };
                                    _context.newss.Add(newss1);
                                    _context.newsfi.Add(newsfi);
                                    _context.catgories.Update(catg);
                                    _context.urlscros.Update(urlscro);
                                    await _context.SaveChangesAsync();
                                    newss1 = _context.newss.Find(iddf);
                                    catg.Newsses.Add(newss1);
                                    _context.catgories.Update(catg);
                                    await _context.SaveChangesAsync();
                                }
                                else
                                {
                                    var catg = new catgory
                                    {
                                        Name = string.Join("", data.items[3].datas.Split("  ", StringSplitOptions.RemoveEmptyEntries)),
                                        count = 1
                                    };
                                    newss1 = new newss
                                    {
                                        Id = iddf,
                                        url = data.url,
                                        site = data.site,
                                        news = data.items[2].datas,
                                        Catgory = catg,
                                        datetime = data.items[5].datas,
                                        like = 0,
                                        newser = data.items[4].datas,
                                        seen = 0,
                                        shorts = data.items[6].datas,
                                        title = data.items[1].datas,
                                        titleimg = data.items[0].datas,
                                        InsertTime = DateTime.Now
                                    };
                                    newsfi newsfi = new newsfi
                                    {
                                        InsertTime = DateTime.Now,
                                        like = 0,
                                        seen = 0,
                                        Id = iddf,
                                        url = data.url,
                                        Catgory = catg,
                                        coment = 0,
                                        datetime = data.items[5].datas,
                                    };
                                    _context.newsfi.Add(newsfi);
                                    _context.catgories.Add(catg);
                                    await _context.SaveChangesAsync();
                                    _context.urlscros.Update(urlscro);
                                    _context.newss.Add(newss1);
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                    catch
                    {
                        urlscro.bad = true;
                        _context.Update(urlscro);
                        await _context.SaveChangesAsync();
                    }
                    dowingasync(newss1.Id).Wait(30000);
                }
            foreach (var item in data.nexts)
            {
                var x = _context.urlscros.Where(p => p.url == item).LongCount();
                if (x == 0)
                {
                    urlscro newss2 = new urlscro
                    {
                        url = item,
                        crowel = false
                    };
                    _context.urlscros.Add(newss2);
                }
                await _context.SaveChangesAsync();
            }
            await dowingasync(newss1.Id);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// خیلی ارور میداد برای ارتبات با دیتا بیس بری همین دو تیکه کردی ارسال درخواست رو یک بخش ارسال میکنه یک بخش  بخش ارسال کننده رو فرامیخونه 
        /// وظیفه اون بولین سند نکست که پایین تعریف کردی اینه که تا یه درخواست کامل نشده بعدی رو نفرسته و ترای کش گذاشتی تا وقتی ارور داد ارسال درخواست ها متوقف نشه
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        bool sendnext = true;
        [Route("send")]
        public async void send()
        {
            //for (; ; ){ if (sendnext){sendnext = false;       Thread.Sleep(30000);
                sendd();
            //    }}
        }
        private async Task sendd()
        {
            try
            {
                HttpClient client = new HttpClient();
                urlscro news;
                var co = _context.urlscros.Count();
                _context.SaveChanges();
                if (co == 0)
                {
                    urlscro newss2 = new urlscro{url = "https://www.isna.ir/news/1401060100766"};
                    _context.urlscros.Add(newss2);
                    _context.SaveChanges();
                }
                else
                {
                    news = _context.urlscros.Where(p => p.crowel == false && p.bad == false).OrderBy(p => Guid.NewGuid()).FirstOrDefault();
                    string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(projectPath)
                        .AddJsonFile("appsettings.json")
                        .Build();
                    Uri myUri = new Uri(news.url);
                    string host = myUri.Host;
                    string re = null;
                    if (host == "www.isna.ir")
                    {
                        re = "{\"apipa\":\"api/news/add\"}";
                    }
                    if (re != null)
                    {
                        var myJObject = JObject.Parse(re);
                        myJObject.Add("site", "isna");
                        myJObject.Add("domain", configuration.GetValue<String>("op:domain"));
                        myJObject.Add("url", news.url);
                        client.BaseAddress = new Uri(configuration.GetValue<String>("op:crowapi"));
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        getwd receve = new getwd();
                        receve = myJObject.ToObject<getwd>();
                        await client.PostAsJsonAsync("getwd", receve);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                sendnext = true;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// این بخش رو طراحی کردی تا لینک های مشکل دار رو جدا کنی ولی استفاده نمیکنی چون به مشکل میخوری 
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [Route("bad")]
        public async void bD(string URL)
        {
            var urlscro = _context.urlscros.Where(p => p.url == URL).FirstOrDefault();
            urlscro.bad = true;
            _context.Update(urlscro);
            _context.SaveChanges();
            send();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// این بخش رو طراحی کردی تا بره عکس هارو دانلود کنه ولی میخوای عوضش کنی 
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("imgt/{id}")]
        public async Task dowingasync(long id)
        {
            int tr = 0;
            bool don = false;
            long f = id;
            string url;
            if (f != 0)
            {
                while (don == false)
                {
                    tr++;
                    try
                    {
                        newss news = _context.newss.Find(f);
                        url = news.titleimg;
                        string[] name = url.Split('/');
                        int le = name.Length;
                        using var httpClient = new HttpClient();
                        var folder = @"titles/";
                        var fileName = id;
                        Uri uri = new Uri(url);
                        var uriWithoutQuery = uri.GetLeftPart(UriPartial.Path);
                        var path = Path.Combine(folder, $"{fileName}.jpg");
                        Directory.CreateDirectory("wwwroot/" + folder);
                        var imageBytes = await httpClient.GetByteArrayAsync(uri);
                        using (Image image = Image.FromStream(new MemoryStream(imageBytes)))
                        { image.Save("wwwroot/" + path, ImageFormat.Jpeg); }
                        arvanuplod arvanuplod = new arvanuplod();
                        arvanuplod.Main("wwwroot/" + path, fileName + ".jpg");
                        news.titleimgdo = "https://newsir.s3.ir-tbz-sh1.arvanstorage.ir/" + fileName + ".jpg";
                        _context.newss.Update(news);
                        _context.SaveChanges();
                        don = true;
                    }
                    catch
                    {
                        newss news = _context.newss.Find(f);
                        url = news.titleimg;
                        string[] name = url.Split('/');
                        int le = name.Length;
                        using var httpClient = new HttpClient();
                        var folder = @"titles/";
                        var fileName = id;
                        Uri uri = new Uri(url);
                        var uriWithoutQuery = uri.GetLeftPart(UriPartial.Path);
                        var path = Path.Combine(folder, $"{fileName}.jpg");
                        Directory.CreateDirectory("wwwroot/" + folder);
                        var imageBytes = await httpClient.GetByteArrayAsync(uri);
                        using (Image image = Image.FromStream(new MemoryStream(imageBytes)))
                        {
                            image.Save("wwwroot/" + path, ImageFormat.Jpeg);
                        }
                        arvanuplod arvanuplod = new arvanuplod();
                        arvanuplod.Main("wwwroot/" + path, fileName + ".jpg");
                        news.titleimgdo = "https://newsir.s3.ir-tbz-sh1.arvanstorage.ir/" + fileName + ".jpg";
                        _context.newss.Update(news);
                        _context.SaveChanges();
                        don = true;
                    }
                    if (tr == 3)
                    {
                        break;
                    }
                }
            }
        }
    }
    public class data
    {
        public string? site { get; set; }
        public string? url { get; set; }
        public List<string>? nexts { get; set; }
        public int? count { get; set; }
        public List<item>? items { get; set; }
    }
    public class item
    {

        public string name { get; set; }
        public string selector { get; set; }
        public string datas { get; set; }
    }
    public class getwd
    {
        public string site { get; set; }
        public string domain { get; set; }
        public string apipa { get; set; }
        public string url { get; set; }
    }
    public class receve
    {
        public string site { get; set; }
        public int itemco { get; set; }
        public receveitem item1 { get; set; }
        public receveitem item2 { get; set; }
        public receveitem item3 { get; set; }
        public receveitem item4 { get; set; }
        public receveitem item5 { get; set; }
        public receveitem item6 { get; set; }
        public receveitem item7 { get; set; }
        public receveop op { get; set; }
    }
    public class receveitem
    {

        public string name { get; set; }
        public string css { get; set; }
        public string type { get; set; }
        public string n { get; set; }
        public string b { get; set; }
        public int num { get; set; }
        public int legh { get; set; }
        public string input { get; set; }
    }
    public class receveop
    {
        public bool next { get; set; }
        public string nexturl { get; set; }
        public string nnexturl { get; set; }
        public string bnexturl { get; set; }
        public string api { get; set; }
        public string domain { get; set; }
    }
}
