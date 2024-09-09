﻿using Apps.Microsoft365People.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Microsoft365People.Models.Contact.Requests;

public class GetContactRequest
{
    [Display("Contact")]
    [DataSource(typeof(ContactDataSourceHandler))]
    public string ContactId { get; set; }
}