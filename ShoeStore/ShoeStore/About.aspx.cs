using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ShoeStore
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Image1.Height = 100;
            Image1.ImageUrl = "~/Photos/ProductID_1/11.jpg";

        }
    }
}
