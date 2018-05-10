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
            [XmlElement("IdTipo_Produto")]
            public int IdTipo_Produto { get; set; }

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

                    comando = "SELECT IdTipo_Produto, Descricao, Quantidade, Valor, Peso, TamanhoX, TamanhoY, TamanhoZ FROM Produto ORDER BY IdTipo_Produto;";

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

                                    IdTipo_Produto = rdr.GetInt32(0),
                                    Descricao = rdr.GetString(1),
                                    Quantidade = rdr.GetInt32(2),
                                    Valor = rdr.GetDouble(3),
                                    Peso = rdr.GetDouble(4),
                                    TamanhoX = rdr.GetDouble(5),
                                    TamanhoY = rdr.GetDouble(6),
                                    TamanhoZ = rdr.GetDouble(7),
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
