using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UserRandom.Data.ExternalServices.Contracts;
using UserRandom.Data.ExternalServices.HttpClients;
using UserRandom.Domain.DTO;

namespace UserRandom.Data.ExternalServices
{
    public class RandomRepository : IRandomRepository
    {

        private readonly IConfiguration configuration;
        private readonly RandomUserHttpClient httpClient;

        public RandomRepository(IConfiguration configuration, RandomUserHttpClient httpClient)
        {
            this.configuration = configuration;
            this.httpClient = httpClient;
        }

        public async Task<RootObject> GetUsersRandom(int count)
        {
            httpClient.BaseAddress = new Uri("https://randomuser.me");
            var response = await httpClient.GetAsync(@$"/api/?results={count}");
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RootObject>(stringResult);

            return result;
        }
    }
}
