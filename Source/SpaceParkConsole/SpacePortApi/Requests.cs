using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SpaceParkConsole.SpacePortApi.Models;
//using RestSharp.Serialization.Json;
//using System.Net;

namespace SpaceParkConsole.SpacePortApi
{
    public class Requests
    {
        private const string _baseURL = "https://localhost:5001/api/";

        // Generic method for fetching data from the API (SpacePark API)
        public static async Task<List<T>> Get<T>(string requestUrl)
        {
            var client = new RestClient(_baseURL);
            
            var request = new RestRequest(requestUrl, DataFormat.Json);

            return await client.GetAsync<List<T>>(request);
        }

        public static async Task PostParking(string personName, string starshipsname, int spacePortId)
        {
            var client = new RestClient(_baseURL);

            var request = new RestRequest("Parking/");

            // Json to post.
            var postParking = new PostParking()
            {
                Traveller = personName,
                StarShip = starshipsname,
                SpacePortId = spacePortId
            };

            request.AddJsonBody(postParking);

            var response = await client.PostAsync<PostParking>(request);

            //string jsonParking = (new JsonSerializer()).Serialize(postParking);

            //request.AddParameter("application/json; charset=utf-8", jsonParking, ParameterType.RequestBody);
            //request.RequestFormat = DataFormat.Json;

            //try
            //{
            //    client.ExecuteAsync(request, response =>
            //    {
            //        if (response.StatusCode == HttpStatusCode.OK)
            //        {
            //            // OK
            //        }
            //        else
            //        {
            //            // NOK
            //        }
            //    });
            //}
            //catch (Exception error)
            //{
            //    // Log
            //}
        }


    }
}
