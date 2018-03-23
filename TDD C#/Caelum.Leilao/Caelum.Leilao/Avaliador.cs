using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        public double MaiorDeTodos { get; set; } = double.MinValue;
        public double MenorDeTodos { get; set; } = double.MaxValue;
        public IList<Lance> TresMaiores { get; set; }
        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances) 
            {
                if (lance.Valor > MaiorDeTodos)
                {
                    MaiorDeTodos = lance.Valor;
                }
                if (lance.Valor < MenorDeTodos)
                {
                    MenorDeTodos = lance.Valor;
                }
            }
        }

        public double CalculaMediaDosLances(Leilao leilao)
        {
            if(leilao.Lances.Count > 0)
            {
                var soma = leilao.Lances.Sum(l => l.Valor);
                var media = soma / leilao.Lances.Count;
                return media;
            }
            return 0.0;
        }

        public void PegaOsMaioresNo(Leilao leilao)
        {
            var filtro = leilao.Lances.OrderByDescending(l => l.Valor).Take(3);
            TresMaiores = new List<Lance>(filtro);
        }
    }
}
