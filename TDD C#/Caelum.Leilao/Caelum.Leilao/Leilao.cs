using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (Lances.Count == 0 || (
                !ultimoLanceDado().Usuario.Equals(lance.Usuario)
                && qtdLancesDo(lance.Usuario)<5
                ))
            {
                Lances.Add(lance);
            }

        }

        private int qtdLancesDo(Usuario usuario)
        {
            int total = 0;

            foreach (Lance lance in Lances)
            {
                if (lance.Usuario.Equals(usuario)) total++;
            }

            return total;
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }
    }
}