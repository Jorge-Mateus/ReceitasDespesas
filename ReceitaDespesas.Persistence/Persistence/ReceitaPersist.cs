using Microsoft.EntityFrameworkCore;
using ReceitaDespesas.Domain;
using ReceitaDespesas.Persistence.Contextos;
using ReceitaDespesas.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Persistence.Persistence
{
    class ReceitaPersist : IReceitaPersist
    {
        private readonly ReceitaDespesasContext _context;

        public ReceitaPersist(ReceitaDespesasContext context)
        {
            _context = context;
        }

        public async Task<Receita[]> GetAllReceitaAsync(bool include = false)
        {

            IQueryable<Receita> query = _context.Receitas
                                        .Include(r => r.ReceitasDespesas);
            if (include)
            {
                query = query
                        .Include(r => r.ReceitasDespesas) ;
            }

            query = query.AsNoTracking().OrderBy(r => r.ID);

            return await query.ToArrayAsync();
        }

        public async Task<Receita[]> GetAllReceitaByDescricaoAsync(string descricao, bool include = false)
        {
            IQueryable<Receita> query = _context.Receitas
                                        .Include(r => r.ReceitasDespesas);
            if (include)
            {
                query = query
                        .Include(r => r.ReceitasDespesas);
            }

            query = query.AsNoTracking().OrderBy(r => r.ID).Where(r => r.Descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Receita> GetReceitaIdAsync(int id, bool include = false)
        {
            IQueryable<Receita> query = _context.Receitas
                                        .Include(r => r.ReceitasDespesas);

            if (include)
            {
                query = query
                        .Include(r => r.ReceitasDespesas);
            }
            query = query.AsNoTracking().OrderBy(r => r.ID).Where(r => r.ID == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
