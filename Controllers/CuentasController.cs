using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ntt.data.test.luis.pita.Data;
using ntt.data.test.luis.pita.Interfaces;
using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentasController : Controller
    {
        private readonly ICuenta _cuentaRepo;
        private readonly ITipoCuenta _tipoCuentaRepo;
        private readonly ICliente _clienteRepo;

        public CuentasController(ICuenta cuentaRepo, ITipoCuenta tipoCuentaRepo, ICliente clienteRepo)
        {
            _cuentaRepo = cuentaRepo;
            _tipoCuentaRepo = tipoCuentaRepo;
            _clienteRepo = clienteRepo;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<CuentaModel> lstCuentas = _cuentaRepo.GetItems();
            return View(lstCuentas);
        }

        [HttpGet("Select")]
        public IActionResult Select(int cuentaId)
        {
            try
            {
                CuentaModel cuentaReturn = _cuentaRepo.GetItem(cuentaId);
                return Ok(cuentaReturn);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpGet("SelectAll")]
        public IActionResult SelectAll()
        {
            IEnumerable<CuentaModel> lstCuentas = _cuentaRepo.GetItems();
            return Ok(lstCuentas);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            CuentaModel cuenta = new CuentaModel();
            ViewBag.TipoCuentas = GetTipoCuenta();
            ViewBag.Clientes = GetCliente();
            return View(cuenta);
        }

        [HttpPost("CreateView")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateView([FromForm] CuentaModel cuenta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Create(cuenta);
                    TempData["Mensaje"] = "La cuenta se creó correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoCuentas = GetTipoCuenta();
                    ViewBag.Clientes = GetCliente();
                }
                return View();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(CuentaModel cuenta)
        {
            try
            {
                ResponseModel response = new ResponseModel();

                _cuentaRepo.Create(cuenta);

                response.ErrorId = 0;
                response.ErrorMensaje = "La cuenta se creó correctamente.";
                response.root.Add(cuenta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var cuenta = _cuentaRepo.GetItem(Id);

            if (cuenta == null)
            {
                return NotFound();
            }
            ViewBag.TipoCuentas = GetTipoCuenta();
            ViewBag.Clientes = GetCliente();
            return View(cuenta);
        }

        [HttpPost("EditView")]
        [ValidateAntiForgeryToken]
        public IActionResult EditView([FromForm] CuentaModel cuenta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Edit(cuenta);
                    TempData["Mensaje"] = "La cuenta se modificó correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoCuentas = GetTipoCuenta();
                    ViewBag.Clientes = GetCliente();
                }
                return View();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost("Edit")]
        public IActionResult Edit(CuentaModel cuenta)
        {
            try
            {
                ResponseModel response = new ResponseModel();

                _cuentaRepo.Edit(cuenta);

                response.ErrorId = 0;
                response.ErrorMensaje = "La cuenta se modificó correctamente.";
                response.root.Add(cuenta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var cuenta = _cuentaRepo.GetItem(Id);

            if (cuenta == null)
            {
                return NotFound();
            }
            ViewBag.TipoCuentas = GetTipoCuenta();
            ViewBag.Clientes = GetCliente();
            return View(cuenta);
        }

        [HttpPost("DeleteCuenta")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCuenta([FromForm] int id)
        {
            try
            {
                DeleteApi(id);
                
                TempData["Mensaje"] = "La cuenta se eliminó correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteApi(int id)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var cuenta = _cuentaRepo.GetItem(id);

                if (cuenta == null)
                {
                    return NotFound();
                }
                _cuentaRepo.Delete(cuenta);

                response.ErrorId = 0;
                response.ErrorMensaje = "La cuenta se eliminó correctamente.";
                response.root.Add(cuenta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        private List<SelectListItem> GetTipoCuenta()
        {
            var lstTipoCuenta = new List<SelectListItem>();
            List<TipoCuentaModel> tipoCuentas = _tipoCuentaRepo.GetItems().ToList();

            lstTipoCuenta = tipoCuentas.Select(tp => new SelectListItem() { Value = tp.Id.ToString(), Text = tp.Valor }).ToList();

            return lstTipoCuenta;
        }

        private List<SelectListItem> GetCliente()
        {
            var lstCliente = new List<SelectListItem>();
            List<ClienteModel> Clientes = _clienteRepo.GetItems().ToList();

            lstCliente = Clientes.Select(tp => new SelectListItem() { Value = tp.Id.ToString(), Text = tp.Persona.Nombre }).ToList();

            return lstCliente;
        }
    }
}
