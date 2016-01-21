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
    [ToolboxData("<{0}:TextBox runat=server></{0}:TextBox>")]
    public class TextBox : System.Web.UI.WebControls.TextBox
    {
        
        public string Name
        {
            get
            {
                if (ViewState["TextboxName_" + this.ID] != null)
                    return ViewState["TextboxName_" + this.ID].ToString();
                else
                    return string.Empty;
            }
            set
            {
                ViewState["TextboxName_" + this.ID] = value;
            }
        }
        public string Message { get; set; }

        private string _Size { get; set; }

        public InputSize Size
        {
            set
            {
                if (value == InputSize.Small)
                    _Size = "form-group-sm";

                if (value == InputSize.Normal)
                    _Size = string.Empty;

                if (value == InputSize.Big)
                    _Size = "form-group-lg";
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


        public bool? FormGroup
        {
            get; set;
        }

        public string Ico
        {
            get
            {
                return IcoLeft;
            }
            set
            {
                IcoLeft = value;
            }
        }

        public string IcoLeft
        {
            get; set;
        }

        public string Placeholder
        {
            set
            {
                base.Attributes["placeholder"] = value;
            }
        }

        protected override void Render(HtmlTextWriter w)
        {
            w.Write(String.Format(@"<div class=""{2} {0} {1}"">", _Size, _State, (FormGroup.HasValue) ? ((FormGroup.Value) ? "form-group" : "") : "form-group"));

            if(!string.IsNullOrWhiteSpace(Name))
            w.Write(String.Format(@"<label class=""control-label"" for=""{0}"">{1}</label>", base.ClientID, this.Name));

            if (IcoLeft != null)
            {
                w.Write(@"<div class=""input-group"">");
                w.Write(String.Format(@"<div class=""input-group-addon"">{0}</div>", IcoLeft));
            }

            base.CssClass += " form-control";
            base.Render(w);

            if (IcoLeft != null)
                w.Write("</div>");
            if (Message != null)
            w.Write(String.Format(@"<p class=""help-block {0}"">{1}</p>", _MessageColor, Message ));

            w.Write("</div>");
        }
    }
}
