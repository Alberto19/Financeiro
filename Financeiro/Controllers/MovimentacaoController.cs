using Financeiro.DAO;
using Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    [Authorize]
    public class MovimentacaoController : Controller
    {
       
        private MovimentacaoDAO movimentacaoDAO;
        private UsuarioDAO usuarioDAO;
        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDAO)
        {
            this.movimentacaoDAO = movimentacaoDAO;
            this.usuarioDAO = usuarioDAO;
        }

        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.List();
            return View();
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                movimentacaoDAO.Adiciona(movimentacao);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.List();
                return View("Form", movimentacao);
            }
        }

        public ActionResult Index()
        {
            IList<Movimentacao> movimentacoes = movimentacaoDAO.List();
            return View(movimentacoes);
        }

        public ActionResult MovimentacoesPorUsuario(MovimentacoesPorUsuarioModel model)
        {
            model.Usuarios = usuarioDAO.List();
            model.Movimentacoes = movimentacaoDAO.BuscaPorUsuario(model.UsuarioId);

            return View(model);
        }

        public ActionResult Busca(BuscaMovimentacoesModel model)
        {
            model.Usuarios = usuarioDAO.List();
            model.Movimentacoes = movimentacaoDAO.Busca(  model.ValorMinimo, model.ValorMaximo,
                                                                    model.DataMinima, model.DataMaxima, 
                                                                    model.Tipo, model.UsuarioId);
            return View(model);
        }


    }
}