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
    [ToolboxData("<{0}:LinkButton runat=server></{0}:LinkButton>")]
    public class LinkButton : System.Web.UI.WebControls.LinkButton
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
                if (value.ToString() == "XtraLarge")
                {
                    base.CssClass += " btn-xl";
                }

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

        public override string CssClass
        {
            get
            {
                return base.CssClass;
            }

            set
            {
                base.CssClass += " " + value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.CssClass += " btn";
        }

        public bool Circle
        {
            set
            {
                if (value)
                {
                    base.CssClass += " btn-circle";
                }
            }
        }

        protected override void Render(HtmlTextWriter w)
        {
            base.Render(w);
        }
    }
}
