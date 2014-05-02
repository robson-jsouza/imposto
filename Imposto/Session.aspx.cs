using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.Usuarios;

namespace AutoImposto
{
    public partial class Session : System.Web.UI.Page
    {
        protected Usuario user;

        protected override void OnLoad(EventArgs e)
        {
            criaSessao();
            base.OnLoad(e);
        }

        private void criaSessao()
        {
            if (Session["usuario"] != null)
            {
                this.user = (Usuario)Session["usuario"];
            }
            else
            {
                Response.Redirect("~/Login.aspx", true);
            }
        }
    }
}