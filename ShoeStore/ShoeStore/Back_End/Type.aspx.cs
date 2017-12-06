using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace ShoeStore.Back_End
{
    public partial class Type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  colorDataSource.ConnectionString = ShoeStore.Data.ShoeStoreDB.GetConnectionString();
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }



        private void BindDataTable()
        {
            DataSet ds = ShoeStore.Data.Product.ProductType.GetTypes();

            GridView1.DataSource = ds;
           // GridView1.DataMember = "TypeItem";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ChangeVisible();
            Response.Redirect("~//Back_End/Type.aspx");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (tbxValue.Text.Length > 0)
            {
                string ltype = Regex.Replace(tbxValue.Text, @"\W", "");
                ShoeStore.Data.Product.ProductType.AddType(ltype);

            }
            else
            {
                lblErrorDB.Text = "В процесе выполнения произошла ошибка. Повторите попытку позже";
                pnlError.Visible = true;
            }

            Response.Redirect("~//Back_End/Type.aspx");

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        private void ChangeVisible()
        {
            pnlCreate.Visible = !pnlCreate.Visible;
            pnlColors.Visible = !pnlCreate.Visible;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ltypeId = (int)GridView1.DataKeys[e.RowIndex].Value;
            int lResult = 1;

            if (ltypeId > 0)
            {
                lResult = ShoeStore.Data.Product.ProductType.DeleteType(ltypeId);
            }
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


            Response.Redirect("~//Back_End/Type.aspx");
            GridView1.DataBind();

        }


        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            BindDataTable();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int lID = (int)GridView1.DataKeys[e.RowIndex].Value;
            if (e.NewValues["TypeItem"] != null)
            {
                string lcolorname = e.NewValues["TypeItem"].ToString();


                lcolorname = Regex.Replace(e.NewValues["TypeItem"].ToString(), @"\W", "");
                bool lResult = ShoeStore.Data.Product.ProductType.EditType(lID, lcolorname);

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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }
    }
}