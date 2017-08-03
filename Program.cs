using System;
using System.Linq;
using OAuth2.Helpers;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OAuth2
{
    class Program
    {

        static readonly string authUrl = "https://id.winks.io/ids";
        static readonly string clientId = "#CLIENTID#";
        static readonly string clientSecret = "#CLIENTSECRET#";
        static readonly string companyName = "#CompanyName#";
        static readonly string callbackUrl = "#CALLBACKURL#";
		static readonly string refresh_token = "#REFRESH_TOKEN#";
        static string accessToken = "";

        static void Main(string[] args)
        {         
            GetStyle();
            Console.ReadLine();
        }

        public static dynamic GetStyle()
        {
            Console.WriteLine(String.Format("Loading Style API..."));

            //NEXT LINE RECIEVES REFRESH_TOKEN BY SENDING YOU TO THE LOGIN PAGE
            //var refresh_token = Auth.GetRefreshToken(authUrl, clientId, clientSecret, callbackUrl)?.RefreshToken;
     
            //AFTER WE HAVE THE REFRESH TOKEN WE CAN GET ACCESS TOKEN AND USE IT TO CALL API
            Console.WriteLine("Getting access token ...");
            accessToken = Auth.RefreshAccessToken(authUrl, clientId, clientSecret, refresh_token);

            Console.WriteLine("Listing Style folders ...");
            var client = new RestClient("https://developers.beproduct.com/");
            var request = new RestRequest("/api/" + companyName + "/Style/Folders", Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            var response = client.Execute<dynamic>(request);
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.Write(response.Content);
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            Console.WriteLine("List of styles from the first folder ...");
            request = new RestRequest("/api/" + companyName + "/Style/Headers?folderId=" + result[0]["id"] + "&pageSize=10&pageNumber=0", Method.POST);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { filters = new object[] { } });
            response = client.Execute<dynamic>(request);
            result = JsonConvert.DeserializeObject(response.Content);
            Console.Write(response.Content);
            Console.WriteLine("Press any key...");
            Console.ReadKey();


            Console.WriteLine("Listing pages of the first style ...");
            var headerid = result["result"][0]["id"];
            request = new RestRequest("/api/" + companyName + "/Style/Pages?headerId=" + headerid, Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            response = client.Execute<dynamic>(request);
            result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.Write(response.Content);
            Console.WriteLine("Press any key...");
            Console.ReadKey();


            Console.WriteLine("Getting first page of the first style ...");
            request = new RestRequest("/api/" + companyName + "/Style/Page?headerId=" + headerid + "&pageId=" + ((IEnumerable<dynamic>) result).First(i => i["id"] != Guid.Empty.ToString())["id"], Method.GET);

            request.AddHeader("Authorization", "Bearer " + accessToken);
            response = client.Execute<dynamic>(request);
            result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.Write(response.Content);


            Console.WriteLine("Yay!");

            Console.WriteLine("Press any key...");
            Console.ReadKey();
            return result;
        }


    }
}
