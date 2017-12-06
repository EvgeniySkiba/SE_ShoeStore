using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ShoeStore.Back_End
{
    public partial class Manufacture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;

            if (!IsPostBack)
            {

                GridView1.DataBind();
                clrCreationDate.SelectedDate = DateTime.Now;  
            }
        }


        /// <summary>
        /// отображение формы создания новой записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        private void ChangeVisible()
        {
            pnlCreate.Visible = !pnlCreate.Visible;
            pnlColors.Visible = !pnlCreate.Visible;
        }



        /// <summary>
        ///  создание новой записи 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string lCompanyName = tbxValue.Text;
                string lCountryName = tbxCountry.Text;
                DateTime lCreationDate = clrCreationDate.SelectedDate;
                string lCode = tbxCode.Text;
                string lDescription = tbxDescription.Text;

                bool lResult = ShoeStore.Data.Product.Manufacture.CreateNewManufacture(lCompanyName, lCountryName, lCode, lCreationDate, lDescription);

                if (!lResult)
                {
                    lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                    pnlError.Visible = true;
                }
                else
                {
                    lblErrorDB.Text = "Данные успешно сохранены";
                    pnlError.Visible = true;

                    tbxValue.Text = string.Empty;
                    tbxCountry.Text = string.Empty;
                    clrCreationDate.SelectedDate = DateTime.Now;
                    tbxCode.Text = string.Empty;
                    tbxDescription.Text = string.Empty;
                }
            }
            Response.Redirect("~/Back_End/Manufacture.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();
            Response.Redirect("~/Back_End/Manufacture.aspx");
        }



        private void GridBind()
        {

        }



        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            // GridBind();
            GridView1.DataSource = ShoeStore.Data.Product.Manufacture.GetManufacture();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //  GridBind();
            GridView1.DataBind();
        }

        /// <summary>
        /// отмена внесенных в таблицу изменений 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;

            int lResult = ShoeStore.Data.Product.Manufacture.DeleteManufacture(lID);

            if (lResult==2)
            {
                lblErrorDB.Text = "Невозможно произвести удаление поскольку некоторые товары используют данное значение. Измените настройки и повторите попытку";
                pnlError.Visible = true;
            }
            if (lResult == 1)
            {
                lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                pnlError.Visible = true;
            }

            GridView1.DataBind();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {



        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;
            if (e.NewValues["Name"] != null && e.NewValues["Country"] != null && e.NewValues["CreationDate"] != null && e.NewValues["Code"] != null && e.NewValues["Description"] != null)
            {
                string lCompanyName = e.NewValues["Name"].ToString();
                lCompanyName = Server.HtmlEncode(lCompanyName);
                
                string lCountryName =  Regex.Replace(e.NewValues["Country"].ToString(), @"\W", "");

                string lCode = e.NewValues["Code"].ToString();
                lCode = Server.HtmlEncode(lCode);

                DateTime lCreateDate = Convert.ToDateTime(e.NewValues["CreationDate"]);
                
                string lDescription = e.NewValues["Description"].ToString();

                lDescription = Server.HtmlEncode(lDescription);


                bool lResult = ShoeStore.Data.Product.Manufacture.UpdateManufacture(lID, lCompanyName, lCountryName, lCode, lCreateDate, lDescription);


                if (!lResult)
                {
                    lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                    pnlError.Visible = true;
                }
                else
                {
                    GridView1.EditIndex = -1;
                    GridView1.DataBind();
                }

            }
            else
            {
                lblErrorDB.Text = "Поля обязательны для заполнения. Заполнитие редактируемые поля или отмените редактирование";
                pnlError.Visible = true;
            }


        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

    }
}