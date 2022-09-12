using ReceitaDespesas.Persistence.Contextos;
using ReceitaDespesas.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Persistence.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ReceitaDespesasContext _context;
        public GeralPersist(ReceitaDespesasContext context)
        {
            _context = context;
        }
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteRange<T>(T[] Entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
