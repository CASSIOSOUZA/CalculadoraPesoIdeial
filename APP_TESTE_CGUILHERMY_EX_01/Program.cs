using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APP_TESTE_CGUILHERMY_EX_01
{
    internal class Program
    {
        private const string divisorTextos = "==============================================";
        private const double valorBaseHomem = 58;
        private const double valorBaseMulher = 44.7;

        private static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n" + divisorTextos);
            Console.WriteLine("\n" + "PROGRAMA DE AVALIAÇÃO EXERCICIO 1");
            Console.WriteLine("\n" + divisorTextos);
            Console.WriteLine("\n" + "DIGITE A QUANTIDADE DE PESSOAS QUE VAI SER CALCULADO:");
            int quantidadePessoas = Convert.ToInt32(Console.ReadLine());

            List<Pessoa> ListaPessoas = new List<Pessoa>();

            for (int i = 0; i < quantidadePessoas; i++)
            {
                var pessoa = new Pessoa();
                pessoa.Nome = ObtenhaDadosUsuario(string.Format("DIGITE O NOME DA {0} PESSOA.", i + 1), default(double), "1");
                pessoa.Sexo = ObtenhaDadosUsuario("DIGITE M-PARA MASCULINO, E F-PARA FEMININO.", default(double), "1");
                pessoa.Altura = Convert.ToDouble(ObtenhaDadosUsuario("DIGITE A ALTURA.", 11, ""));
                pessoa.Peso = Convert.ToDouble(ObtenhaDadosUsuario("DIGITE O PESO.", 11, ""));

                if (pessoa.Sexo == "M" || pessoa.Sexo == "m")
                {//MASCULINO
                    pessoa.Resultado = (pessoa.Peso * pessoa.Altura) - valorBaseHomem;
                }
                else if (pessoa.Sexo == "F" || pessoa.Sexo == "f")
                {//FEMININO
                    pessoa.Resultado = (pessoa.Peso * pessoa.Altura) - valorBaseMulher;
                }

                Console.Clear();
                Console.WriteLine("\n" + divisorTextos);
                Console.WriteLine("\n" + "PROGRAMA DE AVALIAÇÃO EXERCICIO 1");
                Console.WriteLine("\n" + divisorTextos);
                ListaPessoas.Add(pessoa);
            }

            Console.Clear();

            Parallel.ForEach(ListaPessoas, pessoa =>
            {
                Console.WriteLine("\n" + divisorTextos);
                Console.WriteLine("\n" + "RESULTADO DO CALCULO DE " + pessoa.Nome);
                Console.WriteLine("\n" + string.Format("PESO IDEAL:{0} ALTURA:{1} SEXO:{2}", pessoa.Resultado, pessoa.Altura, pessoa.Sexo));
            });

            Console.ReadKey();
        }

        private static string ObtenhaDadosUsuario(string textoPedido, double valorObtidoUm = default(double), string valorObtidoDois = "")
        {
            Console.WriteLine("\n" + textoPedido);
            var resultado = Console.ReadLine();

            if (default(double) != valorObtidoUm)
            {
                var isNumeric = double.TryParse(resultado, out _);

                if (isNumeric)
                {
                    return resultado;
                }
                else
                {
                    Console.WriteLine("Dado informado está invalido.");
                    ObtenhaDadosUsuario(textoPedido, valorObtidoUm, valorObtidoDois);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(resultado))
                {
                    return resultado;
                }
                else
                {
                    Console.WriteLine("\n" + "Dado informado está invalido.");
                    ObtenhaDadosUsuario(textoPedido, valorObtidoUm, valorObtidoDois);
                }
            }

            return resultado;
        }
    }

    internal class Pessoa
    {
        public string Nome { get; set; }
        public double Altura { get; set; }
        public string Sexo { get; set; }
        public double Peso { get; set; }
        public double Resultado { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, double altura, string sexo, double peso, double resultado)
        {
            Nome = nome;
            Altura = altura;
            Sexo = sexo;
            Peso = peso;
            Resultado = resultado;
        }
    }
}