using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Logistica.DAL
{
    [Serializable]
    public class BuscaClienteDAO
    {
        
            [XmlRoot("BuscaCliente")]
            public class ListaCliente
            {
                public ListaCliente() { Items = new List<Cliente>(); }
                [XmlElement("CLIENTE")]
                public List<Cliente> Items { get; set; }



            }
            public class Cliente
            {
                [XmlElement("Nome")]
                public String Nome { get; set; }

                [XmlElement("CPF")]
                public String CPF { get; set; }

                [XmlElement("Usuario")]
                public String Usuario { get; set; }

                [XmlElement("Telefone")]
                public String Telefone { get; set; }

                [XmlElement("Role")]
                public String Role { get; set; }

            }

            public static class Program
            {

                private static SqlConnection con = null;
                private static SqlDataReader rdr = null;
                private static string comando = null;
                private static SqlCommand cmd = null;
                public static ListaCliente list { get; set; }


                public static ListaCliente RetornarCliente()
                {
                    try
                    {
                        con = ConnectionFactory.getConnection();
                        con.Open();

                        comando = "SELECT Nome, CPF, Usuario, Telefone, NomeRole  " +
                        "FROM Usuario INNER JOIN Role ON Usuario.IdRole = Role.IdRole " +
                        "ORDER BY NomeRole;";

                        XmlSerializer ser = new XmlSerializer(typeof(ListaCliente));
                        list = new ListaCliente();

                        using (var cmd = con.CreateCommand())
                        {

                            cmd.CommandText = comando.ToString();
                            using (var rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    list.Items.Add(new Cliente
                                    {

                                        Nome = rdr.GetString(0),
                                        CPF = rdr.GetString(1),
                                        Usuario = rdr.GetString(2),
                                        Telefone = rdr.GetString(3),
                                        Role = rdr.GetString(4)
                                    });
                                }
                            }
                            cmd.Dispose();

                        }

                        return list;

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
                            if (rdr != null)
                            {
                                rdr.Close();
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
}