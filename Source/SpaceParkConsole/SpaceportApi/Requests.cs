using RestSharp;
using SpaceParkConsole.SpaceportApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkConsole.SpaceportApi
{
    public class Requests
    {
        private const string _baseURL = "https://localhost:44360/api";

        // Generic method for fetching data from the API (SpacePark API)
        public static async Task<List<T>> Get<T>(string requestUrl)
        {
            var client = new RestClient(_baseURL);

            var request = new RestRequest(requestUrl, DataFormat.Json);

            return await client.GetAsync<List<T>>(request);
        }

        public static async Task PostParking(string personName, string starshipsname, int spaceportId)
        {
            var postParking = new PostParking()
            {
                Traveller = personName,
                StarShip = starshipsname,
                SpaceportId = spaceportId
            };

            var client = new RestClient(_baseURL);
            var request = new RestRequest("/Parkings/");
            request.AddJsonBody(postParking);

            try
            {
                await client.PostAsync<PostParking>(request);

            }
            catch (Exception e)
            {
                // log the error?
                // do error handling stuff?
                throw; // remove?
            }
        }
    }
}
