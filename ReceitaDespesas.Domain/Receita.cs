using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReceitaDespesas.Domain
{
    public class Receita
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }


        [JsonIgnore]
        public virtual List<ReceitasEDespesas> ReceitasDespesas{get; set; }

    }
}
