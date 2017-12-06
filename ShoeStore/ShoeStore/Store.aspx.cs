using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Security;
using System.Data.SqlClient;

namespace ShoeStore
{
    public partial class Store : System.Web.UI.Page
    {
        int ProductId;
        protected void Page_Load(object sender, EventArgs e)
        {                                                    
            string lidString = Request.QueryString["id"];
            int id = -1;
            if (!string.IsNullOrEmpty(lidString))
            {
                id = Int32.Parse(lidString);
                ProductId = id;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            // id = 2;

            MembershipUser membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                createFeedBack.Visible = true;
            }


            SqlDataSource1.ConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();
         //   string SelectCommand = "SELECT [ID], [UserName], [ReviewText], [CreationDate], [ProductId] FROM [Review] WHERE ([ProductId] = @ProductId)";
         //   DataSource1.SelectCommand = SelectCommand;
         ////   DataSource1.SelectParameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int))

            if (!IsPostBack)
            {
                BindData(id);
            }
        }

        public void BindData(int pid)
        {
            DataSet ldataset = new DataSet();

            ldataset = ShoeStore.Data.Product.Product.GetSizeForCurrentProduct(pid);

            StringBuilder lexistSize = new StringBuilder();
            string ldelimeter = string.Empty;

            foreach (DataRow item in ldataset.Tables[0].Rows)
            {
                lexistSize.Append(ldelimeter);
                lexistSize.Append(item.ItemArray[1].ToString());
                ldelimeter = ",";
            }

            lblSizeValue.Text = lexistSize.ToString();

            DataSet lsizeDataSize = ShoeStore.Data.Product.ProductSize.GetProductSize(pid);
            ddlSize.DataSource = lsizeDataSize;
            ddlSize.DataBind();

            //-------------------------
            DataSet ldataSet = ShoeStore.Data.Product.Product.GetProductByIdFullInfo(pid);

            lblName.Text = ldataSet.Tables[0].Rows[0].ItemArray[1].ToString();
            lblBrandValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[2].ToString();
            lblShoeTypeValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[3].ToString();
            lblSeasonValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[4].ToString();
            lblMaterialValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[5].ToString();
            lblColorValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[6].ToString();
            lblInnerCodeValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[7].ToString();
            lblCountryValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[8].ToString();

            lblPriceValue.Text = ldataSet.Tables[0].Rows[0].ItemArray[9].ToString();
            lblName.Text = ldataSet.Tables[0].Rows[0].ItemArray[10].ToString();
            lblDescription.Text = ldataSet.Tables[0].Rows[0].ItemArray[12].ToString();
            mainImage.Src = ldataSet.Tables[0].Rows[0].ItemArray[11].ToString();

           // rprReview.DataSource = ShoeStore.Data.Product.Review.GetReviewForProduct(ProductId).Tables[0];
          //  rprReview.DataBind();
        }


        /// <summary>
        /// добавить в корзину 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int lquantity = -1;
            if (tbxCount.Text.Length > 0)
            {

                int.TryParse(tbxCount.Text, out lquantity);
            }
            if (lquantity > 0)
            {
                Cart lcart = (Cart)Session["Cart"];

                if (lcart == null)
                {
                    lcart = new Cart();
                }
                   //в корзине
                int lcurrentCount = lcart.TotalProducts();

                int lsize = Convert.ToInt32(ddlSize.SelectedValue);


                //всего в базе 
                int lcount = ShoeStore.Data.Product.Product.GetProductCount(ProductId,lsize);

                //доступно 
                int lavailablecount = lcount - lcurrentCount;

                if (lquantity > lavailablecount)
                {
                    lblInfo.Visible = true;
                    lblInfo.Text = "На текущий момент доступно :  " +  lavailablecount + " единиц(ы)";

                }
                else
                {
                    lblInfo.Visible = false;
                    lcart.AddItem(ProductId, lquantity);

                    Session["Cart"] = lcart;                   
                }

                DataBind();
            }
        }

        protected void CreateReviewList(int pProductId)
        {

        }

        /// <summary>
        /// add review
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateDescription_Click(object sender, EventArgs e)
        {
            string lreview = tbxReview.Text;

            string userName = User.Identity.Name;

            ShoeStore.Data.Product.Product.SetReviewForProduct(ProductId, userName, lreview);

            DataBind();
        }

    }
}