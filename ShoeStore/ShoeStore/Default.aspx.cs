using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoeStore.Controls;

namespace ShoeStore
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dsrcProducts.ConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();
                dsrcProducts.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
                dsrcProducts.SelectCommand = "GetAllProductsInfo";

                //SqlDataSourceWoman
                SqlDataSourceMan.ConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();
                SqlDataSourceMan.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
                SqlDataSourceMan.SelectCommand = "GetAllProductsInfoForMan";

                SqlDataSourceWoman.ConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();
                SqlDataSourceWoman.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
                SqlDataSourceWoman.SelectCommand = "GetAllProductsInfoForWoman";

                Repeater1.DataBind();
            }

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.DataItem != null)
            {
                ProductItem product = (ProductItem)e.Item.FindControl("ProductItem1") as ProductItem;
                product.ProductId = (int)((System.Data.DataRowView)(e.Item.DataItem)).Row[0];

                product.BrandName = (((System.Data.DataRowView)(e.Item.DataItem))).Row.ItemArray[2].ToString();
                product.Price = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[10].ToString();
                product.Size = (((System.Data.DataRowView)(e.Item.DataItem))).Row.ItemArray[3].ToString();
                product.Code = (((System.Data.DataRowView)(e.Item.DataItem))).Row.ItemArray[11].ToString();
            }
        }


        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                ProductItem product = (ProductItem)e.Item.FindControl("ProductItemMan") as ProductItem;
                product.ProductId = (int)((System.Data.DataRowView)(e.Item.DataItem)).Row[0];

                product.BrandName = (((System.Data.DataRowView)(e.Item.DataItem))).Row.ItemArray[2].ToString();
                product.Price = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[10].ToString();
                product.Size = (((System.Data.DataRowView)(e.Item.DataItem))).Row.ItemArray[3].ToString();
                product.Code = (((System.Data.DataRowView)(e.Item.DataItem))).Row.ItemArray[11].ToString();
            }

        }
    }
}