namespace TransferProtocol.RequestIdentifiers;

public interface IRequestIdentifier
{
    public RequestMethod Method { get; }
}