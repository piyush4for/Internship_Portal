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
    public partial class admin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] == null)
                Response.Redirect("login.aspx?x=/admin.aspx");
            Label_welcome.Text = "Welcome " + ccc.QueryToString("select Name from EmpDetails WHERE EmpNo = '" + Session["New"].ToString() + "'");

            if (!this.IsPostBack)
            {
                int CheckAdmin = ccc.QueryToInt("select count(*) from HRDPortal_Intern_AdminRights WHERE EmpNo = '" + Session["New"].ToString() + "'");
                if (CheckAdmin == 0)
                    Response.Redirect("request.aspx");
                this.BindGrid1();
            }


        }
        protected void TransferButton_Click(object sender, EventArgs e)
        {
            Label2.Visible = false;
            if (ccc.QueryToString("select right(RightsType,2) from HRDPortal_Intern_AdminRights where empno ='" + Session["New"].ToString() + "'") ==  "L1")
            {
                ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Request In-Process (L2)' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'"); ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Request In-Process (L2)' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'");
                ccc.ExecuteQuery("update HRDPortal_Internship_Data set hrdremark1='" + TextBoxR.Text + "' where iid='" + Label2.Text + "'");

                this.BindGrid1();
            }
            if (ccc.QueryToString("select right(RightsType,2) from HRDPortal_Intern_AdminRights where empno ='" + Session["New"].ToString() + "'") == "L2")
            {
                ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Finish' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'"); ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Request In-Process (L2)' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'");
                ccc.ExecuteQuery("update HRDPortal_Internship_Data set hrdremark1='" + TextBoxR.Text + "' where iid='" + Label2.Text + "'");
                    
                this.BindGrid1();
            }

        }
            private void BindGrid1()
        {
            
              GridView2.DataSource = ccc.QueryToDataTable("select iid , ('Name : ' + prefix + iname + '<br/><br/>Email : ' + iemail + '<br/><br/>phone number ' + iphone + '<br/><br/>Course : ' + course + '<br/><br/>Branch  : ' + branch + '<br/><br/>Institute : ' + institute ) as Student , (CAST((DATEDIFF(day,sdate,edate)+1) AS varchar) + ' days'+'<br/>Start Date: ' + CONVERT(VARCHAR, sdate, 101) +' <br><br> End Date: ' + CONVERT(VARCHAR,edate,101)) as period , ('Status: '+ status + '<br/></br>Region: '+ region + '<br/><br/>Preferred Guide: '+ pguide +'<br/><br/>Your Remarks: ' + remarks) as status  from HRDPortal_Internship_Data where region in (select substring(RightsType,1,len(RightsType)-3) FROM HRDPortal_Intern_AdminRights where empno = '" + Session["New"].ToString() + "')" );
            /*
            GridView2.DataSource = ccc.QueryToDataTable("select iid , ('Name : ' + prefix + iname + '<br/><br/>Email : ' + iemail + '<br/><br/>phone number ' + iphone + '<br/><br/>Course : ' + course + '<br/><br/>Branch  : ' + branch + '<br/><br/>Institute : ' + institute ) as Student , (CAST((DATEDIFF(day,sdate,edate)+1) AS varchar) + ' days'+'<br/>Start Date: ' + CONVERT(VARCHAR, sdate, 101) +' <br><br> End Date: ' + CONVERT(VARCHAR,edate,101)) as period , ('Status: '+ status + '<br/></br>Region: '+ region + '<br/><br/>Preferred Guide: '+ pguide +'<br/><br/>Your Remarks: ' + remarks) as status  from (select * from HRDPortal_Internship_Data where region=(SELECT RightsType FROM HRDPortal_Intern_AdminRights where empno=(select pguide from HRDPortal_Internship_Data where iid='"+Label2.Text+"')))");
            */

            //GridView1.DataSource = ccc.QueryToDataTable("select * from HRDPortal_Internship_Data where requestBy='" + Session["New"].ToString() + "'");
            GridView2.DataBind();
            //LinkButton1.Visible = false;
        }
        protected void GridView_RowCommand2(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridView2.Rows[rowIndex];

            string iid = row.Cells[0].Text;
            Label2.Text = iid;

            if (e.CommandName == "Select1")
            {

                string sourceFilePath = Server.MapPath("~/Internship/Files//") + ccc.QueryToString("select collegeID from HRDPortal_Internship_Data where iid = '" + iid + "'");


                ccc.ViewPDF(sourceFilePath, "collegeID");
            }
            if (e.CommandName == "Select2")
            {

                string sourceFilePath = Server.MapPath("~/Internship/Files//") + ccc.QueryToString("select collegeletter from HRDPortal_Internship_Data where iid = '" + iid + "'");

                ccc.ViewPDF(sourceFilePath, "collegeLetter");
            }
            if (e.CommandName == "Select3")
            {

                string sourceFilePath = Server.MapPath("~/Internship/Files//") + ccc.QueryToString("select cv from HRDPortal_Internship_Data where iid = '" + iid + "'");

                ccc.ViewPDF(sourceFilePath, "CV");
            }
            if (e.CommandName == "EditButton")
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "a()", true);
                if (ccc.QueryToString("select right(RightsType,2) from HRDPortal_Intern_AdminRights where empno =(select requestBy from HRDPortal_Internship_Data where iid= '" + iid + "')") == "L1")
                {
                    //ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Request In-Process (L2)' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'"); ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Request In-Process (L2)' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'");
                    //ccc.ExecuteQuery("update HRDPortal_Internship_Data set hrdremark1='" + TextBoxR.Text + "' where iid='" + Label2.Text + "'");
                    TransferButton.Text = "submit";
                    this.BindGrid1();
                }
                if (ccc.QueryToString("select right(RightsType,2) from HRDPortal_Intern_AdminRights where empno =(select requestBy from HRDPortal_Internship_Data where iid= '" + iid + "')") == "L2")
                {
                    //ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Finish' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'"); ccc.ExecuteQuery("update HRDPortal_Internship_Data set status='Request In-Process (L2)' where iid = '" + Label2.Text + "' and pguide= '" + TextBoxPG.Text.Substring(0, 5) + "'");
                    //ccc.ExecuteQuery("update HRDPortal_Internship_Data set hrdremark1='" + TextBoxR.Text + "' where iid='" + Label2.Text + "'");
                    TransferButton.Text = "Finish";
                    this.BindGrid1();
                }
                
                
                //this.setValues(iid);

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

        protected void I_Click(object sender, EventArgs e)
        {
            Response.Redirect("interns.aspx");
        }

        protected void N_Click(object sender, EventArgs e)
        {
            Response.Redirect("request.aspx");
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