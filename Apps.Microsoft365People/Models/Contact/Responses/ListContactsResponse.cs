using Apps.Microsoft365People.Models.Contact.Dtos;

namespace Apps.Microsoft365People.Models.Contact.Responses;

public class ListContactsResponse
{
    public IEnumerable<ContactDto> Contacts { get; set; }
}