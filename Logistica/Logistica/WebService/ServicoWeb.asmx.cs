using Logistica.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Logistica.WebService
{
    /// <summary>
    /// Summary description for ServicoWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicoWeb : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Autenticar(string Usuario
                             , string SenhaCriptografada)
        {
            UsuarioDAO usuario = new UsuarioDAO();
            usuario.Login(Usuario, SenhaCriptografada);
            if (usuario.Validar == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool CadastroCliente(string Nome
                                  , string CPF
                                  , string Usuario
                                  , string Senha
                                  , string Telefone
                                  , int IdRole)
        {
            ClienteDAO cliente= new ClienteDAO();
            cliente.Cadastrar(Nome, CPF,Usuario,Senha, Telefone, IdRole);
            if (cliente.valor == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public BuscaClienteDAO.ListaCliente RetornaCliente()
        {
            BuscaClienteDAO.Program.RetornarCliente();

            return BuscaClienteDAO.Program.list;
        }

        [WebMethod]
        public string RetornaRole(string Usuario)
        {
            ClienteDAO cliente = new ClienteDAO();
            var retornoCliente = cliente.BuscaRole(Usuario);

            return retornoCliente;
        }

        [WebMethod]
        public bool CadastroProduto(  int IdTipo_Produto
                                    , string Descricao
                                    , int Quantidade
                                    , double Valor
                                    , double Peso
                                    , double TamanhoX
                                    , double TamanhoY
                                    , double TamanhoZ)
        {
            ProdutoDAO produto = new ProdutoDAO();
            produto.Cadastrar(IdTipo_Produto, Descricao, Quantidade, Valor, Peso, TamanhoX, TamanhoY, TamanhoZ);
            if (produto.valor == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public BuscaProdutoDAO.ListaProduto RetornaProduto()
        {
            BuscaProdutoDAO.Program.RetornarProduto();

            return BuscaProdutoDAO.Program.list;
        }

        [WebMethod]
        public bool CadastroPedido(int IdCliente
                                    , int IdProduto
                                    , int IdEndereco
                                    , DateTime DataEntrega)

        {
            PedidoDAO pedido = new PedidoDAO();
            pedido.Cadastrar(IdCliente, IdProduto, IdEndereco, DataEntrega);
            if (pedido.valor == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public BuscaPedidoDAO.ListaPedido RetornaPedido()
        {
            BuscaPedidoDAO.Program.RetornarPedido();

            return BuscaPedidoDAO.Program.list;
        }

        [WebMethod]
        public bool UpdateEntrega(int IdEntrega
                                  , string Status)

        {
            EntregaDAO entrega = new EntregaDAO();
            entrega.AtualizarStatus(IdEntrega, Status);
            if (entrega.valor == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
