using AutoMapper;
using ReceitaDespesas.Application.Dtos;
using ReceitaDespesas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Application.Helpers
{
    public class ReceitasDespesasProfile : Profile
    {
        public ReceitasDespesasProfile()
        {
            CreateMap<Receita, ReceitaDtos>().ReverseMap();
            CreateMap<Despesas, DespesasDtos>().ReverseMap();
            CreateMap<ReceitasEDespesas, ReceitasEDespesasDtos>().ReverseMap();
        }
    }
}
