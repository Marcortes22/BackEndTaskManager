using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Services.Auth0.Dto;
using Domain.Utils;

namespace Infrastructure.Services.Auth0
{
    public class Auth0Service : IAuth0Service
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        public Auth0Service(IConfiguration configuration, IHttpClientFactory httpClientFactory) {

            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<UserInfoDto> getUserInformation(string token)
        {
            //var auth0Settings = _configuration.GetSection("Auth0");
            var auth0Domain = _configuration["Auth0Domain"];
           

            if (string.IsNullOrEmpty(auth0Domain))
            {
                throw new Exception("Auth0 domain configuration is missing or invalid.");
            }

            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{auth0Domain}/userinfo");

            request.Headers.Add("Authorization", "Bearer " + token);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
 
                var userInfo = await response.Content.ReadFromJsonAsync<UserInfoDto>();

                if (userInfo != null)
                {
                    
                    (string subProvider, string sub) = StringFunctions.SplitAuth0Indentity(userInfo.sub);
                    
                    userInfo.sub = sub;
                    userInfo.provider = subProvider;
                    return userInfo;
                }
            }
            else
            {
               
                throw new Exception("Error fetching user information from Auth0.");
            }

            return null;
        }
    }
}
