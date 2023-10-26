using crowle.Models;
using static crowle.Models.recevedata;

namespace crowle.sitesdata
{
    public class isna
    {
        public long _id { get; set; } = 0;
        public int _itemco { get; set; } = 7;

        public receveop _op { get; set; } = new receveop()
        {
            next = true,
            nexturl = "/news/(.*?)/",
            nnexturl = "https://www.isna.ir/news/",
            bnexturl = "",
            api = "api/news/add",
            domain = "",
        };
        public recevedata.receved set(string _site)
        {
            recevedata.receved receved = new receved();
            receved.site = _site;
            receved.op = _op;
            receved.itemco = _itemco;
            receved.id = _id;
            List<receveitem> receveditem = new List<receveitem>();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            List<string> by = new List<string>() { "css" };
            List<string> selector = new List<string>() { ".full-news-text>.content-full-news>.item-img>img" };
            List<string> next = new List<string>() { };
            List<string> back = new List<string>() { };
            List<bool> all = new List<bool>() { true };
            List<int> itemnum = new List<int>() { };
            List<string> itemdatapart = new List<string>() { "atre" };
            List<string> itematrebute = new List<string>() { "src" };
            receveditem.Add(new receveitem
            {
                name = "titleimg",
                by = by,
                selector = selector,
                next = next,
                back = back,
                all = all,
                itemnum = itemnum,
                itemdatapart = itemdatapart,
                itematrebute = itematrebute
            });

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            by = new List<string>() { "css" };
            selector = new List<string>() { ".first-title" };
            next = new List<string>() { };
            back = new List<string>() { };
            all = new List<bool>() { true };
            itemnum = new List<int>() { };
            itemdatapart = new List<string>() { "text" };
            itematrebute = new List<string>() { };
            receveditem.Add(new receveitem
            {
                name = "title",
                by = by,
                selector = selector,
                next = next,
                back = back,
                all = all,
                itemnum = itemnum,
                itemdatapart = itemdatapart,
                itematrebute = itematrebute
            });
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            by = new List<string>() { "css" };
            selector = new List<string>() { ".content-full-news" };
            next = new List<string>() { };
            back = new List<string>() { };
            all = new List<bool>() { true };
            itemnum = new List<int>() { };
            itemdatapart = new List<string>() { "html" };
            itematrebute = new List<string>() { };
            receveditem.Add(new receveitem
            {
                name = "news",
                by = by,
                selector = selector,
                next = next,
                back = back,
                all = all,
                itemnum = itemnum,
                itemdatapart = itemdatapart,
                itematrebute = itematrebute
            });
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            by = new List<string>() { "css" };
            selector = new List<string>() { ".meta-news>ul>li>.text-meta" };
            next = new List<string>() { };
            back = new List<string>() { };
            all = new List<bool>() { false };
            itemnum = new List<int>() { 2 };
            itemdatapart = new List<string>() { "text" };
            itematrebute = new List<string>() { };
            receveditem.Add(new receveitem
            {
                name = "category",
                by = by,
                selector = selector,
                next = next,
                back = back,
                all = all,
                itemnum = itemnum,
                itemdatapart = itemdatapart,
                itematrebute = itematrebute
            });
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            by = new List<string>() { "css" };
            selector = new List<string>() { ".author-id>li>strong" };
            next = new List<string>() { };
            back = new List<string>() { };
            all = new List<bool>() { true };
            itemnum = new List<int>() { };
            itemdatapart = new List<string>() { "text" };
            itematrebute = new List<string>() { };
            receveditem.Add(new receveitem
            {
                name = "newser",
                by = by,
                selector = selector,
                next = next,
                back = back,
                all = all,
                itemnum = itemnum,
                itemdatapart = itemdatapart,
                itematrebute = itematrebute
            });
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            by = new List<string>() { "css" };
            selector = new List<string>() { ".meta-news>ul>li>.text-meta" };
            next = new List<string>() { };
            back = new List<string>() { };
            all = new List<bool>() { false };
            itemnum = new List<int>() { 1 };
            itemdatapart = new List<string>() { "text" };
            itematrebute = new List<string>() { };
            receveditem.Add(new receveitem
            {
                name = "datetime",
                by = by,
                selector = selector,
                next = next,
                back = back,
                all = all,
                itemnum = itemnum,
                itemdatapart = itemdatapart,
                itematrebute = itematrebute
            });
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            by = new List<string>() { "css" };
            selector = new List<string>() { ".summary" };
            next = new List<string>() { };
            back = new List<string>() { };
            all = new List<bool>() { true };
            itemnum = new List<int>() { };
            itemdatapart = new List<string>() { "text" };
            itematrebute = new List<string>() { };
            receveditem.Add(new receveitem
            {
                name = "shorts",
                by = by,
                selector = selector,
                next = next,
                back = back,
                all = all,
                itemnum = itemnum,
                itemdatapart = itemdatapart,
                itematrebute = itematrebute
            });
            receved.item = receveditem;
            return receved;
        }
    }

}
