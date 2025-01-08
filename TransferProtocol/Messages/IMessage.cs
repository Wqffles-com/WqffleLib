using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;
using TransferProtocol.Body;

namespace TransferProtocol.Messages;

public abstract partial class MessageBase
{
    public Dictionary<string, string> Parameters { get; set; } = new();
    public IBody? Body { get; set; }
    public string Version { get; set; } = WtpGlobals.LatestVersion;
    
    public override string ToString() => $"""
                                          Wqffles' Transfer Protocol v{Version}
                                          {CreateBase()}
                                          Parameters: {string.Join(",", Parameters.Select(p => $"{p.Key} = {p.Value}"))}
                                          ContentType: {Body?.ContentType ?? "null"}
                                          BodyBytes: [{(Body == null ? "null" : string.Join(",", Body.ToBytes().Select(b => b.ToString())))}]
                                          """;

    protected abstract string CreateBase();
    
    protected async Task Initialize(Stream data)
    {
        var bodies = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.IsAssignableTo(typeof(IBody)) && t.GetProperty("ContentTypeStatic") != null)
            .ToList();
        var reader = new StreamReader(data);
        var versionLine = await reader.ReadLineAsync() ?? throw new InvalidOperationException("Failed to read version line");
        var version = VersionRegex().Match(versionLine).Groups[1].Value;
        if (version != WtpGlobals.LatestVersion)
        {
            throw new InvalidOperationException($"Unsupported version: {version}");
        }

        await reader.ReadLineAsync();
        var parametersLine = await reader.ReadLineAsync() ?? throw new InvalidOperationException("Failed to read parameters line");

        try
        {
            var parameters = parametersLine.Split(',').Select(p => p.Split('=')).ToDictionary(p => p[0], p => p[1]);
            Parameters = parameters;
        }
        catch
        {
            Parameters = new Dictionary<string, string>();
        }

        var contentTypeLine = await reader.ReadLineAsync() ?? throw new InvalidOperationException("Failed to read content type line");
        var contentType = contentTypeLine.Split(':').Last().Trim();
        if (contentType == "null")
        {
            return;
        }
        
        var bodyType = bodies.FirstOrDefault(body => body.GetProperty("ContentTypeStatic")!.GetValue(null)!.ToString() == contentType);
        var bodyBytesLine = await reader.ReadLineAsync();
        if (bodyBytesLine is null or "null" || bodyType is null)
        {
            Body = null;
            return;
        }

        var stripped = bodyBytesLine.SkipWhile(c => !char.IsDigit(c)).Reverse().SkipWhile(c => !char.IsDigit(c)).Reverse();
        bodyBytesLine = string.Join("", stripped); // Remove leading and trailing non-digits
        var body = (IBody)bodyType.GetMethod("ParseInternal")!.Invoke(null, [new MemoryStream(bodyBytesLine.Split(',').Select(byte.Parse).ToArray())])!;
        Body = body;
    }

    [GeneratedRegex(@"Wqffles' Transfer Protocol v(\d*\.\d*\.\d*)", RegexOptions.Compiled)]
    public partial Regex VersionRegex();
}