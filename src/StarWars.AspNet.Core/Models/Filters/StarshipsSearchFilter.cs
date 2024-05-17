using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models.Filters;

public class StarshipsSearchFilter
    : SearchFilter
{
    public PersonId? PersonId { get; set; } = null;
}
