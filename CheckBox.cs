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
    [ToolboxData("<{0}:Checkbox runat=server></{0}:Checkbox>")]
    public class CheckBox : System.Web.UI.WebControls.CheckBox
    {
        public string Label
        {
            get; set;
        }

        public override string Text
        {
            set; get;
        }

        public string Message { get; set; }

        private string _State { get; set; }
        private string _MessageColor { get; set; }
        public InputOption State
        {
            set
            {
                _State = " has-" + value.ToString().ToLower();

                if (value == InputOption.Error)
                {
                    _MessageColor = "text-danger";
                }
                else
                {
                    _MessageColor = "text-" + value.ToString().ToLower();
                }

            }
        }

        protected override void Render(HtmlTextWriter w)
        {
            Text = string.Empty;

            w.Write(String.Format(@"<div class=""{0}"">", _State));

            w.Write(@"<div class=""checkbox""><label>");


            base.Render(w);


            w.Write(Label + "</label>");

            if (Message != null)
                w.Write(String.Format(@"<p class=""help-block {0}"">{1}</p>", _MessageColor, Message));

            w.Write("</div></div>");
        }
    }
}
