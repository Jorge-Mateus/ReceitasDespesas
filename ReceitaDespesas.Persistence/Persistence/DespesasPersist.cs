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
    public class DespesasPersist : IDespesasPersist
    {
        private readonly ReceitaDespesasContext _context;

        public DespesasPersist(ReceitaDespesasContext context)
        {
            _context = context;
        }

        public async Task<Despesas[]> GetAllDespesasByAsync(bool include = false)
        {
            IQueryable<Despesas> query = _context.Despesas
                                        .Include(d => d.ReceitaDespesas);
            if (include)
            {
                query = query
                        .Include(d => d.ReceitaDespesas);
            }

            query = query.AsNoTracking().OrderBy(e => e.ID);

            return await query.ToArrayAsync();
        }

        public async Task<Despesas[]> GetAllDespesasByDescricaoAsync(string descricao, bool include = false)
        {

            IQueryable<Despesas> query = _context.Despesas
                                        .Include(d => d.ReceitaDespesas);
            if (include)
            {
                query = query
                        .Include(d => d.ReceitaDespesas);
            }

            query = query.AsNoTracking().OrderBy(d => d.ID).Where(d => d.Descricao.ToLower().Contains(descricao.ToLower())) ;

            return await query.ToArrayAsync();
        }

        public async Task<Despesas> GetDespesasIdAsync(int id, bool include = false)
        {
            IQueryable<Despesas> query = _context.Despesas
                                        .Include(e => e.ReceitaDespesas);
                                  
            if (include)
            {
                query = query
                        .Include(e => e.ReceitaDespesas);
            }
            query = query.AsNoTracking().OrderBy(d => d.ID).Where(d => d.ID == id);
            return await query.FirstOrDefaultAsync();
        }
    
    }
}
