using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Logistica.DAL
{
    [Serializable]
    public class BuscaPedidoDAO
    {
        [XmlRoot("BuscaPedido")]
        public class ListaPedido
        {
            public ListaPedido() { Items = new List<Pedido>(); }
            [XmlElement("PEDIDO")]
            public List<Pedido> Items { get; set; }



        }
        public class Pedido
        {
            [XmlElement("IdPedido")]
            public int IdPedido { get; set; }

            [XmlElement("IdCliente")]
            public int IdCliente { get; set; }

            [XmlElement("IdProduto")]
            public int IdProduto { get; set; }

            [XmlElement("IdEndereco")]
            public int IdEndereco { get; set; }

            [XmlElement("DataDeEntrega")]
            public string DataDeEntrega { get; set; }

        }

        public static class Program
        {

            private static SqlConnection con = null;
            private static SqlDataReader rdr = null;
            private static string comando = null;
            private static SqlCommand cmd = null;
            public static ListaPedido list { get; set; }


            public static ListaPedido RetornarPedido()
            {
                try
                {
                    con = ConnectionFactory.getConnection();
                    con.Open();

                    comando = "SELECT IdPedido, IdCliente, IdProduto, IdEndereco, DataDeEntrega FROM Pedido ORDER BY DataDeEntrega;";

                    XmlSerializer ser = new XmlSerializer(typeof(ListaPedido));
                    list = new ListaPedido();

                    using (var cmd = con.CreateCommand())
                    {

                        cmd.CommandText = comando.ToString();
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                list.Items.Add(new Pedido
                                {
                                    IdPedido = rdr.GetInt32(0),
                                    IdCliente = rdr.GetInt32(1),
                                    IdProduto = rdr.GetInt32(2),
                                    IdEndereco = rdr.GetInt32(3),
                                    DataDeEntrega = rdr.GetDateTime(4).ToString("dd/MM/yyyy").Replace("-","/"),
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
