using Microsoft.EntityFrameworkCore;
using ntt.data.test.luis.pita.Data;
using ntt.data.test.luis.pita.Interfaces;
using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Repository
{
    public class ClienteRepo : ICliente
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ClienteModel> GetItems()
        {
            IEnumerable<ClienteModel> returnCliente = _context.tbCliente.Include(p => p.Persona).ToList();
            return returnCliente;
        }

        public ClienteModel GetItem(int? id)
        {
            ClienteModel cliente = _context.tbCliente.Include(p => p.Persona).Where(u => u.Id == id).FirstOrDefault();
            return cliente;
        }

        public ClienteModel Create(ClienteModel cliente)
        {
            _context.tbCliente.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public ClienteModel Edit(ClienteModel cliente)
        {
            _context.tbCliente.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public ClienteModel Delete(ClienteModel cliente)
        {
            _context.tbCliente.Remove(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}
