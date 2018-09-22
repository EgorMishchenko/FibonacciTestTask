using RestSharp;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace FirstApp.Interfaces
{
    public interface IRestMessageSender
    {
        Task<RestRequest> SendMessage(BigInteger number);
    }
}
