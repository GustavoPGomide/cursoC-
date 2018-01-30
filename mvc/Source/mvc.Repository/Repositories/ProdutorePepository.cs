using Cursocsharp.Dominio;
using mvc.Repository.DataBese;
using System;
using System.Collections.Generic;

namespace mvc.Repository.Repositories
{
    public class ProdutorePepository : Execucao
    {
        private static Conexao conexao = new Conexao();

        public ProdutorePepository() : base(conexao)
        {

        }
        public IEnumerable<Produto> GetProdutos()
        {
            ExecuteProcedure("[dbo].[sp_Selprodutos]");

            var Produtos = new List<Produto>();
            using (var reader = ExecuteReader())
            {

                while (reader.Read())
                    Produtos.Add(new Produto
                    {
                        CodigoProduto = reader.ReadAsInt("CodigoProduto"),
                        Nome = reader.ReadAsString("Nome"),
                        Preco = reader.ReadAsDecimal("Preco"),
                        Estoque = reader.ReadAsShort ("Estoque")
                    });

            }

            return Produtos;
        }
    }
}
