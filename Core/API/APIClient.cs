using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp.Authenticators.OAuth2;

namespace AssetManagement.Core.API
{
    public class APIClient
    {
        private readonly RestClient _restClient;
        public RestRequest Request;
        private RestClientOptions _requestOptions;

        public APIClient(RestClient restClient)
        {
            _restClient = restClient;
            Request = new RestRequest();
        }
        public APIClient(string url)
        {
            _restClient = new RestClient(url);
            Request = new RestRequest();
        }

        public APIClient(RestClientOptions requestOptions)
        {
            _restClient = new RestClient(requestOptions, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
        }

        public APIClient SetBasicAuthentication(string username, string password)
        {
            _requestOptions.Authenticator = new HttpBasicAuthenticator(username, password);
            return this;
        }

        public APIClient SetOAuth2Authentication(string accessToken)
        {
            _requestOptions.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken);
            return this;
        }

        public APIClient SetRequestTokenAuthentication(string consumerKey, string consumerSecret)
        {
            _requestOptions.Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret);
            return this;
        }

        public APIClient SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string oauthToken, string oauthTokenSecret)
        {
            _requestOptions.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthTokenSecret);
            return this;
        }

        public APIClient SetJwtAuthentication(string token)
        {
            _requestOptions.Authenticator = new JwtAuthenticator(token);
            return this;
        }

        public APIClient ClearAuthentication()
        {
            _requestOptions.Authenticator = null;
            return this;
        }
        public APIClient AddDefaultHeader(Dictionary<string, string> headers)
        {
            _restClient.AddDefaultHeaders(headers);
            return this;
        }

        public APIClient AddHeader(string name, string value)
        {
            Request.AddHeader(name, value);
            return this;
        }

        public APIClient CreateRequest(string resource = "")
        {
            Request = new RestRequest(resource);
            return this;
        }

        public APIClient AddAuthorizationHeader(string value)
        {
            return AddHeader("Authorization", value);
        }

        public APIClient AddContentTypeHeader(string value)
        {
            return AddHeader("Content-Type", value);
        }

        public APIClient AddAcceptHeader(string value)
        {
            return AddHeader("Accept", value);
        }
        // s
        public APIClient AddParameter(string name, string value)
        {
            Request.AddParameter(name, value);
            return this;
        }
        public APIClient AddBody(object body, string? contentype = null)
        {
            Request.AddJsonBody(body, contentype);
            return this;
        }
        public async Task<RestResponse> ExecuteGetAsync()
        {
            return await ExecuteRequestAsync(Method.Get);
        }

        public async Task<RestResponse<T>> ExecuteGetAsync<T>()
        {
            return await ExecuteRequestAsync<T>(Method.Get);
        }

        public async Task<RestResponse> ExecutePostAsync()
        {
            return await ExecuteRequestAsync(Method.Post);
        }
        public async Task<RestResponse<T>> ExecutePostAsync<T>()
        {
            return await ExecuteRequestAsync<T>(Method.Post);
        }

        public async Task<RestResponse> ExecutePutAsync()
        {
            return await ExecuteRequestAsync(Method.Put);
        }

        public async Task<RestResponse<T>> ExecutePutAsync<T>()
        {
            return await ExecuteRequestAsync<T>(Method.Put);
        }

        public async Task<RestResponse> ExecuteDeleteAsync()
        {
            return await ExecuteRequestAsync(Method.Delete);
        }
        public async Task<RestResponse<T>> ExecuteDeleteAsync<T>()
        {
            return await ExecuteRequestAsync<T>(Method.Delete);
        }

        public RestResponse ExecuteGet()
        {
            return ExecuteRequest(Method.Get);
        }

        public RestResponse<T> ExecuteGet<T>()
        {
            return ExecuteRequest<T>(Method.Get);
        }

        public RestResponse ExecutePost()
        {
            return ExecuteRequest(Method.Post);
        }

        public RestResponse<T> ExecutePost<T>()
        {
            return ExecuteRequest<T>(Method.Post);
        }


        public RestResponse ExecutePut()
        {
            return ExecuteRequest(Method.Put);
        }

        public RestResponse<T> ExecutePut<T>()
        {
            return ExecuteRequest<T>(Method.Put);
        }

        public RestResponse ExecuteDelete()
        {
            return ExecuteRequest(Method.Delete);
        }

        public RestResponse<T> ExecuteDelete<T>()
        {
            return ExecuteRequest<T>(Method.Delete);
        }

        private async Task<RestResponse> ExecuteRequestAsync(Method method)
        {
            Request.Method = method;
            var response = await _restClient.ExecuteAsync(Request);
            EnsureSuccess(response);
            return response;
        }
        private async Task<RestResponse<T>> ExecuteRequestAsync<T>(Method method)
        {
            Request.Method = method;
            var response = await _restClient.ExecuteAsync<T>(Request);
            EnsureSuccess(response);
            return response;
        }

        private RestResponse ExecuteRequest(Method method)
        {
            Request.Method = method;
            var response = _restClient.Execute(Request);
            EnsureSuccess(response);
            return response;
        }

        private RestResponse<T> ExecuteRequest<T>(Method method)
        {
            Request.Method = method;
            var response = _restClient.Execute<T>(Request);
            EnsureSuccess(response);
            return response;
        }

        private void EnsureSuccess(RestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Request failed with status {response.StatusCode}: {response.ErrorMessage}");
            }
        }

        private void EnsureSuccess<T>(RestResponse<T> response)
        {
            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Request failed with status {response.StatusCode}: {response.ErrorMessage}");
            }
        }
    }
}