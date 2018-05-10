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

            [XmlElement("NomeSolicitante")]
            public String NomeSolicitante { get; set; }

            [XmlElement("NomeProduto")]
            public String NomeProduto { get; set; }

            [XmlElement("CEP")]
            public String CEP { get; set; }

            [XmlElement("Estado")]
            public String Estado { get; set; }

            [XmlElement("Cidade")]
            public String Cidade { get; set; }

            [XmlElement("Bairro")]
            public String Bairro { get; set; }

            [XmlElement("Logradouro")]
            public String Logradouro { get; set; }

            [XmlElement("Numero")]
            public int Numero { get; set; }

            [XmlElement("Complemento")]
            public String Complemento { get; set; }

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

                    comando = "SELECT IdPedido, u.Nome AS Nome_Solicitante, p.Descricao AS Nome_Produto, e.CEP, e.Estado, e.Cidade, e.Bairro, e.Logradouro, e.Numero, e.Complemento, DataDeEntrega " +
                        "FROM Pedido pe INNER JOIN Produto p  ON pe.IdProduto = p.IdProduto  " +
                        "INNER JOIN Endereco e ON e.IdEndereco = pe.IdEndereco " +
                        "INNER JOIN Usuario u ON pe.IdUsuario = u.IdUsuario  " +
                        "ORDER BY DataDeEntrega; ";

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
                                    NomeSolicitante = rdr.GetString(1),
                                    NomeProduto = rdr.GetString(2),
                                    CEP = rdr.GetString(3),
                                    Estado = rdr.GetString(4),
                                    Cidade = rdr.GetString(5),
                                    Bairro = rdr.GetString(6),
                                    Logradouro = rdr.GetString(7),
                                    Numero = rdr.GetInt32(8),
                                    Complemento = rdr.GetString(9),
                                    DataDeEntrega = rdr.GetDateTime(10).ToString("dd/MM/yyyy").Replace("-","/"),
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
