namespace OrienteeringAPI.Data.Base
{
    public interface ITokenProvider
    {
        string GenerateJwtToken(string userName);
    }
}
