using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Logistica.DAL
{
    public class PedidoDAO
    {
    private SqlCommand cmd = null;
    private SqlConnection con = null;

    public int valor { get; set; } = 0;

    public void Cadastrar(
              int IdUsuario
            , int IdProduto
            , int IdEndereco
            , DateTime DataEntrega)
    {
        try
        {
            con = ConnectionFactory.getConnection();
            con.Open();

            cmd = new SqlCommand("INSERT INTO Pedido(IdUsuario, IdProduto, IdEndereco, DataDeEntrega) VALUES " +
                "(@IdUsuario, @IdProduto, @IdEndereco, @DataDeEntrega);", con);

            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            cmd.Parameters.AddWithValue("@IdProduto", IdProduto);
            cmd.Parameters.AddWithValue("@IdEndereco", IdEndereco);
            cmd.Parameters.AddWithValue("@DataDeEntrega", DataEntrega.ToString("yyyy/MM/dd").Replace("/","-"));


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
