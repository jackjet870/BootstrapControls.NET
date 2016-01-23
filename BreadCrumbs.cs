using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace BootstrapControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:BreadCrumbs runat=server></{0}:BreadCrumbs>")]
    public class BreadCrumbs : WebControl
    {
        List<PageItem> ItemAllChildren = new List<PageItem>();
        List<PageItem> ItemFinalList = new List<PageItem>();

        protected override void OnInit(EventArgs e)
        {
            using (StreamReader reader = File.OpenText(Context.Server.MapPath("~/pages.json")))
            {
                var list = new JavaScriptSerializer().Deserialize<RootObject>(reader.ReadToEnd());

                FlattenTheList(list.pages);
                var foundItem = ItemAllChildren.Where(x => Page.ResolveUrl(x.pageUrl.ToLowerInvariant()) == HttpContext.Current.Request.FilePath.ToLowerInvariant()).ToList();
                if (foundItem.Count() > 0)
                    GetThePath(foundItem.First());

                ItemFinalList.Reverse();
            }
        }

        private void FlattenTheList(List<PageItem> list, Guid? id = null)
        {
            foreach (PageItem cat in list)
            {
                var guid = Guid.NewGuid();
                cat.pageId = guid;
                if (id != null)
                    cat.parentId = id;

                ItemAllChildren.Add(cat);
                FlattenTheList(cat.subpages, guid);
            }
        }

        private void GetThePath (PageItem pi)
        {
            ItemFinalList.Add(pi);

            if (pi.parentId != null)
            {
                GetThePath(ItemAllChildren.Where(x => x.pageId == pi.parentId).First());
            }
        }

        protected override void RenderContents(HtmlTextWriter w)
        {
            w.Write(@"<ol class=""breadcrumb"">");

            foreach (var item in ItemFinalList)
            {
                var url = (item.pageUrl != "#") ? Page.ResolveUrl(item.pageUrl) : "javascript:return false;";

                if (url.Contains(HttpContext.Current.Request.FilePath))
                {
                    url = "javascript:return false;";
                }

                w.Write(String.Format(@"<li><a href=""{0}""><i class=""fa {1}""></i>&nbsp;{2}</a></li>", url, item.pageIco, item.pageLabel));
            }

            w.Write(@"</ol>");
        }

        private class PageItem
        {
            public Guid? pageId { get; set; }
            public string pageIco { get; set; }
            public string pageUrl { get; set; }
            public string pageLabel { get; set; }
            public List<PageItem> subpages { get; set; }
            public Guid? parentId { get; set; }
        }

        private class RootObject
        {
            public List<PageItem> pages { get; set; }
        }
    }
}
