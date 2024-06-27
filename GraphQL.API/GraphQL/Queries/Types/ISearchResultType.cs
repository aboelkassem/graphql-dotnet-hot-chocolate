namespace GraphQL.API.GraphQL.Queries.Types
{
    // use [InterfaceType("SearchResult")] If have shared fields like Id
    // use [UnionType("SearchResult")] if have no shared fields
    [UnionType("SearchResult")]
    public interface ISearchResultType
    {
    }
}
