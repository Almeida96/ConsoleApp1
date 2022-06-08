using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Constants
    {
        public const int LIM = 6;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int primeiro = -1, ultimo = -1;
            int? i, proximo, num, opcao = -1;
            int lm = Constants.LIM;
            int[] fila = new int[lm];

            while (opcao != 0)
            {
                Console.WriteLine("1. Inserir Cliente");
                Console.WriteLine("2. Buscar Cliente");
                Console.WriteLine("3. Remover Cliente");
                Console.WriteLine("0. Sair");
                int opcao2 = Convert.ToInt32(Console.ReadLine());
                opcao = opcao2;
                switch (opcao2)
                {
                    // Case 1 = Inserção
                    case 1:
                        using (Classes.Cliente cli = new Classes.Cliente())
                        {
                            //Classes.Cliente cli = new Classes.Cliente();

                            Console.WriteLine("Digite o Codigo do Cliente: ");
                            string? codd = Console.ReadLine();
                            cli.Codigo = (int)Convert.ToInt64(codd);

                            Console.WriteLine("Digite o nome do Cliente: ");
                            string? name = Console.ReadLine();
                            cli.Nome = name.PrimeiraMaiuscula();

                            Console.WriteLine("Digite o Tipo do Cliente: ");
                            string? tip = Console.ReadLine();
                            cli.Tipo = (int)Convert.ToInt64(tip);

                            DateTime date = DateTime.UtcNow;
                            cli.DataCadastro = date;

                            cli.Dispose();
                        }
                        break;

                    //Case 2 = Remoção
                    case 2:


                }
            }

            using (Classes.Cliente cli = new Classes.Cliente())
            {
                //Classes.Cliente cli = new Classes.Cliente();

                Console.WriteLine("Digite o Codigo do Cliente: ");
                string? codd = Console.ReadLine();
                cli.Codigo = (int)Convert.ToInt64(codd);

                Console.WriteLine("Digite o nome do Cliente: ");
                string? name = Console.ReadLine();
                cli.Nome = name.PrimeiraMaiuscula();

                Console.WriteLine("Digite o Tipo do Cliente: ");
                string? tip = Console.ReadLine();
                cli.Tipo = (int)Convert.ToInt64(tip);

                DateTime date = DateTime.UtcNow;
                cli.DataCadastro = date;

                cli.Dispose();
            }
            
            
            



            Console.ReadLine();
        }


    }
}