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
    public partial class request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
            if (Session["New"] == null)
                Response.Redirect("login.aspx?x=/request.aspx");

            Label_welcome.Text = "Welcome " + ccc.QueryToString("select Name from EmpDetails WHERE EmpNo = '" + Session["New"].ToString() + "'");

            if (!this.IsPostBack)
            {
                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());

                int CheckAdmin = ccc.QueryToInt("select count(*) from HRDPortal_Intern_AdminRights WHERE EmpNo = '" + Session["New"].ToString() + "'");
                if (CheckAdmin != 0)
                    AButton.Visible = true;

                TextBoxSD.Text = DateTime.Today.ToString("yyyy-MM-dd");
                TextBoxED.Text = DateTime.Today.AddDays(59).ToString("yyyy-MM-dd");
                TextBoxD.Text = "60";

            }

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

                if ((ext1 == ".pdf" || ext1 == ".PDF") && (ext2 == ".pdf" || ext2==".PDF") && (ext3 == ".pdf" || ext3 == ".PDF"))
                {
                    FileUploadID.SaveAs(idpath);
                    FileUploadLOR.SaveAs(cletterpath);
                    FileUploadCV.SaveAs(cvpath);

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                    conn.Open();

                    string query = "insert into HRDPortal_Internship_Data (prefix, iname, iemail, iphone, course, branch, institute, sdate, edate, pguide, remarks, status, collegeID, collegeletter, cv, requestBy, ts, region)" + " values (@prefix, @iname, @iemail, @iphone, @course, @branch, @institute, @sdate, @edate, @pguide, @remarks, @status, @collegeID, @collegeletter, @cv, @requestBy, GETDATE(), @region)";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@prefix", DropDownListNP.SelectedValue);
                    com.Parameters.AddWithValue("@iname", TextBoxN.Text);
                    com.Parameters.AddWithValue("@iemail", TextBoxE.Text);
                    com.Parameters.AddWithValue("@iphone", TextBoxP.Text);
                    com.Parameters.AddWithValue("@course", DropDownListC.SelectedValue);
                    com.Parameters.AddWithValue("@branch", TextBoxB.Text);
                    com.Parameters.AddWithValue("@institute", TextBoxI.Text);
                    com.Parameters.AddWithValue("@sdate", TextBoxSD.Text);
                    com.Parameters.AddWithValue("@edate", TextBoxED.Text);
                    com.Parameters.AddWithValue("@pguide", (TextBoxPG.Text).Substring(0,5));
                    com.Parameters.AddWithValue("@remarks", TextBoxR.Text);
                    com.Parameters.AddWithValue("@status", "Request In-Process (L1)");
                    com.Parameters.AddWithValue("@collegeID", idfilename);
                    com.Parameters.AddWithValue("@collegeletter", cletterfilename);
                    com.Parameters.AddWithValue("@cv", cvfilename);
                    com.Parameters.AddWithValue("@requestBy", Session["New"].ToString());
                    com.Parameters.AddWithValue("@region", DropDownList1R1.SelectedValue);

                    com.ExecuteNonQuery();

                    conn.Close();

                    modalH.InnerText = "Request Submitted Successfully !!";
                    modalP.InnerText = "";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "a();", true);




                }
                else
                {
                    lpdf.Visible = true;
                }

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
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

        }

        protected void OnDaysChanged(object sender, EventArgs e)
        {
            DateTime StartDate;

            if (DateTime.TryParse(TextBoxSD.Text, out StartDate))
            {
                TextBoxED.Text = StartDate.AddDays(Int16.Parse(TextBoxD.Text) - 1).ToString("yyyy-MM-dd");
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

        protected void A_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        [WebMethod]
        public static List<EmployeeDetails> getEmployees(string EmpNo)
        {
            return ccc.getEmployees(EmpNo);
        }
    }
}

