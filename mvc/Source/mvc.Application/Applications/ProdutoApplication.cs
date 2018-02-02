using mvc.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Application.Applications
{
    public class ProdutoApplication
    {
        private readonly string _enderecoApi = $"{ApiConfig.EnderecoApi}/produto";

        public Response<IEnumerable<ProdutoModel>> GetProdutos()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{_enderecoApi}/listaProdutos").Result;
                return new Response<IEnumerable<ProdutoModel>>(response.Content.ReadAsStringAsync().Result, response.StatusCode);
            }
        }
        public Response<string> PostProduto(ProdutoModel produto)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsync($"{_enderecoApi}/cadastraProduto", produto, new JsonMediaTypeFormatter()).Result;
                return new Response<string>(response.Content.ReadAsStringAsync().Result, response.StatusCode);
            }
        }
        public Response<string> deletaProduto(int codigoProduto)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_enderecoApi}/Deletaproduto/{codigoProduto}").Result;
                return new Response<string>(response.Content.ReadAsStringAsync().Result, response.StatusCode);
            }
        }
    }
}