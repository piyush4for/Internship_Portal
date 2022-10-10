using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;

namespace Intern
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strurltest = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
            WebRequest requestObjGet = WebRequest.Create(strurltest);
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
        }

            //var client = new RestClient("https://jsonplaceholder.typicode.com/posts/1/comments");
            //var request = new RestRequest("employees");
            //var response = client.Execute(request);
            //if(response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    string rawResponse = response.Content;
            //}

            //HttpClient client = new HttpClient();
            //Console.WriteLine("Calling WebAPI ...");
            //var responseTask client.GetAsync("https://azurewebapitestapp.azurewebsites.net/api/Message/Custom
            //responseTask.Wait();
            //if (responseTask.IsCompleted)
            //{
            //    I   
            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var messasgeTask result.Content.ReadAs StringAsync();
            //        messasgeTask.Wait();
            //        Console.WriteLine("Message from WebAPI:+messasgeTask.Result);
            
            //        Console.ReadLine();
            //    }
    }
}