﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestaPostXml();
        }

        private static void TestaPostXml()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57118/api/Carrinho/1");
            request.Method = "POST";
            request.Accept = "application/xml";

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/LojaAPI.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>5</Id><Produtos><Produto><Id>123</Id><Nome>Produto Criado com POST</Nome><Preco>100</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);
            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        private static void TestaPostJson()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57118/api/Carrinho/1");
            request.Method = "POST";
            request.Accept = "application/json";

            string json = "{'Produtos':[{'Id':6237,'Preco':4000.0,'Nome':'XBox','Quantidade':4}],'Endereco':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':3}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        private static void TestaGet()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57118/api/Carrinho/1");
            request.Method = "GET";
            
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        private static void TestaGetJson()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57118/api/Carrinho/1");
            request.Method = "GET";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        private static void TestaGetXml()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57118/api/Carrinho/1");
            request.Method = "GET";
            request.Accept = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }
    }
}
