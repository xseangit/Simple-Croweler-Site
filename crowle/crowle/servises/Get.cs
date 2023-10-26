using crowle.Models;
using Newtonsoft.Json;

using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static crowle.Models.recevedata;
using static crowle.Models.senddata;

using Microsoft.AspNetCore.Html;
using System.Net;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace crowle.servises
{
    public class Get
    {
        public async Task GetData(recevedata.receved receved)
        {
            //IWebDriver driver = new OperaDriver();
            //driver.Url = (string)receved.site;
            //GetFunc(receved, driver).WaitAsync(TimeSpan.FromMinutes(1));
            //driver.Quit();


            string htmlString = "";
            HttpClient client = new HttpClient();
            htmlString = client.GetStringAsync(receved.site).Result.ToString(); //This is an example source for base64 img src, you can change this directly to your source.
            HtmlDocument document = new HtmlDocument();
            htmlString.Replace("\n", "");
            document.LoadHtml(htmlString);
            GetFunc(receved, document).WaitAsync(TimeSpan.FromMinutes(1));


        }
        //public async Task<Task> GetFunc(recevedata.receved receved, IWebDriver driver)
        public async Task<Task> GetFunc(recevedata.receved receved, HtmlDocument driver)
        {



            /////////////////////////////////////////////////////////////////////////////////////////////////
            List<senddata.item> items = new List<senddata.item>();
            List<string> links = new List<string>();
            List<string> newslinks = new List<string>();
            GetElements get = new GetElements();
            /////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var item in receved.item)
            {
                senddata.item valeue = new senddata.item();
                valeue.name = item.name;
                valeue.datas = "";
                valeue.selector = "";
                for (int i = 0; i <= item.selector.Count() - 1; i++)
                {
                    switch (item.by[i])
                    {
                        case "id":
                            {
                                string returned = get.id(driver, item, i);
                                valeue.datas += returned;
                                valeue.selector += item.by[i] + "\\\\\\" + item.selector[i];
                                break;
                            }
                        case "css":
                            {
                                string returned = get.css(driver, item, i);
                                valeue.datas += returned;
                                valeue.selector += item.by[i] + "\\\\\\" + item.selector[i];
                                break;
                            }
                        case "tag":
                            {
                                string returned = get.tag(driver, item, i);
                                valeue.datas += returned;
                                valeue.selector += item.by[i] + "\\\\\\" + item.selector[i];
                                break;
                            }
                    }
                    valeue.selector += "+++++++";
                }
                items.Add(valeue);
            }
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////get links
            ////////////////////////////////////////////////////////////////////
            if (receved.op.next == true)
            {
                string linkss = "";
                var element = driver.QuerySelectorAll("a");
                foreach (var item in element)
                {
                    linkss += item.GetAttributeValue("href", "") + "\n";


                }
                string l = receved.op.nexturl;
                MatchCollection list = Regex.Matches(linkss, l.ToString());
                foreach (Match match in list)
                {
                    string str = match.Groups[1].ToString();
                    string number = "";
                    foreach (Char c in str.ToCharArray())
                    {
                        int Num;
                        bool isNum = int.TryParse(c.ToString(), out Num);
                        if (isNum)
                        {
                            number += c;
                        }
                    }
                    links.Add(receved.op.nnexturl + number.ToString() + receved.op.bnexturl);
                }
                links = RemoveDuplicates(links);
                foreach (string item in links)
                {
                    newslinks.Add(receved.op.nnexturl + item + receved.op.bnexturl);
                }
                static List<T> RemoveDuplicates<T>(List<T> items)
                {
                    return (from s in items select s).Distinct().ToList();
                }
            }

            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////return
            ////////////////////////////////////////////////////////////////////
            var product = new data();
            product.site = receved.site;
            product.nexts = links;
            product.items = items;
            product.count = items.Count();
            product.url = receved.site;
            string fjson = JsonConvert.SerializeObject(product);
            //////////////////////////////send
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(receved.op.domain);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(receved.op.api, product);
            response.EnsureSuccessStatusCode();
            ////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////Exit
            ////////////////////////////////////////////////////////////////////
            Console.WriteLine(items.ToString());
            Console.WriteLine(newslinks.ToString());
            return Task.CompletedTask;
        }
    }
}
