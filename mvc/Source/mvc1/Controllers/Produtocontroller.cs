using Cursocsharp.Dominio;
using mvc.Repository.Repositories;
using System;
using System.Net;
using System.Web.Http;

namespace mvc.Api.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly ProdutorePepository _produtoRepository = new ProdutorePepository();

       [HttpGet,Route("listaProdutos")]
        public IHttpActionResult GetProdutos()
        {
            try
            {
                return Ok(_produtoRepository.GetProdutos());

            }
            catch
            {

                return BadRequest("Erro ao listar produtos");
            }
        }
    }
}