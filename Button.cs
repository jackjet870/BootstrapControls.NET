using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootstrapControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Button runat=server></{0}:Button>")]
    public class Button : System.Web.UI.WebControls.Button
    {

        public ButtonColorType Color
        {
            set
            {
                base.CssClass += " btn-" + value.ToString().ToLower();
            }
        }

        public ButtonSizeType Size
        {
            set
            {
                if (value.ToString() == "Large")
                {
                    base.CssClass += " btn-lg";
                }

                if (value.ToString() == "Small")
                {
                    base.CssClass += " btn-sm";
                }

                if (value.ToString() == "Mini")
                {
                    base.CssClass += " btn-xs";
                }
            }
        }

        public bool Block
        {
            set
            {
                if (value)
                {
                    base.CssClass += " btn-block";
                }
            }
        }

        public bool Outline
        {
            set
            {
                if (value)
                {
                    base.CssClass += " btn-outline";
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.CssClass += " form-control";
        }


        protected override void Render(HtmlTextWriter w)
        {
            base.Render(w);
        }
    }
}
