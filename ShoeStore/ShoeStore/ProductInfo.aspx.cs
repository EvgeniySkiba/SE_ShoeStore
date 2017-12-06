using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeStore
{
    public partial class ProductInfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            List<CurrentCart> lcart = (List<CurrentCart>)Session["CurrentCart"];
            if (lcart == null)
            {
                lcart = new List<CurrentCart>();
            }

            
        }
    }
}