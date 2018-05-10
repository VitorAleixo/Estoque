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
        public string connectionString = "Data Source=UPDEVLAB0522;Initial Catalog=Logistica;User ID=sa;Password=sa";

        public bool Login (string Usuario, string SenhaCriptografada)
        { 
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            Login log = new Login();
            string result = "";

            SqlCommand cmd = new SqlCommand("SELECT Senha FROM Usuario WHERE Usuario = @Usuario", con);
            cmd.Parameters.AddWithValue("@Usuario", Usuario);

            SqlDataReader resultado = cmd.ExecuteReader();
            
            while (resultado.Read())
            {
               result = resultado["Senha"].ToString();             
            }
            if (result == SenhaCriptografada)
            {
                return true;
            }
            else
            {
                return false;
            }
            cmd.Dispose();
            con.Close();
        }
    }
}