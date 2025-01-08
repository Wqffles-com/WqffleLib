using TransferProtocol.Messages;

namespace TransferProtocol;

public delegate WtpResponseMessage RequestDelegate(WtpRequestMessage request);