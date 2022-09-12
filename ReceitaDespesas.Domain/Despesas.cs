using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ReceitaDespesas.Domain
{
    public class Despesas
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        
        [JsonIgnore]
        public virtual List<ReceitasEDespesas> ReceitaDespesas { get; set; }

    }
}
