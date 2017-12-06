using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ShoeStore.Back_End
{
    public partial class Admin : System.Web.UI.MasterPage
    {   /* пользователь  которому доступно регистрирование */
        private string UserName
        { get { return "evad"; } }

        protected override void OnPreRender(EventArgs e)
        {
          /* MembershipUser membershipUser = Membership.GetUser();

            //если не зарегистрирован
           if (membershipUser == null)
           {
               Response.Redirect("~/");
           }
            //если такой пользователь не имеет доступа
            if (membershipUser.UserName != UserName)
            {
                Response.Redirect("~/");
            }
            */
            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }
    }
}