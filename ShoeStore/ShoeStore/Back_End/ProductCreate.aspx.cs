using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using jQueryUploadTest;

namespace ShoeStore.Back_End
{
    /// <summary>
    /// page for editing current product 
    /// </summary>
    public partial class ProductCreate : System.Web.UI.Page
    {
        private List<SizeItem> CurrentSize
        {
            get
            {
                object obj = ViewState["CurrentSize"];
                if (obj == null)
                {
                    SizeItem lsizeItem = new SizeItem();
                   // lsizeItem.ID = 1;
                    lsizeItem.Size = 0;
                    lsizeItem.Count = 1;
                    lsizeItem.SizeId = 0;

                    List<SizeItem> lsizeList = new List<SizeItem>();
                    lsizeList.Add(lsizeItem);

                    return lsizeList;
                }
                else
                {
                    return (List<SizeItem>)obj;
                }
            }
        }

        string lphotoDirrName = "Photos";

        protected void Page_Load(object sender, EventArgs e)
        {
            string lstringId = Request.QueryString["id"];

            int lid = 0;

            Int32.TryParse(lstringId, out lid);
            //-------------------------------------------------------------------

            if (!(lid > 0))
            {
                Response.Redirect("/Back_End/Product.aspx");
            }


            Session["productID"] = lid;


            string lConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();
            ColorDataSource.ConnectionString = lConnectionString;
            dsrcManufacture.ConnectionString = lConnectionString;
            dsrcMaterial.ConnectionString = lConnectionString;
            dsrcSex.ConnectionString = lConnectionString;
            dsrcSize.ConnectionString = lConnectionString;
            dsrcSeason.ConnectionString = lConnectionString;
            dsrcType.ConnectionString = lConnectionString;

            //  ddlManufacture.DataBind();
            if (!IsPostBack)
            {
                DataBindingOnFields(lid);
                btnDownPicture.Visible = true;
                GetProductSize(lid);

            }

            grdSize.DataBind();
        }


        /// <summary>
        /// получить текущие значения из базы 
        /// </summary>
        /// <param name="pProductId"></param>
        private void GetProductSize(int pProductId)
        {
            DataSet ldataSet = new DataSet();

            ldataSet = ShoeStore.Data.Product.ProductSize.GetCountSize((int)Session["productID"]);

            List<SizeItem> litemList = (List<SizeItem>)ViewState["CurrentSize"];

            if (litemList == null)
            {
                litemList = new List<SizeItem>();
            }

            SizeItem litems;

            foreach (var item in ldataSet.Tables[0].Rows)
            {
                litems = new SizeItem();
                litems.SizeId = Convert.ToInt32(((System.Data.DataRow)(item)).ItemArray[0]);
                litems.Size = Convert.ToInt32(((System.Data.DataRow)(item)).ItemArray[1]);
                object lObjCount = ((System.Data.DataRow)(item)).ItemArray[2];
                
                try
                {
                    litems.Count = Convert.ToInt32(lObjCount);
                }
                catch(InvalidCastException es)
                {
                     litems.Count = 0;
                }

               

                litemList.Add(litems);
            }

            ViewState["CurrentSize"] = litemList;


        }
        /// <summary>
        /// get curret products setting and bindigs 
        /// </summary>
        /// <param name="pId"></param>
        private void DataBindingOnFields(int pId)
        {
            DataSet ldataSet = ShoeStore.Data.Product.Product.GetProductById(pId);
           if (ldataSet.Tables[0].Rows.Count > 0)
            {
                tbxName.Text = ldataSet.Tables[0].Rows[0].ItemArray[1].ToString();// lobjList[1].ToString();
                tbxCode.Text = ldataSet.Tables[0].Rows[0].ItemArray[10].ToString(); //code 

                ddlManufacture.SelectedValue = ldataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                ddlMaterial.SelectedValue = ldataSet.Tables[0].Rows[0].ItemArray[3].ToString();

                drlColors.SelectedValue = ldataSet.Tables[0].Rows[0].ItemArray[4].ToString();
                ddlSex.SelectedValue = ldataSet.Tables[0].Rows[0].ItemArray[5].ToString();
                ddlSeason.SelectedValue = ldataSet.Tables[0].Rows[0].ItemArray[6].ToString();
                ddlTypeItem.SelectedValue = ldataSet.Tables[0].Rows[0].ItemArray[7].ToString();

                string limageUrl = ldataSet.Tables[0].Rows[0].ItemArray[8].ToString();

                tbxCost.Text = ldataSet.Tables[0].Rows[0].ItemArray[9].ToString();
                object ldescription = ldataSet.Tables[0].Rows[0].ItemArray[11];

                tbxDescription.Text = ldescription.ToString();


                imgTitle.ImageUrl = limageUrl;
                // imgTitle.Height = 300;
                imgTitle.Width = 256;

               // int lcountvalue;
                //object lcount = ldataSet.Tables[0].Rows[0].ItemArray[12];
                /*if (lcount == null)
                {
                    lcountvalue = 0;
                }
                else
                {
                   // lcountvalue = Convert.ToInt32(lcount);
                } */

              //  tbxCount.Text = lcount.ToString();
            }

        }

