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
    public partial class YourRequests : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] == null)
                Response.Redirect("login.aspx?x=/YourRequests.aspx");

            Label_welcome.Text = "Welcome " + ccc.QueryToString("select Name from empdetails WHERE EmpNo = '" + Session["New"].ToString() + "'");
            if (!this.IsPostBack)
            {
                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                int CheckAdmin = ccc.QueryToInt("select count(*) from HRDPortal_Intern_AdminRights WHERE EmpNo = '" + Session["New"].ToString() + "'");
                if (CheckAdmin != 0)
                    AButton.Visible = true;

                this.BindGrid1();



            }

        }
        protected void OnDChanged(object sender, EventArgs e)
        {
            DateTime StartDate;
            DateTime EndDate;

            if (DateTime.TryParse(TextBoxSD.Text, out StartDate) && DateTime.TryParse(TextBoxED.Text, out EndDate))
            {
                TextBoxD.Text = ((EndDate - StartDate).Days + 1).ToString();
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "a();", true);

        }

        protected void OnDaysChanged(object sender, EventArgs e)
        {
            DateTime StartDate;

            if (DateTime.TryParse(TextBoxSD.Text, out StartDate))
            {
                TextBoxED.Text = StartDate.AddDays(Int16.Parse(TextBoxD.Text) - 1).ToString("yyyy-MM-dd");
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "a();", true);

        }
        
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {
                string folderPath = Server.MapPath("~/Internship/Files/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string idfilename = Session["New"].ToString() + "_id_" + ccc.GetTimestamp(DateTime.Now) + ".pdf";
                string cletterfilename = Session["New"].ToString() + "_cletter_" + ccc.GetTimestamp(DateTime.Now) + ".pdf";
                string cvfilename = Session["New"].ToString() + "_cv_" + ccc.GetTimestamp(DateTime.Now) + ".pdf";

                string idpath = folderPath + idfilename;
                string cletterpath = folderPath + cletterfilename;
                string cvpath = folderPath + cvfilename;

                string ext1 = Path.GetExtension(FileUploadID.PostedFile.FileName);
                string ext2 = Path.GetExtension(FileUploadLOR.PostedFile.FileName);
                string ext3 = Path.GetExtension(FileUploadCV.PostedFile.FileName);

                if ((ext1 == ".pdf" || ext1 == ".PDF") && (ext2 == ".pdf" || ext2 == ".PDF") && (ext3 == ".pdf" || ext3 == ".PDF"))
                {
                    FileUploadID.SaveAs(idpath);
                    FileUploadLOR.SaveAs(cletterpath);
                    FileUploadCV.SaveAs(cvpath);

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                    conn.Open();
                    string iid = Label1.Text;
                    string tcollegeID = ccc.QueryToString("select collegeID from HRDPortal_Internship_Data where iid="+iid);
                    string tcollegeLOR = ccc.QueryToString("select collegeletter from HRDPortal_Internship_Data where iid= "+iid);
                    string tcollegeCV = ccc.QueryToString("select cv from HRDPortal_Internship_Data where iid="+iid);
                    string query = "update HRDPortal_Internship_Data set  prefix = @prefix, iname = @iname ,   iemail = @iemail ,   iphone = @iphone ,course = @course ,   branch = @branch ,   institute = @institute ,   sdate = @sdate ,   edate = @edate ,   pguide = @pguide , remarks = @remarks ,   status = @status , collegeID = @collegeID ,   collegeletter = @collegeletter ,   cv = @cv , requestBy = @requestBy , region = @region" + " where iid = @iid";
                    
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@iid", Label1.Text);
                    com.Parameters.AddWithValue("@prefix", DropDownListNP.SelectedValue);
                    com.Parameters.AddWithValue("@iname", TextBoxN.Text);
                    com.Parameters.AddWithValue("@iemail", TextBoxE.Text);
                    com.Parameters.AddWithValue("@iphone", TextBoxP.Text);
                    com.Parameters.AddWithValue("@course", DropDownListC.SelectedValue);
                    com.Parameters.AddWithValue("@branch", TextBoxB.Text);
                    com.Parameters.AddWithValue("@institute", TextBoxI.Text);
                    com.Parameters.AddWithValue("@sdate", TextBoxSD.Text);
                    com.Parameters.AddWithValue("@edate", TextBoxED.Text);
                    com.Parameters.AddWithValue("@pguide", (TextBoxPG.Text).Substring(0, 5));
                    com.Parameters.AddWithValue("@remarks", TextBoxR.Text);
                    com.Parameters.AddWithValue("@status", "Request In-Process");
                    if(FileUploadID.HasFile)
                        com.Parameters.AddWithValue("@collegeID", idfilename);
                    else
                        com.Parameters.AddWithValue("@collegeID", tcollegeID);
                    if(FileUploadLOR.HasFile)
                        com.Parameters.AddWithValue("@collegeletter", cletterfilename);
                    else
                        com.Parameters.AddWithValue("@collegeletter", tcollegeLOR);
                    if (FileUploadCV.HasFile)
                        com.Parameters.AddWithValue("@cv", cvfilename);
                    else
                        com.Parameters.AddWithValue("@cv", tcollegeCV);


                    com.Parameters.AddWithValue("@requestBy", Session["New"].ToString());
                    com.Parameters.AddWithValue("@region", DropDownList1R1.SelectedValue);

                    com.ExecuteNonQuery();

                    conn.Close();

                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "a();", true);




                }
                

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            }
        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            ccc.ExecuteQuery("delete from  HRDPortal_Internship_Data where iid = '" + Label1.Text + "'");
            this.BindGrid1();



        }
       

        private void BindGrid1()
        {
            GridView1.DataSource = ccc.QueryToDataTable("select iid , ('Name : ' + prefix + iname + '<br/><br/>Email : ' + iemail + '<br/><br/>phone number ' + iphone + '<br/><br/>Course : ' + course + '<br/><br/>Branch  : ' + branch + '<br/><br/>Institute : ' + institute ) as Student , (CAST((DATEDIFF(day,sdate,edate)+1) AS varchar) + ' days'+'<br/>Start Date: ' + CONVERT(VARCHAR, sdate, 101) +' <br><br> End Date: ' + CONVERT(VARCHAR,edate,101)) as period , ('Status: '+ status + '<br/></br>Region: '+ region + '<br/><br/>Preferred Guide: '+ pguide +'<br/><br/>Your Remarks: ' + remarks) as status  from HRDPortal_Internship_Data where requestBy='" + Session["New"].ToString() + "'");

            //GridView1.DataSource = ccc.QueryToDataTable("select * from HRDPortal_Internship_Data where requestBy='" + Session["New"].ToString() + "'");
            GridView1.DataBind();
            //LinkButton1.Visible = false;
        }
        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e) 
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridView1.Rows[rowIndex];

            string iid = row.Cells[0].Text;
            Label1.Text = ccc.QueryToString("select iid from HRDPortal_Internship_Data where iid=" + iid);
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
                this.setValues(iid);

            }
            
        }

        private void setValues(string iid)
        {
            Label1.Visible = false;

            DropDownListNP.Text = ccc.QueryToString("select prefix from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxN.Text = ccc.QueryToString("select iname from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxE.Text = ccc.QueryToString("select iemail from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxP.Text = ccc.QueryToString("select iphone from HRDPortal_Internship_Data where iid = '" + iid + "'");
            DropDownListC.Text = ccc.QueryToString("select course from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxB.Text = ccc.QueryToString("select branch from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxI.Text = ccc.QueryToString("select institute from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxSD.Text = ccc.QueryToString("select convert(varchar, sdate, 23) from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxD.Text = ccc.QueryToString("select DATEDIFF(DAY,sdate,edate)+1  from HRDPortal_Internship_Data where iid = '" + iid + "'");

            TextBoxED.Text = ccc.QueryToString("select distinct convert(varchar, edate, 23) from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxR.Text = ccc.QueryToString("select pguide from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxPG.Text = ccc.QueryToString("select pguide from HRDPortal_Internship_Data where iid = '" + iid + "'");
            DropDownList1R1.Text = ccc.QueryToString("select region from HRDPortal_Internship_Data where iid = '" + iid + "'");
            TextBoxR.Text = ccc.QueryToString("select remarks from HRDPortal_Internship_Data where iid = '" + iid + "'");
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

        protected void N_Click(object sender, EventArgs e)
        {
            Response.Redirect("request.aspx");
        }

        protected void I_Click(object sender, EventArgs e)
        {
            Response.Redirect("interns.aspx");
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