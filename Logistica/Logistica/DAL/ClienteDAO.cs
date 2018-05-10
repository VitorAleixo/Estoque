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
                , string Usuario
                , string Senha
                , string Telefone
                , int IdRole)
        {
            try
            {
                con = ConnectionFactory.getConnection();
                con.Open();

                cmd = new SqlCommand("INSERT INTO Usuario(Nome, CPF, Usuario, Senha, Telefone, IdRole) VALUES " +
                    "(@Nome, @CPF, @Usuario, @Senha, @Telefone, @IdRole);", con);

                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Senha", Senha);
                cmd.Parameters.AddWithValue("@Telefone", Telefone);
                cmd.Parameters.AddWithValue("@IdRole", IdRole);


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
        public string BuscaRole(string Usuario)
        {
            try
            {
                con = ConnectionFactory.getConnection();
                con.Open();

                cmd = new SqlCommand("SELECT NomeRole FROM Role r INNER JOIN Usuario u ON u.IdRole = r.IdRole WHERE u.Usuario = @Usuario;", con);

                cmd.Parameters.AddWithValue("@Usuario", Usuario);

                SqlDataReader resultado = cmd.ExecuteReader();
                var result = "";
                while (resultado.Read())
                {
                   result = resultado["NomeRole"].ToString();
                }
                return result;
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