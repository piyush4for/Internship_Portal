using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intern
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strurltest = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
                WebRequest requestObjGet =  WebRequest.Create(strurltest);
                requestObjGet.Method = "GET";
                HttpWebResponse responseObjGet = null;
                responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();
                string strresulttest = null;    
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close(); 
            }

            //string strUrl = String.Format("https://isonplaceholder.typicode.com/posts");
            //WebRequest requestObjPost = WebRequest.Create(strUrl);
            //requestObjPost.Method = "POST";
            //requestObjPost.ContentType = "application/json";
            //string postData = "{\"title\":\"testdata\",\"body\":\"testbody\",\"userId\":\"50\"}";
            //using (var streamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            //{
            //    streamWriter.Write(postData);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //    var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();
            //    using (var streamReader = new StreamReader(requestObjPost.GetRequestStream()))
            //    {
            //        var result2 = streamReader.ReadToEnd();
            //    }

            //}

        }


    }
}
