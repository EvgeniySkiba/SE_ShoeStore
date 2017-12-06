using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQueryUploadTest;
using System.Configuration;
using System.IO;

namespace ShoeStore.Back_End
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        #region Global variable

        object selectedColor;
        string lphotoDirrName = "Photos";

        //корневая директория для фотографий
        string lpathPhotos;

        private List<SizeItem> CurrentSize
        {
            get
            {
                object obj = ViewState["CurrentSize"];
                if (obj == null)
                {
                    SizeItem lsizeItem = new SizeItem();
                   // lsizeItem.ID = 1;
                    lsizeItem.Size =0;
                    lsizeItem.Count = 1;

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string lConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();
                ColorDataSource.ConnectionString = lConnectionString;
                dsrcManufacture.ConnectionString = lConnectionString;
                dsrcMaterial.ConnectionString = lConnectionString;
                dsrcSex.ConnectionString = lConnectionString;
                dsrcSize.ConnectionString = lConnectionString;
                dsrcSeason.ConnectionString = lConnectionString;
                dsrcType.ConnectionString = lConnectionString;

            }

           
          //  grdSize.DataBind();


        }

        protected void drlColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // selectedColor = drlColors.SelectedItem.Value;
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string lname = string.Empty;
                lname = tbxName.Text;
                string lcode = tbxCode.Text;

                int lmanufactureId = Convert.ToInt32(ddlManufacture.SelectedItem.Value);
                int lcolorId = Convert.ToInt32(drlColors.SelectedItem.Value);
                int lmaterialId = Convert.ToInt32(ddlMaterial.SelectedItem.Value);
                int lsizeId = Convert.ToInt32(ddlSize.SelectedItem.Value);
                int lsexId = Convert.ToInt32(ddlSex.SelectedItem.Value);
                int lSeasonId = Convert.ToInt32(ddlSeason.SelectedItem.Value);
                int lTypeId = Convert.ToInt32(ddlTypeItem.SelectedItem.Value);
                // int lcount = Convert.ToInt32(tbxCount.Text);

                decimal lcost = Convert.ToDecimal(tbxCost.Text);
                string ldescription = string.Empty;
                ldescription = tbxDescription.Text;

                int lcount = 1;
                //if (tbxCount.Text.Length > 0)
               // {
               //     Int32.TryParse(tbxCount.Text, out lcount);
               // }

                int lsizeresult = 0;

                int lresult = 0;
                lresult = ShoeStore.Data.Product.Product.CreateProduct(lcolorId, lsizeId, lsexId, lmaterialId,
                    lmanufactureId, lSeasonId, lTypeId, lname, lcost, lcode, ldescription);

                fltInfo.Visible = true;
                if (lresult > 0)
                {
                    lblInfo.Text = "Данные успешно внесены в базу данных";                   
                    btnDownPicture.Visible = true;
                    Session["productID"] = lresult;

                    List<SizeItem> litemList = (List<SizeItem>)ViewState["CurrentSize"];

                    if (litemList != null && litemList.Count > 0)
                    {
                        foreach (var item in litemList)
                        {
                           ShoeStore.Data.Product.ProductSize.SetProductsSize(lresult,item.SizeId,item.Count);    
                        }
                    }
                }
                else
                {
                    lblInfo.Text = "В процесе сохранения произошла ошибка. Проверите правильлность заполнения полей и повторите попытку ";
                    //notified that an error has occurred 
                }

                


            }
            else
            {
                lblInfo.Text = "Проверьте правильность заполнения полей";
                lblInfo.Visible = true;
            }
        }

        /// <summary>
        /// загрузка фото 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreatePicture_Click(object sender, EventArgs e)
        {
            DirectoryInfo lcurrentDirectory = new DirectoryInfo(Request.MapPath("."));
            DirectoryInfo lrootDirectory = (lcurrentDirectory.Parent);


            lpathPhotos = string.Concat(lrootDirectory.FullName, "\\", lphotoDirrName);
            DirectoryInfo dir = new DirectoryInfo(lpathPhotos);

            object lproductIDobject = Session["productID"];

            int lproductID = (int)lproductIDobject;

            if (lproductID > 0)
            {

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
        }

        //добавить размер
        protected void btnAddSize_Click(object sender, EventArgs e)
        {
        //    int lsize = Convert.ToInt32(ddlSize.SelectedItem.Value);
            int lsizeId = Convert.ToInt32(ddlSize.SelectedItem.Value);
            int lsize = Convert.ToInt32(ddlSize.SelectedItem.Text);
            int lcount = Convert.ToInt32(tbxCountSize.Text);


            bool isAvalable = true;

            List<SizeItem> litemList = (List<SizeItem>)ViewState["CurrentSize"];

          

            if (litemList == null)
            {
                litemList = new List<SizeItem>();
            }
            else{
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
                SizeItem lsizeItem = new SizeItem(lsizeId,lsize,lcount);
                litemList.Add(lsizeItem);
            }    

            ViewState["CurrentSize"] = litemList;

            grdSize.DataBind();
            
        }

        protected void grdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int lID = (int)grdSize.DataKeys[e.RowIndex].Value;

            List<SizeItem> litemList = (List<SizeItem>)ViewState["CurrentSize"];

            if (litemList == null)
            {
                litemList = new List<SizeItem>();
            }
            else
            {
                litemList.RemoveAt(e.RowIndex);
            }   

            ViewState["CurrentSize"] = litemList;
            grdSize.DataBind();

        }

        protected void grdSize_DataBinding(object sender, EventArgs e)
        {
            grdSize.DataSource = CurrentSize;
        }
    }
}