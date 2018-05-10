using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Logistica.DAL
{
    public class ClienteDAO
    {
        private SqlCommand cmd = null;
        private SqlConnection con = null;

        public int valor { get; set; } = 0;

        public void Cadastrar(
                  string Nome
                , string CPF
                , string Telefone
                , int IdEndereco)
        {
            try
            {
                con = ConnectionFactory.getConnection();
                con.Open();

                cmd = new SqlCommand("INSERT INTO Cliente(Nome, CPF, Telefone, IdEndereco) VALUES " +
                    "(@Nome, @CPF, @Telefone, @IdEndereco);", con);

                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Telefone", Telefone);
                cmd.Parameters.AddWithValue("@IdEndereco", IdEndereco);


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