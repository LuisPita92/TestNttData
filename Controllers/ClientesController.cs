using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ntt.data.test.luis.pita.Interfaces;
using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ntt.data.test.luis.pita.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IPersona _personaRepo;
        private readonly ICliente _clienteRepo;

        public ClientesController(ICliente clienteRepo, IPersona personaRepo)
        {
            _clienteRepo = clienteRepo;
            _personaRepo = personaRepo;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<ClienteModel> lstClientes = _clienteRepo.GetItems();
            return View(lstClientes);
        }

        [HttpGet("Select")]
        public IActionResult Select(int clienteId)
        {
            try
            {
                ClienteModel clienteReturn = _clienteRepo.GetItem(clienteId);
                return Ok(clienteReturn);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpGet("SelectAll")]
        public IActionResult SelectAll()
        {
            IEnumerable<ClienteModel> lstClientes = _clienteRepo.GetItems();
            return Ok(lstClientes);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ClienteModel cliente = new ClienteModel();
            ViewBag.Personas = GetPersonas();
            ViewBag.Generos = GetGeneros();
            return View(cliente);
        }

        [HttpPost("CreateView")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateView([FromForm] ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Create(cliente);
                    TempData["Mensaje"] = "El cliente se creó correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Personas = GetPersonas();
                    ViewBag.Generos = GetGeneros();
                }
                return View();
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(ClienteModel cliente)
        {
            try
            {
                ResponseModel response = new ResponseModel();

                PersonaModel persona = _personaRepo.Create(cliente.Persona);
                cliente.PersonaId = persona.Id;
                _clienteRepo.Create(cliente);

                response.ErrorId = 0;
                response.ErrorMensaje = "El cliente se creó correctamente.";
                response.root.Add(cliente);

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
            var cliente = _clienteRepo.GetItem(Id);

            if (cliente == null)
            {
                return NotFound();
            }
            ViewBag.Personas = GetPersonas();
            ViewBag.Generos = GetGeneros();
            return View(cliente);
        }

        [HttpPost("EditView")]
        [ValidateAntiForgeryToken]
        public IActionResult EditView([FromForm] ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Edit(cliente);
                    TempData["Mensaje"] = "El cliente se modificó correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Personas = GetPersonas();
                    ViewBag.Generos = GetGeneros();
                }
                return View();
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpPost("Edit")]
        public IActionResult Edit(ClienteModel cliente)
        {
            try
            {
                ResponseModel response = new ResponseModel();

                _clienteRepo.Edit(cliente);

                response.ErrorId = 0;
                response.ErrorMensaje = "El cliente se modificó correctamente.";
                response.root.Add(cliente);

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
            var cliente = _clienteRepo.GetItem(Id);

            if (cliente == null)
            {
                return NotFound();
            }
            ViewBag.Personas = GetPersonas();
            ViewBag.Generos = GetGeneros();
            return View(cliente);
        }

        [HttpPost("DeleteCliente")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCliente([FromForm] int id)
        {
            try
            {
                DeleteApi(id);

                TempData["Mensaje"] = "El cliente se eliminó correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteApi(int id)
        {
            try
            {
                ResponseModel response = new ResponseModel();

                var cliente = _clienteRepo.GetItem(id);

                if (cliente == null)
                {
                    return NotFound();
                }
                _clienteRepo.Delete(cliente);
                _personaRepo.Delete(cliente.Persona);

                response.ErrorId = 0;
                response.ErrorMensaje = "El cliente se eliminó correctamente.";
                response.root.Add(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel() { ErrorId = 1, ErrorMensaje = ex.Message });
            }
        }

        private List<SelectListItem> GetPersonas()
        {
            var lstPersona = new List<SelectListItem>();
            List<PersonaModel> personas = _personaRepo.GetItems().ToList();

            lstPersona = personas.Select(tp => new SelectListItem() { Value = tp.Id.ToString(), Text = tp.Nombre }).ToList();

            return lstPersona;
        }

        private List<SelectListItem> GetGeneros()
        {
            var lstGenero = new List<SelectListItem>();
            SelectListItem defItem;
            defItem = new SelectListItem() { Value = "M", Text = "Masculino" };
            lstGenero.Insert(0, defItem);

            defItem = new SelectListItem() { Value = "F", Text = "Femenino" };
            lstGenero.Insert(1, defItem);

            return lstGenero;
        }
    }
}
