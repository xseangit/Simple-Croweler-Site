using crowle.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;


namespace crowle.servises
{
    public class GetElements
    {
        public string id(HtmlDocument webDriver, recevedata.receveitem receveitem, int i)
        {
            string returndata = "";
            string css = receveitem.selector[i];
            var element = webDriver.QuerySelectorAll(css);

            if (receveitem.all[i] == true)
            {
                foreach (var te in element)
                {
                    switch (receveitem.itemdatapart[i])
                    {
                        case "html":
                            {
                                returndata += te.InnerHtml;
                                break;
                            }
                        case "text":
                            {
                                returndata += te.InnerText;
                                break;
                            }
                        case "atre":
                            {
                                string at = receveitem.itematrebute[i];
                                returndata += te.GetAttributeValue(at, "");
                                break;
                            }
                    }
                }
            }
            else
            {
                var te = element.ToList()[receveitem.itemnum[i] - 1];
                switch (receveitem.itemdatapart[i])
                {
                    case "html":
                        {
                            returndata += te.InnerHtml;
                            break;
                        }
                    case "text":
                        {
                            returndata += te.InnerText;
                            break;
                        }
                    case "atre":
                        {
                            string at = receveitem.itematrebute[i];
                            returndata += te.GetAttributeValue(at, "");
                            break;
                        }
                }
            }
            return returndata;
        }
        public string css(HtmlDocument webDriver, recevedata.receveitem receveitem, int i)
        {
            string returndata = "";
            string css = receveitem.selector[i];
            var element = webDriver.QuerySelectorAll(css);

            if (receveitem.all[i] == true)
            {
                foreach (var te in element)
                {
                    switch (receveitem.itemdatapart[i])
                    {
                        case "html":
                            {
                                returndata += te.InnerHtml;
                                break;
                            }
                        case "text":
                            {
                                returndata += te.InnerText;
                                break;
                            }
                        case "atre":
                            {
                                string at = receveitem.itematrebute[i];
                                returndata += te.GetAttributeValue(at, "");
                                break;
                            }
                    }
                }
            }
            else
            {
                var te = element.ToList()[receveitem.itemnum[i] - 1];
                switch (receveitem.itemdatapart[i])
                {
                    case "html":
                        {
                            returndata += te.InnerHtml;
                            break;
                        }
                    case "text":
                        {
                            returndata += te.InnerText;
                            break;
                        }
                    case "atre":
                        {
                            string at = receveitem.itematrebute[i];
                            returndata += te.GetAttributeValue(at, "");
                            break;
                        }
                }
            }
            return returndata;
        }
        public string tag(HtmlDocument webDriver, recevedata.receveitem receveitem, int i)
        {
            string returndata = "";
            string css = receveitem.selector[i];
            var element = webDriver.QuerySelectorAll(css);

            if (receveitem.all[i] == true)
            {
                foreach (var te in element)
                {
                    switch (receveitem.itemdatapart[i])
                    {
                        case "html":
                            {
                                returndata += te.InnerHtml;
                                break;
                            }
                        case "text":
                            {
                                returndata += te.InnerText;
                                break;
                            }
                        case "atre":
                            {
                                string at = receveitem.itematrebute[i];
                                returndata += te.GetAttributeValue(at, "");
                                break;
                            }
                    }
                }
            }
            else
            {
                var te = element.ToList()[receveitem.itemnum[i] - 1];
                switch (receveitem.itemdatapart[i])
                {
                    case "html":
                        {
                            returndata += te.InnerHtml;
                            break;
                        }
                    case "text":
                        {
                            returndata += te.InnerText;
                            break;
                        }
                    case "atre":
                        {
                            string at = receveitem.itematrebute[i];
                            returndata += te.GetAttributeValue(at, "");
                            break;
                        }
                }
            }
            return returndata;
        }
    }
}
