using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Hydroponics.Repositories
{
    public class ProdutorRepositorio : IProdutorRepository
    {
        hydroponicsContext context = new hydroponicsContext();
        public async Task<Produtor> Post(Produtor produtor)
        {
            await context.Produtor.AddAsync(produtor);
            await context.SaveChangesAsync();
            return produtor;
        }
        public Produtor VerificacaoEmail(ForgotPasswordViewModel verificacao)
        {
            Produtor produtor = context.Produtor.FirstOrDefault(u => u.Email == verificacao.Email);
            return produtor;
        }
        public async Task<Produtor> Put(Produtor produtor)
        {
            context.Entry(produtor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return produtor;
        }
        public async Task<Produtor> GetById(int id)
        {
            return await context.Produtor.FirstOrDefaultAsync(a => a.IdProdutor == id);
        }

        public async Task<List<Produtor>> GetList()
        {
            return await context.Produtor.ToListAsync();
        }
    }
}