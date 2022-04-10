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
    public class CuentaRepo : ICuenta
    {
        private readonly ApplicationDbContext _context;

        public CuentaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CuentaModel> GetItems(int? tipoCuentaId = 0)
        {
            IEnumerable<CuentaModel> returnCuenta = null;

            if (tipoCuentaId != 0)
            {
                returnCuenta = _context.tbCuenta.Include(p => p.TipoCuenta).Include(p => p.Cliente).Include(p => p.Cliente.Persona).Where(u => u.TipoCuentaId == tipoCuentaId).ToList();
            }
            else
            {
                returnCuenta = _context.tbCuenta.Include(p => p.TipoCuenta).Include(p => p.Cliente).Include(p => p.Cliente.Persona).ToList();
            }
            return returnCuenta;
        }

        public CuentaModel GetItem(int? id)
        {
            CuentaModel cuenta = _context.tbCuenta.Include(p => p.TipoCuenta).Include(p => p.Cliente).Include(p => p.Cliente.Persona).Where(u => u.Id == id).FirstOrDefault();
            return cuenta;
        }

        public CuentaModel Create(CuentaModel cuenta)
        {
            _context.tbCuenta.Add(cuenta);
            _context.SaveChanges();
            return cuenta;
        }

        public CuentaModel Edit(CuentaModel cuenta)
        {
            _context.tbCuenta.Update(cuenta);
            _context.SaveChanges();
            return cuenta;
        }

        public CuentaModel Delete(CuentaModel cuenta)
        {
            _context.tbCuenta.Remove(cuenta);
            _context.SaveChanges();
            return cuenta;
        }
    }
}
