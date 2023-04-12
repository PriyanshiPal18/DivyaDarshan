using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Divya_Darshan
{
    public partial class Temple1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Convert.ToString(Session["u1"])=="")
            {
                Response.Redirect("Login1.aspx");
            }

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Aarti_registration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("E_paas_Reg.aspx");
        }
    }
}