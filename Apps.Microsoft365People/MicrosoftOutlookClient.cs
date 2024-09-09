﻿using Blackbird.Applications.Sdk.Common.Authentication;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Apps.Microsoft365People;

public class MicrosoftOutlookClient(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    : GraphServiceClient(GetAuthenticationProvider(authenticationCredentialsProviders))
{
    private static BaseBearerTokenAuthenticationProvider GetAuthenticationProvider(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var token = authenticationCredentialsProviders.First(p => p.KeyName == "Authorization").Value;
        var accessTokenProvider = new AccessTokenProvider(token);
        return new BaseBearerTokenAuthenticationProvider(accessTokenProvider);
    }
}