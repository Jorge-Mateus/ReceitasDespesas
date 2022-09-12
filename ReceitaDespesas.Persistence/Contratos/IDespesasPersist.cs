using ReceitaDespesas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Persistence.Contratos
{
    public interface IDespesasPersist
    {
        Task<Despesas[]> GetAllDespesasByDescricaoAsync(string descricao, bool include = false);
        Task<Despesas[]> GetAllDespesasByAsync(bool include = false);
        Task<Despesas> GetDespesasIdAsync(int id, bool include = false);
    }
}
