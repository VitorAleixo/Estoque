using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Logistica.DAL
{
    public class EntregaDAO
    {
        private SqlCommand cmd = null;
        private SqlConnection con = null;

        public int valor { get; set; } = 0;
        public void AtualizarStatus(int IdEntrega, string StatusEntrega)
        {
            try
            {
            con = ConnectionFactory.getConnection();
            con.Open();

            cmd = new SqlCommand("UPDATE Entregas SET StatusEntrega = @StatusEntrega WHERE IdEntregas = @IdEntrega;", con);

            cmd.Parameters.AddWithValue("@IdEntrega", IdEntrega);
            cmd.Parameters.AddWithValue("@StatusEntrega", StatusEntrega);
           
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