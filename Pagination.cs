using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootstrapControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Pagination runat=server></{0}:Pagination>")]
    public class Pagination : WebControl
    {
        protected System.Web.UI.WebControls.LinkButton aPrev = new System.Web.UI.WebControls.LinkButton();
        protected System.Web.UI.WebControls.LinkButton aNext = new System.Web.UI.WebControls.LinkButton();
        protected List<System.Web.UI.WebControls.LinkButton> aPage = new List<System.Web.UI.WebControls.LinkButton>();

        public int RecordsPerQuery
        {
            get
            {
                if (ViewState["RecordsPerQuery_" + this.ID] != null)
                {
                    return int.Parse(ViewState["RecordsPerQuery_" + this.ID].ToString());
                }
                else
                {
                    ViewState["RecordsPerQuery_" + this.ID] = 10;
                    return 10;
                }
            }

            set
            {
                ViewState["RecordsPerQuery_" + this.ID] = value;
            }
        }

        public int RecordsOffset
        {
            get
            {
                if (ViewState["RecordsOffset_" + this.ID] != null)
                {
                    return int.Parse(ViewState["RecordsOffset_" + this.ID].ToString());
                }
                else
                {
                    ViewState["RecordsOffset_" + this.ID] = 0;
                    return 0;
                }
            }

            set
            {
                ViewState["RecordsOffset_" + this.ID] = value;
            }
        }

        public int TotalRecords
        {
            get; set;
        }

        public string NextButtonText
        {
            get; set;
        }

        public string PrevButtonText
        {
            get; set;
        }

        public PaginationPosition PaginationSide
        {
            get; set;
        }

        public enum PaginationPosition
        {
            Right,
            Left
        }

        public int MaxDisplayedPagerButtons
        {
            get
            {
                if (ViewState["MaxDisplayedPagerButtons_" + this.ID] != null)
                {
                    return int.Parse(ViewState["MaxDisplayedPagerButtons_" + this.ID].ToString());
                }
                else
                {
                    ViewState["MaxDisplayedPagerButtons_" + this.ID] = 5;
                    return 5;
                }
            }

            set
            {
                ViewState["MaxDisplayedPagerButtons_" + this.ID] = value;
            }
        }

        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber_" + this.ID] != null)
                {
                    return int.Parse(ViewState["PageNumber_" + this.ID].ToString());
                }
                else
                {
                    ViewState["PageNumber_" + this.ID] = 1;
                    return 1;
                }
            }

            set
            {
                ViewState["PageNumber_" + this.ID] = value;
            }
        }

        private List<PageItem> Items
        {
            get
            {
                if (ViewState["Items_" + this.ID] != null)
                {
                    return (List<PageItem>)(ViewState["Items_" + this.ID]);
                }
                else
                {
                    return new List<PageItem>();
                }
            }

            set
            {
                ViewState["Items_" + this.ID] = value;
            }
        }

        public delegate void MyHandler(Pagination pagination);
        public event MyHandler LoadData;

        public void InitPagination()
        {
            LoadData(this);
            CalculatePagination();
        }

        protected void OnLoadData(Pagination pagination)
        {
            if (LoadData != null)
            {
                LoadData(this);
            }
        }

        private void ButtonGenerator()
        {
            this.Controls.Clear();
            aPage.Clear();

            foreach (var item in Items)
            {

                var lb = new System.Web.UI.WebControls.LinkButton();
                lb.ID = this.ID + "_pages_" + item.Iteration;
                lb.Command += lbPage_Command;
                lb.CommandArgument = item.Iteration.ToString();
                lb.Text = item.Iteration.ToString();
                lb.CssClass = (item.Active) ? "active" : "";
                lb.EnableViewState = false;
                aPage.Add(lb);
                this.Controls.Add(lb);

            }

            aPrev.Click += OnPrevHandler;
            aPrev.Text = "Poprzednie";
            aPrev.ID = this.ID + "_prev_btn";

            aNext.Click += OnNextHandler;
            aNext.Text = "Następne";
            aNext.ID = this.ID + "_next_btn";

            this.Controls.Add(aPrev);
            this.Controls.Add(aNext);
        }

        private void CalculatePagination()
        {
            int numberOfPages = (int)Math.Ceiling(((float)TotalRecords / (float)RecordsPerQuery));
            int currentPage = PageNumber;

            aPrev.Enabled = true;
            aNext.Enabled = true;

            if (currentPage <= 1)
            {
                aPrev.Enabled = false;
            }
            if (currentPage >= numberOfPages)
            {
                aNext.Enabled = false;
            }

            int from, to;

            from = currentPage - this.MaxDisplayedPagerButtons / 2;
            to = currentPage + this.MaxDisplayedPagerButtons / 2;

            if (from < 1)
            {
                to = to + Math.Abs(from);
                from = 1;
                to++;
                if (to > numberOfPages) to = numberOfPages;
            }
            else if (to > numberOfPages)
            {
                from = from - (to - numberOfPages);
                if (from < 1) from = 1;
                to = numberOfPages;
            }

            List<PageItem> list = new List<PageItem>();

            for (int i = from; i <= to; i++)
            {
                list.Add(new PageItem { Active = (currentPage == i) ? true : false, Iteration = i });
            }

            Items = list;
        }

        //private event EventHandler NextHandler;
        void OnNextHandler(object sender, EventArgs e)
        {
            this.RecordsOffset += this.RecordsPerQuery;
            this.PageNumber += 1;

            LoadData(this);
            CalculatePagination();
            ButtonGenerator();
        }
        //private event EventHandler PrevHandler;
        void OnPrevHandler(object sender, EventArgs e)
        {
            this.RecordsOffset -= this.RecordsPerQuery;
            this.PageNumber -= 1;

            LoadData(this);
            CalculatePagination();
            ButtonGenerator();
        }

        protected void lbPage_Command(object sender, CommandEventArgs e)
        {
            PageNumber = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);
            this.RecordsOffset = (PageNumber - 1) * this.RecordsPerQuery;
            LoadData(this);
            CalculatePagination();
            ButtonGenerator();

        }

        protected override void OnLoad(EventArgs e)
        {
            ButtonGenerator();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        public override void RenderBeginTag(HtmlTextWriter w)
        {
            w.Write(String.Format(@"<ul class=""pagination {0} {1}"">", (PaginationSide == PaginationPosition.Right) ? "pull-right" : "", CssClass));
        }

        public override void RenderEndTag(HtmlTextWriter w)
        {
            w.Write(@"</ul>");
        }

        protected override void RenderContents(HtmlTextWriter w)
        {
            ButtonGenerator();

            var x = aPrev.UniqueID;

            

            w.Write(String.Format(@"<li class=""{0}"">", (aPrev.Enabled) ? "" : "disabled"));
            aPrev.RenderControl(w);
            w.Write(@"</li>");

            foreach(var item in aPage)
            {

                w.Write(String.Format(@"<li class=""{0}"">", item.CssClass ));

                item.RenderControl(w);


                w.Write("</li>");
            }


            w.Write(String.Format(@"<li class=""{0}"">", (aNext.Enabled) ? "" : "disabled"));
            aNext.RenderControl(w);
            w.Write(@"</li>");


            
        }

        [Serializable]
        public class PageItem
        {
            public bool Active { get; set; }
            public int Iteration { get; set; }

        }
    }
}
