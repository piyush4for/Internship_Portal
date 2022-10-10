using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
#pragma warning disable CS0105 // Using directive appeared previously in this namespace
using System.Drawing;
#pragma warning restore CS0105 // Using directive appeared previously in this namespace


namespace commonCode
{

    public class ccc
    {

      
        

    

 
        public static void ExportToExcel(GridView GridView1 , string excelFileName)
        {
            HttpContext.Current.Response.Clear();
            
            HttpContext.Current.Response.Buffer = true;
            string filen = "attachment;filename=" + excelFileName + "_" + DateTime.Today.ToString("dd-MM-yyyy") + ".xls";
            HttpContext.Current.Response.AddHeader("content-disposition", filen);
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {

                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                //GridView1.AllowPaging = false;
                //this.BindGrid1();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }


                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Output.Write(sw.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            
        }


        public static DataTable QueryToDataTable(string query)
        {
            DataTable dtb1 = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
					cmd.CommandText = query;
					cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtb1);
                    }
                }                                        
            }

            return dtb1;
        }

        public static string QueryToString(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
                
            SqlCommand Qcom = new SqlCommand(query, conn);
            string Qresult = Qcom.ExecuteScalar().ToString();
            
            conn.Close();

            return Qresult;
        }

        public static int QueryToInt(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
                
            SqlCommand Qcom = new SqlCommand(query, conn);
            int Qresult = Convert.ToInt32(Qcom.ExecuteScalar().ToString());
            
            conn.Close();

            return Qresult;
        }

        public static void ExecuteQuery(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
                
            SqlCommand Qcom = new SqlCommand(query, conn);
            Qcom.ExecuteNonQuery();
            
            conn.Close();
        }

        public static bool IsEmpExist(string emp)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

                string CheckQuery = "select count(*) from empdetails WHERE EmpNo = '" + emp + "' and active='1'";
                SqlCommand CheckCom = new SqlCommand(CheckQuery, conn);
                int CheckValue = Convert.ToInt32(CheckCom.ExecuteScalar().ToString());

            conn.Close(); 

            if(CheckValue > 0)
                return true;
            else
                return false;
        }

        public static bool IsOdisha(string emp)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

                string CheckQuery = "SELECT count(*) FROM empdetails where active = '1' and EmpNo = '" + emp + "' and region = 'ER-II' and location in ('Angul' , 'Balasore' , 'Baripada' , 'Bhadrak' , 'Bhawanipatna' , 'Bhubaneswar' , 'Bolangir' , 'Boudh' , 'Brahmpur(Or)' , 'Cuttack' , 'Indravati' , 'Jeypore' , 'Kaniha' , 'Keonjhar' , 'Kishorenagar' , 'Nayagarh' , 'Pandiabilli' , 'Parlakhemundi' , 'Phulbani' , 'Rengali' , 'Rourkela' , 'Sambalpur' , 'Sakhigopal' , 'Sundergarh' , 'Uganda')";
                SqlCommand CheckCom = new SqlCommand(CheckQuery, conn);
                int CheckValue = Convert.ToInt32(CheckCom.ExecuteScalar().ToString());

            conn.Close(); 

            if(CheckValue > 0)
                return true;
            else
                return false;
        }

        public static string CheckLevel(string empNo)
        {
            string cat="";
            string level , desg;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

                string empQ = "select level from empdetails WHERE Empno = '" + empNo + "'";
                SqlCommand empQcom = new SqlCommand(empQ, conn);
                level = empQcom.ExecuteScalar().ToString();

                empQ = "select desg from empdetails WHERE Empno = '" + empNo + "'";
                empQcom = new SqlCommand(empQ, conn);
                desg = empQcom.ExecuteScalar().ToString();

            conn.Close();

            if(level == "E2" || level == "E2A" || level == "E3" || level == "E4")
                cat = "E2E4";
            else if(level == "E5" || level == "E6" || level == "E7" )
                cat = "E5E7";
            else if(level == "E8" || level == "E9" || level == "E9A" || level == "E9B" || level == "E9C")
            {
                if((desg).Substring(0, 2) == "Ch" || level == "E9" || level == "E9A" || level == "E9B" || level == "E9C")
                    cat = "CGME9";
                else
                    cat = "E8GMSrGM";
            }
            else if(level.Substring(0, 1) == "S")
                cat = "SUP";
            else if(level.Substring(0, 1) == "W")
                cat = "WORKMEN";
            return cat; 
        } 

        public static int LevelOrder(string empNo)
        { 
            string empLevel = ccc.QueryToString("select level from EmpDetails WHERE EmpNo = '" + empNo + "'");
            string empDesg = ccc.QueryToString("select desg from EmpDetails WHERE EmpNo = '" + empNo + "'");



            if(empLevel == "W0" || empLevel == "WT" || empLevel == "WTT")
                return 1;
            else if(empLevel == "W1")
                return 2;
            else if(empLevel == "W2")
                return 3;
            else if(empLevel == "W3")
                return 4;
            else if(empLevel == "W4")
                return 5;
            else if(empLevel == "W5")
                return 6;
            else if(empLevel == "W6")
                return 7;
            else if(empLevel == "W7")
                return 8;
            else if(empLevel == "W8")
                return 9;
            else if(empLevel == "W9")
                return 10;
            else if(empLevel == "W10")
                return 11;
            else if(empLevel == "W11")
                return 12;
            else if(empLevel == "WSG")
                return 13;
            else if(empLevel == "S1" || empLevel == "SDT" || empLevel == "ST")
                return 14;
            else if(empLevel == "S2")
                return 15;
            else if(empLevel == "S3")
                return 16;
            else if(empLevel == "S4")
                return 17;
            else if(empLevel == "SSG")
                return 18;
            else if(empLevel == "E2" || empLevel == "AET" || empLevel == "ET" || empLevel == "ET ")
                return 19;
            else if(empLevel == "E3")
                return 20;
            else if(empLevel == "E4")
                return 21;
            else if(empLevel == "E5")
                return 22;
            else if(empLevel == "E6")
                return 23;
            else if(empLevel == "E7" && (empDesg == "Principal Exe Secy" || empDesg.Substring(0, 1) == "D"))
                return 24;
            else if(empLevel == "E7"  && empDesg.Substring(0, 1) == "S")
                return 25;
            else if(empLevel == "E8"  && empDesg.Substring(0, 1) == "G")
                return 26;
            else if(empLevel == "E8"  && empDesg.Substring(0, 1) == "S")
                return 27;
            else if(empLevel == "E8"  && empDesg.Substring(0, 1) == "C")
                return 28;
            else if(empLevel == "E9")
                return 29;
            else if(empLevel == "E9A")
                return 30;
            else if(empLevel == "E9B")
                return 31;
            else if(empLevel == "E9C")
                return 32;
            else
                return 99; 


        }

       /*  public static int GetExperienceInYears(string empNo , DateTime endDate)
        {
            DateTime startDate = Convert.ToDateTime(ccc.QueryToString("SELECT TOP 1 StartDate FROM Experiences where empno = '600" + empNo + "' and Level not in ('AET' , 'ET' , 'SDT' , 'ST' , 'WT' , 'WTT' , 'ST Deptl' , 'ET Deptl' , 'AET Deptl') order by StartDate"));

            startDate = new DateTime(2020, 09, 11, 23, 59, 59);
            endDate = new DateTime(2021, 09, 11, 23, 59, 59);
            TimeSpan ts = endDate - startDate;
            int tyears = ts.Days;

 

            return tyears;
        }
 */

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static void ViewPDF(string sourceFilePath , string filename)
        {
            byte[] bytes = File.ReadAllBytes(sourceFilePath); 
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/pdf";
            string temp = "inline; filename="+filename+".pdf";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", temp );
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static String GetFYfromDate(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            if(Convert.ToInt32(month) > 3)
                return year + "-" + date.AddYears(1).ToString("yy");
            else
                return date.AddYears(-1).ToString("yyyy") + "-" + date.ToString("yy");
        }

        public static DataTable GetnFYfromDate(DateTime date , int n)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("FY")});
            
            for (int i = 0; i < n; i++) 
                dt.Rows.Add(GetFYfromDate(date.AddYears(-i)));
 
            return dt;
        }

        public static List<EmployeeDetails> getEmployees(string EmpNo)
        {
            List<EmployeeDetails> empObj = new List<EmployeeDetails>();
            string cs = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        com.CommandText = string.Format("select Empno,Name,Desg,Dept,Region from empdetails where active = 1 and (Empno like '{0}%' OR Name like '%{0}%')", EmpNo);
                        com.Connection = con;
                        con.Open();
                        SqlDataReader sdr = com.ExecuteReader();
                        EmployeeDetails emp = null;
                        while (sdr.Read())
                        {
                            emp = new EmployeeDetails
                            {
                                EmpDbKey = Convert.ToString(sdr["Empno"]),
                                EmpName = Convert.ToString(sdr["Name"]),
								EmpDesg = Convert.ToString(sdr["Desg"]),
                                EmpDept = Convert.ToString(sdr["Dept"]),
                                EmpRegion = Convert.ToString(sdr["Region"]),
                            };
                            empObj.Add(emp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error {0}", ex.Message);
            }
            return empObj;
        }

    }

    [Serializable]
    public class EmployeeDetails
    {
        public string EmpDbKey { get; set; }
        public string EmpName { get; set; }

        public string EmpDesg { get; set; }
        public string EmpDept { get; set; }
        public string EmpRegion { get; set; }

    }

    
    
}