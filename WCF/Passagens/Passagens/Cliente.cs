using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Passagens
{
    [DataContract]
    public class Cliente
    {
        //DataMemberAttribute informa ao WCF que esse atributo da classe deve trafegar pelo serviço
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cpf { get; set; }
    }
}
