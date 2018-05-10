using Logistica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Logistica.DAL
{

    public class UsuarioDAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public bool Validar { get; set; } = false;

        public void Login (string Usuario, string SenhaCriptografada)
        {
            con = ConnectionFactory.getConnection();
            con.Open();
            string result = "";
            cmd = new SqlCommand("SELECT Senha FROM Entregador WHERE Usuario = @Usuario;", con);
            cmd.Parameters.AddWithValue("@Usuario", Usuario);

            SqlDataReader resultado = cmd.ExecuteReader();
            
            while (resultado.Read())
            {
               result = resultado["Senha"].ToString();             
            }
            if (result == SenhaCriptografada)
            {
                Validar = true;
            }
            else
            {
                Validar = false;
            }
            cmd.Dispose();
            con.Close();
        }
    }
}