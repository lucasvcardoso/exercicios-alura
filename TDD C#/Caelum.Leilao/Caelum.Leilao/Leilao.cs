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
            if (Lances.Count == 0 || PodeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }

        }

        private bool PodeDarLance(Usuario usuario)
        {
            return !ultimoLanceDado().Usuario.Equals(usuario)
                            && qtdLancesDo(usuario) < 5;
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

        public void DobraLance(Usuario usuario) {
            Lance lance = ultimoLanceDo(usuario);
            if (lance != null)
            {
                Propoe(new Lance(usuario, lance.Valor * 2));
            }
        }

        private Lance ultimoLanceDo(Usuario usuario)
        {
            for (int i = Lances.Count - 1; i >= 0; i--)
            {
                if (Lances[i].Usuario == usuario)
                {
                    return Lances[i];
                }
            }
            return null;
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }
    }
}