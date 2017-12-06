using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ShoeStore
{
    public partial class Basket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart lcart = (Cart)Session["Cart"];

            if ((lcart == null) || (lcart.Lines.Count() < 1))
            {
                lblInfo.Text = "Ваша корзина пуста";
            }
            else
            {
                lblInfo.Text = String.Concat("В корзине ", lcart.TotalProducts(), " ", "товаров");

                lblTotalValue.Text = lcart.ComputeToValue().ToString();
                grdCart.DataSource = lcart.Lines;
                grdCart.DataBind();

            }
        }

        protected void grdCart_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grdCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = (int)grdCart.DataKeys[e.RowIndex].Value;

            //int index = e.RowIndex;
            Cart lcart = (Cart)Session["Cart"];

            if (!(lcart == null) && (lcart.Lines.Count() > 0))
            {
                lcart.RemoveItem(index);

                Session["Cart"] = lcart; 
                grdCart.DataBind();
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagePayment.aspx");
        }

        protected override void OnPreRender(EventArgs e)
        {

            MembershipUser luser = Membership.GetUser();
            if (luser == null)
            {
                Response.Redirect("~/");
            }

            base.OnPreRender(e);
            base.OnPreRender(e);
        }
    }
}