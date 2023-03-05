using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Repositories
{
    public interface IObserverRepository
    {
        Task ObserverHandre([FromServices] IMensagemRepository _repository);
    }
}
