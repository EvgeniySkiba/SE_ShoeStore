using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeStore.Controls
{
    public partial class ProductItem : System.Web.UI.UserControl
    {
        public int ProductId;

        private string ImagePath;

        public string Code;

        public string BrandName;

        public string Price;

        public string Size;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // ProductId = 45;
                string limageUrl =  ShoeStore.Data.Product.Product.GetProductTitleImage(ProductId);
                if (!String.IsNullOrEmpty(limageUrl))
                {
                    ImagePath = limageUrl;

                    ImgProduct.Height = 83;
                    ImgProduct.Width = 136;
                    ImgProduct.ImageUrl = ImagePath; 
                }

                lblBrand.Text = BrandName;
                lblCode.Text = Code;
                lblCost.Text = Price;
                lblSize.Text = Size;

                string lnavigationUrl = string.Concat("~/Store.aspx?id=", ProductId);
                hlkImage.NavigateUrl = lnavigationUrl;

            }
        }
    }
}