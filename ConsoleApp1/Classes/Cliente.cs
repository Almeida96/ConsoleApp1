using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    // Partial - particionar a classe
    public partial class Cliente
    {
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public int? Tipo { get; set; }
        public DateTime? DataCadastro { get; set; }

        // ? serve para poder usar variaves null, string não precisa dessa definição
        // prop - predefinição de propriedade

        public List<Contato> Contatos { get; set; }

        //Lista - usado para multiplicidade de classe

    }
}
