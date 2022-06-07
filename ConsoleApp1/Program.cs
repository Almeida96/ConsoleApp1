using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (Classes.Cliente cli2 = new Classes.Cliente(2))
            {
                
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
            //}
            //catch (ConsoleApp1.Excecoes.ValidacaoException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //using (Classes.Cliente cli2 = new Classes.Cliente(5))
            //{
            //    cli2.Nome = "Pote";
            //}


            Classes.Contato contato1 = new Classes.Contato();
            contato1.Codigo = 1;
            contato1.DadosContato = "1111-1111";
            contato1.Tipo = "Telefone";

            Classes.Contato contato2 = new Classes.Contato();
            contato2.Codigo = 2;
            contato2.DadosContato = "2222@2222";
            contato2.Tipo = "Email";

            Classes.Contato contato3 = new Classes.Contato();
            contato3.Codigo = 3;
            contato3.DadosContato = "33333333";
            contato3.Tipo = "Outra forma de contato";


            //cli.Contatos = new List<Classes.Contato>();
            //cli.Contatos.Add(contato1);
            //cli.Contatos.Add(contato2);
            //cli.Contatos.Add(contato3);

            //cli.Gravar();

            //foreach (Classes.Contato cont in cli.Contatos)
            //{
            //   Console.WriteLine(cont.DadosContato);
            //}

            //cli.Contatos.ForEach(cont => Console.WriteLine(cont.DadosContato));

            //cli.Contatos.ForEach(cont => cont.Gravar());
            // -------------------------------------------------
            // Convert.ToDateTime("..."); - Converte variavel para data
            //cli.Valor = 25;
            //cli.Valor = cli.Valor.Juros();
            //int metadeCliente = cli.Codigo.Metade();
            //Console.WriteLine(cli.Valor);
            // -------------------------------------------------

            //Classes.Contato contatoBuscado = cli.Contatos.FirstOrDefault(x => x.Tipo == "Telefone");
            Console.ReadLine();
        }


    }
}