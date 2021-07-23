using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.IO;

namespace CRUDManager
{
    public partial class MainWindow : Window
    {

        string serverUrl = "http://swirly.me";
        public void InitUserControl()
        {
            setWorkerGroupList();
        }

        public void setWorkerGroupList()
        {
            var dataGet_workerGroup = getData("/user/worker/group", null);
            var dataList = dataGet_workerGroup;
            foreach (var item in dataList)
            {
                comboxWorkerGroup.Items.Add(item["name"]);
            }
            comboxWorkerGroup.SelectedIndex = 0;
        }

        public void userTagCheck_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            if (getTag_Number.Trim().Equals(""))
            {
                MessageBox.Show("사용자 RFID TAG를 읽혀 주세요");
            }

            try
            {
                param.Add("tag_serial", getTag_Number);
                var dataGet_worker = getData("/user/worker/", param);

                var dataList_User = dataGet_worker["user"];
                Console.WriteLine(dataList_User["name"]);
                var dataList_worker = dataGet_worker["worker"];
                var dataList_Worker_group_code = dataList_worker["group_code"];
                var dataList_Worker_group_name = dataList_worker["group_name"];
                Console.WriteLine("dataList_Worker_group_code : " + dataList_Worker_group_code + " / dataList_Worker_group_name : " + dataList_Worker_group_name);

            }
            catch (Exception error)
            {
                Console.WriteLine("[ERROR] userTagCheck_Click : " + error.Message);
            }
            
        }


        public dynamic getData(string endpoint, Dictionary<string, string> param)
        {
            var client = new RestClient(serverUrl + endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            JArray newJArray = new JArray();
            JObject newJObject = new JObject();
            try
            {
                if (param != null)
                {
                    foreach (KeyValuePair<string, string> pair in param)
                    {
                        request.AddQueryParameter(pair.Key, pair.Value);
                    }
                    IRestResponse response = client.Execute(request);
                    newJObject = JObject.Parse(response.Content);
                    return newJObject;
                }
                else
                {
                    IRestResponse response = client.Execute(request);
                    newJArray = JArray.Parse(response.Content);
                    return newJArray;
                }
            } 
            catch(Exception error)
            {
                Console.WriteLine("[ERROR] GET REQUEST [ERROR] : " + error.Message);
                return 0;
            }
        }

        public dynamic postData(string endpoint, Dictionary<string, string> param)
        {
            var client = new RestClient(serverUrl + endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Authorization", ""); Authorization 값

            if (param != null)
            {
                foreach (KeyValuePair<string, string> pair in param)
                {
                    request.AddParameter(pair.Key, pair.Value, ParameterType.QueryString);
                }
            }
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        // 제네릭을 이용하여 Response 객체를 넘기면 자동으로 해당 객체로 변환하여 Return해줌
        public static T Request<T>(Method method, string endpoint, string subUrl, Dictionary<string, string> header = null, Dictionary<string, string> queryParameter = null, Dictionary<string, string> bodyParameter = null)
        {
            var serverUrl = "http://swirly.me";
            var restClient = new RestClient(serverUrl + endpoint);
            var request = new RestRequest(subUrl, method);

            // Timeout을 -1로 설정하면 무제한으로 설정한다는 뜻입니다.
            restClient.Timeout = -1;

            if (header != null)
            {
                request.AddHeaders(header);
            }

            if (queryParameter != null)
            {
                foreach (var pair in queryParameter)
                {
                    request.AddQueryParameter(pair.Key, pair.Value);
                }
            }

            if (method != Method.GET && bodyParameter != null)
            {
                foreach (var pair in bodyParameter)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }
            }

            // Response를 자동으로 T Type으로 변환해줍니다.
            var response = restClient.Execute<T>(request);

            return response.Data;
        }
    }
}
