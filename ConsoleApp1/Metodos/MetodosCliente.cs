using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MetodosExtensao
{
    public static int Metade (this int Valor)
    {
        return Valor / 2;
    }
    public static double Juros(this double Valor)
    {
        return Valor + 20;
    }
    public static string PrimeiraMaiuscula(this string Valor)
    {
        return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
    }
    public static string PrimeiraMaiuscula(this string Valor, bool UltimasMinusculas)
    {
        if (UltimasMinusculas)
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
        }
        else
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1);
        }
    }
}

namespace ConsoleApp1.Classes
{
    public partial class Cliente : IDisposable
    {
        public void Gravar()
        {
            int x = 3;
        }
        public void Apagar()
        {

        }



        public Cliente()
        {

        }
        public Cliente(int Codigo)
        {
            // TODO: Criar o procedimento de leitura baseado no parâmetro código
            int x = 0;
        }
        public void Dispose()
        {
            this.Gravar();
        }
    }
}
