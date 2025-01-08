using System.Text.RegularExpressions;

namespace TransferProtocol.RequestIdentifiers;

public class RegexRequestIdentifier : IRequestIdentifier
{
    public required RequestMethod Method { get; init; }
    public required Regex Regex { get; init; }
}