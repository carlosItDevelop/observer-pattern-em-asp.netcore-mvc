using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Domain.Repositories;
using Cooperchip.Observer.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Infra.Repository
{
    public class MensagemRepository : IMensagemRepository
    {

        public List<Mensagens> notas = new List<Mensagens>();

        private readonly ApplicationDbContext _context;

        public MensagemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Mensagens model)
        {
            notas.Add(model);
            await Task.CompletedTask;
        }

        public async Task Commit()
        {
            foreach (var nota in notas)
            {
                await _context.AddRangeAsync(nota);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mensagens>> GetAllMensagens()
        {
            return await _context.Mensagens.AsNoTracking().ToListAsync();
        }

        public void Dispose() => _context?.Dispose();
    }
}
