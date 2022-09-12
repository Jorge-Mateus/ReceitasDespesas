using ReceitaDespesas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Persistence.Contratos
{
    public interface IReceitaPersist
    {
        Task<Receita[]> GetAllReceitaByDescricaoAsync(string descricao, bool include = false);
        Task<Receita[]> GetAllReceitaAsync(bool include = false);
        Task<Receita> GetReceitaIdAsync(int id, bool include = false);
    }

}
