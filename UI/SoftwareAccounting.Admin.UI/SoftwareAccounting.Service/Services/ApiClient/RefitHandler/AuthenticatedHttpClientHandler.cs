using SoftwareAccounting.Common.Models.AuthModel;

namespace SoftwareAccounting.Service.Services.ApiClient.RefitHandler
{
    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly AuthState _authState;
        private readonly Func<Task<bool>> _refreshTokenCallback;

        public AuthenticatedHttpClientHandler(AuthState authState, Func<Task<bool>> refreshTokenCallback)
        {
            _authState = authState;
            _refreshTokenCallback = refreshTokenCallback;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(_authState.AccessToken))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authState.AccessToken);

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                bool refreshed = await _refreshTokenCallback();
                if (refreshed)
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authState.AccessToken);
                    response.Dispose();
                    return await base.SendAsync(request, cancellationToken);
                }
            }

            return response;
        }
    }
}