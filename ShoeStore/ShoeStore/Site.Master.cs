using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeStore
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// текущая стоимость покупки 
        /// </summary>
        public decimal CurrentCost;

        protected void Page_Load(object sender, EventArgs e)
        {
            Cart lcart = (Cart)Session["Cart"];

            if (!(lcart == null) && (lcart.Lines.Count() > 0))
            {
                CurrentCost = lcart.ComputeToValue();
            } 
            else
            {
                CurrentCost = 0;
            }

            Page.DataBind();
        }
    }
}
