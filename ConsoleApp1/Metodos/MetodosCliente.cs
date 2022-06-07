using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //System.Data.SqlClient.SqlConnection
            using (SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Loja;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Insert Into Cliente (Codigo, Nome, Tipo, DataCadastro) Values (@codigo, @nome, @tipo, @datacadastro)";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@datacadastro", this._datacadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public void Apagar()
        {

        }
        
        public Cliente()
        {

        }
        public Cliente(int Codigo)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Loja;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    throw;
                }
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * From Cliente Where Codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", Codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            this._nome = dr.GetString(dr.GetOrdinal("Nome"));
                            this._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                            this._datacadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));
                        }
                    }
                }

            }
        }
        public void Dispose()
        {
            this.Gravar();
        }
    }
}
