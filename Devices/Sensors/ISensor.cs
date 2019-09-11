using System.Threading.Tasks;

namespace dependencyInAction{
    public interface ISensor : IDevice
    {
        ISensorResponse GetResponse();
        Task<ISensorResponse> GetResponseAsync();
    }
}