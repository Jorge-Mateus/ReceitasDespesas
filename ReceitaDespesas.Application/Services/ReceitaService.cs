using AutoMapper;
using ReceitaDespesas.Application.Contratos;
using ReceitaDespesas.Application.Dtos;
using ReceitaDespesas.Domain;
using ReceitaDespesas.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Application.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IReceitaPersist _receitaPersist;
        private readonly IMapper _mapper;

        public ReceitaService(IGeralPersist geralPersist, IReceitaPersist receitaPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _receitaPersist = receitaPersist;
            _mapper = mapper;
        }
        public async Task<ReceitaDtos> AddReceita(ReceitaDtos model)
        {
            try
            {
                var receita = _mapper.Map<Receita>(model);

                _geralPersist.Add<Receita>(receita);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var retorno = await _receitaPersist.GetReceitaIdAsync(receita.ID, false);

                    return _mapper.Map<ReceitaDtos>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReceitaDtos> UpdateReceita(int id, ReceitaDtos model)
        {
            try
            {
                var receita = await _receitaPersist.GetReceitaIdAsync(id);
                if (receita == null) return null;

                model.ID = receita.ID;

                _mapper.Map(model, receita);

                _geralPersist.Update<Receita>(receita);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var retorno = await _receitaPersist.GetReceitaIdAsync(receita.ID, false);
                    return _mapper.Map<ReceitaDtos>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteReceita(int id, ReceitaDtos model)
        {
            try
            {
                var receita = await _receitaPersist.GetReceitaIdAsync(id, false);
                if (receita == null) throw new Exception("Receita para delete não encontrado.");

                _geralPersist.Delete<Receita>(receita);
                return await _geralPersist.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReceitaDtos[]> GetAllReceitaAsync(bool include = false)
        {
            try
            {
                var receita = await _receitaPersist.GetAllReceitaAsync(include);
                if (receita == null) return null;

                var resultado = _mapper.Map<ReceitaDtos[]>(receita);
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ReceitaDtos[]> GetAllReceitaByDescricaoAsync(string descricao, bool include = false)
        {
            try
            {
                var receita = await _receitaPersist.GetAllReceitaByDescricaoAsync(descricao, include);
                if (receita == null) return null;

                var resultado = _mapper.Map<ReceitaDtos[]>(receita);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ReceitaDtos> GetReceitaIdAsync(int id, bool include = false)
        {
            try
            {
                var receita = await _receitaPersist.GetReceitaIdAsync(id, include);
                if (receita == null) return null;
                else
                {
                    var resultado = _mapper.Map<ReceitaDtos>(receita);
                    return resultado;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
