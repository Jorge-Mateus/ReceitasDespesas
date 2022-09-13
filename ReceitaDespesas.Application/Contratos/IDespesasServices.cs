using ReceitaDespesas.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Application.Contratos
{
    public interface IDespesasServices
    {
        Task<DespesasDtos> AddDespesas(DespesasDtos model);
        Task<DespesasDtos> UpdateDespesas(int id, DespesasDtos model);
        Task<bool> DeleteDespesas(int id, DespesasDtos model);

        Task<DespesasDtos[]> GetAllDespesasByDescricaoAsync(string descricao, bool include = false);
        Task<DespesasDtos[]> GetAllDespesasByAsync(bool include = false);
        Task<DespesasDtos> GetDespesasIdAsync(int id, bool include = false);
    }
}
