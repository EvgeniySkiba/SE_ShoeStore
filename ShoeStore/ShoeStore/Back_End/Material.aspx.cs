using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeStore.Back_End
{
    public partial class Material : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }
           /// <summary>
           /// создание новой записи
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        /// <summary>
        /// сохранение изменений 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(tbxValue.Text.Length>0)
            {
                string lMaterialName  = tbxValue.Text;

                bool lResult = ShoeStore.Data.Product.ProductMaterial.CreateNewMaterial(lMaterialName);

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
                }

                Response.Redirect("~/Back_End/Material.aspx");
            }

        }

        /// <summary>
        /// отменить изменения и отобразить список достиупных материаллов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeVisible();
            Response.Redirect("~/Back_End/Material.aspx");
        }

        /// <summary>
        /// отмена вневенных значенний
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind(); 
        }


        private void ChangeVisible()
        {
            pnlCreate.Visible = !pnlCreate.Visible;
            pnlColors.Visible = !pnlCreate.Visible;
        }

        /// <summary>
        /// удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;

            bool lResult = ShoeStore.Data.Product.ProductMaterial.DeleteMaterial(lID);

            if (!lResult)
            {
                lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                pnlError.Visible = true;
            }

            Response.Redirect("~/Back_End/Material.aspx");

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        { 
            GridView1.DataBind();
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            GridView1.DataSource = ShoeStore.Data.Product.ProductMaterial.GetMaterial();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;
            if (e.NewValues["MaterialType"] != null)
            {
                string lMaterialType = e.NewValues["MaterialType"].ToString();

                int lResult = ShoeStore.Data.Product.ProductMaterial.UpdateMaterial(lID, lMaterialType);

                if (lResult == 2)
                {
                    lblErrorDB.Text = "Невозможно произвести удаление поскольку некоторые товары используют данное значение. Измените настройки и повторите попытку";
                    pnlError.Visible = true;
                }
                if (lResult == 1)
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
    }
}