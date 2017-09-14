using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Caelum.CaixaEletronico.Contas;

namespace Caelum.CaixaEletronico
{
    static class Serializer
    {
        public static string AsXml(this Conta resource)
        {
            var stringWriter = new StringWriter();
            new XmlSerializer(resource.GetType()).Serialize(stringWriter, resource);
            return stringWriter.ToString();
        }
    }


}
