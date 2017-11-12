using LojaAPI.DAO;
using LojaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        /*
         Por convenção nomeia-se os métodos do controller de acordo com os verbos HTTP aos quais esses métodos responderão
             */
        public HttpResponseMessage Get(int id)
        {
            try
            {
                CarrinhoDAO dao = new CarrinhoDAO();
                Carrinho carrinho = dao.Busca(id);
                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch
            {
                string mensagem = $"O carrinho {id} não foi encontrado";
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        //FromBodyAttribute sinaliza que os dados para o POST virão do Body da
        //requisição
        public HttpResponseMessage Post([FromBody]Carrinho carrinho)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);
            HttpResponseMessage response = Request
                .CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", 
                new { controller = "carrinho", id = carrinho.Id });
            response.Headers.Location = new Uri(location);
            return response;
        }

        //RouteAttribute define uma rota customizada para o método
        [Route("api/carrinho/{idCarrinho}/produto/{idProduto}")]
        //FromUriAttribute sinaliza que os dados para o DELETE virão da URI da requisição
        public HttpResponseMessage Delete([FromUri] int idCarrinho, [FromUri] int idProduto)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            Carrinho carrinho = dao.Busca(idCarrinho);
            carrinho.Remove(idProduto);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/carrinho/{idCarrinho}/produto/{idProduto}/quantidade")]
        public HttpResponseMessage Put([FromBody] Produto produto, [FromUri] int idCarrinho)
        {
            var dao = new CarrinhoDAO();
            var carrinho = dao.Busca(idCarrinho);
            carrinho.TrocaQuantidade(produto);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
