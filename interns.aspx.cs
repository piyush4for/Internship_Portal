using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using commonCode;



namespace Intern
{
    public partial class interns : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] == null)
                Response.Redirect("login.aspx?x=/interns.aspx");
            Label_welcome.Text = "Welcome " + ccc.QueryToString("select Name from EmpDetails WHERE EmpNo = '" + Session["New"].ToString() + "'");

            if (!this.IsPostBack)
            {
                int CheckAdmin = ccc.QueryToInt("select count(*) from HRDPortal_Intern_AdminRights WHERE EmpNo = '" + Session["New"].ToString() + "'");
                if (CheckAdmin != 0)
                  AButton.Visible = true;



            }

        }



        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("https://hrd.powergrid.in");
        }

        protected void H_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://hrd.powergrid.in");
        }

        protected void R_Click(object sender, EventArgs e)
        {
            Response.Redirect("YourRequests.aspx");
        }

        protected void N_Click(object sender, EventArgs e)
        {
            Response.Redirect("request.aspx");
        }

        protected void A_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void STNA_Click(object sender, EventArgs e)
        {
            Response.Redirect("subOrdinates.aspx");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

    }
}