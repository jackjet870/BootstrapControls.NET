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
    [ToolboxData("<{0}:NotifyPanel runat=server></{0}:NotifyPanel>")]
    public class NotifyPanel : WebControl
    {

        public bool Dismissable
        {
            get; set;
        }

        public NotifyTypeOption State
        {
            get; set;
        }

        public string Message
        {
            get;
            set;
        }


        protected override void RenderContents(HtmlTextWriter w)
        {
            if (Message != null)
            {
                w.Write(String.Format(@"<div class=""alert {0} {1}"" role=""alert"">", (this.Dismissable) ? "alert-dismissible" : string.Empty, (this.State.ToString().Length > 0) ? "alert-" + this.State.ToString().ToLower() : string.Empty));
                if (this.Dismissable)
                    w.Write(String.Format(@"<button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close""><span aria-hidden=""true"">×</span></button>"));

                w.Write(Message);

                w.Write("</div>");
            }
        }
    }
}
