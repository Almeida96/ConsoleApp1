using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    
    public partial class Cliente
    {
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { 
                if (value < 0)
                {
                    throw new ConsoleApp1.Excecoes.ValidacaoException("O Codigo do Cliente nao pode ser negativo");
                    _codigo = 0;
                }
                _codigo = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { 
                if (value.Length <= 3)
                {
                    throw new ConsoleApp1.Excecoes.ValidacaoException("O nome do cliente precisa ter no minimo 4 caracteres");
                }
                _nome = value; }
        }

        private int? _tipo;
        public int? Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private DateTime? _datacadastro;
        public DateTime? DataCadastro
        {
            get { return _datacadastro; }
            set { _datacadastro = value; }
        }

        

        public List<Contato> Contatos { get; set; }

        //Lista - usado para multiplicidade de classe
        // ? serve para poder usar variaves null, string não precisa dessa definição
        // prop - predefinição de propriedade

        //public int Codigo { get; set; }
        //public string Nome { get; set; }
        //public int? Tipo { get; set; }
        //public DateTime? DataCadastro { get; set; }

        // Partial - particionar a classe

    }
}
