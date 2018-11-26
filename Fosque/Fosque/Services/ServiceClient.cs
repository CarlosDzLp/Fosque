using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fosque.Services
{
    public class ServiceClient
    {
        public async Task<T> GetListAllWithParam<T>(string BaseUrl, string where)
        {
            try
            {
                if(string.IsNullOrEmpty(where))
                {
                    Console.WriteLine("where empty");
                    return default(T);
                }
                string url = where;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseUrl);

                var response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deserializer = JsonConvert.DeserializeObject<T>(responseString);
                    return deserializer;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return default(T);
        }

    }
}
