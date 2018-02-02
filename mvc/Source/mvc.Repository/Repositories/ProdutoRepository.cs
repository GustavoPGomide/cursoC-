using Cursocsharp.Dominio;
using mvc.Repository.DataBese;
using System;
using System.Collections.Generic;

namespace mvc.Repository.Repositories
{
    public class ProdutoRepository : Execucao
    {
        private static readonly Conexao conexao = new Conexao();

        public ProdutoRepository() : base(conexao)
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

        public string CadrastraProduto(Produto produto)
        {
            ExecuteProcedure("SP_InsProduto");
            AddParameter("@Nome",produto.Nome);
            AddParameter("@Preco",produto.Preco);
            AddParameter("@Estoque",produto.Estoque);

            var retorno = ExecuteNonQueryWithReturn();
            if (retorno == 1)
                return "Erro ao inserir o produto";
            return null;
        }

        public string DeletarProduto(int codigoProduto)
        {
            ExecuteProcedure("SP_DelProduto");
            AddParameter("@CodigoProduto", codigoProduto);

            var retorno = ExecuteNonQueryWithReturn();

            switch (retorno)
            {
                case 1:return "Execlusã não permitida ";
                case 2:return "Produto adicionado com sucesso";

            }
            return null;
        }
    }
}
