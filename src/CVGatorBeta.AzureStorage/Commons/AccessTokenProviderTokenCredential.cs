using Azure.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace CVGatorBeta.AzureStorage.Blob.Commons
{
    /// <summary>
    /// HACK: Azure AD + Storage
    /// For checking purpose. Seems token not working here.
    /// </summary>
    public class AccessTokenProviderTokenCredential : TokenCredential
    {
        readonly private IAccessTokenProvider _accessTokenProvider;

        //private readonly List<string> _storageScopes = new List<string> { "https://storage.azure.com/user_impersonation" };
        private readonly List<string> _storageScopes = new List<string> { "api://b5c7f38b-0836-455a-8e5f-5c07443f6c6a/api" };

        public AccessTokenProviderTokenCredential(IAccessTokenProvider accessTokenProvider)
        {
            _accessTokenProvider = accessTokenProvider;
        }

        public override Azure.Core.AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            //_storageScopes.AddRange(requestContext.Scopes);

            _accessTokenProvider.RequestAccessToken(
                new Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions()
                {
                    Scopes = _storageScopes,
                })
                .GetAwaiter()
                .GetResult().TryGetToken(out Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessToken token);

            return new Azure.Core.AccessToken(token.Value, token.Expires);
        }

        public override async ValueTask<Azure.Core.AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            //_storageScopes.AddRange(requestContext.Scopes);

            var result = await _accessTokenProvider.RequestAccessToken(
                            new Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions()
                            {
                                Scopes = _storageScopes,
                            })
                            .ConfigureAwait(false);

            result.TryGetToken(out Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessToken token);

            return new Azure.Core.AccessToken(token.Value, token.Expires);
        }
    }
}
