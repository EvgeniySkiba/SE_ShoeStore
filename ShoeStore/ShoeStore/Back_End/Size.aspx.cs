using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ShoeStore.Back_End
{
    public partial class Size : System.Web.UI.Page
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
            DataTable lTable = ShoeStore.Data.Product.ProductSize.GetSeason().Tables[0];
            GridView1.DataSource = lTable;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;
            if (e.NewValues["Size"] != null)
            {
                string lSize = e.NewValues["Size"].ToString();

                bool lResult = ShoeStore.Data.Product.ProductSize.UpdateSize(lID, lSize);


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

            int lResult = ShoeStore.Data.Product.ProductSize.DeleteSize(lID);

            if (lResult == 1)
            {
                lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                pnlError.Visible = true;
            }
            if (lResult == 2)
            {
                lblErrorDB.Text = "Невозможно произвести удаление поскольку некоторые товары используют данное значение. Измените настройки и повторите попытку";
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
            GridView1.EditIndex = -1;
            GridView1.DataBind();
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
                string lSize = tbxValue.Text;

                bool lResult = ShoeStore.Data.Product.ProductSize.CreateNewSize(lSize);

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
        }

        private void ChangeVisible()
        {
            pnlCreate.Visible = !pnlCreate.Visible;
            pnlColors.Visible = !pnlCreate.Visible;
        }



        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //  GridView1.Sort(e.SortExpression, e.SortDirection); 

            DataTable dt =  ShoeStore.Data.Product.ProductSize.GetSeason().Tables[0];

            string sd = string.Empty;

            if (e.SortDirection == SortDirection.Ascending)
            {
                sd = "ASC";
            }
            else
            {
                sd = "DESC";
            }

            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                dataView.Sort = e.SortExpression + " " + sd;

                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }


        }


    }
}