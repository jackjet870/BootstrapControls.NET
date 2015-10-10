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
    [ToolboxData("<{0}:DropDown runat=server></{0}:DropDown>")]
    public class DropDown : System.Web.UI.WebControls.DropDownList
    {
        
        public string Name { get; set; }
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

        public string AdditionalStyle { get; set; }

        public string Placeholder
        {
            set
            {
                base.Attributes["placeholder"] = value;
            }
        }

        protected override void Render(HtmlTextWriter w)
        {
            w.Write(String.Format(@"<div style=""{2}"" class=""form-group {0} {1}"">", _Size, _State, AdditionalStyle));

            if(Name != null)
            w.Write(String.Format(@"<label class=""control-label"" for=""{0}"">{1}</label>", base.ClientID, this.Name));

            base.CssClass += " form-control";
            base.Render(w);

            if(Message != null)
            w.Write(String.Format(@"<p class=""help-block {0}"">{1}</p>", _MessageColor, Message ));

            w.Write("</div>");
        }
    }
}
