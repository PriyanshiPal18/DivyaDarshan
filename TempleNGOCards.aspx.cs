﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Divya_Darshan
{
    public partial class TempleNGOCards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Temple1.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("NgoPage.aspx");
        }
    }
}