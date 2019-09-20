
using AutoMapper;
using BaseDDD.Application.Interface;
using BaseDDD.Domain.Entities;
using BaseDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BaseDDD.MVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;
        private readonly IPedidoAppService _pedidoApp;
        private readonly IPedidoItemAppService _pedidoItemApp;
        private readonly IMapper _mapper;

        public PedidosController(IProdutoAppService produtoApp, IClienteAppService clienteApp, IMapper mapper, IPedidoAppService pedidoApp, IPedidoItemAppService pedidoItemApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
            _mapper = mapper;
            _pedidoApp = pedidoApp;
            _pedidoItemApp = pedidoItemApp;
        }

        public ActionResult Index()
        {
            var produtoViewModel = _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoApp.GetAll());

            return View(produtoViewModel);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            var pedido = _pedidoApp.GetById(id);
            var pedidoViewModel = _mapper.Map<Pedido, PedidoViewModel>(pedido);

            return View(pedidoViewModel);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome");
            return View();
        }

        public ActionResult AddProduto(int produtoId, int pedidoId)
        {
            if(pedidoId == 0)
            {    
                _pedidoApp.Add(new Pedido());
            }

            return RedirectToAction("Index");
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel pedido)
        {
            if (ModelState.IsValid)
            {
                var pedidoDomain = _mapper.Map<PedidoViewModel, Pedido>(pedido);
                _pedidoApp.Add(pedidoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ProdutosId = new SelectList(_produtoApp.GetAll(), "ProdutosId", "Nome", pedido.PedidoId);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            var pedido = _pedidoApp.GetById(id);
            var pedidoViewModel = _mapper.Map<Pedido, PedidoViewModel>(pedido);

            ViewBag.ProdutosId = new SelectList(_produtoApp.GetAll(), "ProdutosId", "Nome", pedido.PedidoId);

            return View(pedidoViewModel);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedido)
        {
            if (ModelState.IsValid)
            {
                var pedidoDomain = _mapper.Map<PedidoViewModel, Pedido>(pedido);
                _pedidoApp.Update(pedidoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ProdutosId = new SelectList(_produtoApp.GetAll(), "ProdutosId", "Nome", pedido.PedidoId);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            var pedido = _pedidoApp.GetById(id);
            var pedidoViewModel = _mapper.Map<Pedido, PedidoViewModel>(pedido);

            return View(pedidoViewModel);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pedido = _pedidoApp.GetById(id);
            _pedidoApp.Remove(pedido);

            return RedirectToAction("Index");
        }
    }
}
