using System.Threading.Tasks;
using Orleans;

namespace Interfaces
{
    /// <summary>
    /// Grain interface IGrain1
    /// </summary>
    public interface IPerson : IGrainWithStringKey
    {
        Task SayHelloAsync(string message);
    }
}
