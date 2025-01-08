namespace TransferProtocol.RequestIdentifiers;

public class StringRequestIdentifier : IRequestIdentifier
{
    public required RequestMethod Method { get; init; }
    public required string Route { get; set; }

    public void JoinRoute(string route2)
    {
        if (Route.EndsWith('/') && route2.StartsWith('/'))
        {
            Route += route2.SkipWhile(c => c == '/');
        }
        else if (!Route.EndsWith('/') && !route2.StartsWith('/'))
        {
            Route += '/' + route2;
        }
        else
        {
            Route += route2;
        }
    }
    
    public void PrependRoute(string route2)
    {
        if (Route.StartsWith('/') && route2.EndsWith('/'))
        {
            Route = route2.SkipWhile(c => c == '/') + Route;
        }
        else if (!Route.StartsWith('/') && !route2.EndsWith('/'))
        {
            Route = route2 + '/' + Route;
        }
        else
        {
            Route = route2 + Route;
        }
    }
}