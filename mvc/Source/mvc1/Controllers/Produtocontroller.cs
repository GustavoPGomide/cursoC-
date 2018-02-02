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
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

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

        [HttpDelete, Route("Deletaproduto/{codigoProduto}")]
        public IHttpActionResult DeletarProduto(int codigoProduto)
        {
            try
            {
                var resposta = _produtoRepository.DeletarProduto(codigoProduto);

                if (resposta != null)
                    return BadRequest(resposta);

                return Ok("Prosduto foi deletado com sucesso");

            }
            catch
            {
                return BadRequest("Algo de errado");
            }

        }
    }
}

