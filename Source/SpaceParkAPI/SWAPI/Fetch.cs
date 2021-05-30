using RestSharp;
using SpaceParkAPI.SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkAPI.SWAPI
{
    public static class Fetch
    {
        private const string _baseURL = "http://swapi.dev/api/";
        private struct RequestURLs
        {
            internal static string People = "http://swapi.dev/api/people/";
            internal static string Starships = "http://swapi.dev/api/starships/";
        }

        // Generic method for fetching data from the API (swapi.com)
        public static async Task<List<T>> Data<T>(string requestUrl)
        {
            try
            {
                var client = new RestClient(_baseURL);
                APIResponse<T> response;
                List<T> result = new();

                while (requestUrl != null)
                {
                    string resource = requestUrl.Substring(_baseURL.Length);
                    var request = new RestRequest(resource, DataFormat.Json);
                    response = await client.GetAsync<APIResponse<T>>(request);

                    result.AddRange(response.Results);
                    requestUrl = response.Next;
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //Fetch people from API
        public async static Task<List<Person>> People(string name = null)
        {
            string requestUrl = RequestURLs.People;
            if (name != null)
            {
                requestUrl += $"?search={name}";
            }

            return await Fetch.Data<Person>(requestUrl);
        }

        //Fetch Starships from API
        public async static Task<List<Starship>> Starships(string name = null)
        {
            string requestUrl = RequestURLs.Starships;

            if (name != null)
            {
                requestUrl += $"?search={name}";
            }

            return await Fetch.Data<Starship>(requestUrl);
        }
    }
}
