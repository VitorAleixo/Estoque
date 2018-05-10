using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Logistica.DAL
{
    public class ProdutoDAO
    {
        private SqlCommand cmd = null;
        private SqlConnection con = null;

        public int valor { get; set; } = 0;

        public void Cadastrar(
                   int IdTipo_Produto
                 , string Descricao
                 , int Quantidade
                 , double Valor
                 , double Peso
                 , double TamanhoX
                 , double TamanhoY
                 , double TamanhoZ)
        {
            try
            {
                con = ConnectionFactory.getConnection();
                con.Open();

                cmd = new SqlCommand("INSERT INTO Produto(IdTipo_Produto, Descricao, Quantidade, Valor, Peso, TamanhoX, TamanhoY, TamanhoZ) VALUES " +
                    "(@IdTipo_Produto, @Descricao, @Quantidade, @Valor, @Peso, @TamanhoX, @TamanhoY, @TamanhoZ);", con);

                cmd.Parameters.AddWithValue("@IdTipo_Produto", IdTipo_Produto);
                cmd.Parameters.AddWithValue("@Descricao", Descricao);
                cmd.Parameters.AddWithValue("@Quantidade", Quantidade);
                cmd.Parameters.AddWithValue("@Valor", Valor.ToString().Replace(',','.'));
                cmd.Parameters.AddWithValue("@Peso", Peso.ToString().Replace(',', '.'));
                cmd.Parameters.AddWithValue("@TamanhoX", TamanhoX.ToString().Replace(',', '.'));
                cmd.Parameters.AddWithValue("@TamanhoY", TamanhoY.ToString().Replace(',', '.'));
                cmd.Parameters.AddWithValue("@TamanhoZ", TamanhoZ.ToString().Replace(',', '.'));


                if (cmd.ExecuteNonQuery() == 1)
                {
                    valor = 1;
                }
                else
                {
                    valor = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                try
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                try
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
    }
}
