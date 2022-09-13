using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReceitaDespesas.Application.Dtos
{
    public class ReceitaDtos
    {
        public virtual int ID { get; set; }
        public virtual string Descricao { get; set; }
        public virtual double Valor { get; set; }
        public virtual DateTime Data { get; set; }

        [JsonIgnore]
        public virtual List<ReceitasEDespesasDtos> ReceitaDespesas { get; set; }
    }
}
