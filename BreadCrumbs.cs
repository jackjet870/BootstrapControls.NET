using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootstrapControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:BreadCrumbs runat=server></{0}:BreadCrumbs>")]
    public class BreadCrumbs : WebControl
    {
        List<BreadCrumbItem> ItemList = new List<BreadCrumbItem>();

        protected override void OnInit(EventArgs e)
        {
            using (StreamReader reader = File.OpenText(Context.Server.MapPath("~/pages.json")))
            {
                List<BreadCrumbItem> list = new List<BreadCrumbItem>();
                dynamic x = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                foreach (var k in x.pages)
                {
                    if (Page.ResolveUrl(k.pageUrl.ToString()).Contains(HttpContext.Current.Request.FilePath))
                    {
                        list.Add(new BreadCrumbItem { PageUrl = k.pageUrl, PageIco = k.pageIco, PageName = k.pageLabel });
                    }
                    else if (k.subpages != null)
                    {
                        foreach (var h in k.subpages)
                        {
                            if (Page.ResolveUrl(h.pageUrl.ToString()).Contains(HttpContext.Current.Request.FilePath))
                            {
                                list.Add(new BreadCrumbItem { PageUrl = k.pageUrl, PageIco = k.pageIco, PageName = k.pageLabel });
                                list.Add(new BreadCrumbItem { PageUrl = h.pageUrl, PageIco = h.pageIco, PageName = h.pageLabel });
                            }
                            else if (h.subpages != null)
                            {
                                foreach (var t in h.subpages)
                                {
                                    if (Page.ResolveUrl(t.pageUrl.ToString()).Contains(HttpContext.Current.Request.FilePath))
                                    {
                                        list.Add(new BreadCrumbItem { PageUrl = k.pageUrl, PageIco = k.pageIco, PageName = k.pageLabel });
                                        list.Add(new BreadCrumbItem { PageUrl = h.pageUrl, PageIco = h.pageIco, PageName = h.pageLabel });
                                        list.Add(new BreadCrumbItem { PageUrl = t.pageUrl, PageIco = t.pageIco, PageName = t.pageLabel });
                                    }
                                    else if (t.subpages != null)
                                    {
                                        foreach (var tt in t.subpages)
                                        {
                                            if (Page.ResolveUrl(tt.pageUrl.ToString()).Contains(HttpContext.Current.Request.FilePath))
                                            {
                                                list.Add(new BreadCrumbItem { PageUrl = k.pageUrl, PageIco = k.pageIco, PageName = k.pageLabel });
                                                list.Add(new BreadCrumbItem { PageUrl = h.pageUrl, PageIco = h.pageIco, PageName = h.pageLabel });
                                                list.Add(new BreadCrumbItem { PageUrl = t.pageUrl, PageIco = t.pageIco, PageName = t.pageLabel });
                                                list.Add(new BreadCrumbItem { PageUrl = tt.pageUrl, PageIco = tt.pageIco, PageName = tt.pageLabel });
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                ItemList = list;
            }
        }

        protected override void RenderContents(HtmlTextWriter w)
        {
            w.Write(@"<ol class=""breadcrumb"">");

            foreach (var item in ItemList)
            {
                var url = (item.PageUrl != "#") ? Page.ResolveUrl(item.PageUrl) : "javascript:return false;";

                if (url.Contains(HttpContext.Current.Request.FilePath))
                {
                    url = "javascript:return false;";
                }

                w.Write(String.Format(@"<li><a href=""{0}""><i class=""fa {1}""></i>&nbsp;{2}</a></li>", url, item.PageIco, item.PageName));
            }

            w.Write(@"</ol>");
        }

        public class BreadCrumbItem
        {
            public string PageUrl { get; set; }
            public string PageIco { get; set; }
            public string PageName { get; set; }
        }
    }


}
