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
            Classes.Cliente cli = new Classes.Cliente();
            cli.Codigo = Convert.ToInt32("3");
            cli.Nome = "Jaime";
            cli.Tipo = 1;
            cli.DataCadastro = new DateTime(2022, 05, 31);
            // Convert.ToDateTime("..."); - Converte variavel para data


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
            contato3.Tipo = "O que o jaime faz conosco";


            cli.Contatos = new List<Classes.Contato>();
            cli.Contatos.Add(contato1);
            cli.Contatos.Add(contato2);
            cli.Contatos.Add(contato3);

            //cli.Gravar();

            //foreach (Classes.Contato cont in cli.Contatos)
            //{
            //   Console.WriteLine(cont.DadosContato);
            //}

            //cli.Contatos.ForEach(cont => Console.WriteLine(cont.DadosContato));

            cli.Contatos.ForEach(cont => cont.Gravar());

            Classes.Contato contatoBuscado = cli.Contatos.FirstOrDefault(x => x.Tipo == "Telefone");
            //Console.WriteLine(contatoBuscado.DadosContato);
            Console.ReadLine();
        }
    }
}