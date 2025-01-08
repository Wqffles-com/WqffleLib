namespace TransferProtocol;

public enum ResponseCode
{
    // 0-99: Success
    Ok = 0,
    Created = 1,
    Merged = 2,
    Deleted = 3,
    
    // 100-199: Server errors
    ServerError = 100,
    RateLimited = 101,
    NotFound = 102,
    
    // 200-299: Client errors
    MissingPermissions = 201,
    LoginRequired = 202,
    InvalidBody = 203,
    InvalidRequest = 204,
}