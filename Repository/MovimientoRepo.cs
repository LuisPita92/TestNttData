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
    public class MovimientoRepo : IMovimiento
    {
        private readonly ApplicationDbContext _context;

        public MovimientoRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovimientoModel> GetItems()
        {
            IEnumerable<MovimientoModel> returnMov = null;

            returnMov = _context.tbMovimiento.Include(p => p.Cuenta).Include(p => p.Cuenta.TipoCuenta).Include(p => p.Cuenta.Cliente).Include(p => p.Cuenta.Cliente.Persona).ToList();

            return returnMov;
        }

        public IEnumerable<MovimientoModel> GetItemReporte(ReporteModel reporte)
        {
            IEnumerable<MovimientoModel> movimiento = _context.tbMovimiento
                .Include(p => p.Cuenta)
                .Include(p => p.Cuenta.TipoCuenta)
                .Include(p => p.Cuenta.Cliente)
                .Include(p => p.Cuenta.Cliente.Persona)
                .Where(u => u.Cuenta.ClienteId == reporte.idCliente && (u.Fecha.Date >= reporte.fechaInicio.Date && u.Fecha.Date <= reporte.fechaFin.Date));
            return movimiento;
        }

        public MovimientoModel Create(MovimientoModel movimiento)
        {
            _context.tbMovimiento.Add(movimiento);
            _context.SaveChanges();
            return movimiento;
        }

        public MovimientoModel Edit(MovimientoModel movimiento)
        {
            _context.tbMovimiento.Update(movimiento);
            _context.SaveChanges();
            return movimiento;
        }

        public MovimientoModel Delete(MovimientoModel movimiento)
        {
            _context.tbMovimiento.Remove(movimiento);
            _context.SaveChanges();
            return movimiento;
        }
    }
}
