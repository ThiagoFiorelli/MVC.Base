using AutoMapper;
using BaseDDD.Application.Interface;
using BaseDDD.Domain.Entities;
using BaseDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseDDD.MVC.Controllers
{
    public class PedidoItemController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IPedidoAppService _pedidoApp;
        private readonly IPedidoItemAppService _pedidoItemApp;
        private readonly IMapper _mapper;

        public PedidoItemController(IProdutoAppService produtoApp, IMapper mapper, IPedidoAppService pedidoApp, IPedidoItemAppService pedidoItemApp)
        {
            _produtoApp = produtoApp;
            _mapper = mapper;
            _pedidoApp = pedidoApp;
            _pedidoItemApp = pedidoItemApp;
        }

        // GET: PedidoItem
        public ActionResult Index()
        {
            var pedidoItemViewModel = _mapper.Map<IEnumerable<PedidoItem>, IEnumerable<PedidoItemViewModel>>(_pedidoItemApp.GetAll());

            return View(pedidoItemViewModel);
        }

        public ActionResult AdicionarItem(PedidoItemViewModel pedidoItem)
        {
            var pedidoDomain = _mapper.Map<PedidoItemViewModel, PedidoItem>(pedidoItem);
            _pedidoItemApp.Add(pedidoDomain);

            return View();
        }

        // GET: PedidoItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
