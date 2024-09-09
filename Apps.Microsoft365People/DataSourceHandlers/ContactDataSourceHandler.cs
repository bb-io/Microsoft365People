using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Microsoft365People.DataSourceHandlers;

public class ContactDataSourceHandler(InvocationContext invocationContext)
    : BaseInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var client = new MicrosoftOutlookClient(InvocationContext.AuthenticationCredentialsProviders);
        var contacts = await client.Me.Contacts.GetAsync(requestConfiguration =>
        {
            requestConfiguration.QueryParameters.Select = ["id", "displayName"];
            requestConfiguration.QueryParameters.Search = context.SearchString ?? " ";
            requestConfiguration.QueryParameters.Top = 20;
        }, cancellationToken);
        return contacts.Value.ToDictionary(c => c.Id, c => c.DisplayName);
    }
}