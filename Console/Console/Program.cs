using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma linha de texto para ser reproduzida, ou pressione CTRL+Z e Enter para sair");
            TextReader leitor = Console.In;
            string linha = leitor.ReadLine();
            while (linha != null)
            {
                Console.WriteLine("Você digitou:\"{0}\"", linha);
                linha = leitor.ReadLine();                
            }
        
        }
    }
}