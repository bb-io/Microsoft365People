﻿using Apps.Microsoft365People.Auth.OAuth2;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Microsoft365People;

public class Microsoft365PeopleApplication  : BaseInvocable, IApplication, ICategoryProvider
{
    private readonly Dictionary<Type, object> _typesInstances;

    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Microsoft365Apps, ApplicationCategory.Communication];
        set { }
    }
    
    public Microsoft365PeopleApplication(InvocationContext invocationContext) : base(invocationContext)
    {
        _typesInstances = CreateTypesInstances();
    }

    public string Name
    {
        get => "Microsoft Outlook";
        set { }
    }

    public T GetInstance<T>()
    {
        if (!_typesInstances.TryGetValue(typeof(T), out var value))
        {
            throw new InvalidOperationException($"Instance of type '{typeof(T)}' not found");
        }
        return (T)value;
    }
    
    private Dictionary<Type, object> CreateTypesInstances()
    {
        return new Dictionary<Type, object>
        {
            { typeof(IOAuth2AuthorizeService), new OAuth2AuthorizeService(InvocationContext) },
            { typeof(IOAuth2TokenService), new OAuth2TokenService(InvocationContext) }
        };
    }
}