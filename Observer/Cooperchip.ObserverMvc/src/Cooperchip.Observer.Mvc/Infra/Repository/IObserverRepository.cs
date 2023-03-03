using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Infra.Repository
{
    public interface IObserverRepository
    {
        Task ObserverHandre([FromServices] IMensagemRepository _repository);
    }
}
