using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Domain
{
    public class ReceitasEDespesas
    {
        public int Id { get; set; }
        public virtual Despesas Despesas { get; set; }
        public virtual Receita Receita { get; set; }

        public int DespesasId { get; set; }
        public int ReceitaId { get; set; }
    }
}
