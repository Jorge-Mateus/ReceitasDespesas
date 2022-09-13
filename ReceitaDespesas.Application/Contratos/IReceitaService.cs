using ReceitaDespesas.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Application.Contratos
{
    public interface IReceitaService
    {
        Task<ReceitaDtos> AddReceita(ReceitaDtos model);
        Task<ReceitaDtos> UpdateReceita(int id, ReceitaDtos model);
        Task<bool> DeleteReceita(int id, ReceitaDtos model);

        Task<ReceitaDtos[]> GetAllReceitaByDescricaoAsync(string descricao, bool include = false);
        Task<ReceitaDtos[]> GetAllReceitaAsync(bool include = false);
        Task<ReceitaDtos> GetReceitaIdAsync(int id, bool include = false);
    }
}
