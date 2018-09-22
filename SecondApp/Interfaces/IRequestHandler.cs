using System.Numerics;

namespace SecondApp.Interfaces
{
    public interface IRequestHandler
    {
        BigInteger ProcessRequest(string message);
    }
}
