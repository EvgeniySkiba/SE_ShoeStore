using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.AccessControl;

namespace ShoeStore.Back_End
{
    public partial class Product : System.Web.UI.Page
    {

        string lphotoDirrName = "Photos";

        protected void Page_Load(object sender, EventArgs e)
        {    
            dataSourceProducts.ConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();


        }

        /// <summary>
        ///  выбор продукта из таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grdProducts.SelectedIndex;
            int lid = (int)grdProducts.SelectedDataKey.Values["ID"];

            Response.Redirect(string.Concat("~/Back_End/ProductCreate.aspx?id=", lid));
        }

        protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = grdProducts.SelectedIndex;
            int lid = (int)grdProducts.SelectedDataKey.Values["ID"];
        }

        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int lColorID = (int)grdProducts.DataKeys[e.RowIndex].Value;
        }

        protected void btnCreateProduct_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Back_End/ProductEdit.aspx");           
        }

        protected void grdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {   
            int lID = (int)grdProducts.DataKeys[e.RowIndex].Value;
            /*
            bool lResult = ShoeStore.Data.Product.Product.DeleteProduct(lID);
                                  */

            DirectoryInfo lcurrentDirectory = new DirectoryInfo(Request.MapPath("."));
            DirectoryInfo lrootDirectory = (lcurrentDirectory.Parent);


            string lpathPhotos = string.Concat(lrootDirectory.FullName, "\\", lphotoDirrName);
            DirectoryInfo dir = new DirectoryInfo(lpathPhotos);

            int lproductID = lID;

            string lfolderForDownName = string.Concat("ProductID_", lproductID);
            
            string lpathCurrentPhoto = string.Concat(lpathPhotos, "\\", lfolderForDownName, "\\");


            bool exist = Directory.Exists(lpathCurrentPhoto);

            if (exist)
            {
                DirectoryInfo dr = new DirectoryInfo(lpathCurrentPhoto);
                DirectorySecurity dsr = new DirectorySecurity(lpathCurrentPhoto, AccessControlSections.Access);//.Owner);
                FileInfo[] fileInfo = dr.GetFiles();

                foreach (var item in fileInfo)
                {
                    File.Delete(item.FullName);
                }
                
                dr.SetAccessControl(dsr);
                dr.Delete();
            }

            grdProducts.DataBind();
        }              
    }
}