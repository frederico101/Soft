using Newtonsoft.Json;
using Soft.Bussiness.Models.Books;
using Soft.Bussiness.Models.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient _httpClient;
        private readonly IUserRepository _bookRepository;
        public UserServices(IUserRepository bookRepository, HttpClient httpClient)
        {
            _bookRepository = bookRepository;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_httpClient.BaseAddress = new Uri("http://localhost:50547/");
        }

        public async Task<string> GetUserAsync(User user)
        {
            try
            {
                 
                var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:50547/api/account/login", jsonContent);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(responseString);

                string token = result?.Token;
                if (string.IsNullOrEmpty(token))
                    throw new InvalidOperationException("Token is null or empty.");

                // Store the token for future requests
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return token;
            }
            catch (HttpRequestException httpEx)
            {
                throw new InvalidOperationException("Error making HTTP request", httpEx);
            }
        }

    }
}
