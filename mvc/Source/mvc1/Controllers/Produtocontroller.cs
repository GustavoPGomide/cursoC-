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
        [HttpPost, Route("cadastraProduto")]
        public IHttpActionResult PostProduto(Produto produto)
        {
            try
            {
                var retorno = _produtoRepository.CadrastraProduto(produto);
                if (retorno != null)
                {
                    return BadRequest(retorno);
                }
                return Ok("Produtos fo cadastrado com sucesso!");
            }
            catch
            {
                return BadRequest();
            }

            }

        }
    }
