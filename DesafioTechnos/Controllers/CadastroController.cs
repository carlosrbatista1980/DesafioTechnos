using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DesafioTechnos.Models;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Helpers;
using EntityFrameworkCore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace DesafioTechnos.Controllers
{
    public class CadastroController : Controller
    {
        // GET: CadastroController
        public ActionResult Index()
        {
            ViewBag.Marcas = new MarcaService().GetMarcas();
            ViewBag.TipoProdutos = new TipoProdutoService().GetTipoProdutos();

            return View();
        }

        // GET: CadastroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadastroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadastroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadastroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Cadastra os produtos especificos de acordo com o requisito
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/CadastrarProdutos")]
        public IActionResult CadastrarProdutos([FromBody] JsonElement json)
        {
            var request = JsonConvert.DeserializeObject<ProdutoModel>(json.ToString());

            if (request is null)
            {
                return new JsonResult(new
                {
                    statusCode = new HttpResponseMessage(HttpStatusCode.BadRequest).StatusCode,
                    mensagem = new HttpResponseMessage(HttpStatusCode.BadRequest).ReasonPhrase,
                });
            }

            try
            {
                var produto = new Produto();
                produto = MapHelper.MapFrom(request, produto);
                var ret = new ProdutoService().CadastrarProduto(produto);
                if (ret > 0)
                {
                    return new JsonResult(new
                    {
                        statusCode = new HttpResponseMessage(HttpStatusCode.Accepted).StatusCode,
                        mensagem = $"Produto {request.Nome} cadastrado com sucesso!",
                    });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    statusCode = new HttpResponseMessage(HttpStatusCode.InternalServerError).StatusCode,
                    mensagem = $"ERROR: {ex.GetBaseException().Message}",
                });
            }

            return null;
        }

        [HttpGet]
        [Route("api/[controller]/GetToken")]
        public IActionResult GetToken()
        {
            var usuario = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVxXyYzZ1234567890";

            return new JsonResult(new
            {
                token = AuthenticationService.BuildToken(usuario),
            }); 
        }

        public IActionResult Produtos()
        {
            var list = new List<ProdutoModel>();
            var produtos = new ProdutoService().GetProdutos();
            foreach (var produto in produtos)
            {
                var model = new ProdutoModel();
                MapHelper.MapFrom(produto, model);
                list.Add(model);
            }

            return View(list);
        }
    }
}
