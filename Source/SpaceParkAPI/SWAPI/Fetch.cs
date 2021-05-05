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
                List<T> result = new List<T>();

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
        public static Task<List<Person>> People(int? input = null)
        {
            string requestUrl = RequestURLs.People;
            if (input != null)
            {
                requestUrl += $"?search={input}";
            }

            return Fetch.Data<Person>(requestUrl);
        }

        //Fetch Starships from API
        public static Task<List<Starship>> Starships(int? input = null)
        {
            string requestUrl = RequestURLs.Starships;

            if(input != null)
            {
                requestUrl += $"?search={input}";
            }

            return Fetch.Data<Starship>(requestUrl);
        }
    }
}