        /// <summary>
        /// сохранение выбранных значений 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (true)
            {

                int lproductId = (int)Session["productID"];
                string lname = tbxName.Text;
                string lcode = tbxCode.Text;

                int lmanufactureID = Int32.Parse(ddlManufacture.SelectedValue);
                int lcolorID = Int32.Parse(drlColors.SelectedValue);
                int lmaterialId = Int32.Parse(ddlMaterial.SelectedValue);
                int lsizeID = Int32.Parse(ddlSize.SelectedValue);
                int lsexID = Int32.Parse(ddlSex.SelectedValue);
                int lseasonID = Int32.Parse(ddlSeason.SelectedValue);
                int ltypeId = Int32.Parse(ddlTypeItem.SelectedValue);

                decimal lcost = Convert.ToDecimal(tbxCost.Text);
                string ldescription = tbxDescription.Text;

              //  int lcount = 1;
              //  if (tbxCount.Text.Length > 0)
               // {
              //      Int32.TryParse(tbxCount.Text, out lcount);
              //  }
               // int lseasonID = 0;

                bool res = ShoeStore.Data.Product.Product.UpdateProduct(lproductId, lname, lcode, lmanufactureID, lcolorID
                    , lmaterialId, lsizeID, lsexID, lseasonID, ltypeId, ldescription, lcost);
                if (res)
                {
                    List<SizeItem> litemList = (List<SizeItem>)ViewState["CurrentSize"];

                    if (litemList != null && litemList.Count > 0)
                    {
                        foreach (var item in litemList)
                        {
                            ShoeStore.Data.Product.ProductSize.SetProductsSize(lproductId, item.SizeId, item.Count);
                        }
                    }
                    else if (litemList.Count == 0)
                    {
                        ShoeStore.Data.Product.ProductSize.DeleteSizeFromProduct(lproductId);
                    }

                    Response.Redirect("/Back_End/Product.aspx");
                }
                else
                {
                    fltInfo.Visible = true;
                    lblInfo.Text = "В процсе обновления произошла ошибка повторите попытку попозже";
                }
            }

        }

        /// <summary>
        /// загрузка нового фото 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownPicture_Click(object sender, EventArgs e)
        {
            DirectoryInfo lcurrentDirectory = new DirectoryInfo(Request.MapPath("."));
            DirectoryInfo lrootDirectory = (lcurrentDirectory.Parent);


            string lpathPhotos = string.Concat(lrootDirectory.FullName, "\\", lphotoDirrName);
            DirectoryInfo dir = new DirectoryInfo(lpathPhotos);

            object lproductIDobject = Session["productID"];

            int lproductID = (int)lproductIDobject;

            string lfolderForDownName = string.Concat("ProductID_", lproductID);

            //  string lpathCurrentPhoto = string.Concat(dir.FullName, "\\", lcurrFolder);

            string lpathCurrentPhoto = string.Concat(lpathPhotos, "\\", lfolderForDownName, "\\");


            bool exist = Directory.Exists(lpathCurrentPhoto);
            if (!exist)
            {
                dir.CreateSubdirectory(lfolderForDownName);
            }

            Session["Path"] = String.Concat(lpathCurrentPhoto, "");
            FileTransferHandler.StorageRoot = String.Concat(lpathCurrentPhoto);

            Response.Redirect(string.Concat("ImageUpload.aspx?id=", lproductID));
        }

        protected void btnCopySize_Click(object sender, EventArgs e)
        {
            //получить текущие размера для данного продукта 


            //получить новое значение 

        }

        protected void btnAddSize_Click(object sender, EventArgs e)
        {      
            int lsize =  Convert.ToInt32(ddlSize.SelectedItem.Text);
            int lsizeId = Convert.ToInt32(ddlSize.SelectedItem.Value);
              int lcount  = 0;
            if (tbxCount.Text.Length > 0)
            {
                lcount = Convert.ToInt32(tbxCountSize.Text);
            }

            bool isAvalable = true;

            List<SizeItem> litemList = (List<SizeItem>)ViewState["CurrentSize"];



            if (litemList == null)
            {
                litemList = new List<SizeItem>();
            }
            else
            {
                foreach (var item in litemList)
                {
                    //если такой размер уже указан 
                    if (item.Size == lsize)
                    {
                        isAvalable = false;
                    }
                }
            }

            if (isAvalable)
            {
                SizeItem lsizeItem = new SizeItem(lsizeId, lsize, lcount);
                litemList.Add(lsizeItem);
            }

            ViewState["CurrentSize"] = litemList;

            grdSize.DataBind();

        }

        protected void grdSize_DataBinding(object sender, EventArgs e)
        {
            grdSize.DataSource = CurrentSize;
        }

        protected void grdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //  int lID = (int)grdSize.DataKeys[e.RowIndex].Value;

            List<SizeItem> litemList = (List<SizeItem>)ViewState["CurrentSize"];


            if (litemList == null)
            {
                litemList = new List<SizeItem>();
            }
            else if (litemList.Count > 0)
            {
                litemList.RemoveAt(e.RowIndex);
            }

            ViewState["CurrentSize"] = litemList;
            grdSize.DataBind();
        }


    }
}