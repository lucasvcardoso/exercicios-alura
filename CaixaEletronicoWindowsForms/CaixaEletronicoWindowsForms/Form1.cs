
using Caelum.CaixaEletronico.Contas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caelum.CaixaEletronico.Sistema;

namespace Caelum.CaixaEletronico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ContaPoupanca conta = new ContaPoupanca();
        private Conta[] contas ;//= new Conta[10];
        private int quantidadeDeContas = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            contas = new Conta[10];
            contas[0] = new ContaCorrente();
            contas[0].stringTitular = "Vitor";
            contas[0].Numero = 1;

            contas[1] = new ContaPoupanca();
            contas[1].Numero = 2;
            contas[1].stringTitular = "Mario";

            foreach (Conta c in contas)
            {
                if (c != null)
                {
                    comboContas.Items.Add(c.stringTitular);
                    destinoTransferencia.Items.Add(c.stringTitular);
                }
            }
        }

        private void botaoDepositar_Click(object sender, EventArgs e)
        {
            contas[comboContas.SelectedIndex].Deposita(Convert.ToDouble(textoValor.Text));
            textoSaldo.Text = Convert.ToString(contas[comboContas.SelectedIndex].Saldo);
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {

            contas[comboContas.SelectedIndex].Saca(Convert.ToDouble(textoValor.Text));
            textoSaldo.Text = Convert.ToString(contas[comboContas.SelectedIndex].Saldo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Exemplos de manipulações de string

            //Concatenação de strings
            string titulo = "Arquitetura e " + "Design de software";
            titulo += "!";

            MessageBox.Show(titulo);

            //Concatenação de string com variável
            int idade = 42;
            string nome = "Guilherme";
            string mensagem = "A sua idade é: " + idade;

            MessageBox.Show(mensagem);
            
            //Utilização de string.Format() pra inserir variáveis em uma string
            mensagem = string.Format("Olá {0}, sua idade é: {1}", nome, idade);

            MessageBox.Show(mensagem);

            //Utilização de string.Split() para separar uma string em partes
            //passando como limitador o caracter desejado para o método Split
            //retornar um vetor de string
            string texto = "Guilherme,42,sao paulo,brasil";
            string[] partes = texto.Split(',');

            //Iterando sobre o vetor (array) para exibir as partes separadas pelo Split
            foreach (var parte in partes)
            {
                MessageBox.Show(parte);
            }

            //Exemplo de como strings são imutáveis.
            //No caso abaixo, utilizamos o método ToUpper(), que muda as letras da string para maiúsculas
            //porém sem atribuir o retorno do método a nenhuma variável.
            //Ao exibir o conteúdo da variável, ainda está em letras minúsculas, pois o valor de uma string
            //é imutável.
            string curso = "fn11";
            curso.ToUpper();
            MessageBox.Show(curso);

            //Correção para exibir em letra maiúsculas:
            curso = curso.ToUpper();
            MessageBox.Show(curso);

            //Utilizando o método Replace() para substituir parte da string:
            curso = curso.Replace("1","2");
            MessageBox.Show(curso);

            //Utilizando o método Substring() para obter parte da string original
            string nomeCompleto = "Guilherme Silveira";
            string primeiroNome = nomeCompleto.Substring(0, 9);
            MessageBox.Show(primeiroNome);

            //Utilizando o método IndexOf() para obter a posição de um determinado caracter na string
            int posicaoDoSobrenome = nomeCompleto.IndexOf("s");
            string segundoNome = nomeCompleto.Substring(posicaoDoSobrenome);
            MessageBox.Show(segundoNome);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textoTitular.Text = contas[comboContas.SelectedIndex].stringTitular;
            textoSaldo.Text = Convert.ToString(contas[comboContas.SelectedIndex].Saldo);
            textoNumero.Text = Convert.ToString(contas[comboContas.SelectedIndex].Numero);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contas[comboContas.SelectedIndex].Transfere(Convert.ToDouble(textoValor.Text), contas[destinoTransferencia.SelectedIndex]);            
        }

        public void AdicionaConta(Conta conta)
        {
            this.contas[this.quantidadeDeContas] = conta;
            this.quantidadeDeContas++;

            comboContas.Items.Add(conta.stringTitular);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CadastroDeContas cadastro = new CadastroDeContas(this);
            cadastro.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var contas = new List<Conta>();
            contas.Add(ContaComSaldo(2300));
            contas.Add(ContaComSaldo(1000));
            contas.Add(ContaComSaldo(2500));

            //Exemplo de select com filtro simples em LINQ
            var filtradasPorSaldo = from c in contas
                            where c.Saldo > 2000
                            select c;

            foreach (Conta c in filtradasPorSaldo)
            {
                MessageBox.Show("O saldo é: " + c.Saldo);
            }

            //Exemplo de soma com método Sum() em LINQ com lambda
            double saldoTotal = filtradasPorSaldo.Sum(c => c.Saldo);
            MessageBox.Show("O total é: " + saldoTotal);

            //Exemplo de select com filtro por string em LINQ
            var filtradasPorNome = from c in contas
                                   where c.stringTitular.StartsWith("G")
                                   select c;

            //Exemplo de filtro utilizando o método Where() 
            //disponível em listas e vetores, passando uma lambda
            var filtradasComMetodo = contas
                                        .Where(c => c.Numero < 1000 && c.Numero > 5000);

            //Exemplo de filtro com Min() passando uma lambda,
            //para obter o menor elemento da lista ou vetor
            var menorSaldo = contas.Min(c => c.Saldo);

            //Exemplo de contagem utilzando Count() e passando uma lambda
            //com a condição para incluir na contagem
            var quantidade = contas.Count(c => c.Saldo > 5000);

            //Exemplo de filtro em LINQ para criação de lista de tipos anônimos
            var filtradasObjetoAnon = from c in contas
                                      where c.Numero < 1000
                                      select new { Titular = c.Titular, Saldo = c.Saldo};

            //Exemplo de soma de elementos filtrados de um vetor utilizando Where() 
            //e Sum() combinados
            int[] inteiros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 15, 17 };
            var somaFiltrada = inteiros.Where(x => x >= 10).Sum();
            
            //Exemplo de select filtrado e ordenado em LINQ
            var listaFiltradaOrdenada = from c in contas
                                where c.Saldo > 1000
                                orderby c.Numero descending
                                select c;

            //Exemplo de filtragem e ordenação utilizando 
            //métodos Where() e OrderByDescending() e lambda
            listaFiltradaOrdenada = contas.Where(c => c.Saldo < 1000)
                                            .OrderByDescending(c => c.Numero);

            //Exemplo de ordenação de lista de strings utilizando mais de um
            //critério: primeiro pelo tamanho da string, segundo alfabeticamente
            List<string> nomes = (List<string>)from c in contas
                                 select c.stringTitular;
            var listaOrdenadaString = from n in nomes
                                      orderby n.Length, n
                                      select n;

            //Exemplo de cima, utilizando métodos e lambda
            listaOrdenadaString = nomes.OrderBy(n => n.Length).ThenBy(n => n);
        }

        private Conta ContaComSaldo(double saldo)
        {
            Conta c = new ContaCorrente();
            c.Deposita(saldo);
            return c;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Exemplo de chamada de método para alterar uma string
            MessageBox.Show(StringUtils.Pluralize("Conta"));

            //Exemplo da utilização do mesmo método em formato de extension method.
            //Dessa forma o método passa a ser parte da classe String, podendo ser
            //chamado direto a partir da própria string.
            //ATENÇÃO: Extension methods NÃO sobrescrevem o comportamento de métodos
            //da classe original.
            MessageBox.Show("Conta".Pluralize());

            Conta conta = ContaComSaldo(3500);
            conta.Titular = new Usuarios.Cliente() { nome = "lucas", Idade = 26};
            System.Console.WriteLine(conta.AsXml());

        }
    }
}
