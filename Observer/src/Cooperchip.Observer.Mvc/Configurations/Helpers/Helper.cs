using Cooperchip.Observer.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cooperchip.Observer.Mvc.Configurations.Helpers
{
    public static class Helper
    {
        public static int TotalNotify(ApplicationDbContext ctx) => (from total in ctx.Mensagens.AsNoTracking().Select(x => x.Mensagem) select total).Count();
    }
}
