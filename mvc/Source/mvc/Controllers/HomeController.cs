using mvc.Application.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc.Controllers
{
    public class HomeController : Controllers
    {
      private readonly ProdutoApplication _produtoApplication = new ProdutoApplication();

        public ActionrResult ListarProduto()
        {
            var response -_produtoApplication.GetProdutos();
            
            if (response_Status !=HttpStatusCodeResult.ok)
                response. Status - (int)HttpStatusCodeResult.BadRequest
                Response.TrySkiptisCustomErros = true;
            return ContentResult (response )

        }
    }
}