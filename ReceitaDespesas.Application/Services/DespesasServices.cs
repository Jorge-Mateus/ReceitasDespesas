using AutoMapper;
using ReceitaDespesas.Application.Contratos;
using ReceitaDespesas.Application.Dtos;
using ReceitaDespesas.Persistence.Contratos;
using ReceitaDespesas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesasDespesas.Application.Services
{
    public class DespesasServices : IDespesasServices
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IDespesasServices _despesasServices;
        private readonly IMapper _mapper;

        public DespesasServices(IGeralPersist geralPersist, IDespesasServices despesasServices, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _despesasServices = despesasServices;
            _mapper = mapper;
        }
        public async Task<DespesasDtos> AddDespesas(DespesasDtos model)
        {
            try
            {
                var Despesas = _mapper.Map<Despesas>(model);

                _geralPersist.Add<Despesas>(Despesas);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var retorno = await _despesasServices.GetDespesasIdAsync(Despesas.ID, false);

                    return _mapper.Map<DespesasDtos>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DespesasDtos> UpdateDespesas(int id, DespesasDtos model)
        {
            try
            {
                var despesa = await _despesasServices.GetDespesasIdAsync(id);
                if (despesa == null) return null;

                model.ID = despesa.ID;

                _mapper.Map(model, despesa);

                _geralPersist.Update<Despesas>(despesa);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var retorno = await _despesasServices.GetDespesasIdAsync(despesa.ID, false);
                    return _mapper.Map<DespesasDtos>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteDespesas(int id, DespesasDtos model)
        {
            try
            {
                var Despesas = await _despesasServices.GetDespesasIdAsync(id, false);
                if (Despesas == null) throw new Exception("Despesas para delete não encontrado.");

                _geralPersist.Delete<Despesas>(Despesas);
                return await _geralPersist.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DespesasDtos[]> GetAllDespesasByDescricaoAsync(string descricao, bool include = false)
        {
            try
            {
                var Despesas = await _despesasServices.GetAllDespesasByDescricaoAsync(descricao, include);
                if (Despesas == null) return null;

                var resultado = _mapper.Map<DespesasDtos[]>(Despesas);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<DespesasDtos> GetDespesasIdAsync(int id, bool include = false)
        {
            try
            {
                var Despesas = await _despesasServices.GetDespesasIdAsync(id, include);
                if (Despesas == null) return null;
                else
                {
                    var resultado = _mapper.Map<DespesasDtos>(Despesas);
                    return resultado;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DespesasDtos[]> GetAllDespesasByAsync(bool include = false)
        {
            try
            {
                var Despesas = await _despesasServices.GetAllDespesasByAsync(include);
                if (Despesas == null) return null;

                var resultado = _mapper.Map<DespesasDtos[]>(Despesas);
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
