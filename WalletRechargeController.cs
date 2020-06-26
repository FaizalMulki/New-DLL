using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Vigilance.Web;

namespace OrchestratorAsset.Web.Controllers
{
    
    public class WalletRechargeController : Controller
    {
        // GET: WalletRecharge
        public ActionResult Recharge()
        {
            return View();
        }

        //public string GetData()
        //{


        //        var URL = 'some url';
        //        var json = new StringBuilder();

        //        json.Append("\"flag\": \"" + "RECH" + "\",");
        //        json.Append("\"vrn\": \"KA19\",");
        //        json.Append("\"rechargeTxnid\": \"1234\",");
        //        json.Append("\"rechargeAmt\": \"200.00\"");
        //        var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
        //        var client = new HttpClient();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        try
        //        {
        //            var response = await client.PostAsJsonAsync(URL, data);
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            return result;
        //        }
        //        catch (Exception e)
        //        {

        //            return "Exception" + e.Message;
        //        }

        //    }


        public void GetData()
        {

            try
            {
                string ContactUs = "https://125.19.66.195/kbxwnetc/RechargeCustomerAccount";
                string MyProxyHostString = "172.16.240.153";
                int MyProxyPort = 8080;
                var request = (HttpWebRequest)WebRequest.Create(ContactUs);
                request.Proxy = new WebProxy(MyProxyHostString, MyProxyPort);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                RequestClass obj = new RequestClass();

                obj.flag = "RECH";
                obj.etcCustId = "";
                obj.vrn = "KA19";
                obj.rechargeTxnid = "1234";
                obj.rechargeAmt = "120.00";

                string json = JsonConvert.SerializeObject(obj);
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                requestWriter.Write(json);
                requestWriter.Close();
                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();
                responseReader.Close();
                request.GetResponse().Close();
                return "";
            }
            catch(Exception e)
            {
                var k = e.Message;
            }
        }



    }

    public class RequestClass
    {
        public string flag { get; set; }
        public string vrn { get; set; }
        public string etcCustId { get; set; }
        public string rechargeTxnid { get; set; }
        public string rechargeAmt { get; set; }
    }
}