using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using commonCode;

namespace Intern
{

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                if (Request.QueryString["x"] != null)
                    Response.Redirect(Request.QueryString["x"]);
                else
                    Response.Redirect("request.aspx");
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            int result= ccc.QueryToInt("select count(*) from empdetails where Empno='" + txtuser1.Text + "' and password='"+txtpass1.Text+"'");

            if (result > 0)
            {
                Session["New"] = txtuser1.Text;
                if (Request.QueryString["x"] != null)
                    Response.Redirect(Request.QueryString["x"]);
                else
                    Response.Redirect("request.aspx");
            }

            else
            {
                Label1.Text = "*Login unsuccessful. Please try Again.";
            }
        }

    }
}









