using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rest;
using RestSharp;
using SAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using RestClient = RestSharp.RestClient;

namespace SAL
{
    public class comunication
    {
        public List<AppViewModel> GetAppList()
        {
            List<AppViewModel> Applist = new List<AppViewModel>();
            string Url = WebConfigurationManager.AppSettings["WebUrl"];
            string AuthCode = WebConfigurationManager.AppSettings["AuthCode"];

            var client = new RestClient(Url);
            client.Timeout = 4000;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic " + AuthCode);
            IRestResponse response = client.Execute(request);
            try
            {
                var result = response.Content.ToString();
                Applist = JsonConvert.DeserializeObject<List<AppViewModel>>(result);
            }
            catch (Exception EX)
            {
                //write exception log here
                return Applist;
            }
            return Applist;
        }

        public bool CreateNewApp(AddNewApp Request)
        {
            bool Issuccess = false;
            try
            {
                List<AppViewModel> Applist = new List<AppViewModel>();
                string Url = WebConfigurationManager.AppSettings["WebUrl"];
                string AuthCode = WebConfigurationManager.AppSettings["AuthCode"];
                var client = new RestClient(Url);
                client.Timeout = 1000;
                var request = new RestRequest(Method.POST);
                var jsonReq = new JavaScriptSerializer().Serialize(Request);
                request.AddParameter("application/json", jsonReq, ParameterType.RequestBody);
                request.AddHeader("Authorization", "Basic " + AuthCode);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {
                Issuccess = false;
            }
            return Issuccess;
        }

        public AppViewModel GetAppByAppID(string AppID)
        {
            AppViewModel AppDetils = new AppViewModel();
            try
            {

                var request = new RestRequest(Method.GET);
                string Url = WebConfigurationManager.AppSettings["WebUrl"];
                string AuthCode = WebConfigurationManager.AppSettings["AuthCode"];
                var client = new RestClient(Url + "/" + AppID);
                client.Timeout = 1000;
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Basic " + AuthCode);
                IRestResponse response = client.Execute(request);
                var result = response.Content.ToString();
                AppDetils = JsonConvert.DeserializeObject<AppViewModel>(result);
            }
            catch (Exception e)
            {
            }
            return AppDetils;
        }

        public bool UpdateApp(UpdateApp UpdateRequest, string AppID)
        {
            bool Issuccess = false;
            try
            {
                var request = new RestRequest(Method.PUT);
                string Url = WebConfigurationManager.AppSettings["WebUrl"];
                string AuthCode = WebConfigurationManager.AppSettings["AuthCode"];
                var client = new RestClient(Url + "/" + AppID);
                client.Timeout = 1000;

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Basic " + AuthCode);
                var jsonReq = new JavaScriptSerializer().Serialize(UpdateRequest);
                request.AddParameter("application/json", jsonReq, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {
                Issuccess = false;
            }
            return Issuccess;
        }
    }
}
