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
        public string connectionString = "Data Source=MEUPC;Initial Catalog=Logistica;User ID=sa;Password=sa";
        public bool Validar { get; set; } = false;

        public void Login (string Usuario, string SenhaCriptografada)
        { 
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            Login log = new Login();
            string result = "";
            string comando = "SELECT Senha FROM Usuario WHERE Usuario = '" + Usuario + "';";
            SqlCommand cmd = new SqlCommand(comando, con);
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