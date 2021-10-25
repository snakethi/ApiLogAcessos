using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAplication.Models
{
    public class PopulacaoService
    {
        public static List<PopulacaoModel> GetPopulacaoPorEstado()
        {
            var lista = new List<PopulacaoModel>();
            lista.Add(new PopulacaoModel { Hora = "00:00", Quantidade = 19});
            lista.Add(new PopulacaoModel { Hora = "00:01", Quantidade = 18});
            lista.Add(new PopulacaoModel { Hora = "00:02", Quantidade = 15});
            lista.Add(new PopulacaoModel { Hora = "00:03", Quantidade = 13});
            lista.Add(new PopulacaoModel { Hora = "00:04", Quantidade = 4});
            return lista;
        }

        public class PopulacaoModel
        {
            public string Hora { get; set; }
            public decimal Quantidade { get; set; }
        }
    }
}