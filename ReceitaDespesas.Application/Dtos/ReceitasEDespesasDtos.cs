using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Application.Dtos
{
    public class ReceitasEDespesasDtos
    {
        public virtual int Id { get; set; }
        public virtual DespesasDtos Despesas { get; set; }
        public virtual ReceitaDtos Receita { get; set; }

        public virtual int DespesasId { get; set; }
        public virtual int ReceitaId { get; set; }
    }
}
