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
    [ToolboxData("<{0}:RadioButton runat=server></{0}:RadioButton>")]
    public class RadioButton : System.Web.UI.WebControls.RadioButton
    {
        public override bool Checked
        {
            get
            {
                bool s = false;

                if (ViewState["Checked_" + this.ID] != null)
                {
                    if (bool.TryParse(ViewState["Checked_" + this.ID].ToString(), out s))
                    {
                        return (bool)ViewState["Checked_" + this.ID];
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
                
            }

            set
            {
                ViewState["Checked_" + this.ID] = value;
            }
        }

        public string Value
        {
            get; set;
        }

        public string GroupValue
        {
            get
            {
                return Context.Request[base.GroupName];
            }
        }

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
            var viewstateVal = Context.Request[base.GroupName];

            if(Value == viewstateVal && (!string.IsNullOrWhiteSpace(Value) && !string.IsNullOrWhiteSpace(viewstateVal)))
            {
                Checked = true;
            }

            var check = (Checked) ? "checked" : "";

            w.Write(String.Format(@"<div class=""{0}"">", _State));

            w.Write(@"<div class=""radio""><label>");
            w.Write("<input id=\"" + base.ClientID + "\" ");
            w.Write("type=\"radio\" ");
            w.Write("name=\"" + base.GroupName + "\" ");
            w.Write("value=\"" + Value + "\" " + check + "  />");
            w.Write(base.Text);
            w.Write("</label></div>");

            w.Write("</div>");
        }
    }
}
