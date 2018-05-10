using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Logistica.DAL
{
    [Serializable]
    public class BuscaProdutoDAO
    {
        [XmlRoot("BuscaProduto")]
        public class ListaProduto
        {
            public ListaProduto() { Items = new List<Produto>(); }
            [XmlElement("PRODUTO")]
            public List<Produto> Items { get; set; }



        }
        public class Produto
        {
            [XmlElement("IdProduto")]
            public int IdProduto { get; set; }

            [XmlElement("Tipo")]
            public string Tipo { get; set; }

            [XmlElement("Fragilidade")]
            public String Fragilidade { get; set; }

            [XmlElement("Descricao")]
            public String Descricao { get; set; }

            [XmlElement("Quantidade")]
            public int Quantidade { get; set; }

            [XmlElement("Valor")]
            public double Valor { get; set; }

            [XmlElement("Peso")]
            public double Peso { get; set; }

            [XmlElement("TamanhoX")]
            public double TamanhoX { get; set; }

            [XmlElement("TamanhoY")]
            public double TamanhoY { get; set; }

            [XmlElement("TamanhoZ")]
            public double TamanhoZ { get; set; }

        }

        public static class Program
        {

            private static SqlConnection con = null;
            private static SqlDataReader rdr = null;
            private static string comando = null;
            private static SqlCommand cmd = null;
            public static ListaProduto list { get; set; }


            public static ListaProduto RetornarProduto()
            {
                try
                {
                    con = ConnectionFactory.getConnection();
                    con.Open();

                    comando = "SELECT IdProduto, p.Tipo, p.Fragilidade, Descricao, Quantidade, Valor, Peso, TamanhoX, TamanhoY, TamanhoZ" +
                        " FROM Produto INNER JOIN Tipo_Produto p ON Produto.IdTipo_Produto = p.IdTipo_Produto" +
                        " ORDER BY p.Tipo;";

                    XmlSerializer ser = new XmlSerializer(typeof(ListaProduto));
                    list = new ListaProduto();

                    using (var cmd = con.CreateCommand())
                    {

                        cmd.CommandText = comando.ToString();
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                list.Items.Add(new Produto
                                {

                                    IdProduto = rdr.GetInt32(0),
                                    Tipo = rdr.GetString(1),
                                    Fragilidade = rdr.GetString(2),
                                    Descricao = rdr.GetString(3),
                                    Quantidade = rdr.GetInt32(4),
                                    Valor = rdr.GetDouble(5),
                                    Peso = rdr.GetDouble(6),
                                    TamanhoX = rdr.GetDouble(7),
                                    TamanhoY = rdr.GetDouble(8),
                                    TamanhoZ = rdr.GetDouble(9),
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
