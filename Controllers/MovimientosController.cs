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
    public class MovimientosController : Controller
    {
        private readonly ICuenta _cuentaRepo;
        private readonly ITipoCuenta _tipoCuentaRepo;
        private readonly ICliente _clienteRepo;
        private readonly IMovimiento _movimientoRepo;
        private string mensaje = string.Empty;

        public MovimientosController(ICuenta cuentaRepo, ITipoCuenta tipoCuentaRepo, ICliente clienteRepo, IMovimiento movimientoRepo)
        {
            _cuentaRepo = cuentaRepo;
            _tipoCuentaRepo = tipoCuentaRepo;
            _clienteRepo = clienteRepo;
            _movimientoRepo = movimientoRepo;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<MovimientoModel> lstMovimiento = _movimientoRepo.GetItems();
            return View(lstMovimiento);
        }

        [HttpGet("Select")]
        public IActionResult Select(int id)
        {
            try
            {
                MovimientoModel movReturn = _movimientoRepo.GetItem(id);
                return Ok(movReturn);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpGet("SelectAll")]
        public IActionResult SelectAll()
        {
            IEnumerable<MovimientoModel> lstMov = _movimientoRepo.GetItems();
            return Ok(lstMov);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            MovimientoModel mov = new MovimientoModel();
            ViewBag.Cuentas = GetCuenta();
            ViewBag.TipoMov = GetTipoMovimiento();
            return View(mov);
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] MovimientoModel movimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string json = JsonSerializer.Serialize(movimiento);
                    CreateApi(movimiento);
                    if (string.IsNullOrEmpty(mensaje))
                    {
                    TempData["Mensaje"] = "El movimiento se registró correctamente.";
                    return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Mensaje"] = mensaje; 
                        ViewBag.Cuentas = GetCuenta();
                        ViewBag.TipoMov = GetTipoMovimiento();
                    }
                }
                else
                {
                    ViewBag.Cuentas = GetCuenta();
                    ViewBag.TipoMov = GetTipoMovimiento();
                }
                return View();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("CreateApi")]
        public IActionResult CreateApi(MovimientoModel movimiento)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                decimal valorMov = 0;
                CuentaModel cuenta;

                if (movimiento.TipoMovimiento == "D" && movimiento.Valor > decimal.Parse(GlobalParametro.valorRetiro))
                {
                    response.ErrorId = 1;
                    response.ErrorMensaje = "Excede el valor díario de retiro.";
                    mensaje = response.ErrorMensaje;

                    return Ok(response);
                }

                //Setear la fecha de movimiento
                movimiento.Fecha = DateTime.Now;

                //Obtener en valor del movimiento según tipo
                valorMov = (movimiento.TipoMovimiento == "D" ? (movimiento.Valor * -1) : movimiento.Valor);

                //Consultar saldo de la cuenta
                cuenta = GetCuenta(movimiento.CuentaId);

                if (movimiento.TipoMovimiento == "D" && cuenta.Saldo == 0)
                {
                    response.ErrorId = 1;
                    response.ErrorMensaje = "Saldo no disponible.";
                    mensaje = response.ErrorMensaje;

                    return Ok(response);
                }

                if (movimiento.TipoMovimiento == "D" && cuenta.Saldo < movimiento.Valor)
                {
                    response.ErrorId = 1;
                    response.ErrorMensaje = "Cupo diario excedido.";
                    mensaje = response.ErrorMensaje;

                    return Ok(response);
                }

                //Calcular valores
                movimiento.SaldoInicial = cuenta.Saldo;
                movimiento.Saldo = cuenta.Saldo + valorMov;

                //Crear movimiento
                _movimientoRepo.Create(movimiento);

                //Actualizar saldo de la cuenta
                cuenta.Saldo = movimiento.Saldo;
                _cuentaRepo.Edit(cuenta);

                response.ErrorId = 0;
                response.ErrorMensaje = "El movimiento se registró correctamente.";
                response.root.Add(movimiento);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        private List<SelectListItem> GetCuenta()
        {
            var lstCuenta = new List<SelectListItem>();
            List<CuentaModel> cuentas = _cuentaRepo.GetItems().ToList();

            lstCuenta = cuentas.Select(tp => new SelectListItem() { Value = tp.Id.ToString(), Text = tp.Numero + " - " + tp.TipoCuenta.Valor + " - " + tp.Cliente.Persona.Nombre }).ToList();

            return lstCuenta;
        }

        private CuentaModel GetCuenta(int id)
        {
            CuentaModel cuenta = _cuentaRepo.GetItem(id);

            return cuenta;
        }

        private decimal GetSalodCuenta(int idCuenta)
        {
            CuentaModel cuenta = _cuentaRepo.GetItem(idCuenta);
            return cuenta.Saldo;
        }

        private List<SelectListItem> GetTipoMovimiento()
        {
            var lstGenero = new List<SelectListItem>();
            SelectListItem defItem;
            defItem = new SelectListItem() { Value = "C", Text = "Crédito" };
            lstGenero.Insert(0, defItem);

            defItem = new SelectListItem() { Value = "D", Text = "Débito" };
            lstGenero.Insert(1, defItem);

            return lstGenero;
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
