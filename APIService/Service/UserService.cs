using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.APIService.Model.Request;
using AssetManagement.APIService.Model.Response;
using AssetManagement.Core.API;
using AssetManagement.Model;
using AssetManagement.Service.Constant;
using AssetManagement.Service.Model.Request;
using AssetManagement.Service.Model.Response;
using Core.ShareData;
using OpenQA.Selenium.DevTools.V123.FedCm;
using RestSharp;

namespace AssetManagement.Service.Service
{
    public class UserService
    {
        private readonly APIClient _client;
        public UserService(APIClient client)
        {
            _client = client;
        }
        public async Task<RestResponse<GenerateTokenResponseDto>> GenerateToken(string username, string password)
        {
            GenerateTokenRequestDto request = new()
            {
                Username = username,
                Password = password
            };
            return await _client.CreateRequest(String.Format(EndpointConstant.GenerateTokenEndpoint))
                .AddContentTypeHeader("application/json")
                .AddBody(request)
                .ExecutePostAsync<GenerateTokenResponseDto>();
        }
        public async Task<RestResponse<CreateAccountResponseDto>> CreateAccount(CreateAccountRequestDto request, string token)
        {
            return await _client.CreateRequest(String.Format(EndpointConstant.CreateUserEndpoint))
                .AddContentTypeHeader("application/json")
                .AddBody(request)
                .AddAuthorizationHeader(token)
                .ExecutePostAsync<CreateAccountResponseDto>();
        }
        public async Task<RestResponse<ChangePasswordResponseDto>> ChangePassword(string oldPassword, string newPassword, string token)
        {
            ChangePasswordRequestDto request = new ChangePasswordRequestDto()
            {
                OldPassword = oldPassword,
                NewPassword = newPassword
            };
            return await _client.CreateRequest(String.Format(EndpointConstant.ChangePasswordEndpoint))
                .AddContentTypeHeader("application/json")
                .AddAuthorizationHeader(token)
                .AddBody(request)
                .ExecutePostAsync<ChangePasswordResponseDto>();
        }
        // public async Task StoreUserToken(string accountKey, string username, string password)
        // {
        //     if (DataStorage.GetData(accountKey) is null)
        //     {
        //         var response = await GenerateToken(username, password);
        //         response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        //         var result = (dynamic)JsonConvert.DeserializeObject(response.Content);
        //         DataStorage.SetData(accountKey, result["token"]);
        //     }
        // }
        // public string GetUserToken(string accountKey)
        // {
        //     if (DataStorage.GetData(accountKey) is null)
        //     {
        //         throw new Exception("Token is not stored with account " + accountKey);
        //     }

        //     return DataStorage.GetData(accountKey).ToString();
        // }

    }
}