﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app
{
    public partial class Docks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSlips.PageIndex = 0;
        }
    }
}