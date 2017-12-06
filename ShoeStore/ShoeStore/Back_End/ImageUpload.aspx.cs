using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQueryUploadTest;

namespace ShoeStore.Back_End
{
    public partial class ImageUpload : System.Web.UI.Page
    {
        #region Gloabal Variable

        string PreviousPage = "~/Back_End/ProductEdit.aspx";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string lpath = (string)Session["Path"];

            //если есть id редактируемого товара 
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(lpath))
            {
               FileTransferHandler.StorageRoot = lpath;
               FileTransferHandler.ProductId = Int32.Parse(id);
            }
            else
            {
                Response.Redirect(PreviousPage);
            }  

        }
    }
}