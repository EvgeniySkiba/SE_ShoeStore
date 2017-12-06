using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeStore.Back_End
{
    public partial class SeasonalType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            GridView1.DataSource = ShoeStore.Data.Product.ProductSeasonal.GetSeason();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;
            if (e.NewValues["Name"] != null)
            {
                string lSeasonType = e.NewValues["Name"].ToString();

                bool lResult = ShoeStore.Data.Product.ProductSeasonal.UpdateSeasonalType(lID, lSeasonType);


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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;

            bool lResult = ShoeStore.Data.Product.ProductSeasonal.DeleteSeasonal(lID);

            if (!lResult)
            {
                lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                pnlError.Visible = true;
            }

            GridView1.DataBind();

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
        /// <summary>
        /// отображение формы для создания записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ChangeVisible();
            

        }

        /// <summary>
        /// create a new record in database  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxValue.Text.Length > 0)
            {
                string lSeasonName = tbxValue.Text;

                bool lResult = ShoeStore.Data.Product.ProductSeasonal.CreateNewSeason(lSeasonName);

                if (!lResult)
                {
                    lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                    pnlError.Visible = true;
                }
                else
                {
                    lblErrorDB.Text = "Данные успешно сохранены";
                    Response.Redirect("~//Back_End/SeasonalType.aspx");
                }
            }

        }
        /// <summary>
        /// возврат в режим отображения записей 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();
            Response.Redirect("~/Back_End/SeasonalType.aspx");
        }

        private void ChangeVisible()
        {
            pnlCreate.Visible = !pnlCreate.Visible;
            pnlColors.Visible = !pnlCreate.Visible;
        }


    }
}